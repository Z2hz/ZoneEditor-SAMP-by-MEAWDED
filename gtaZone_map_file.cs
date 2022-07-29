using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using System.IO;

namespace SA_MAP
{
    class gtaZone_map_file
    {
        public enum EXPORT_TYPE
        {
            STREAMER,
            ZONE_FILTERSCRIPT,
            ZONE_DATA
        };

        public gtaZone_map_file()
        {

        }

        public void save(List<gtaZone> zones, string filename)
        {
            try
            {
                using (XmlWriter writer = XmlWriter.Create(filename))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("zones");
                    foreach (gtaZone zone in zones)
                    {
                        writer.WriteStartElement("zone");
                        writer.WriteAttributeString("name", zone.getName());
                        gtaZone.GTAZONE_TYPE type = zone.getType();
                        writer.WriteAttributeString("type", ((int)type).ToString());

                        if (type == gtaZone.GTAZONE_TYPE.AREA)
                        {
                            writer.WriteStartElement("points");
                            foreach (Point p in ((gtaZone_area)zone).getMarks())
                            {
                                writer.WriteStartElement("point");
                                writer.WriteAttributeString("x", p.X.ToString());
                                writer.WriteAttributeString("y", p.Y.ToString());
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                        }
                        else if (type == gtaZone.GTAZONE_TYPE.CIRCLE)
                        {
                            Point p = ((gtaZone_circle)zone).getCentre();
                            float r = ((gtaZone_circle)zone).getRadius();
                            writer.WriteAttributeString("x", p.X.ToString());
                            writer.WriteAttributeString("y", p.Y.ToString());
                            writer.WriteAttributeString("r", r.ToString());
                        }
                        else if (type == gtaZone.GTAZONE_TYPE.RECTANGLE)
                        {
                            Rectangle p = ((gtaZone_rectangle)zone).getRectangle();

                            writer.WriteAttributeString("x", p.X.ToString());
                            writer.WriteAttributeString("y", p.Y.ToString());
                            writer.WriteAttributeString("w", p.Width.ToString());
                            writer.WriteAttributeString("h", p.Height.ToString());
                        }

                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }

            }
            catch (Exception er)
            {

            }
        }
        public void export(List<gtaZone> zones, string filename, gtaZone_map_file.EXPORT_TYPE et)
        {
            if (et == EXPORT_TYPE.ZONE_FILTERSCRIPT)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(filename))
                    {
                        writer.WriteLine("/* SAMP ZONE Editor by Grimrandomer */");
                        writer.WriteLine("/* Version: 1.0.0.6 */");
                        writer.WriteLine("/* Export: Zone Filterscript */");
                        writer.WriteLine("/* Total zones: " + zones.Count + " */");
                        writer.WriteLine("");
                        writer.WriteLine("#include <a_samp>");
                        writer.WriteLine("#include <streamer>");
                        writer.WriteLine("");
                        writer.WriteLine("#define MAX_ZONES " + zones.Count);
                        writer.WriteLine("");
                        writer.WriteLine("new zones[MAX_ZONES];");
                        for (int z = 0; z < zones.Count; z++)
                        {
                            writer.WriteLine("new Float:zones_points_" + z + "[] = {");
                            gtaZone zone = zones[z];
                            if (zone.getType() == gtaZone.GTAZONE_TYPE.AREA)
                            {
                                List<Point> ps = ((gtaZone_area)zone).getMarks();
                                if (ps.Count >= 2)
                                {
                                    Point fp = ps[0];
                                    String _bi = "	";
                                    int leng = 0;
                                    foreach (Point p in ps)
                                    {
                                        leng++;
                                        _bi += "" + p.X + ".0," + p.Y + ".0,";
                                        if (leng >= 10)
                                        {
                                            writer.WriteLine(_bi);
                                            _bi = "	";
                                            leng = 0;
                                        }
                                    }
                                    writer.WriteLine(_bi + "" + fp.X + ".0," + fp.Y + ".0");
                                }
                                else
                                {
                                    writer.WriteLine("	0.0,0.0,0.0,0.0,0.0,0.0");
                                }
                            }
                            else if (zone.getType() == gtaZone.GTAZONE_TYPE.CIRCLE)
                            {
                                Point p = ((gtaZone_circle)zone).getCentre();
                                float r = ((gtaZone_circle)zone).getRadius();
                                writer.WriteLine("	" + p.X + ".0, " + p.Y + ".0, " + r.ToString(".0###"));
                            }
                            else if (zone.getType() == gtaZone.GTAZONE_TYPE.RECTANGLE)
                            {
                                Rectangle p = ((gtaZone_rectangle)zone).getRectangle();

                                int tl_x = p.X;
                                int tl_y = p.Y;
                                int br_x = tl_x + p.Width;
                                int br_y = tl_y - p.Height;

                                writer.WriteLine("	" + tl_x + ".0, " + br_y + ".0, " + br_x + ".0, " + tl_y + ".0 ");
                            }
                            writer.WriteLine("};");
                        }
                        writer.WriteLine("new zones_text[MAX_ZONES][64] = {");
                        for (int zIndex = 0; zIndex < zones.Count; zIndex++)
                        {
                            writer.WriteLine("	\"" + zones[zIndex].getName() + "\"" + ((zIndex < (zones.Count - 1)) ? "," : ""));
                        }
                        writer.WriteLine("};");
                        writer.WriteLine("");
                        writer.WriteLine("");
                        writer.WriteLine("public OnFilterScriptInit() {");
                        writer.WriteLine("	print(\"--------------------------------------\");");
                        writer.WriteLine("	print(\"GTA SA Zone Editor by Grimrandomer - Exporter\");");
                        writer.WriteLine("	print(\"--------------------------------------\");");
                        writer.WriteLine("");
                        for (int zIndex = 0; zIndex < zones.Count; zIndex++)
                        {
                            if (zones[zIndex].getType() == gtaZone.GTAZONE_TYPE.AREA)
                            {
                                writer.WriteLine("	zones[" + zIndex + "] = CreateDynamicPolygon(zones_points_" + zIndex + ");");
                            }
                            else if (zones[zIndex].getType() == gtaZone.GTAZONE_TYPE.CIRCLE)
                            {
                                writer.WriteLine("	zones[" + zIndex + "] = CreateDynamicCircle(zones_points_" + zIndex + "[0], zones_points_" + zIndex + "[1], zones_points_" + zIndex + "[2]);");
                            }
                            else if (zones[zIndex].getType() == gtaZone.GTAZONE_TYPE.RECTANGLE)
                            {
                                writer.WriteLine("	zones[" + zIndex + "] = CreateDynamicRectangle(zones_points_" + zIndex + "[0], zones_points_" + zIndex + "[1], zones_points_" + zIndex + "[2], zones_points_" + zIndex + "[3]);");
                            }
                        }
                        writer.WriteLine("");
                        writer.WriteLine("	return 1;");
                        writer.WriteLine("}");
                        writer.WriteLine("");
                        writer.WriteLine("public OnFilterScriptExit() {");
                        writer.WriteLine("	return 1;");
                        writer.WriteLine("}");
                        writer.WriteLine("");
                        writer.WriteLine("public OnPlayerEnterDynamicArea(playerid, areaid) {");
                        writer.WriteLine("	for (new zone=0; zone<MAX_ZONES; zone++) {");
                        writer.WriteLine("		if (areaid==zones[zone]) {");
                        writer.WriteLine("			new msg[90];");
                        writer.WriteLine("			format(msg, 90, \"Welcome to %s\", zones_text[zone]);");
                        writer.WriteLine("			SendClientMessage(playerid, 0xFFFFFFFF, msg);");
                        writer.WriteLine("		}");
                        writer.WriteLine("	}");
                        writer.WriteLine("	return 1;");
                        writer.WriteLine("}");
                        writer.WriteLine("");
                        writer.WriteLine("public OnPlayerLeaveDynamicArea(playerid, areaid) {");
                        writer.WriteLine("	for (new zone=0; zone<MAX_ZONES; zone++) {");
                        writer.WriteLine("		if (areaid==zones[zone]) {");
                        writer.WriteLine("			new msg[90];");
                        writer.WriteLine("			format(msg, 90, \"Goodbye from %s\", zones_text[zone]);");
                        writer.WriteLine("			SendClientMessage(playerid, 0xFFFFFFFF, msg);");
                        writer.WriteLine("		}");
                        writer.WriteLine("	}");
                        writer.WriteLine("	return 1;");
                        writer.WriteLine("}");
                    }
                }
                catch (Exception er) { }
            }
            else if (et == EXPORT_TYPE.ZONE_DATA)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(filename))
                    {
                        writer.WriteLine("/* SAMP ZONE Editor by Grimrandomer */");
                        writer.WriteLine("/* Version: 1.0.0.6 */");
                        writer.WriteLine("/* Export: Zone Data */");
                        writer.WriteLine("/* Total zones: " + zones.Count + " */");
                        writer.WriteLine("");
                        for (int z = 0; z < zones.Count; z++)
                        {
                            writer.WriteLine("new Float:zones_points_" + z + "[] = {");
                            gtaZone zone = zones[z];
                            string typeName = "Unknown";
                            if (zone.getType() == gtaZone.GTAZONE_TYPE.AREA)
                            {
                                typeName = "AREA";
                                List<Point> ps = ((gtaZone_area)zone).getMarks();
                                if (ps.Count >= 2)
                                {
                                    Point fp = ps[0];
                                    String _bi = "	";
                                    int leng = 0;
                                    foreach (Point p in ps)
                                    {
                                        leng++;
                                        _bi += "" + p.X + ".0," + p.Y + ".0,";
                                        if (leng >= 10)
                                        {
                                            writer.WriteLine(_bi);
                                            _bi = "	";
                                            leng = 0;
                                        }
                                    }
                                    writer.WriteLine(_bi + "" + fp.X + ".0," + fp.Y + ".0");
                                }
                                else
                                {
                                    writer.WriteLine("	0.0,0.0,0.0,0.0,0.0,0.0");
                                }
                            }
                            else if (zone.getType() == gtaZone.GTAZONE_TYPE.CIRCLE)
                            {
                                typeName = "CIRCLE";
                                Point p = ((gtaZone_circle)zone).getCentre();
                                float r = ((gtaZone_circle)zone).getRadius();
                                writer.WriteLine("	" + p.X + ".0, " + p.Y + ".0, " + r.ToString(".0###"));
                            }
                            else if (zone.getType() == gtaZone.GTAZONE_TYPE.RECTANGLE)
                            {
                                typeName = "RECTANGLE";
                                Rectangle p = ((gtaZone_rectangle)zone).getRectangle();
                                int tl_x = p.X;
                                int tl_y = p.Y;
                                int br_x = tl_x + p.Width;
                                int br_y = tl_y - p.Height;

                                writer.WriteLine("	" + tl_x + ".0, " + br_y + ".0, " + br_x + ".0, " + tl_y + ".0 ");
                            }
                            writer.WriteLine("}; //("+typeName+") " + zone.getName());
                        }
                    }
                }
                catch (Exception er) { }
            }
        }
        public List<gtaZone> open(string filename)
        {
            List<gtaZone> nZones = new List<gtaZone>();

            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(filename);

                XmlNodeList zoneNodes = doc.GetElementsByTagName("zone");
                foreach (XmlNode zoneNode in zoneNodes)
                {
                    XmlNode name = zoneNode.Attributes.GetNamedItem("name");
                    XmlNode type = zoneNode.Attributes.GetNamedItem("type");
                    if (name != null)
                    {
                        gtaZone.GTAZONE_TYPE zoneType = gtaZone.GTAZONE_TYPE.AREA;
                        if (type != null)
                        {
                            int typeInt = int.Parse(type.Value);
                            if (typeInt==0) {
                                zoneType = gtaZone.GTAZONE_TYPE.AREA;
                            } else if (typeInt == 1)
                            {
                                zoneType = gtaZone.GTAZONE_TYPE.CIRCLE;
                            }
                            else if (typeInt == 2)
                            {
                                zoneType = gtaZone.GTAZONE_TYPE.RECTANGLE;
                            }
                        }

                        if (zoneType == gtaZone.GTAZONE_TYPE.AREA)
                        {
                            gtaZone_area nZone = new gtaZone_area(name.Value);
                            try
                            {
                                foreach (XmlNode pointsNode in zoneNode.ChildNodes)
                                {
                                    if (pointsNode.Name.Equals("points"))
                                    {
                                        foreach (XmlNode pointNode in pointsNode.ChildNodes)
                                        {
                                            try
                                            {
                                                if (pointNode.Name.Equals("point"))
                                                {
                                                    XmlNode pX = pointNode.Attributes.GetNamedItem("x");
                                                    XmlNode pY = pointNode.Attributes.GetNamedItem("y");
                                                    if (pX != null && pY != null)
                                                    {
                                                        int x = int.Parse(pX.Value);
                                                        int y = int.Parse(pY.Value);
                                                        nZone.addMark(new Point(x, y));
                                                    }
                                                }
                                            }
                                            catch (Exception er) { }
                                        }
                                    }
                                }
                            }
                            catch (Exception er) { }
                            nZones.Add(nZone);
                        }
                        else if (zoneType == gtaZone.GTAZONE_TYPE.CIRCLE)
                        {
                            gtaZone_circle nZone = new gtaZone_circle(name.Value);
                            try
                            {
                                XmlNode pX = zoneNode.Attributes.GetNamedItem("x");
                                XmlNode pY = zoneNode.Attributes.GetNamedItem("y");
                                XmlNode pF = zoneNode.Attributes.GetNamedItem("r");
                                if (pX != null && pY != null && pF != null)
                                {
                                    int x = int.Parse(pX.Value);
                                    int y = int.Parse(pY.Value);
                                    float f = float.Parse(pF.Value);
                                    nZone.setCentre(new Point(x, y));
                                    nZone.setRadius(f);
                                    
                                }
                            }
                            catch (Exception er) { }
                            nZones.Add(nZone);
                        }
                        else if (zoneType == gtaZone.GTAZONE_TYPE.RECTANGLE)
                        {
                            gtaZone_rectangle nZone = new gtaZone_rectangle(name.Value);
                            try
                            {
                                XmlNode pX = zoneNode.Attributes.GetNamedItem("x");
                                XmlNode pY = zoneNode.Attributes.GetNamedItem("y");
                                XmlNode pW = zoneNode.Attributes.GetNamedItem("w");
                                XmlNode pH = zoneNode.Attributes.GetNamedItem("h");
                                if (pX != null && pY != null && pW != null && pH != null)
                                {
                                    int x = int.Parse(pX.Value);
                                    int y = int.Parse(pY.Value);
                                    int w = int.Parse(pW.Value);
                                    int h = int.Parse(pH.Value);

                                    nZone.setRectangle(new Rectangle(x, y, w, h));

                                }
                            }
                            catch (Exception er) { }
                            nZones.Add(nZone);
                        }
                    }
                }

            }
            catch (Exception er) { }
            return nZones;
        }
    }
}

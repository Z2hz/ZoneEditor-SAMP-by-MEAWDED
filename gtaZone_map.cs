using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using System.Resources;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace SA_MAP
{
    class gtaZone_map
    {
        public const int VIEW_BOUNDRY = 4000;

        public enum GTAZONE_ZOOM //2,1,0.5,0.25
        {
            ZOOM_1X, //2
            ZOOM_2X, //1
            ZOOM_4X, //0.5
            ZOOM_8X //0.25
        };

        private List<gtaZone> zones;
        private int desiredfps = 60;
        private int p_x = 0;
        private int p_y = 0;
        private GTAZONE_ZOOM zoom = GTAZONE_ZOOM.ZOOM_2X;
       

        private Thread threadDraw = null;
        private Graphics grap;
        private BufferedGraphicsContext currentContext;
        private BufferedGraphics myBuffer;
        private Image mapImage;
        private Image mapImageHalf;
        private Image mapImageQuart;

        private Image[,] mapImageDoubleTile;
        private Image[,] mapImageTile;
        private Image[,] mapImageHalfTile;
        private Image[,] mapImageQuartTile;

        private Rectangle sc;
        private bool cross = true;
        private bool useTiles = true;


        public gtaZone_map()
        {
            zones = new List<gtaZone>();
            currentContext = BufferedGraphicsManager.Current;

            mapImageDoubleTile = new Image[30, 30];
            mapImageTile = new Image[30, 30];
            mapImageHalfTile = new Image[12, 12];
            mapImageQuartTile = new Image[6, 6];
        }

        public float zoomValue(GTAZONE_ZOOM z)
        {
            if (z == GTAZONE_ZOOM.ZOOM_1X)
            {
                return 2.0f;
            }
            else if (z == GTAZONE_ZOOM.ZOOM_2X)
            {
                return 1.0f;
            }
            else if (z == GTAZONE_ZOOM.ZOOM_4X)
            {
                return 0.5f;
            }
            else if (z == GTAZONE_ZOOM.ZOOM_8X)
            {
                return 0.25f;
            }
            return 0.0f;
        }

        public GTAZONE_ZOOM getZoom()
        {
            return zoom;
        }

        public float getZoomFloat()
        {
            return zoomValue(zoom);
        }

        public void setZoom(GTAZONE_ZOOM z)
        {
            zoom = z;
        }

        public List<gtaZone> getZones()
        {
            return zones;
        }

        public void addZone(gtaZone z)
        {
            zones.Add(z);
        }

        private bool validZoneIndex(int index)
        {
            if ((index >= 0) && (index < zones.Count))
            {
                return true;
            }
            return false;
        }

        public void swapZones(int index1, int index2)
        {
            if (validZoneIndex(index1) && validZoneIndex(index2))
            {
                try
                {
                    gtaZone swap = zones[index1];
                    zones[index1] = zones[index2];
                    zones[index2] = swap;
                }
                catch (Exception er) { }
            }
        }

        public void removeAt(int index)
        {
            zones.RemoveAt(index);
        }

        public void setZones(List<gtaZone> zs)
        {
            zones.Clear();
            zones.AddRange(zs);
        }

        public void setLocation(int x, int y)
        {
            if (x > gtaZone_map.VIEW_BOUNDRY)
                x = gtaZone_map.VIEW_BOUNDRY;

            if (y > gtaZone_map.VIEW_BOUNDRY)
                y = gtaZone_map.VIEW_BOUNDRY;

            if (x < -gtaZone_map.VIEW_BOUNDRY)
                x = -gtaZone_map.VIEW_BOUNDRY;

            if (y < -gtaZone_map.VIEW_BOUNDRY)
                y = -gtaZone_map.VIEW_BOUNDRY;

            p_x = x;
            p_y = y;
        }

        public void addLocation(int x, int y)
        {
            setLocation(p_x - x, p_y + y);
        }

        public Point offsetLocation(Point loc, int x, int y)
        {
            return (new Point(loc.X - x, loc.Y + y));
        }

        public Point getLocation()
        {
            return new Point(p_x, p_y);
        }

        public Point scalePoint(Point p)
        {
            float rZoom = zoomValue(zoom);
            return (new Point((int)((sc.Size.Width / 2) - ((p_x - p.X) * rZoom)), (int)((sc.Size.Height / 2) + ((p_y - p.Y) * rZoom))));
        }

        public int scaleLength(int l)
        {
            float rZoom = zoomValue(zoom);
            return ((int)(l * rZoom));
        }

        private int tilePointCal(int x, int tileSize, int scale)
        {
            return ((int)Math.Ceiling((double)((x / scale) / tileSize)));
        }

        public Point tilePoint(int x, int y, int tileSize, int scale)
        {
            int repX = -1;
            int repY = -1;
            if ((x >= -3000) && (x <= 3000))
                repX = tilePointCal(x + 3000, tileSize, scale);

            if ((y >= -3000) && (y <= 3000))
                repY = tilePointCal(y + 3000, tileSize, scale);

            return (new Point(repX, repY));
        }

        public void createIfNotExists(string folderpath)
        {
            try
            {
                bool isExists = System.IO.Directory.Exists(folderpath);

                if (!isExists)
                    System.IO.Directory.CreateDirectory(folderpath);

            }
            catch (Exception er)
            {
            }
        }

        public void startGraphics(Graphics g, Rectangle r)
        {
            myBuffer = currentContext.Allocate(g, r);
            mapImage = SA_MAP.Properties.Resources.gtasa_aerial_map;
            mapImageHalf = SA_MAP.Properties.Resources.gtasa_aerial_map_half;
            mapImageQuart = SA_MAP.Properties.Resources.gtasa_aerial_map_quart;
            sc = r;
            grap = g;
            threadDraw = new Thread(this.drawThreadRoutine);
            threadDraw.Start();
        }

        public void stopGraphics()
        {
            if (threadDraw != null)
            {
                threadDraw.Abort();
                threadDraw = null;
            }
        }

        public Image getTile(int x, int y, GTAZONE_ZOOM zoom, out int wasNew)
        {
            wasNew = 0;
            if (zoom == GTAZONE_ZOOM.ZOOM_1X)
            {
                if (mapImageDoubleTile[x, y] == null)
                {
                    wasNew = 1;
                    mapImageDoubleTile[x, y] = new Bitmap(400, 400);
                    using (Graphics grD = Graphics.FromImage(mapImageDoubleTile[x, y]))
                    {
                        grD.DrawImage(mapImage, new Rectangle(0, 0, 400, 400), new Rectangle((x * 200), (y * 200), 200, 200), GraphicsUnit.Pixel);
                    }
                }
                return mapImageDoubleTile[x, y];
            }
            else if (zoom == GTAZONE_ZOOM.ZOOM_2X)
            {
                if (mapImageTile[x, y] == null)
                {
                    wasNew = 1;
                    mapImageTile[x, y] = new Bitmap(200, 200);
                    using (Graphics grD = Graphics.FromImage(mapImageTile[x, y]))
                    {
                        grD.DrawImage(mapImage, new Rectangle(0, 0, 200, 200), new Rectangle((x * 200), (y * 200), 200, 200), GraphicsUnit.Pixel);
                    }
                }
                return mapImageTile[x, y];
            }
            else if (zoom == GTAZONE_ZOOM.ZOOM_4X)
            {
                if (mapImageHalfTile[x, y] == null)
                {
                    wasNew = 1;
                    mapImageHalfTile[x, y] = new Bitmap(250, 250);
                    using (Graphics grD = Graphics.FromImage(mapImageHalfTile[x, y]))
                    {
                        grD.DrawImage(mapImageHalf, new Rectangle(0, 0, 250, 250), new Rectangle((x * 250), (y * 250), 250, 250), GraphicsUnit.Pixel);
                    }
                }
                return mapImageHalfTile[x, y];
            }
            else if (zoom == GTAZONE_ZOOM.ZOOM_8X)
            {
                if (mapImageQuartTile[x, y] == null)
                {
                    wasNew = 1;
                    mapImageQuartTile[x, y] = new Bitmap(250, 250);
                    using (Graphics grD = Graphics.FromImage(mapImageQuartTile[x, y]))
                    {
                        grD.DrawImage(mapImageQuart, new Rectangle(0, 0, 250, 250), new Rectangle((x * 250), (y * 250), 250, 250), GraphicsUnit.Pixel);
                    }
                }
                return mapImageQuartTile[x, y];
            }

            return null;
        }

        public void updateGraphics(Rectangle r)
        {
            if (threadDraw != null)
            {
                try
                {
                    sc = r;
                    myBuffer = currentContext.Allocate(grap, r);
                }
                catch (Exception er) { }
            }
        }
        public bool myCallback()
        {
            return false;
        }
        private void drawThreadRoutine()
        {
            Pen penBlack = new Pen(Color.Black, 1);
            Pen penRed = new Pen(Color.Red, 1);
            Pen penBlue = new Pen(Color.Blue, 1);

            Stopwatch stopwatch = new Stopwatch();
            Font fontFramerate = new Font("Helvetica", 10, FontStyle.Bold);
            Font fontCircle = new Font("Helvetica", 8, FontStyle.Bold);
            Brush brushRed = new SolidBrush(Color.Red);

            int frame = 0;
            long frames = 0, totaltime = 0;
            double fps = 0;
            int newTiles = 0;

            SolidBrush b = new SolidBrush(Color.LightGray);

            while (threadDraw != null)
            {
                try
                {
                    stopwatch.Start();
                    myBuffer.Graphics.Clear(Color.White);

                    int tile_size = 200;
                    int tile_map_size = 200;
                    int tile_count = 30;
                    int tile_x = -1;
                    int tile_y = -1;
                    int tile_map_x = p_x + 3000;
                    int tile_map_y = (p_y * -1) + 3000;

                    if (zoom == GTAZONE_ZOOM.ZOOM_1X)
                    {
                        tile_size = 400;
                        tile_map_size = 200;
                        tile_count = 30;
                    }
                    else if (zoom == GTAZONE_ZOOM.ZOOM_2X)
                    {
                        tile_size = 200;
                        tile_map_size = 200;
                        tile_count = 30;
                    }
                    else if (zoom == GTAZONE_ZOOM.ZOOM_4X)
                    {
                        tile_size = 250;
                        tile_map_size = 500;
                        tile_count = 12;
                    }
                    else if (zoom == GTAZONE_ZOOM.ZOOM_8X)
                    {
                        tile_size = 250;
                        tile_map_size = 1000;
                        tile_count = 6;
                    }

                    double scale = (double)tile_size / (double)tile_map_size;
                    int tile_map_x_scaled = (int)Math.Floor((double)(tile_map_x * scale));
                    int tile_map_y_scaled = (int)Math.Floor((double)(tile_map_y * scale));
                    int map_size = (tile_size * tile_count);
                    tile_x = (int)(tile_map_x_scaled / tile_size);
                    tile_y = (int)(tile_map_y_scaled / tile_size);

                    if (tile_x < 0)
                        tile_x = -1;

                    if (tile_y < 0)
                        tile_y = -1;

                    if (tile_x >= tile_count)
                        tile_x = tile_count - 1;

                    if (tile_y >= tile_count)
                        tile_y = tile_count - 1;

                    int tile_pos_x = (int)Math.Floor((double)(((tile_x * tile_map_size) - 3000) - p_x));
                    int tile_pos_y = (int)Math.Floor((double)(((tile_y * tile_map_size) - 3000) + p_y));

                    int tile_dim = (int)(tile_size * scale);

                    Point tilePoint = new Point(
                        (int)Math.Floor((double)(sc.Size.Width / 2) + (tile_pos_x * scale)),
                        (int)Math.Floor((double)(sc.Size.Height / 2) + (tile_pos_y * scale))
                    );

                    int tile_showX = (int)Math.Floor((double)(sc.Size.Width / tile_size));
                    int tile_showY = (int)Math.Floor((double)(sc.Size.Height / tile_size));

                    for (int _ox = (tile_showX * -1); _ox < tile_showX + 1; _ox++)
                    {
                        for (int _oy = (tile_showY * -1); _oy < tile_showY + 1; _oy++)
                        {
                            if (((tile_x + _ox) >= 0) && ((tile_y - _oy) >= 0) && ((tile_x + _ox) < tile_count) && ((tile_y - _oy) < tile_count))
                            {
                                int wasNewTile = 0;
                                Image tile = getTile(tile_x + _ox, tile_y - _oy, zoom, out wasNewTile);
                                newTiles += wasNewTile;

                                if (tile != null)
                                {
                                    myBuffer.Graphics.DrawImage(
                                       tile,
                                        new Rectangle(tilePoint.X + (_ox * tile_size), tilePoint.Y - (_oy * tile_size), tile_size, tile_size),
                                        new Rectangle(0, 0, tile_size, tile_size), GraphicsUnit.Pixel);

                                }
                            }
                        }
                    }

                    foreach (gtaZone zone in zones)
                    {
                        gtaZone.GTAZONE_TYPE type = zone.getType();
                        if (type == gtaZone.GTAZONE_TYPE.AREA)
                        {
                            List<Point> marks = ((gtaZone_area)zone).getMarks();
                            if (marks.Count > 0)
                            {
                                List<Point> marksDraw = new List<Point>();
                                foreach (Point mark in marks)
                                {
                                    Point p = scalePoint(mark); // new Point((sc.Size.Width / 2) - (p_x - mark.X), (sc.Size.Height / 2) + (p_y - mark.Y));
                                    marksDraw.Add(p);
                                    myBuffer.Graphics.DrawEllipse(penBlue, new Rectangle(p.X - 2, p.Y - 2, 4, 4));
                                }
                                if (marks.Count >= 3)
                                {
                                    myBuffer.Graphics.DrawPolygon(penBlue, marksDraw.ToArray());
                                }
                            }
                        }
                        else if (type == gtaZone.GTAZONE_TYPE.CIRCLE)
                        {
                            gtaZone_circle cr = ((gtaZone_circle)zone);
                            Point p_m = cr.getCentre();
                            Point p = scalePoint(p_m); // new Point((sc.Size.Width / 2) - (p_x - p_m.X), (sc.Size.Height / 2) + (p_y - p_m.Y));
                            int r = (int)Math.Round(cr.getRadius());
                            if (r < 1) { r = 1; }
                            r = scaleLength(r);

                            myBuffer.Graphics.DrawEllipse(penBlue, new Rectangle(p.X - r, p.Y - r, (r * 2), (r * 2)));
                            if (r < 5)
                            {
                                myBuffer.Graphics.DrawString("Circle [" + cr.getName() + "]", fontCircle, brushRed, p.X + (r * 2), p.Y + (r * 2));
                            }
                        }
                        else if (type == gtaZone.GTAZONE_TYPE.RECTANGLE)
                        {
                            gtaZone_rectangle r = ((gtaZone_rectangle)zone);
                            Rectangle p_r = r.getRectangle();

                            Point s_p = scalePoint(p_r.Location);
                            int s_w = scaleLength(p_r.Width);
                            int s_h = scaleLength(p_r.Height);

                            myBuffer.Graphics.DrawRectangle(penBlue, new Rectangle(s_p.X, s_p.Y, s_w, s_h));
                        }
                    }

                    if (cross)
                    {
                        myBuffer.Graphics.DrawLine(penRed, new Point((sc.Size.Width / 2), 0), new Point((sc.Size.Width / 2), sc.Size.Height));
                        myBuffer.Graphics.DrawLine(penRed, new Point(0, (sc.Size.Height / 2)), new Point(sc.Size.Width, (sc.Size.Height / 2)));
                    }

                    myBuffer.Graphics.DrawString("แสดงไทล์ทั้งหมด: " + newTiles, fontCircle, brushRed, 12, 26);
                    myBuffer.Graphics.DrawString(string.Format("FPS: {1}", frames, fps), fontFramerate, brushRed, 12, 9);
                    myBuffer.Render();

                    #region CONSTANT FPS CALCULATIONS
                    stopwatch.Stop();
                    frames = stopwatch.ElapsedMilliseconds;
                    stopwatch.Reset();
                    int df = (int)(1000 / desiredfps);
                    int waittime = df - (int)frames;

                    if (waittime > 0)
                    {
                        totaltime += df;
                        Thread.Sleep(waittime);
                    }
                    else
                    {
                        totaltime += frames;
                    }
                    if (frame >= 5 && totaltime > 0)
                    {
                        fps = Math.Floor((double)((1000 / totaltime) * frame));
                        frame = 0;
                        totaltime = 0;
                    }
                    frame++;
                    #endregion

                }
                catch (Exception er)
                {

                }
            }
        }

        public bool crossEnabled()
        {
            return cross;
        }
        public void setCrossEnabled(bool e)
        {
            cross = e;
        }
        public void toggleCross()
        {
            setCrossEnabled(!cross);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace SA_MAP
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private gtaZone_map map;
        private gtaZone selectedZone = null;
        private gtaZone_map_file file;
        private string mapname = "";
        private string title_raw;

        private void main_Load(object sender, EventArgs e)
        {
            file = new gtaZone_map_file();
            map = new gtaZone_map();
            map.startGraphics(this.pictureBox1.CreateGraphics(), new Rectangle(this.pictureBox1.Location, this.pictureBox1.Size));
            title_raw = this.Text;
            zone_add_combo.SelectedIndex = 0;

            update_gui_zone_list();
            update_gui();
        }
        private void open_main()
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "pzn|*.pzn";
            if (o.ShowDialog() == DialogResult.OK)
            {
                List<gtaZone> nZones = file.open(o.FileName);
                map.setZones(nZones);

                selectedZone = null;
                mapname = o.FileName;

                update_title();
                update_gui_zone_list();
                update_gui();
            }
        }
        private void new_main()
        {
            List<gtaZone> nZones = new List<gtaZone>();
            map.setZones(nZones);

            selectedZone = null;
            mapname = "";

            update_title();
            update_gui_zone_list();
            update_gui();
        }
        private void update_title()
        {
            try
            {
                if (mapname != null && mapname.Length > 0)
                {
                    this.Text = title_raw + " - " + Path.GetFileName(mapname);
                }
                else
                {
                    this.Text = title_raw;
                }
            }
            catch (Exception er) { }
        }

        #region GUI
        private void update_gui_zone_list()
        {
            int oldSelectedIndex = -1;
            if (zone_list.SelectedIndex >= 0)
            {
                oldSelectedIndex = zone_list.SelectedIndex;
            }

            zone_list.Items.Clear();
            foreach (gtaZone z in map.getZones())
            {
                string zT = "Unknown";
                string zTE = "";
                gtaZone.GTAZONE_TYPE type = z.getType();
                if (type == gtaZone.GTAZONE_TYPE.AREA)
                {
                    zT = "Polygon";
                    zTE = " (" + ((gtaZone_area)z).getMarks().Count.ToString() + ")";
                }
                else if (type == gtaZone.GTAZONE_TYPE.CIRCLE)
                {
                    zT = "Circle";
                }
                else if (type == gtaZone.GTAZONE_TYPE.RECTANGLE)
                {
                    zT = "Rectangle";
                }
                zone_list.Items.Add("[" + zT + "] " + z.getName() + zTE);
            }

            if (oldSelectedIndex > -1)
            {
                try
                {
                    if (oldSelectedIndex < zone_list.Items.Count)
                    {
                        zone_list.SelectedIndex = oldSelectedIndex;
                    }
                }
                catch (Exception er) { }
            }
        }
        private void update_gui_zone_area_list()
        {
            int selectIndex = zone_area_list.SelectedIndex;
            zone_area_list.Items.Clear();
            if (selectedZone != null)
            {
                gtaZone.GTAZONE_TYPE type = selectedZone.getType();
                if (type == gtaZone.GTAZONE_TYPE.AREA)
                {
                    foreach (Point p in ((gtaZone_area)selectedZone).getMarks())
                    {
                        zone_area_list.Items.Add("Point (" + p.X + "," + p.Y + ")");
                    }
                }
            }

            try
            {
                zone_area_list.SelectedIndex = selectIndex;
            }
            catch (Exception err) { }

        }
        private void update_gui()
        {

            if (zone_add_combo.SelectedIndex >= 0)
            {
                zone_add.Enabled = true;
            }
            else
            {
                zone_add.Enabled = false;
            }

            if (zone_list.Items.Count > 0)
            {
                if (zone_list.SelectedIndex >= 0)
                {
                    zone_remove.Enabled = true;
                }
                else
                {
                    zone_remove.Enabled = false;
                }
            }
            else
            {
                zone_remove.Enabled = false;
            }


            if (zone_list.Items.Count >= 2)
            {
                if (zone_list.SelectedIndex > 0)
                {
                    zone_up.Enabled = true;
                }
                else
                {
                    zone_up.Enabled = false;
                }

                if (zone_list.SelectedIndex < (zone_list.Items.Count - 1))
                {
                    zone_down.Enabled = true;
                }
                else
                {
                    zone_down.Enabled = false;
                }
            }
            else
            {
                zone_up.Enabled = false;
                zone_down.Enabled = false;
            }

            if (selectedZone != null)
            {
                gtaZone.GTAZONE_TYPE type = selectedZone.getType();
                if (type == gtaZone.GTAZONE_TYPE.AREA)
                {
                    zone_area_group.Text = "Area Point's [" + selectedZone.getName() + "]";
                    zone_area_group.Visible = true;
                    zone_circle_group.Visible = false;
                    zone_rectangle_group.Visible = false;
                    if (zone_area_list.Items.Count > 0)
                    {
                        if (zone_area_list.SelectedIndex >= 0)
                        {
                            zone_area_remove.Enabled = true;
                        }
                        else
                        {
                            zone_area_remove.Enabled = false;
                        }
                    }
                    else
                    {
                        zone_area_remove.Enabled = false;
                    }
                }
                else if (type == gtaZone.GTAZONE_TYPE.CIRCLE)
                {
                    zone_circle_group.Text = "Circle Area [" + selectedZone.getName() + "]";

                    Point p = ((gtaZone_circle)selectedZone).getCentre();
                    float r = ((gtaZone_circle)selectedZone).getRadius();
                    zone_circle_x.Value = p.X;
                    zone_circle_y.Value = p.Y;
                    zone_circle_r.Value = (decimal)r;

                    zone_circle_group.Visible = true;
                    zone_area_group.Visible = false;
                    zone_rectangle_group.Visible = false;
                }
                else if (type == gtaZone.GTAZONE_TYPE.RECTANGLE)
                {
                    zone_rectangle_group.Text = "Rectangle Area [" + selectedZone.getName() + "]";

                    Rectangle r = ((gtaZone_rectangle)selectedZone).getRectangle();
                    zone_rectangle_x.Value = r.X;
                    zone_rectangle_y.Value = r.Y;
                    zone_rectangle_w.Value = r.Width;
                    zone_rectangle_h.Value = r.Height;

                    zone_rectangle_group.Visible = true;
                    zone_area_group.Visible = false;
                    zone_circle_group.Visible = false;
                }
            }
            else
            {
                zone_area_group.Visible = false;
                zone_circle_group.Visible = false;
                zone_rectangle_group.Visible = false;
            }
        }
        #endregion

        #region ZONE
        private void zone_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (zone_add_combo.SelectedIndex >= 0)
                {
                    string name = Microsoft.VisualBasic.Interaction.InputBox("Name this area", "Name this area", "New Area", this.Location.X + (this.Size.Width / 2) - 200, this.Location.Y + (this.Size.Height / 2) - 50);
                    if (name != null && name.Length > 0)
                    {
                        if (zone_add_combo.SelectedIndex == 0)
                        {
                            gtaZone_area z = new gtaZone_area(name);
                            map.addZone(z);
                        }
                        else if (zone_add_combo.SelectedIndex == 1)
                        {
                            gtaZone_circle z = new gtaZone_circle(name);
                            Point mp = map.getLocation();
                            z.setCentre(mp);
                            z.setRadius(4.0f);
                            map.addZone(z);
                        }
                        else if (zone_add_combo.SelectedIndex == 2)
                        {
                            gtaZone_rectangle z = new gtaZone_rectangle(name);
                            Point mp = map.getLocation();
                            z.setRectangle(new Rectangle(mp, new Size(10, 10)));
                            map.addZone(z);
                        }
                        update_gui_zone_list();
                        zone_list.SelectedIndex = zone_list.Items.Count - 1;
                    }
                }
            }
            catch (Exception er)
            {

            }
        }
        private void zone_remove_Click(object sender, EventArgs e)
        {
            if (zone_list.Items.Count > 0)
            {
                if (zone_list.SelectedItems.Count > 0)
                {
                    try
                    {
                        map.removeAt(zone_list.SelectedIndex);
                        selectedZone = null;
                        update_gui_zone_list();
                        update_gui_zone_area_list();
                        update_gui();
                    }
                    catch (Exception er) { }
                }
            }
        }
        private void zone_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedZone = map.getZones().ElementAt(zone_list.SelectedIndex);
                update_gui_zone_area_list();
                update_gui();
            }
            catch (Exception er) { }
        }
        private void zone_add_combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void zone_down_Click(object sender, EventArgs e)
        {
            try
            {
                if (zone_list.Items.Count > 1)
                {
                    if (zone_list.SelectedItems.Count > 0)
                    {

                        if (zone_list.SelectedIndex < (zone_list.Items.Count - 1))
                        {
                            int _index = zone_list.SelectedIndex;
                            map.swapZones(_index, _index + 1);
                            update_gui_zone_list();
                            update_gui();
                            zone_list.SelectedIndex = _index + 1;
                        }
                    }
                }
            }
            catch (Exception er) { }
        }
        private void zone_up_Click(object sender, EventArgs e)
        {
            try
            {
                if (zone_list.Items.Count > 1)
                {
                    if (zone_list.SelectedItems.Count > 0)
                    {

                        if (zone_list.SelectedIndex > 0)
                        {
                            int _index = zone_list.SelectedIndex;
                            map.swapZones(_index, _index - 1);
                            update_gui_zone_list();
                            update_gui();
                            zone_list.SelectedIndex = _index - 1;
                        }
                    }
                }
            }
            catch (Exception er) { }
        }
        #endregion

        #region ZONE AREA
        private void zone_area_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_gui();
        }
        private void zone_area_list_DoubleClick(object sender, EventArgs e)
        {
            if (selectedZone != null)
            {
                gtaZone.GTAZONE_TYPE type = selectedZone.getType();
                if (type == gtaZone.GTAZONE_TYPE.AREA)
                {
                    try
                    {
                        Point p = ((gtaZone_area)selectedZone).getMarks().ElementAt(zone_area_list.SelectedIndex);
                        map.setLocation(p.X, p.Y);
                        Point rp = map.getLocation();
                        locX.Value = rp.X;
                        locY.Value = rp.Y;
                    }
                    catch (Exception er) { }
                }
            }
        }
        private void zone_area_add_Click(object sender, EventArgs e)
        {
            if (selectedZone != null)
            {
                gtaZone.GTAZONE_TYPE type = selectedZone.getType();
                if (type == gtaZone.GTAZONE_TYPE.AREA)
                {
                    try
                    {
                        Point mp = map.getLocation();
                        zone_area_addPoint(mp.X, mp.Y);
                    }
                    catch (Exception er) { }
                }
            }
        }
        private void zone_area_remove_Click(object sender, EventArgs e)
        {
            if (selectedZone != null)
            {
                gtaZone.GTAZONE_TYPE type = selectedZone.getType();
                if (type == gtaZone.GTAZONE_TYPE.AREA)
                {
                    try
                    {
                        int oI = zone_area_list.SelectedIndex;
                        ((gtaZone_area)selectedZone).removeMarkAt(zone_area_list.SelectedIndex);
                        update_gui_zone_area_list();

                        oI--;

                        if (oI >= 0)
                        {
                            if (oI >= zone_area_list.Items.Count)
                            {
                                oI = zone_area_list.Items.Count - 1;
                            }
                            zone_area_list.SelectedIndex = oI;
                        }
                    }
                    catch (Exception er) { }
                }
            }
        }
        private void zone_area_addPoint(int x, int y)
        {
            if (selectedZone != null)
            {
                gtaZone.GTAZONE_TYPE type = selectedZone.getType();
                if (type == gtaZone.GTAZONE_TYPE.AREA)
                {
                    try
                    {
                        Point p = new Point(x, y);
                        if (zone_area_list.SelectedItems.Count > 0)
                        {
                            int index = zone_area_list.SelectedIndex;
                            ((gtaZone_area)selectedZone).addMarkAt(p, index + 1);
                            update_gui_zone_area_list();
                            zone_area_list.SelectedIndex = (index + 1);
                        }
                        else
                        {
                            ((gtaZone_area)selectedZone).addMark(p);
                            update_gui_zone_area_list();
                            zone_area_list.SelectedIndex = zone_area_list.Items.Count - 1;
                        }
                        update_gui_zone_list();
                    }
                    catch (Exception er) { }
                }
            }
        }
        #endregion

        #region ZONE CIRCLE
        private void zone_circle_setCentre(int x, int y)
        {
            if (selectedZone != null)
            {
                gtaZone.GTAZONE_TYPE type = selectedZone.getType();
                if (type == gtaZone.GTAZONE_TYPE.CIRCLE)
                {
                    try
                    {
                        ((gtaZone_circle)selectedZone).setCentre(new Point(x, y));
                        zone_circle_x.Value = x;
                        zone_circle_y.Value = y;

                    }
                    catch (Exception er) { }
                }
            }
        }
        private void zone_circle_setRadius(float r)
        {
            if (selectedZone != null)
            {
                gtaZone.GTAZONE_TYPE type = selectedZone.getType();
                if (type == gtaZone.GTAZONE_TYPE.CIRCLE)
                {
                    try
                    {
                        ((gtaZone_circle)selectedZone).setRadius(r);
                        zone_circle_r.Value = (decimal)r;
                    }
                    catch (Exception er) { }
                }
            }
        }
        private void zone_circle_update_centre_Click(object sender, EventArgs e)
        {
            int p_x = (int)zone_circle_x.Value;
            int p_y = (int)zone_circle_y.Value;
            zone_circle_setCentre(p_x, p_y);
        }
        private void zone_circle_r_ValueChanged(object sender, EventArgs e)
        {
            float p_r = (float)zone_circle_r.Value;
            zone_circle_setRadius(p_r);
        }
        #endregion

        #region ZONE RECTANGLE
        private void zone_rectangle_setLocation(int x, int y)
        {
            if (selectedZone != null)
            {
                gtaZone.GTAZONE_TYPE type = selectedZone.getType();
                if (type == gtaZone.GTAZONE_TYPE.RECTANGLE)
                {
                    try
                    {
                        ((gtaZone_rectangle)selectedZone).setLocation(new Point(x, y));
                        zone_rectangle_x.Value = x;
                        zone_rectangle_y.Value = y;
                    }
                    catch (Exception er) { }
                }
            }
        }

        public Rectangle rectangleFromPoints(Point A, Point B)
        {
            try
            {

                int px;
                int py;
                int pw;
                int ph;

                if (A.X < B.X)
                {
                    px = A.X;
                    pw = B.X - A.X;
                }
                else
                {
                    px = B.X;
                    pw = A.X - B.X;
                }

                if (A.Y > B.Y)
                {
                    py = A.Y;
                    ph = A.Y - B.Y;
                }
                else
                {
                    py = B.Y;
                    ph = B.Y - A.Y;
                }

                if (pw < 1) { pw = 1; }
                if (ph < 1) { ph = 1; }
                
                return new Rectangle(new Point(px, py), new Size(pw, ph));
            }
            catch { }
            return new Rectangle(A, new Size(1, 1));
        }
        private void zone_rectangle_update_location_Click(object sender, EventArgs e)
        {
            if (selectedZone != null)
            {
                gtaZone.GTAZONE_TYPE type = selectedZone.getType();
                if (type == gtaZone.GTAZONE_TYPE.RECTANGLE)
                {
                    try
                    {
                        ((gtaZone_rectangle)selectedZone).setLocation(new Point((int)zone_rectangle_x.Value, (int)zone_rectangle_y.Value));
                    }
                    catch (Exception er) { }
                }
            }
        }

        private void zone_rectangle_update_size_Click(object sender, EventArgs e)
        {
            if (selectedZone != null)
            {
                gtaZone.GTAZONE_TYPE type = selectedZone.getType();
                if (type == gtaZone.GTAZONE_TYPE.RECTANGLE)
                {
                    try
                    {
                        ((gtaZone_rectangle)selectedZone).setSize(new Size((int)zone_rectangle_w.Value, (int)zone_rectangle_h.Value));
                    }
                    catch (Exception er) { }
                }
            }
        }
        #endregion

        #region TOOL STRIP
        private void fpsLab_Click(object sender, EventArgs e)
        {
            map.toggleCross();
            locationLab.Text = "ข้ามตำแหน่ง: " + (map.crossEnabled() ? "เปิดใช้งาน" : "ปิดใช้งาน");
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map.getZones().Count > 0)
            {
                SaveFileDialog s = new SaveFileDialog();
                s.Filter = "pzn|*.pzn";
                if (s.ShowDialog() == DialogResult.OK)
                {
                    file.save(map.getZones(), s.FileName);

                    mapname = s.FileName;
                    update_title();
                }
            }
            else
            {
                MessageBox.Show("Zero zones to save", "Error Saving");
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map.getZones().Count > 0)
            {
                if (MessageBox.Show("Are you sure you wish to open a new file, any unsaved changes will be lost?", "Unsaved Changes", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    open_main();
                }
            }
            else
            {
                open_main();
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map.getZones().Count > 0)
            {
                if (MessageBox.Show("Are you sure you wish to open a new file, any unsaved changes will be lost?", "Unsaved Changes", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    new_main();
                }
            }
        }
        private void streamerDynamicZonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map.getZones().Count > 0)
            {
                SaveFileDialog s = new SaveFileDialog();
                s.Filter = "txt|*.txt";
                if (s.ShowDialog() == DialogResult.OK)
                {
                    file.export(map.getZones(), s.FileName, gtaZone_map_file.EXPORT_TYPE.STREAMER);
                }
            }
            else
            {
                MessageBox.Show("Zero zones to export", "Error Exporting");
            }
        }
        private void streamerDynamicZonesFilterscriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map.getZones().Count > 0)
            {
                SaveFileDialog s = new SaveFileDialog();
                s.Filter = "pwn|*.pwn";
                if (s.ShowDialog() == DialogResult.OK)
                {
                    file.export(map.getZones(), s.FileName, gtaZone_map_file.EXPORT_TYPE.ZONE_FILTERSCRIPT);
                }
            }
            else
            {
                MessageBox.Show("Zero zones to export", "Error Exporting");
            }
        }
        private void zoneDataArraysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map.getZones().Count > 0)
            {
                SaveFileDialog s = new SaveFileDialog();
                s.Filter = "txt|*.txt";
                if (s.ShowDialog() == DialogResult.OK)
                {
                    file.export(map.getZones(), s.FileName, gtaZone_map_file.EXPORT_TYPE.ZONE_DATA);
                }
            }
            else
            {
                MessageBox.Show("Zero zones to export", "Error Exporting");
            }
        }
        #endregion

        #region CLOSING / RESIZING
        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            map.stopGraphics();
        }
        private void main_ResizeEnd(object sender, EventArgs e)
        {
            map.updateGraphics(new Rectangle(this.pictureBox1.Location, this.pictureBox1.Size));
        }
        private void main_Resize(object sender, EventArgs e)
        {
            map.updateGraphics(new Rectangle(this.pictureBox1.Location, this.pictureBox1.Size));
        }
        #endregion

        #region CLICK & DRAG
        private Point lastP;
        private Point lastLoc;
        private Point lastOrigLoc;
        private bool mouseDown = false;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastP = new Point(e.X, e.Y);
            lastLoc = map.getLocation();

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (selectedZone != null)
                {
                    gtaZone.GTAZONE_TYPE type = selectedZone.getType();
                    if ((type == gtaZone.GTAZONE_TYPE.CIRCLE) || (type == gtaZone.GTAZONE_TYPE.RECTANGLE))
                    {
                        Point loc = map.getLocation();
                        float sc = map.getZoomFloat();
                        int nx = loc.X + (int)((e.X - (this.pictureBox1.Width / 2)) / sc);
                        int ny = loc.Y - (int)((e.Y - (this.pictureBox1.Height / 2)) / sc);
                        lastOrigLoc = new Point(nx, ny);
                        if (type == gtaZone.GTAZONE_TYPE.CIRCLE)
                        {
                            try
                            {
                                ((gtaZone_circle)selectedZone).setCentre(lastOrigLoc);
                                zone_circle_x.Value = nx;
                                zone_circle_y.Value = ny;
                            }
                            catch (Exception er) { }
                        }
                        else if (type == gtaZone.GTAZONE_TYPE.RECTANGLE)
                        {
                            try
                            {
                                ((gtaZone_rectangle)selectedZone).setLocation(lastOrigLoc);
                                zone_rectangle_x.Value = nx;
                                zone_rectangle_y.Value = ny;
                            }
                            catch (Exception er) { }
                        }
                    }
                }
            }

        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                try
                {


                    bool drag = true;

                    if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        if (selectedZone != null)
                        {
                            gtaZone.GTAZONE_TYPE type = selectedZone.getType();
                            if ((type == gtaZone.GTAZONE_TYPE.CIRCLE) || (type == gtaZone.GTAZONE_TYPE.RECTANGLE))
                            {
                                drag = false;
                                Point loc = map.getLocation();
                                float sc = map.getZoomFloat();
                                int nx = loc.X + (int)((e.X - (this.pictureBox1.Width / 2)) / sc);
                                int ny = loc.Y - (int)((e.Y - (this.pictureBox1.Height / 2)) / sc);
  
                                if (type == gtaZone.GTAZONE_TYPE.CIRCLE)
                                {
                                    try
                                    {

                                        int xd = lastOrigLoc.X-nx;
                                        int yd = lastOrigLoc.Y-ny;
                                        float range = (float)Math.Sqrt(xd * xd + yd * yd);

                                        ((gtaZone_circle)selectedZone).setRadius(range);

                                        zone_circle_r.Value = (int)range;
                                    }
                                    catch (Exception er) { }
                                }
                                else if (type == gtaZone.GTAZONE_TYPE.RECTANGLE)
                                {
                                    try
                                    {
                                        Rectangle r = rectangleFromPoints(lastOrigLoc, new Point(nx, ny));

                                        ((gtaZone_rectangle)selectedZone).setRectangle(r);

                                        zone_rectangle_x.Value = r.X;
                                        zone_rectangle_y.Value = r.Y;
                                        zone_rectangle_w.Value = r.Width;
                                        zone_rectangle_h.Value = r.Height;
                                    }
                                    catch (Exception er) { }
                                }
                            }
                        }
                    }

                    if (drag)
                    {
                        Point cp = new Point(e.X, e.Y);
                        float sc = map.getZoomFloat();
                        int addX = (int)((cp.X - lastP.X) / sc);
                        int addY = (int)((cp.Y - lastP.Y) / sc);
                        Point nL = map.offsetLocation(lastLoc, addX, addY);
                        map.setLocation(nL.X, nL.Y);
                        locX.Value = nL.X;
                        locY.Value = nL.Y;
                    }
                }
                catch (Exception er)
                {

                }
            }
            else
            {
                Point loc = map.getLocation();
                float sc = map.getZoomFloat();
                int nx = loc.X + (int)((e.X - (this.pictureBox1.Width / 2)) / sc);
                int ny = loc.Y - (int)((e.Y - (this.pictureBox1.Height / 2)) / sc);
                posLab.Text = "ตำแหน่ง: " + nx + "," + ny;
            }
        }
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (selectedZone != null)
            {
                gtaZone.GTAZONE_TYPE type = selectedZone.getType();

                Point loc = map.getLocation();
                float sc = map.getZoomFloat();
                int nx = loc.X + (int)((e.X - (this.pictureBox1.Width / 2)) / sc);
                int ny = loc.Y - (int)((e.Y - (this.pictureBox1.Height / 2)) / sc);

                if (type == gtaZone.GTAZONE_TYPE.AREA)
                {
                    zone_area_addPoint(nx, ny);
                }
                else if (type == gtaZone.GTAZONE_TYPE.CIRCLE)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        zone_circle_setCentre(nx, ny);
                    }
                }
                else if (type == gtaZone.GTAZONE_TYPE.RECTANGLE)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        zone_rectangle_setLocation(nx, ny);
                    }
                }
            }
        }

        private void pos_Click(object sender, EventArgs e)
        {
            map.setLocation((int)locX.Value, (int)locY.Value);
        }
        #endregion

        #region ZOOM
        private void main_zoom_in_Click(object sender, EventArgs e)
        {
            try
            {
                main_zoom_scrollbar.Value++;
            }
            catch (Exception er) { }
        }

        private void main_zoom_out_Click(object sender, EventArgs e)
        {
            try
            {
                main_zoom_scrollbar.Value--;
            }
            catch (Exception er) { }
        }

        private void main_zoom_scrollbar_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void main_zoom_scrollbar_ValueChanged(object sender, EventArgs e)
        {
            if (main_zoom_scrollbar.Value == 1)
            {
                map.setZoom(gtaZone_map.GTAZONE_ZOOM.ZOOM_8X);
            }
            else if (main_zoom_scrollbar.Value == 2)
            {
                map.setZoom(gtaZone_map.GTAZONE_ZOOM.ZOOM_4X);
            }
            else if (main_zoom_scrollbar.Value == 3)
            {
                map.setZoom(gtaZone_map.GTAZONE_ZOOM.ZOOM_2X);
            }
            else if (main_zoom_scrollbar.Value == 4)
            {
                map.setZoom(gtaZone_map.GTAZONE_ZOOM.ZOOM_1X);
            }
        }
        #endregion

        private void posLab_Click(object sender, EventArgs e)
        {

        }
    }
}

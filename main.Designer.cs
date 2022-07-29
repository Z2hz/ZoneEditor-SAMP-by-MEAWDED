namespace SA_MAP
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.locationLab = new System.Windows.Forms.ToolStripStatusLabel();
            this.posLab = new System.Windows.Forms.ToolStripStatusLabel();
            this.map_group = new System.Windows.Forms.GroupBox();
            this.main_zoom_scrollbar = new System.Windows.Forms.HScrollBar();
            this.main_zoom_out = new System.Windows.Forms.Button();
            this.locX = new System.Windows.Forms.NumericUpDown();
            this.main_zoom_in = new System.Windows.Forms.Button();
            this.locY = new System.Windows.Forms.NumericUpDown();
            this.pos = new System.Windows.Forms.Button();
            this.zone_group = new System.Windows.Forms.GroupBox();
            this.zone_add_combo = new System.Windows.Forms.ComboBox();
            this.zone_add = new System.Windows.Forms.Button();
            this.zone_list = new System.Windows.Forms.ListBox();
            this.zone_up = new System.Windows.Forms.Button();
            this.zone_remove = new System.Windows.Forms.Button();
            this.zone_down = new System.Windows.Forms.Button();
            this.zone_area_group = new System.Windows.Forms.GroupBox();
            this.zone_area_list = new System.Windows.Forms.ListBox();
            this.zone_area_add = new System.Windows.Forms.Button();
            this.zone_area_remove = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streamerDynamicZonesFilterscriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoneDataArraysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zone_circle_group = new System.Windows.Forms.GroupBox();
            this.zone_circle_r = new System.Windows.Forms.NumericUpDown();
            this.zone_circle_radius_label = new System.Windows.Forms.Label();
            this.zone_circle_centre_label = new System.Windows.Forms.Label();
            this.zone_circle_x = new System.Windows.Forms.NumericUpDown();
            this.zone_circle_y = new System.Windows.Forms.NumericUpDown();
            this.zone_circle_update_centre = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.zone_rectangle_group = new System.Windows.Forms.GroupBox();
            this.zone_rectangle_update_size = new System.Windows.Forms.Button();
            this.zone_rectangle_h = new System.Windows.Forms.NumericUpDown();
            this.zone_rectangle_w = new System.Windows.Forms.NumericUpDown();
            this.zone_rectangle_size_label = new System.Windows.Forms.Label();
            this.zone_rectangle_centre_label = new System.Windows.Forms.Label();
            this.zone_rectangle_x = new System.Windows.Forms.NumericUpDown();
            this.zone_rectangle_y = new System.Windows.Forms.NumericUpDown();
            this.zone_rectangle_update_location = new System.Windows.Forms.Button();
            this.image_panel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.map_group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.locX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locY)).BeginInit();
            this.zone_group.SuspendLayout();
            this.zone_area_group.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.zone_circle_group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zone_circle_r)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zone_circle_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zone_circle_y)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.zone_rectangle_group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zone_rectangle_h)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zone_rectangle_w)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zone_rectangle_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zone_rectangle_y)).BeginInit();
            this.image_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locationLab,
            this.posLab});
            this.statusStrip1.Location = new System.Drawing.Point(0, 600);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(1034, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // locationLab
            // 
            this.locationLab.Name = "locationLab";
            this.locationLab.Size = new System.Drawing.Size(113, 17);
            this.locationLab.Text = "ข้ามตำแหน่ง: เปิดใช้งาน";
            this.locationLab.ToolTipText = "Click to Enable/Disable the red cross";
            this.locationLab.Click += new System.EventHandler(this.fpsLab_Click);
            // 
            // posLab
            // 
            this.posLab.Name = "posLab";
            this.posLab.Size = new System.Drawing.Size(65, 17);
            this.posLab.Text = "ตำแหน่ง: 0,0";
            this.posLab.ToolTipText = "Current map position of the mouse";
            this.posLab.Click += new System.EventHandler(this.posLab_Click);
            // 
            // map_group
            // 
            this.map_group.BackColor = System.Drawing.SystemColors.Control;
            this.map_group.Controls.Add(this.main_zoom_scrollbar);
            this.map_group.Controls.Add(this.main_zoom_out);
            this.map_group.Controls.Add(this.locX);
            this.map_group.Controls.Add(this.main_zoom_in);
            this.map_group.Controls.Add(this.locY);
            this.map_group.Controls.Add(this.pos);
            this.map_group.Location = new System.Drawing.Point(3, 3);
            this.map_group.Name = "map_group";
            this.map_group.Size = new System.Drawing.Size(276, 75);
            this.map_group.TabIndex = 13;
            this.map_group.TabStop = false;
            this.map_group.Text = "แมพ โลเคชั่น";
            // 
            // main_zoom_scrollbar
            // 
            this.main_zoom_scrollbar.LargeChange = 1;
            this.main_zoom_scrollbar.Location = new System.Drawing.Point(63, 46);
            this.main_zoom_scrollbar.Maximum = 4;
            this.main_zoom_scrollbar.Minimum = 1;
            this.main_zoom_scrollbar.Name = "main_zoom_scrollbar";
            this.main_zoom_scrollbar.Size = new System.Drawing.Size(147, 23);
            this.main_zoom_scrollbar.TabIndex = 7;
            this.main_zoom_scrollbar.Value = 3;
            this.main_zoom_scrollbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.main_zoom_scrollbar_Scroll);
            this.main_zoom_scrollbar.ValueChanged += new System.EventHandler(this.main_zoom_scrollbar_ValueChanged);
            // 
            // main_zoom_out
            // 
            this.main_zoom_out.Location = new System.Drawing.Point(6, 46);
            this.main_zoom_out.Name = "main_zoom_out";
            this.main_zoom_out.Size = new System.Drawing.Size(54, 23);
            this.main_zoom_out.TabIndex = 6;
            this.main_zoom_out.Text = "ซูม -";
            this.main_zoom_out.UseVisualStyleBackColor = true;
            this.main_zoom_out.Click += new System.EventHandler(this.main_zoom_out_Click);
            // 
            // locX
            // 
            this.locX.Location = new System.Drawing.Point(6, 21);
            this.locX.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.locX.Minimum = new decimal(new int[] {
            4000,
            0,
            0,
            -2147483648});
            this.locX.Name = "locX";
            this.locX.Size = new System.Drawing.Size(62, 20);
            this.locX.TabIndex = 1;
            // 
            // main_zoom_in
            // 
            this.main_zoom_in.Location = new System.Drawing.Point(213, 46);
            this.main_zoom_in.Name = "main_zoom_in";
            this.main_zoom_in.Size = new System.Drawing.Size(54, 23);
            this.main_zoom_in.TabIndex = 5;
            this.main_zoom_in.Text = "ซูม +";
            this.main_zoom_in.UseVisualStyleBackColor = true;
            this.main_zoom_in.Click += new System.EventHandler(this.main_zoom_in_Click);
            // 
            // locY
            // 
            this.locY.Location = new System.Drawing.Point(74, 21);
            this.locY.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.locY.Minimum = new decimal(new int[] {
            4000,
            0,
            0,
            -2147483648});
            this.locY.Name = "locY";
            this.locY.Size = new System.Drawing.Size(62, 20);
            this.locY.TabIndex = 2;
            // 
            // pos
            // 
            this.pos.Location = new System.Drawing.Point(142, 19);
            this.pos.Name = "pos";
            this.pos.Size = new System.Drawing.Size(73, 23);
            this.pos.TabIndex = 3;
            this.pos.Text = "อัพเดท";
            this.pos.UseVisualStyleBackColor = true;
            this.pos.Click += new System.EventHandler(this.pos_Click);
            // 
            // zone_group
            // 
            this.zone_group.Controls.Add(this.zone_add_combo);
            this.zone_group.Controls.Add(this.zone_add);
            this.zone_group.Controls.Add(this.zone_list);
            this.zone_group.Controls.Add(this.zone_up);
            this.zone_group.Controls.Add(this.zone_remove);
            this.zone_group.Controls.Add(this.zone_down);
            this.zone_group.Location = new System.Drawing.Point(3, 84);
            this.zone_group.Name = "zone_group";
            this.zone_group.Size = new System.Drawing.Size(276, 213);
            this.zone_group.TabIndex = 12;
            this.zone_group.TabStop = false;
            this.zone_group.Text = "โซนพอยท์";
            // 
            // zone_add_combo
            // 
            this.zone_add_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zone_add_combo.FormattingEnabled = true;
            this.zone_add_combo.Items.AddRange(new object[] {
            "Polygon Area",
            "Circle Area",
            "Rectangle Area"});
            this.zone_add_combo.Location = new System.Drawing.Point(9, 19);
            this.zone_add_combo.Name = "zone_add_combo";
            this.zone_add_combo.Size = new System.Drawing.Size(122, 21);
            this.zone_add_combo.TabIndex = 11;
            this.zone_add_combo.SelectedIndexChanged += new System.EventHandler(this.zone_add_combo_SelectedIndexChanged);
            // 
            // zone_add
            // 
            this.zone_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zone_add.Enabled = false;
            this.zone_add.Location = new System.Drawing.Point(137, 19);
            this.zone_add.Name = "zone_add";
            this.zone_add.Size = new System.Drawing.Size(62, 21);
            this.zone_add.TabIndex = 0;
            this.zone_add.Text = "เพิ่ม";
            this.zone_add.UseVisualStyleBackColor = true;
            this.zone_add.Click += new System.EventHandler(this.zone_add_Click);
            // 
            // zone_list
            // 
            this.zone_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zone_list.FormattingEnabled = true;
            this.zone_list.Location = new System.Drawing.Point(9, 46);
            this.zone_list.Name = "zone_list";
            this.zone_list.Size = new System.Drawing.Size(261, 134);
            this.zone_list.TabIndex = 4;
            this.zone_list.SelectedIndexChanged += new System.EventHandler(this.zone_list_SelectedIndexChanged);
            // 
            // zone_up
            // 
            this.zone_up.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zone_up.Enabled = false;
            this.zone_up.Location = new System.Drawing.Point(142, 186);
            this.zone_up.Name = "zone_up";
            this.zone_up.Size = new System.Drawing.Size(125, 21);
            this.zone_up.TabIndex = 10;
            this.zone_up.Text = "ขึ้น";
            this.zone_up.UseVisualStyleBackColor = true;
            this.zone_up.Click += new System.EventHandler(this.zone_up_Click);
            // 
            // zone_remove
            // 
            this.zone_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zone_remove.Enabled = false;
            this.zone_remove.Location = new System.Drawing.Point(205, 19);
            this.zone_remove.Name = "zone_remove";
            this.zone_remove.Size = new System.Drawing.Size(62, 21);
            this.zone_remove.TabIndex = 8;
            this.zone_remove.Text = "ลบ";
            this.zone_remove.UseVisualStyleBackColor = true;
            this.zone_remove.Click += new System.EventHandler(this.zone_remove_Click);
            // 
            // zone_down
            // 
            this.zone_down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zone_down.Enabled = false;
            this.zone_down.Location = new System.Drawing.Point(9, 186);
            this.zone_down.Name = "zone_down";
            this.zone_down.Size = new System.Drawing.Size(122, 21);
            this.zone_down.TabIndex = 9;
            this.zone_down.Text = "ลง";
            this.zone_down.UseVisualStyleBackColor = true;
            this.zone_down.Click += new System.EventHandler(this.zone_down_Click);
            // 
            // zone_area_group
            // 
            this.zone_area_group.Controls.Add(this.zone_area_list);
            this.zone_area_group.Controls.Add(this.zone_area_add);
            this.zone_area_group.Controls.Add(this.zone_area_remove);
            this.zone_area_group.Location = new System.Drawing.Point(3, 303);
            this.zone_area_group.Name = "zone_area_group";
            this.zone_area_group.Size = new System.Drawing.Size(276, 268);
            this.zone_area_group.TabIndex = 11;
            this.zone_area_group.TabStop = false;
            this.zone_area_group.Text = "จุดพอยท์";
            // 
            // zone_area_list
            // 
            this.zone_area_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zone_area_list.FormattingEnabled = true;
            this.zone_area_list.Location = new System.Drawing.Point(6, 46);
            this.zone_area_list.Name = "zone_area_list";
            this.zone_area_list.Size = new System.Drawing.Size(264, 212);
            this.zone_area_list.TabIndex = 5;
            this.zone_area_list.SelectedIndexChanged += new System.EventHandler(this.zone_area_list_SelectedIndexChanged);
            this.zone_area_list.DoubleClick += new System.EventHandler(this.zone_area_list_DoubleClick);
            // 
            // zone_area_add
            // 
            this.zone_area_add.Location = new System.Drawing.Point(6, 19);
            this.zone_area_add.Name = "zone_area_add";
            this.zone_area_add.Size = new System.Drawing.Size(125, 21);
            this.zone_area_add.TabIndex = 6;
            this.zone_area_add.Text = "เพิ่ม";
            this.zone_area_add.UseVisualStyleBackColor = true;
            this.zone_area_add.Click += new System.EventHandler(this.zone_area_add_Click);
            // 
            // zone_area_remove
            // 
            this.zone_area_remove.Enabled = false;
            this.zone_area_remove.Location = new System.Drawing.Point(142, 19);
            this.zone_area_remove.Name = "zone_area_remove";
            this.zone_area_remove.Size = new System.Drawing.Size(125, 21);
            this.zone_area_remove.TabIndex = 7;
            this.zone_area_remove.Text = "ลบ";
            this.zone_area_remove.UseVisualStyleBackColor = true;
            this.zone_area_remove.Click += new System.EventHandler(this.zone_area_remove_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1034, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "ไฟล์";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "ใหม่";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "เปิด";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "บันทึกเป็น....";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.streamerDynamicZonesFilterscriptToolStripMenuItem,
            this.zoneDataArraysToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToolStripMenuItem.Text = "ส่งออก";
            // 
            // streamerDynamicZonesFilterscriptToolStripMenuItem
            // 
            this.streamerDynamicZonesFilterscriptToolStripMenuItem.Name = "streamerDynamicZonesFilterscriptToolStripMenuItem";
            this.streamerDynamicZonesFilterscriptToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.streamerDynamicZonesFilterscriptToolStripMenuItem.Text = "Streamer Dynamic Zones Filterscript";
            this.streamerDynamicZonesFilterscriptToolStripMenuItem.Click += new System.EventHandler(this.streamerDynamicZonesFilterscriptToolStripMenuItem_Click);
            // 
            // zoneDataArraysToolStripMenuItem
            // 
            this.zoneDataArraysToolStripMenuItem.Name = "zoneDataArraysToolStripMenuItem";
            this.zoneDataArraysToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.zoneDataArraysToolStripMenuItem.Text = "Zone Data Array\'s";
            this.zoneDataArraysToolStripMenuItem.Click += new System.EventHandler(this.zoneDataArraysToolStripMenuItem_Click);
            // 
            // zone_circle_group
            // 
            this.zone_circle_group.Controls.Add(this.zone_circle_r);
            this.zone_circle_group.Controls.Add(this.zone_circle_radius_label);
            this.zone_circle_group.Controls.Add(this.zone_circle_centre_label);
            this.zone_circle_group.Controls.Add(this.zone_circle_x);
            this.zone_circle_group.Controls.Add(this.zone_circle_y);
            this.zone_circle_group.Controls.Add(this.zone_circle_update_centre);
            this.zone_circle_group.Location = new System.Drawing.Point(3, 577);
            this.zone_circle_group.Name = "zone_circle_group";
            this.zone_circle_group.Size = new System.Drawing.Size(276, 84);
            this.zone_circle_group.TabIndex = 12;
            this.zone_circle_group.TabStop = false;
            this.zone_circle_group.Text = "Circle Area";
            // 
            // zone_circle_r
            // 
            this.zone_circle_r.Location = new System.Drawing.Point(61, 54);
            this.zone_circle_r.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.zone_circle_r.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.zone_circle_r.Name = "zone_circle_r";
            this.zone_circle_r.Size = new System.Drawing.Size(62, 20);
            this.zone_circle_r.TabIndex = 9;
            this.zone_circle_r.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.zone_circle_r.ValueChanged += new System.EventHandler(this.zone_circle_r_ValueChanged);
            // 
            // zone_circle_radius_label
            // 
            this.zone_circle_radius_label.AutoSize = true;
            this.zone_circle_radius_label.Location = new System.Drawing.Point(15, 56);
            this.zone_circle_radius_label.Name = "zone_circle_radius_label";
            this.zone_circle_radius_label.Size = new System.Drawing.Size(40, 13);
            this.zone_circle_radius_label.TabIndex = 8;
            this.zone_circle_radius_label.Text = "Radius";
            // 
            // zone_circle_centre_label
            // 
            this.zone_circle_centre_label.AutoSize = true;
            this.zone_circle_centre_label.Location = new System.Drawing.Point(17, 30);
            this.zone_circle_centre_label.Name = "zone_circle_centre_label";
            this.zone_circle_centre_label.Size = new System.Drawing.Size(38, 13);
            this.zone_circle_centre_label.TabIndex = 7;
            this.zone_circle_centre_label.Text = "Centre";
            // 
            // zone_circle_x
            // 
            this.zone_circle_x.Location = new System.Drawing.Point(61, 28);
            this.zone_circle_x.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.zone_circle_x.Minimum = new decimal(new int[] {
            4000,
            0,
            0,
            -2147483648});
            this.zone_circle_x.Name = "zone_circle_x";
            this.zone_circle_x.Size = new System.Drawing.Size(62, 20);
            this.zone_circle_x.TabIndex = 4;
            // 
            // zone_circle_y
            // 
            this.zone_circle_y.Location = new System.Drawing.Point(129, 28);
            this.zone_circle_y.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.zone_circle_y.Minimum = new decimal(new int[] {
            4000,
            0,
            0,
            -2147483648});
            this.zone_circle_y.Name = "zone_circle_y";
            this.zone_circle_y.Size = new System.Drawing.Size(62, 20);
            this.zone_circle_y.TabIndex = 5;
            // 
            // zone_circle_update_centre
            // 
            this.zone_circle_update_centre.Location = new System.Drawing.Point(197, 25);
            this.zone_circle_update_centre.Name = "zone_circle_update_centre";
            this.zone_circle_update_centre.Size = new System.Drawing.Size(73, 23);
            this.zone_circle_update_centre.TabIndex = 6;
            this.zone_circle_update_centre.Text = "Update";
            this.zone_circle_update_centre.UseVisualStyleBackColor = true;
            this.zone_circle_update_centre.Click += new System.EventHandler(this.zone_circle_update_centre_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.map_group);
            this.flowLayoutPanel1.Controls.Add(this.zone_group);
            this.flowLayoutPanel1.Controls.Add(this.zone_area_group);
            this.flowLayoutPanel1.Controls.Add(this.zone_circle_group);
            this.flowLayoutPanel1.Controls.Add(this.zone_rectangle_group);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(749, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(285, 576);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // zone_rectangle_group
            // 
            this.zone_rectangle_group.Controls.Add(this.zone_rectangle_update_size);
            this.zone_rectangle_group.Controls.Add(this.zone_rectangle_h);
            this.zone_rectangle_group.Controls.Add(this.zone_rectangle_w);
            this.zone_rectangle_group.Controls.Add(this.zone_rectangle_size_label);
            this.zone_rectangle_group.Controls.Add(this.zone_rectangle_centre_label);
            this.zone_rectangle_group.Controls.Add(this.zone_rectangle_x);
            this.zone_rectangle_group.Controls.Add(this.zone_rectangle_y);
            this.zone_rectangle_group.Controls.Add(this.zone_rectangle_update_location);
            this.zone_rectangle_group.Location = new System.Drawing.Point(3, 667);
            this.zone_rectangle_group.Name = "zone_rectangle_group";
            this.zone_rectangle_group.Size = new System.Drawing.Size(276, 84);
            this.zone_rectangle_group.TabIndex = 14;
            this.zone_rectangle_group.TabStop = false;
            this.zone_rectangle_group.Text = "Rectangle Area";
            // 
            // zone_rectangle_update_size
            // 
            this.zone_rectangle_update_size.Location = new System.Drawing.Point(197, 51);
            this.zone_rectangle_update_size.Name = "zone_rectangle_update_size";
            this.zone_rectangle_update_size.Size = new System.Drawing.Size(73, 23);
            this.zone_rectangle_update_size.TabIndex = 11;
            this.zone_rectangle_update_size.Text = "Update";
            this.zone_rectangle_update_size.UseVisualStyleBackColor = true;
            this.zone_rectangle_update_size.Click += new System.EventHandler(this.zone_rectangle_update_size_Click);
            // 
            // zone_rectangle_h
            // 
            this.zone_rectangle_h.Location = new System.Drawing.Point(129, 54);
            this.zone_rectangle_h.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.zone_rectangle_h.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.zone_rectangle_h.Name = "zone_rectangle_h";
            this.zone_rectangle_h.Size = new System.Drawing.Size(62, 20);
            this.zone_rectangle_h.TabIndex = 10;
            this.zone_rectangle_h.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // zone_rectangle_w
            // 
            this.zone_rectangle_w.Location = new System.Drawing.Point(61, 54);
            this.zone_rectangle_w.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.zone_rectangle_w.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.zone_rectangle_w.Name = "zone_rectangle_w";
            this.zone_rectangle_w.Size = new System.Drawing.Size(62, 20);
            this.zone_rectangle_w.TabIndex = 9;
            this.zone_rectangle_w.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // zone_rectangle_size_label
            // 
            this.zone_rectangle_size_label.AutoSize = true;
            this.zone_rectangle_size_label.Location = new System.Drawing.Point(28, 56);
            this.zone_rectangle_size_label.Name = "zone_rectangle_size_label";
            this.zone_rectangle_size_label.Size = new System.Drawing.Size(27, 13);
            this.zone_rectangle_size_label.TabIndex = 8;
            this.zone_rectangle_size_label.Text = "Size";
            // 
            // zone_rectangle_centre_label
            // 
            this.zone_rectangle_centre_label.AutoSize = true;
            this.zone_rectangle_centre_label.Location = new System.Drawing.Point(7, 30);
            this.zone_rectangle_centre_label.Name = "zone_rectangle_centre_label";
            this.zone_rectangle_centre_label.Size = new System.Drawing.Size(48, 13);
            this.zone_rectangle_centre_label.TabIndex = 7;
            this.zone_rectangle_centre_label.Text = "Location";
            // 
            // zone_rectangle_x
            // 
            this.zone_rectangle_x.Location = new System.Drawing.Point(61, 28);
            this.zone_rectangle_x.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.zone_rectangle_x.Minimum = new decimal(new int[] {
            4000,
            0,
            0,
            -2147483648});
            this.zone_rectangle_x.Name = "zone_rectangle_x";
            this.zone_rectangle_x.Size = new System.Drawing.Size(62, 20);
            this.zone_rectangle_x.TabIndex = 4;
            // 
            // zone_rectangle_y
            // 
            this.zone_rectangle_y.Location = new System.Drawing.Point(129, 28);
            this.zone_rectangle_y.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.zone_rectangle_y.Minimum = new decimal(new int[] {
            4000,
            0,
            0,
            -2147483648});
            this.zone_rectangle_y.Name = "zone_rectangle_y";
            this.zone_rectangle_y.Size = new System.Drawing.Size(62, 20);
            this.zone_rectangle_y.TabIndex = 5;
            // 
            // zone_rectangle_update_location
            // 
            this.zone_rectangle_update_location.Location = new System.Drawing.Point(197, 25);
            this.zone_rectangle_update_location.Name = "zone_rectangle_update_location";
            this.zone_rectangle_update_location.Size = new System.Drawing.Size(73, 23);
            this.zone_rectangle_update_location.TabIndex = 6;
            this.zone_rectangle_update_location.Text = "Update";
            this.zone_rectangle_update_location.UseVisualStyleBackColor = true;
            this.zone_rectangle_update_location.Click += new System.EventHandler(this.zone_rectangle_update_location_Click);
            // 
            // image_panel
            // 
            this.image_panel.Controls.Add(this.pictureBox1);
            this.image_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.image_panel.Location = new System.Drawing.Point(0, 24);
            this.image_panel.Name = "image_panel";
            this.image_panel.Size = new System.Drawing.Size(749, 576);
            this.image_panel.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(749, 576);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1034, 622);
            this.Controls.Add(this.image_panel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.Text = "Zone Editor by MEAWDED";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_FormClosing);
            this.Load += new System.EventHandler(this.main_Load);
            this.ResizeEnd += new System.EventHandler(this.main_ResizeEnd);
            this.Resize += new System.EventHandler(this.main_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.map_group.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.locX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locY)).EndInit();
            this.zone_group.ResumeLayout(false);
            this.zone_area_group.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.zone_circle_group.ResumeLayout(false);
            this.zone_circle_group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zone_circle_r)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zone_circle_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zone_circle_y)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.zone_rectangle_group.ResumeLayout(false);
            this.zone_rectangle_group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zone_rectangle_h)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zone_rectangle_w)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zone_rectangle_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zone_rectangle_y)).EndInit();
            this.image_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel locationLab;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button zone_area_remove;
        private System.Windows.Forms.Button zone_area_add;
        private System.Windows.Forms.ListBox zone_area_list;
        private System.Windows.Forms.ListBox zone_list;
        private System.Windows.Forms.Button pos;
        private System.Windows.Forms.NumericUpDown locY;
        private System.Windows.Forms.NumericUpDown locX;
        private System.Windows.Forms.Button zone_add;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel posLab;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streamerDynamicZonesFilterscriptToolStripMenuItem;
        private System.Windows.Forms.Button zone_remove;
        private System.Windows.Forms.Button zone_down;
        private System.Windows.Forms.Button zone_up;
        private System.Windows.Forms.GroupBox zone_area_group;
        private System.Windows.Forms.GroupBox zone_group;
        private System.Windows.Forms.GroupBox map_group;
        private System.Windows.Forms.ComboBox zone_add_combo;
        private System.Windows.Forms.GroupBox zone_circle_group;
        private System.Windows.Forms.Label zone_circle_centre_label;
        private System.Windows.Forms.NumericUpDown zone_circle_x;
        private System.Windows.Forms.NumericUpDown zone_circle_y;
        private System.Windows.Forms.Button zone_circle_update_centre;
        private System.Windows.Forms.NumericUpDown zone_circle_r;
        private System.Windows.Forms.Label zone_circle_radius_label;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel image_panel;
        private System.Windows.Forms.Button main_zoom_out;
        private System.Windows.Forms.Button main_zoom_in;
        private System.Windows.Forms.HScrollBar main_zoom_scrollbar;
        private System.Windows.Forms.GroupBox zone_rectangle_group;
        private System.Windows.Forms.Button zone_rectangle_update_size;
        private System.Windows.Forms.NumericUpDown zone_rectangle_h;
        private System.Windows.Forms.NumericUpDown zone_rectangle_w;
        private System.Windows.Forms.Label zone_rectangle_size_label;
        private System.Windows.Forms.Label zone_rectangle_centre_label;
        private System.Windows.Forms.NumericUpDown zone_rectangle_x;
        private System.Windows.Forms.NumericUpDown zone_rectangle_y;
        private System.Windows.Forms.Button zone_rectangle_update_location;
        private System.Windows.Forms.ToolStripMenuItem zoneDataArraysToolStripMenuItem;

    }
}


namespace BasicFarmland
{
    partial class MainFrame
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图导航ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拉框放大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拉框缩小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.漫游ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基本农田信息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.责任人信息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.axToolbarControl2 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axLicenseControl2 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.基本农田查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.zoomFixedIn = new System.Windows.Forms.ToolStripButton();
            this.zoomFixedOut = new System.Windows.Forms.ToolStripButton();
            this.fullExtend = new System.Windows.Forms.ToolStripButton();
            this.zoomIn = new System.Windows.Forms.ToolStripButton();
            this.zoomOut = new System.Windows.Forms.ToolStripButton();
            this.Pan = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.地图导航ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.查询ToolStripMenuItem,
            this.用户管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(731, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.另存为ToolStripMenuItem,
            this.关闭ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.另存为ToolStripMenuItem.Text = "另存为";
            this.另存为ToolStripMenuItem.Click += new System.EventHandler(this.另存为ToolStripMenuItem_Click);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.关闭ToolStripMenuItem.Text = "关闭";
            // 
            // 地图导航ToolStripMenuItem
            // 
            this.地图导航ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.拉框放大ToolStripMenuItem,
            this.拉框缩小ToolStripMenuItem,
            this.漫游ToolStripMenuItem});
            this.地图导航ToolStripMenuItem.Name = "地图导航ToolStripMenuItem";
            this.地图导航ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.地图导航ToolStripMenuItem.Text = "地图导航";
            // 
            // 拉框放大ToolStripMenuItem
            // 
            this.拉框放大ToolStripMenuItem.Name = "拉框放大ToolStripMenuItem";
            this.拉框放大ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.拉框放大ToolStripMenuItem.Text = "拉框放大";
            this.拉框放大ToolStripMenuItem.Click += new System.EventHandler(this.拉框放大ToolStripMenuItem_Click);
            // 
            // 拉框缩小ToolStripMenuItem
            // 
            this.拉框缩小ToolStripMenuItem.Name = "拉框缩小ToolStripMenuItem";
            this.拉框缩小ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.拉框缩小ToolStripMenuItem.Text = "拉框缩小";
            this.拉框缩小ToolStripMenuItem.Click += new System.EventHandler(this.拉框缩小ToolStripMenuItem_Click);
            // 
            // 漫游ToolStripMenuItem
            // 
            this.漫游ToolStripMenuItem.Name = "漫游ToolStripMenuItem";
            this.漫游ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.漫游ToolStripMenuItem.Text = "漫游";
            this.漫游ToolStripMenuItem.Click += new System.EventHandler(this.漫游ToolStripMenuItem_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基本农田信息管理ToolStripMenuItem,
            this.责任人信息管理ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.工具ToolStripMenuItem.Text = "信息管理";
            // 
            // 基本农田信息管理ToolStripMenuItem
            // 
            this.基本农田信息管理ToolStripMenuItem.Name = "基本农田信息管理ToolStripMenuItem";
            this.基本农田信息管理ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.基本农田信息管理ToolStripMenuItem.Text = "基本农田信息管理";
            this.基本农田信息管理ToolStripMenuItem.Click += new System.EventHandler(this.基本农田信息管理ToolStripMenuItem_Click);
            // 
            // 责任人信息管理ToolStripMenuItem
            // 
            this.责任人信息管理ToolStripMenuItem.Name = "责任人信息管理ToolStripMenuItem";
            this.责任人信息管理ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.责任人信息管理ToolStripMenuItem.Text = "责任人信息管理";
            this.责任人信息管理ToolStripMenuItem.Click += new System.EventHandler(this.责任人信息管理ToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sQLToolStripMenuItem,
            this.基本农田查询ToolStripMenuItem});
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.查询ToolStripMenuItem.Text = "查询";
            // 
            // sQLToolStripMenuItem
            // 
            this.sQLToolStripMenuItem.Name = "sQLToolStripMenuItem";
            this.sQLToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.sQLToolStripMenuItem.Text = "SQL查询";
            this.sQLToolStripMenuItem.Click += new System.EventHandler(this.sQLToolStripMenuItem_Click);
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加用户ToolStripMenuItem,
            this.修改用户ToolStripMenuItem,
            this.删除用户ToolStripMenuItem});
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.用户管理ToolStripMenuItem.Text = "用户管理";
            // 
            // 添加用户ToolStripMenuItem
            // 
            this.添加用户ToolStripMenuItem.Name = "添加用户ToolStripMenuItem";
            this.添加用户ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加用户ToolStripMenuItem.Text = "添加用户";
            this.添加用户ToolStripMenuItem.Click += new System.EventHandler(this.添加用户ToolStripMenuItem_Click);
            // 
            // 修改用户ToolStripMenuItem
            // 
            this.修改用户ToolStripMenuItem.Name = "修改用户ToolStripMenuItem";
            this.修改用户ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改用户ToolStripMenuItem.Text = "修改用户";
            this.修改用户ToolStripMenuItem.Click += new System.EventHandler(this.修改用户ToolStripMenuItem_Click);
            // 
            // 删除用户ToolStripMenuItem
            // 
            this.删除用户ToolStripMenuItem.Name = "删除用户ToolStripMenuItem";
            this.删除用户ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除用户ToolStripMenuItem.Text = "删除用户";
            this.删除用户ToolStripMenuItem.Click += new System.EventHandler(this.删除用户ToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.zoomFixedIn,
            this.zoomFixedOut,
            this.fullExtend,
            this.zoomIn,
            this.zoomOut,
            this.Pan,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MinimumSize = new System.Drawing.Size(60, 60);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(731, 60);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.axToolbarControl2);
            this.panel1.Controls.Add(this.axLicenseControl2);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 61);
            this.panel1.TabIndex = 2;
            // 
            // axToolbarControl2
            // 
            this.axToolbarControl2.Location = new System.Drawing.Point(396, 16);
            this.axToolbarControl2.Name = "axToolbarControl2";
            this.axToolbarControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl2.OcxState")));
            this.axToolbarControl2.Size = new System.Drawing.Size(814, 28);
            this.axToolbarControl2.TabIndex = 3;
            // 
            // axLicenseControl2
            // 
            this.axLicenseControl2.Enabled = true;
            this.axLicenseControl2.Location = new System.Drawing.Point(676, -13);
            this.axLicenseControl2.Name = "axLicenseControl2";
            this.axLicenseControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl2.OcxState")));
            this.axLicenseControl2.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl2.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.axMapControl2);
            this.panel2.Controls.Add(this.axTOCControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 292);
            this.panel2.TabIndex = 3;
            // 
            // axMapControl2
            // 
            this.axMapControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.axMapControl2.Location = new System.Drawing.Point(0, 120);
            this.axMapControl2.Name = "axMapControl2";
            this.axMapControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl2.OcxState")));
            this.axMapControl2.Size = new System.Drawing.Size(240, 172);
            this.axMapControl2.TabIndex = 1;
            this.axMapControl2.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl2_OnMouseDown);
            this.axMapControl2.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.axMapControl2_OnMouseUp);
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(240, 292);
            this.axTOCControl1.TabIndex = 0;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(240, 86);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(491, 292);
            this.axMapControl1.TabIndex = 4;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl1_OnExtentUpdated);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // 基本农田查询ToolStripMenuItem
            // 
            this.基本农田查询ToolStripMenuItem.Name = "基本农田查询ToolStripMenuItem";
            this.基本农田查询ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.基本农田查询ToolStripMenuItem.Text = "基本农田查询";
            this.基本农田查询ToolStripMenuItem.Click += new System.EventHandler(this.基本农田查询ToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.BackColor = System.Drawing.Color.Gainsboro;
            this.toolStripButton2.Image = global::BasicFarmland.Properties.Resources.Save;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 57);
            this.toolStripButton2.Text = "保存";
            this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // zoomFixedIn
            // 
            this.zoomFixedIn.BackColor = System.Drawing.Color.Gainsboro;
            this.zoomFixedIn.Image = global::BasicFarmland.Properties.Resources.ZoomFixedZoomIn_B_32;
            this.zoomFixedIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomFixedIn.Name = "zoomFixedIn";
            this.zoomFixedIn.Size = new System.Drawing.Size(36, 57);
            this.zoomFixedIn.Text = "放大";
            this.zoomFixedIn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.zoomFixedIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.zoomFixedIn.Click += new System.EventHandler(this.zoomFixedIn_Click);
            // 
            // zoomFixedOut
            // 
            this.zoomFixedOut.BackColor = System.Drawing.Color.Gainsboro;
            this.zoomFixedOut.Image = global::BasicFarmland.Properties.Resources.ZoomFixedZoomOut_B_32;
            this.zoomFixedOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomFixedOut.Name = "zoomFixedOut";
            this.zoomFixedOut.Size = new System.Drawing.Size(36, 57);
            this.zoomFixedOut.Text = "缩小";
            this.zoomFixedOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.zoomFixedOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.zoomFixedOut.Click += new System.EventHandler(this.zoomFixedOut_Click);
            // 
            // fullExtend
            // 
            this.fullExtend.BackColor = System.Drawing.Color.Gainsboro;
            this.fullExtend.Image = global::BasicFarmland.Properties.Resources.ZoomFullExtent32;
            this.fullExtend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fullExtend.Name = "fullExtend";
            this.fullExtend.Size = new System.Drawing.Size(60, 57);
            this.fullExtend.Text = "全图显示";
            this.fullExtend.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.fullExtend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.fullExtend.Click += new System.EventHandler(this.fullExtend_Click);
            // 
            // zoomIn
            // 
            this.zoomIn.BackColor = System.Drawing.Color.Gainsboro;
            this.zoomIn.Image = global::BasicFarmland.Properties.Resources.ZoomInTool_B_32;
            this.zoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomIn.Name = "zoomIn";
            this.zoomIn.Size = new System.Drawing.Size(60, 57);
            this.zoomIn.Text = "拉框放大";
            this.zoomIn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.zoomIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.zoomIn.Click += new System.EventHandler(this.zoomIn_Click);
            // 
            // zoomOut
            // 
            this.zoomOut.BackColor = System.Drawing.Color.Gainsboro;
            this.zoomOut.Image = global::BasicFarmland.Properties.Resources.ZoomOutTool_B_32;
            this.zoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOut.Name = "zoomOut";
            this.zoomOut.Size = new System.Drawing.Size(60, 57);
            this.zoomOut.Text = "拉框缩小";
            this.zoomOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.zoomOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.zoomOut.Click += new System.EventHandler(this.zoomOut_Click);
            // 
            // Pan
            // 
            this.Pan.BackColor = System.Drawing.Color.Gainsboro;
            this.Pan.Image = global::BasicFarmland.Properties.Resources.PanTool_B_32;
            this.Pan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Pan.Name = "Pan";
            this.Pan.Size = new System.Drawing.Size(36, 57);
            this.Pan.Text = "漫游";
            this.Pan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Pan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Pan.Click += new System.EventHandler(this.Pan_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.Gainsboro;
            this.toolStripButton1.Image = global::BasicFarmland.Properties.Resources.find;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 57);
            this.toolStripButton1.Text = "农田信息";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 378);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrame";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "阜新市基本农田信息管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainFrame_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton zoomFixedIn;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton zoomFixedOut;
        private System.Windows.Forms.ToolStripButton fullExtend;
        private System.Windows.Forms.ToolStripButton zoomOut;
        private System.Windows.Forms.ToolStripButton zoomIn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl2;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图导航ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拉框放大ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拉框缩小ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 漫游ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl2;
        private System.Windows.Forms.ToolStripButton Pan;
        private System.Windows.Forms.ToolStripMenuItem 添加用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除用户ToolStripMenuItem;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl2;
        private System.Windows.Forms.ToolStripMenuItem sQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 基本农田信息管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 责任人信息管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem 基本农田查询ToolStripMenuItem;
    }
}


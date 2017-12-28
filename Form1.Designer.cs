namespace ThorMotor
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MainStrip = new System.Windows.Forms.ToolStrip();
            this.bnLoadProfile = new System.Windows.Forms.ToolStripButton();
            this.bnSaveProfile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bnLoadExperiment = new System.Windows.Forms.ToolStripButton();
            this.bnSaveExperiment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bnPark = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bnRasterScan = new System.Windows.Forms.ToolStripButton();
            this.bnStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bn3Dview = new System.Windows.Forms.ToolStripButton();
            this.stMain = new System.Windows.Forms.StatusStrip();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbSaveJcamp = new System.Windows.Forms.CheckBox();
            this.cbOverWrite = new System.Windows.Forms.CheckBox();
            this.cbDatebased = new System.Windows.Forms.CheckBox();
            this.cbAutosave = new System.Windows.Forms.CheckBox();
            this.rxView = new System.Windows.Forms.RichTextBox();
            this.tcMotor = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbHfast = new System.Windows.Forms.CheckBox();
            this.bnSetupAxis = new System.Windows.Forms.Button();
            this.txHpoints = new System.Windows.Forms.TextBox();
            this.txHstep = new System.Windows.Forms.TextBox();
            this.txHto = new System.Windows.Forms.TextBox();
            this.txHfrom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            //this.bnHset = new System.Windows.Forms.Button();
            this.bnGetPos = new System.Windows.Forms.Button();
            this.bnHome = new System.Windows.Forms.Button();
            this.bnHgoto = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbH10000 = new System.Windows.Forms.RadioButton();
            this.bnHup = new System.Windows.Forms.Button();
            this.bnHdown = new System.Windows.Forms.Button();
            this.rbH1000 = new System.Windows.Forms.RadioButton();
            this.rbH100 = new System.Windows.Forms.RadioButton();
            this.rbH10 = new System.Windows.Forms.RadioButton();
            this.txHgotopos = new System.Windows.Forms.TextBox();
            this.txHsetpos = new System.Windows.Forms.TextBox();
            this.txHposition = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            //this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txVpoints = new System.Windows.Forms.TextBox();
            this.bnVsetup = new System.Windows.Forms.Button();
            this.txVstep = new System.Windows.Forms.TextBox();
            this.txVto = new System.Windows.Forms.TextBox();
            this.txVfrom = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.bnVset = new System.Windows.Forms.Button();
            this.bnVgoto = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbV10000 = new System.Windows.Forms.RadioButton();
            this.bnVup = new System.Windows.Forms.Button();
            this.bnVdown = new System.Windows.Forms.Button();
            this.rbV1000 = new System.Windows.Forms.RadioButton();
            this.rbV100 = new System.Windows.Forms.RadioButton();
            this.rbV10 = new System.Windows.Forms.RadioButton();
            this.txVgotopos = new System.Windows.Forms.TextBox();
            this.txVsetpos = new System.Windows.Forms.TextBox();
            this.txVposition = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            //this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbD10000 = new System.Windows.Forms.RadioButton();
            this.bnDup = new System.Windows.Forms.Button();
            this.bnDdown = new System.Windows.Forms.Button();
            this.rbD1000 = new System.Windows.Forms.RadioButton();
            this.rbD100 = new System.Windows.Forms.RadioButton();
            this.rbD10 = new System.Windows.Forms.RadioButton();
            this.txDgotopos = new System.Windows.Forms.TextBox();
            this.txDsetpos = new System.Windows.Forms.TextBox();
            this.txDposition = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cbZeronorm = new System.Windows.Forms.CheckBox();
            this.cbAutonorm = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txBottom = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txLeft = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txTop = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txRight = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txYmax = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbTicks = new System.Windows.Forms.CheckBox();
            this.txYmin = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cbLabels = new System.Windows.Forms.CheckBox();
            this.cbGrid = new System.Windows.Forms.CheckBox();
            this.txFontsize = new System.Windows.Forms.TextBox();
            this.txSpectra = new System.Windows.Forms.TextBox();
            this.txFolder = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txExperiment = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txCollectionTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.sgMain = new Dgraph.DGraph();
            this.stGraph = new System.Windows.Forms.StatusStrip();
            this.lbMarker = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.bnMarkerToggle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.bnPrev = new System.Windows.Forms.ToolStripButton();
            this.bnNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.bnXYnorm = new System.Windows.Forms.ToolStripButton();
            this.bnYnorm = new System.Windows.Forms.ToolStripButton();
            this.bnXnorm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.bnDelete = new System.Windows.Forms.ToolStripButton();
            this.bnDeleteAll = new System.Windows.Forms.ToolStripButton();
            this.pnDumpView = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbSpectrum = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bkgWorker = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cbInclude3D = new System.Windows.Forms.CheckBox();
            this.bnDXoptions = new System.Windows.Forms.ToolStripButton();
            this.MainStrip.SuspendLayout();
            this.stMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tcMotor.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            //this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            //this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.stGraph.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainStrip
            // 
            this.MainStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MainStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnLoadProfile,
            this.bnSaveProfile,
            this.toolStripSeparator3,
            this.bnDXoptions,
            this.bnLoadExperiment,
            this.bnSaveExperiment,
            this.toolStripSeparator4,
            this.bnPark,
            this.toolStripSeparator1,
            this.bnRasterScan,
            this.bnStop,
            this.toolStripSeparator2,
            this.bn3Dview});
            this.MainStrip.Location = new System.Drawing.Point(0, 0);
            this.MainStrip.Name = "MainStrip";
            this.MainStrip.Size = new System.Drawing.Size(1197, 39);
            this.MainStrip.TabIndex = 0;
            this.MainStrip.Text = "toolStrip1";
            // 
            // bnLoadProfile
            // 
            this.bnLoadProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnLoadProfile.Image = global::ThorMotor.Properties.Resources.NLoadPlayground;
            this.bnLoadProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnLoadProfile.Name = "bnLoadProfile";
            this.bnLoadProfile.Size = new System.Drawing.Size(36, 36);
            this.bnLoadProfile.Text = "Load Profile";
            this.bnLoadProfile.Click += new System.EventHandler(this.bnLoadProfile_Click);
            // 
            // bnSaveProfile
            // 
            this.bnSaveProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnSaveProfile.Image = global::ThorMotor.Properties.Resources.NSavePlayground;
            this.bnSaveProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnSaveProfile.Name = "bnSaveProfile";
            this.bnSaveProfile.Size = new System.Drawing.Size(36, 36);
            this.bnSaveProfile.Text = "Save Profile";
            this.bnSaveProfile.Click += new System.EventHandler(this.bnSaveProfile_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // bnLoadExperiment
            // 
            this.bnLoadExperiment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnLoadExperiment.Image = global::ThorMotor.Properties.Resources.BOpen;
            this.bnLoadExperiment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnLoadExperiment.Name = "bnLoadExperiment";
            this.bnLoadExperiment.Size = new System.Drawing.Size(36, 36);
            this.bnLoadExperiment.Text = "Load Experiment";
            this.bnLoadExperiment.Click += new System.EventHandler(this.bnLoadExperiment_Click);
            // 
            // bnSaveExperiment
            // 
            this.bnSaveExperiment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnSaveExperiment.Image = global::ThorMotor.Properties.Resources.BSave;
            this.bnSaveExperiment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnSaveExperiment.Name = "bnSaveExperiment";
            this.bnSaveExperiment.Size = new System.Drawing.Size(36, 36);
            this.bnSaveExperiment.Text = "Save Experiment";
            this.bnSaveExperiment.Click += new System.EventHandler(this.bnSaveExperiment_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // bnPark
            // 
            this.bnPark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnPark.Image = global::ThorMotor.Properties.Resources.BHome;
            this.bnPark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnPark.Name = "bnPark";
            this.bnPark.Size = new System.Drawing.Size(36, 36);
            this.bnPark.Text = "Park @ home";
            this.bnPark.Click += new System.EventHandler(this.bnPark_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // bnRasterScan
            // 
            this.bnRasterScan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnRasterScan.Image = global::ThorMotor.Properties.Resources.BStart;
            this.bnRasterScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnRasterScan.Name = "bnRasterScan";
            this.bnRasterScan.Size = new System.Drawing.Size(36, 36);
            this.bnRasterScan.Text = "Raster Scan";
            this.bnRasterScan.Click += new System.EventHandler(this.bnRasterScan_Click);
            // 
            // bnStop
            // 
            this.bnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnStop.Image = global::ThorMotor.Properties.Resources.BStop;
            this.bnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnStop.Name = "bnStop";
            this.bnStop.Size = new System.Drawing.Size(36, 36);
            this.bnStop.Text = "Stop scanning";
            this.bnStop.Click += new System.EventHandler(this.bnStop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // bn3Dview
            // 
            this.bn3Dview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bn3Dview.Image = global::ThorMotor.Properties.Resources.B3DViev;
            this.bn3Dview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bn3Dview.Name = "bn3Dview";
            this.bn3Dview.Size = new System.Drawing.Size(36, 36);
            this.bn3Dview.Text = "Show 3D view of your Data";
            this.bn3Dview.Click += new System.EventHandler(this.bn3Dview_Click);
            // 
            // stMain
            // 
            this.stMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatus});
            this.stMain.Location = new System.Drawing.Point(0, 772);
            this.stMain.Name = "stMain";
            this.stMain.Size = new System.Drawing.Size(1197, 22);
            this.stMain.TabIndex = 1;
            this.stMain.Text = "statusStrip1";
            // 
            // lbStatus
            // 
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(42, 17);
            this.lbStatus.Text = "Status:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cbSaveJcamp);
            this.splitContainer1.Panel1.Controls.Add(this.cbInclude3D);
            this.splitContainer1.Panel1.Controls.Add(this.cbOverWrite);
            this.splitContainer1.Panel1.Controls.Add(this.cbDatebased);
            this.splitContainer1.Panel1.Controls.Add(this.cbAutosave);
            this.splitContainer1.Panel1.Controls.Add(this.rxView);
            this.splitContainer1.Panel1.Controls.Add(this.tcMotor);
            this.splitContainer1.Panel1.Controls.Add(this.txSpectra);
            this.splitContainer1.Panel1.Controls.Add(this.txFolder);
            this.splitContainer1.Panel1.Controls.Add(this.label22);
            this.splitContainer1.Panel1.Controls.Add(this.txExperiment);
            this.splitContainer1.Panel1.Controls.Add(this.label21);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.txCollectionTime);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.SizeChanged += new System.EventHandler(this.splitContainer1_Panel1_SizeChanged);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1197, 733);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 2;
            // 
            // cbSaveJcamp
            // 
            this.cbSaveJcamp.AutoSize = true;
            this.cbSaveJcamp.Checked = true;
            this.cbSaveJcamp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaveJcamp.Location = new System.Drawing.Point(3, 20);
            this.cbSaveJcamp.Name = "cbSaveJcamp";
            this.cbSaveJcamp.Size = new System.Drawing.Size(187, 17);
            this.cbSaveJcamp.TabIndex = 2;
            this.cbSaveJcamp.Text = "Save Jcamp-DX vs. SpectraSolve";
            this.cbSaveJcamp.UseVisualStyleBackColor = true;
            this.cbSaveJcamp.CheckedChanged += new System.EventHandler(this.cbSaveJcamp_CheckedChanged);
            // 
            // cbOverWrite
            // 
            this.cbOverWrite.AutoSize = true;
            this.cbOverWrite.Location = new System.Drawing.Point(3, 54);
            this.cbOverWrite.Name = "cbOverWrite";
            this.cbOverWrite.Size = new System.Drawing.Size(126, 17);
            this.cbOverWrite.TabIndex = 2;
            this.cbOverWrite.Text = "OverWrite or Append";
            this.cbOverWrite.UseVisualStyleBackColor = true;
            // 
            // cbDatebased
            // 
            this.cbDatebased.AutoSize = true;
            this.cbDatebased.Checked = true;
            this.cbDatebased.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDatebased.Location = new System.Drawing.Point(3, 37);
            this.cbDatebased.Name = "cbDatebased";
            this.cbDatebased.Size = new System.Drawing.Size(164, 17);
            this.cbDatebased.TabIndex = 2;
            this.cbDatebased.Text = "Include timestamp in filename";
            this.cbDatebased.UseVisualStyleBackColor = true;
            this.cbDatebased.CheckedChanged += new System.EventHandler(this.txHfrom_TextChanged);
            // 
            // cbAutosave
            // 
            this.cbAutosave.AutoSize = true;
            this.cbAutosave.Location = new System.Drawing.Point(3, 3);
            this.cbAutosave.Name = "cbAutosave";
            this.cbAutosave.Size = new System.Drawing.Size(125, 17);
            this.cbAutosave.TabIndex = 2;
            this.cbAutosave.Text = "Autosave experiment";
            this.cbAutosave.UseVisualStyleBackColor = true;
            // 
            // rxView
            // 
            this.rxView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rxView.Location = new System.Drawing.Point(0, 480);
            this.rxView.Name = "rxView";
            this.rxView.ReadOnly = true;
            this.rxView.Size = new System.Drawing.Size(239, 253);
            this.rxView.TabIndex = 2;
            this.rxView.Text = "";
            this.rxView.DoubleClick += new System.EventHandler(this.rxView_DoubleClick);
            // 
            // tcMotor
            // 
            this.tcMotor.Controls.Add(this.tabPage1);
            //this.tcMotor.Controls.Add(this.tabPage2);
            //this.tcMotor.Controls.Add(this.tabPage3);
            this.tcMotor.Controls.Add(this.tabPage4);
            this.tcMotor.Location = new System.Drawing.Point(3, 159);
            this.tcMotor.Name = "tcMotor";
            this.tcMotor.SelectedIndex = 0;
            this.tcMotor.Size = new System.Drawing.Size(233, 320);
            this.tcMotor.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            //this.tabPage1.Controls.Add(this.bnHset);
            this.tabPage1.Controls.Add(this.bnGetPos);
            this.tabPage1.Controls.Add(this.bnHome);
            this.tabPage1.Controls.Add(this.bnHgoto);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.txHgotopos);
            this.tabPage1.Controls.Add(this.txHsetpos);
            this.tabPage1.Controls.Add(this.txHposition);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(225, 246);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Horizontal";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbHfast);
            this.groupBox2.Controls.Add(this.bnSetupAxis);
            this.groupBox2.Controls.Add(this.txHpoints);
            this.groupBox2.Controls.Add(this.txHstep);
            this.groupBox2.Controls.Add(this.txHto);
            this.groupBox2.Controls.Add(this.txHfrom);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(2, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 88);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RasterScan";
            // 
            // cbHfast
            // 
            this.cbHfast.AutoSize = true;
            this.cbHfast.Checked = true;
            this.cbHfast.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHfast.Location = new System.Drawing.Point(147, 41);
            this.cbHfast.Name = "cbHfast";
            this.cbHfast.Size = new System.Drawing.Size(68, 17);
            this.cbHfast.TabIndex = 2;
            this.cbHfast.Text = "Fast Axis";
            this.cbHfast.UseVisualStyleBackColor = true;
            this.cbHfast.CheckedChanged += new System.EventHandler(this.txHfrom_TextChanged);
            // 
            // bnSetupAxis
            // 
            this.bnSetupAxis.Location = new System.Drawing.Point(142, 60);
            this.bnSetupAxis.Name = "bnSetupAxis";
            this.bnSetupAxis.Size = new System.Drawing.Size(75, 23);
            this.bnSetupAxis.TabIndex = 4;
            this.bnSetupAxis.Text = "Setup Axis";
            this.bnSetupAxis.UseVisualStyleBackColor = true;
            this.bnSetupAxis.Click += new System.EventHandler(this.bnSetupAxis_Click);
            // 
            // txHpoints
            // 
            this.txHpoints.Location = new System.Drawing.Point(160, 16);
            this.txHpoints.Name = "txHpoints";
            this.txHpoints.ReadOnly = true;
            this.txHpoints.Size = new System.Drawing.Size(57, 20);
            this.txHpoints.TabIndex = 1;
            this.txHpoints.Text = "0";
            // 
            // txHstep
            // 
            this.txHstep.Location = new System.Drawing.Point(37, 62);
            this.txHstep.Name = "txHstep";
            this.txHstep.Size = new System.Drawing.Size(78, 20);
            this.txHstep.TabIndex = 1;
            this.txHstep.Text = "100";
            this.txHstep.TextChanged += new System.EventHandler(this.txHfrom_TextChanged);
            // 
            // txHto
            // 
            this.txHto.Location = new System.Drawing.Point(37, 39);
            this.txHto.Name = "txHto";
            this.txHto.Size = new System.Drawing.Size(78, 20);
            this.txHto.TabIndex = 1;
            this.txHto.Text = "103000";
            this.txHto.TextChanged += new System.EventHandler(this.txHfrom_TextChanged);
            // 
            // txHfrom
            // 
            this.txHfrom.Location = new System.Drawing.Point(37, 16);
            this.txHfrom.Name = "txHfrom";
            this.txHfrom.Size = new System.Drawing.Size(78, 20);
            this.txHfrom.TabIndex = 1;
            this.txHfrom.Text = "100000";
            this.txHfrom.TextChanged += new System.EventHandler(this.txHfrom_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Points";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Step";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "From";
            // 
            // bnHset
            //

            /* 
            this.bnHset.Location = new System.Drawing.Point(34, 23);
            this.bnHset.Name = "bnHset";
            this.bnHset.Size = new System.Drawing.Size(75, 23);
            this.bnHset.TabIndex = 4;
            this.bnHset.Text = "Set";
            this.bnHset.UseVisualStyleBackColor = true;
            this.bnHset.Click += new System.EventHandler(this.bnSet_Click);
            */
            // 
            // bnHgoto
            //

            this.bnGetPos.Location = new System.Drawing.Point(34, 23);
            this.bnGetPos.Name = "bnGetPos";
            this.bnGetPos.Size = new System.Drawing.Size(75, 23);
            this.bnGetPos.TabIndex = 4;
            this.bnGetPos.Text = "get current position";
            this.bnGetPos.UseVisualStyleBackColor = true;
            this.bnGetPos.Click += new System.EventHandler(this.bnGetPos_Click);

            this.bnHome.Location = new System.Drawing.Point(34, 69);
            this.bnHome.Name = "bnHome";
            this.bnHome.Size = new System.Drawing.Size(75, 23);
            this.bnHome.TabIndex = 4;
            this.bnHome.Text = "Home";
            this.bnHome.UseVisualStyleBackColor = true;
            this.bnHome.Click += new System.EventHandler(this.bnHome_Click);



            this.bnHgoto.Location = new System.Drawing.Point(34, 46);
            this.bnHgoto.Name = "bnHgoto";
            this.bnHgoto.Size = new System.Drawing.Size(75, 23);
            this.bnHgoto.TabIndex = 4;
            this.bnHgoto.Text = "Goto";
            this.bnHgoto.UseVisualStyleBackColor = true;
            this.bnHgoto.Click += new System.EventHandler(this.bnGoto_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbH10000);
            this.groupBox1.Controls.Add(this.bnHup);
            this.groupBox1.Controls.Add(this.bnHdown);
            this.groupBox1.Controls.Add(this.rbH1000);
            this.groupBox1.Controls.Add(this.rbH100);
            this.groupBox1.Controls.Add(this.rbH10);
            this.groupBox1.Location = new System.Drawing.Point(2, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 85);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Move motor";
            // 
            // rbH10000
            // 
            this.rbH10000.AutoSize = true;
            this.rbH10000.Location = new System.Drawing.Point(11, 65);
            this.rbH10000.Name = "rbH10000";
            this.rbH10000.Size = new System.Drawing.Size(58, 17);
            this.rbH10000.TabIndex = 0;
            this.rbH10000.Text = "10,000";
            this.rbH10000.UseVisualStyleBackColor = true;
            // 
            // bnHup
            // 
            this.bnHup.Image = global::ThorMotor.Properties.Resources.MoveUp;
            this.bnHup.Location = new System.Drawing.Point(156, 19);
            this.bnHup.Name = "bnHup";
            this.bnHup.Size = new System.Drawing.Size(60, 58);
            this.bnHup.TabIndex = 2;
            this.bnHup.UseVisualStyleBackColor = true;
            this.bnHup.Click += new System.EventHandler(this.bnMotorUpDown_Click);
            // 
            // bnHdown
            // 
            this.bnHdown.Image = global::ThorMotor.Properties.Resources.MoveDn;
            this.bnHdown.Location = new System.Drawing.Point(93, 19);
            this.bnHdown.Name = "bnHdown";
            this.bnHdown.Size = new System.Drawing.Size(60, 58);
            this.bnHdown.TabIndex = 2;
            this.bnHdown.UseVisualStyleBackColor = true;
            this.bnHdown.Click += new System.EventHandler(this.bnMotorUpDown_Click);
            // 
            // rbH1000
            // 
            this.rbH1000.AutoSize = true;
            this.rbH1000.Checked = true;
            this.rbH1000.Location = new System.Drawing.Point(11, 48);
            this.rbH1000.Name = "rbH1000";
            this.rbH1000.Size = new System.Drawing.Size(49, 17);
            this.rbH1000.TabIndex = 0;
            this.rbH1000.TabStop = true;
            this.rbH1000.Text = "1000";
            this.rbH1000.UseVisualStyleBackColor = true;
            // 
            // rbH100
            // 
            this.rbH100.AutoSize = true;
            this.rbH100.Location = new System.Drawing.Point(11, 31);
            this.rbH100.Name = "rbH100";
            this.rbH100.Size = new System.Drawing.Size(43, 17);
            this.rbH100.TabIndex = 0;
            this.rbH100.Text = "100";
            this.rbH100.UseVisualStyleBackColor = true;
            // 
            // rbH10
            // 
            this.rbH10.AutoSize = true;
            this.rbH10.Location = new System.Drawing.Point(11, 14);
            this.rbH10.Name = "rbH10";
            this.rbH10.Size = new System.Drawing.Size(37, 17);
            this.rbH10.TabIndex = 0;
            this.rbH10.Text = "10";
            this.rbH10.UseVisualStyleBackColor = true;
            // 
            // txHgotopos
            // 
            this.txHgotopos.Location = new System.Drawing.Point(116, 49);
            this.txHgotopos.Name = "txHgotopos";
            this.txHgotopos.Size = new System.Drawing.Size(78, 20);
            this.txHgotopos.TabIndex = 1;
            this.txHgotopos.Text = "0";
            // 
            // txHsetpos
            // 
            this.txHsetpos.Location = new System.Drawing.Point(116, 26);
            this.txHsetpos.Name = "txHsetpos";
            this.txHsetpos.Size = new System.Drawing.Size(78, 20);
            this.txHsetpos.TabIndex = 1;
            this.txHsetpos.Text = "0";
            // 
            // txHposition
            // 
            this.txHposition.Location = new System.Drawing.Point(116, 3);
            this.txHposition.Name = "txHposition";
            this.txHposition.ReadOnly = true;
            this.txHposition.Size = new System.Drawing.Size(78, 20);
            this.txHposition.TabIndex = 1;
            this.txHposition.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current position (mm)";
            // 
            // tabPage2
            //
            
            /* 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.bnVset);
            this.tabPage2.Controls.Add(this.bnVgoto);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.txVgotopos);
            this.tabPage2.Controls.Add(this.txVsetpos);
            this.tabPage2.Controls.Add(this.txVposition);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(225, 246);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vertical";
            this.tabPage2.UseVisualStyleBackColor = true;
            */


            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txVpoints);
            this.groupBox3.Controls.Add(this.bnVsetup);
            this.groupBox3.Controls.Add(this.txVstep);
            this.groupBox3.Controls.Add(this.txVto);
            this.groupBox3.Controls.Add(this.txVfrom);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(2, 158);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(221, 88);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RasterScan";
            // 
            // txVpoints
            // 
            this.txVpoints.Location = new System.Drawing.Point(160, 16);
            this.txVpoints.Name = "txVpoints";
            this.txVpoints.ReadOnly = true;
            this.txVpoints.Size = new System.Drawing.Size(57, 20);
            this.txVpoints.TabIndex = 1;
            this.txVpoints.Text = "0";
            // 
            // bnVsetup
            // 
            this.bnVsetup.Location = new System.Drawing.Point(142, 60);
            this.bnVsetup.Name = "bnVsetup";
            this.bnVsetup.Size = new System.Drawing.Size(75, 23);
            this.bnVsetup.TabIndex = 11;
            this.bnVsetup.Text = "Setup Axis";
            this.bnVsetup.UseVisualStyleBackColor = true;
            // 
            // txVstep
            // 
            this.txVstep.Location = new System.Drawing.Point(37, 62);
            this.txVstep.Name = "txVstep";
            this.txVstep.Size = new System.Drawing.Size(78, 20);
            this.txVstep.TabIndex = 1;
            this.txVstep.Text = "100";
            this.txVstep.TextChanged += new System.EventHandler(this.txHfrom_TextChanged);
            // 
            // txVto
            // 
            this.txVto.Location = new System.Drawing.Point(37, 39);
            this.txVto.Name = "txVto";
            this.txVto.Size = new System.Drawing.Size(78, 20);
            this.txVto.TabIndex = 1;
            this.txVto.Text = "123000";
            this.txVto.TextChanged += new System.EventHandler(this.txHfrom_TextChanged);
            // 
            // txVfrom
            // 
            this.txVfrom.Location = new System.Drawing.Point(37, 16);
            this.txVfrom.Name = "txVfrom";
            this.txVfrom.Size = new System.Drawing.Size(78, 20);
            this.txVfrom.TabIndex = 1;
            this.txVfrom.Text = "120000";
            this.txVfrom.TextChanged += new System.EventHandler(this.txHfrom_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(121, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Points";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "To";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Step";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "From";
            // 
            // bnVset
            // 
            this.bnVset.Location = new System.Drawing.Point(34, 23);
            this.bnVset.Name = "bnVset";
            this.bnVset.Size = new System.Drawing.Size(75, 23);
            this.bnVset.TabIndex = 14;
            this.bnVset.Text = "Set";
            this.bnVset.UseVisualStyleBackColor = true;
            this.bnVset.Click += new System.EventHandler(this.bnSet_Click);
            // 
            // bnVgoto
            // 
            this.bnVgoto.Location = new System.Drawing.Point(34, 46);
            this.bnVgoto.Name = "bnVgoto";
            this.bnVgoto.Size = new System.Drawing.Size(75, 23);
            this.bnVgoto.TabIndex = 13;
            this.bnVgoto.Text = "Goto";
            this.bnVgoto.UseVisualStyleBackColor = true;
            this.bnVgoto.Click += new System.EventHandler(this.bnGoto_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbV10000);
            this.groupBox4.Controls.Add(this.bnVup);
            this.groupBox4.Controls.Add(this.bnVdown);
            this.groupBox4.Controls.Add(this.rbV1000);
            this.groupBox4.Controls.Add(this.rbV100);
            this.groupBox4.Controls.Add(this.rbV10);
            this.groupBox4.Location = new System.Drawing.Point(2, 71);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(221, 85);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Move motor";
            // 
            // rbV10000
            // 
            this.rbV10000.AutoSize = true;
            this.rbV10000.Location = new System.Drawing.Point(11, 65);
            this.rbV10000.Name = "rbV10000";
            this.rbV10000.Size = new System.Drawing.Size(58, 17);
            this.rbV10000.TabIndex = 0;
            this.rbV10000.Text = "10,000";
            this.rbV10000.UseVisualStyleBackColor = true;
            // 
            // bnVup
            // 
            this.bnVup.Image = global::ThorMotor.Properties.Resources.MoveUp;
            this.bnVup.Location = new System.Drawing.Point(156, 19);
            this.bnVup.Name = "bnVup";
            this.bnVup.Size = new System.Drawing.Size(60, 58);
            this.bnVup.TabIndex = 2;
            this.bnVup.UseVisualStyleBackColor = true;
            this.bnVup.Click += new System.EventHandler(this.bnMotorUpDown_Click);
            // 
            // bnVdown
            // 
            this.bnVdown.Image = global::ThorMotor.Properties.Resources.MoveDn;
            this.bnVdown.Location = new System.Drawing.Point(93, 19);
            this.bnVdown.Name = "bnVdown";
            this.bnVdown.Size = new System.Drawing.Size(60, 58);
            this.bnVdown.TabIndex = 2;
            this.bnVdown.UseVisualStyleBackColor = true;
            this.bnVdown.Click += new System.EventHandler(this.bnMotorUpDown_Click);
            // 
            // rbV1000
            // 
            this.rbV1000.AutoSize = true;
            this.rbV1000.Checked = true;
            this.rbV1000.Location = new System.Drawing.Point(11, 48);
            this.rbV1000.Name = "rbV1000";
            this.rbV1000.Size = new System.Drawing.Size(49, 17);
            this.rbV1000.TabIndex = 0;
            this.rbV1000.TabStop = true;
            this.rbV1000.Text = "1000";
            this.rbV1000.UseVisualStyleBackColor = true;
            // 
            // rbV100
            // 
            this.rbV100.AutoSize = true;
            this.rbV100.Location = new System.Drawing.Point(11, 31);
            this.rbV100.Name = "rbV100";
            this.rbV100.Size = new System.Drawing.Size(43, 17);
            this.rbV100.TabIndex = 0;
            this.rbV100.Text = "100";
            this.rbV100.UseVisualStyleBackColor = true;
            // 
            // rbV10
            // 
            this.rbV10.AutoSize = true;
            this.rbV10.Location = new System.Drawing.Point(11, 14);
            this.rbV10.Name = "rbV10";
            this.rbV10.Size = new System.Drawing.Size(37, 17);
            this.rbV10.TabIndex = 0;
            this.rbV10.Text = "10";
            this.rbV10.UseVisualStyleBackColor = true;
            // 
            // txVgotopos
            // 
            this.txVgotopos.Location = new System.Drawing.Point(116, 49);
            this.txVgotopos.Name = "txVgotopos";
            this.txVgotopos.Size = new System.Drawing.Size(78, 20);
            this.txVgotopos.TabIndex = 7;
            this.txVgotopos.Text = "0";
            // 
            // txVsetpos
            // 
            this.txVsetpos.Location = new System.Drawing.Point(116, 26);
            this.txVsetpos.Name = "txVsetpos";
            this.txVsetpos.Size = new System.Drawing.Size(78, 20);
            this.txVsetpos.TabIndex = 8;
            this.txVsetpos.Text = "0";
            // 
            // txVposition
            // 
            this.txVposition.Location = new System.Drawing.Point(116, 3);
            this.txVposition.Name = "txVposition";
            this.txVposition.ReadOnly = true;
            this.txVposition.Size = new System.Drawing.Size(78, 20);
            this.txVposition.TabIndex = 9;
            this.txVposition.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Current position";
            // 
            // tabPage3
            //
            /* 
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.button9);
            this.tabPage3.Controls.Add(this.button10);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.txDgotopos);
            this.tabPage3.Controls.Add(this.txDsetpos);
            this.tabPage3.Controls.Add(this.txDposition);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(225, 246);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Diagonal";
            this.tabPage3.UseVisualStyleBackColor = true;
            */
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(144, 218);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 11;
            this.button8.Text = "Setup Axis";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(34, 23);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 14;
            this.button9.Text = "Set";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.bnSet_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(34, 46);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 13;
            this.button10.Text = "Goto";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.bnGoto_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbD10000);
            this.groupBox6.Controls.Add(this.bnDup);
            this.groupBox6.Controls.Add(this.bnDdown);
            this.groupBox6.Controls.Add(this.rbD1000);
            this.groupBox6.Controls.Add(this.rbD100);
            this.groupBox6.Controls.Add(this.rbD10);
            this.groupBox6.Location = new System.Drawing.Point(2, 71);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(221, 85);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Move motor";
            // 
            // rbD10000
            // 
            this.rbD10000.AutoSize = true;
            this.rbD10000.Location = new System.Drawing.Point(11, 65);
            this.rbD10000.Name = "rbD10000";
            this.rbD10000.Size = new System.Drawing.Size(58, 17);
            this.rbD10000.TabIndex = 0;
            this.rbD10000.Text = "10,000";
            this.rbD10000.UseVisualStyleBackColor = true;
            // 
            // bnDup
            // 
            this.bnDup.Image = global::ThorMotor.Properties.Resources.MoveUp;
            this.bnDup.Location = new System.Drawing.Point(156, 19);
            this.bnDup.Name = "bnDup";
            this.bnDup.Size = new System.Drawing.Size(60, 58);
            this.bnDup.TabIndex = 2;
            this.bnDup.UseVisualStyleBackColor = true;
            this.bnDup.Click += new System.EventHandler(this.bnMotorUpDown_Click);
            // 
            // bnDdown
            // 
            this.bnDdown.Image = global::ThorMotor.Properties.Resources.MoveDn;
            this.bnDdown.Location = new System.Drawing.Point(93, 19);
            this.bnDdown.Name = "bnDdown";
            this.bnDdown.Size = new System.Drawing.Size(60, 58);
            this.bnDdown.TabIndex = 2;
            this.bnDdown.UseVisualStyleBackColor = true;
            this.bnDdown.Click += new System.EventHandler(this.bnMotorUpDown_Click);
            // 
            // rbD1000
            // 
            this.rbD1000.AutoSize = true;
            this.rbD1000.Checked = true;
            this.rbD1000.Location = new System.Drawing.Point(11, 48);
            this.rbD1000.Name = "rbD1000";
            this.rbD1000.Size = new System.Drawing.Size(49, 17);
            this.rbD1000.TabIndex = 0;
            this.rbD1000.TabStop = true;
            this.rbD1000.Text = "1000";
            this.rbD1000.UseVisualStyleBackColor = true;
            // 
            // rbD100
            // 
            this.rbD100.AutoSize = true;
            this.rbD100.Location = new System.Drawing.Point(11, 31);
            this.rbD100.Name = "rbD100";
            this.rbD100.Size = new System.Drawing.Size(43, 17);
            this.rbD100.TabIndex = 0;
            this.rbD100.Text = "100";
            this.rbD100.UseVisualStyleBackColor = true;
            // 
            // rbD10
            // 
            this.rbD10.AutoSize = true;
            this.rbD10.Location = new System.Drawing.Point(11, 14);
            this.rbD10.Name = "rbD10";
            this.rbD10.Size = new System.Drawing.Size(37, 17);
            this.rbD10.TabIndex = 0;
            this.rbD10.Text = "10";
            this.rbD10.UseVisualStyleBackColor = true;
            // 
            // txDgotopos
            // 
            this.txDgotopos.Location = new System.Drawing.Point(116, 49);
            this.txDgotopos.Name = "txDgotopos";
            this.txDgotopos.Size = new System.Drawing.Size(102, 20);
            this.txDgotopos.TabIndex = 7;
            this.txDgotopos.Text = "0";
            // 
            // txDsetpos
            // 
            this.txDsetpos.Location = new System.Drawing.Point(116, 26);
            this.txDsetpos.Name = "txDsetpos";
            this.txDsetpos.Size = new System.Drawing.Size(102, 20);
            this.txDsetpos.TabIndex = 8;
            this.txDsetpos.Text = "0";
            // 
            // txDposition
            // 
            this.txDposition.Location = new System.Drawing.Point(116, 3);
            this.txDposition.Name = "txDposition";
            this.txDposition.ReadOnly = true;
            this.txDposition.Size = new System.Drawing.Size(102, 20);
            this.txDposition.TabIndex = 9;
            this.txDposition.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(31, 5);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "Current position";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cbZeronorm);
            this.tabPage4.Controls.Add(this.cbAutonorm);
            this.tabPage4.Controls.Add(this.groupBox7);
            this.tabPage4.Controls.Add(this.txYmax);
            this.tabPage4.Controls.Add(this.label20);
            this.tabPage4.Controls.Add(this.cbTicks);
            this.tabPage4.Controls.Add(this.txYmin);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.label19);
            this.tabPage4.Controls.Add(this.cbLabels);
            this.tabPage4.Controls.Add(this.cbGrid);
            this.tabPage4.Controls.Add(this.txFontsize);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(225, 246);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Dump View";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cbZeronorm
            // 
            this.cbZeronorm.AutoSize = true;
            this.cbZeronorm.Location = new System.Drawing.Point(117, 132);
            this.cbZeronorm.Name = "cbZeronorm";
            this.cbZeronorm.Size = new System.Drawing.Size(100, 17);
            this.cbZeronorm.TabIndex = 2;
            this.cbZeronorm.Text = "Y-axis zeronorm";
            this.cbZeronorm.UseVisualStyleBackColor = true;
            this.cbZeronorm.Click += new System.EventHandler(this.txLeft_TextChanged);
            // 
            // cbAutonorm
            // 
            this.cbAutonorm.AutoSize = true;
            this.cbAutonorm.Location = new System.Drawing.Point(7, 132);
            this.cbAutonorm.Name = "cbAutonorm";
            this.cbAutonorm.Size = new System.Drawing.Size(101, 17);
            this.cbAutonorm.TabIndex = 2;
            this.cbAutonorm.Text = "Y-axis autonorm";
            this.cbAutonorm.UseVisualStyleBackColor = true;
            this.cbAutonorm.Click += new System.EventHandler(this.txLeft_TextChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txBottom);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.txLeft);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.txTop);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.txRight);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Location = new System.Drawing.Point(1, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(217, 66);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Frame";
            // 
            // txBottom
            // 
            this.txBottom.Location = new System.Drawing.Point(150, 38);
            this.txBottom.Name = "txBottom";
            this.txBottom.Size = new System.Drawing.Size(56, 20);
            this.txBottom.TabIndex = 1;
            this.txBottom.Text = "25";
            this.txBottom.TextChanged += new System.EventHandler(this.txLeft_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Left";
            // 
            // txLeft
            // 
            this.txLeft.Location = new System.Drawing.Point(38, 15);
            this.txLeft.Name = "txLeft";
            this.txLeft.Size = new System.Drawing.Size(56, 20);
            this.txLeft.TabIndex = 1;
            this.txLeft.Text = "25";
            this.txLeft.TextChanged += new System.EventHandler(this.txLeft_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Top";
            // 
            // txTop
            // 
            this.txTop.Location = new System.Drawing.Point(38, 38);
            this.txTop.Name = "txTop";
            this.txTop.Size = new System.Drawing.Size(56, 20);
            this.txTop.TabIndex = 1;
            this.txTop.Text = "10";
            this.txTop.TextChanged += new System.EventHandler(this.txLeft_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(107, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Bottom";
            // 
            // txRight
            // 
            this.txRight.Location = new System.Drawing.Point(150, 15);
            this.txRight.Name = "txRight";
            this.txRight.Size = new System.Drawing.Size(56, 20);
            this.txRight.TabIndex = 1;
            this.txRight.Text = "10";
            this.txRight.TextChanged += new System.EventHandler(this.txLeft_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(115, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Right";
            // 
            // txYmax
            // 
            this.txYmax.Location = new System.Drawing.Point(143, 152);
            this.txYmax.Name = "txYmax";
            this.txYmax.Size = new System.Drawing.Size(70, 20);
            this.txYmax.TabIndex = 1;
            this.txYmax.Text = "250";
            this.txYmax.TextChanged += new System.EventHandler(this.txLeft_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(113, 155);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(27, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Max";
            // 
            // cbTicks
            // 
            this.cbTicks.AutoSize = true;
            this.cbTicks.Checked = true;
            this.cbTicks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTicks.Location = new System.Drawing.Point(7, 92);
            this.cbTicks.Name = "cbTicks";
            this.cbTicks.Size = new System.Drawing.Size(52, 17);
            this.cbTicks.TabIndex = 2;
            this.cbTicks.Text = "Ticks";
            this.cbTicks.UseVisualStyleBackColor = true;
            this.cbTicks.Click += new System.EventHandler(this.txLeft_TextChanged);
            // 
            // txYmin
            // 
            this.txYmin.Location = new System.Drawing.Point(41, 152);
            this.txYmin.Name = "txYmin";
            this.txYmin.Size = new System.Drawing.Size(63, 20);
            this.txYmin.TabIndex = 1;
            this.txYmin.Text = "0";
            this.txYmin.TextChanged += new System.EventHandler(this.txLeft_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(97, 76);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Font size";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 155);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(34, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Y-Min";
            // 
            // cbLabels
            // 
            this.cbLabels.AutoSize = true;
            this.cbLabels.Checked = true;
            this.cbLabels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLabels.Location = new System.Drawing.Point(7, 75);
            this.cbLabels.Name = "cbLabels";
            this.cbLabels.Size = new System.Drawing.Size(57, 17);
            this.cbLabels.TabIndex = 2;
            this.cbLabels.Text = "Labels";
            this.cbLabels.UseVisualStyleBackColor = true;
            this.cbLabels.Click += new System.EventHandler(this.txLeft_TextChanged);
            // 
            // cbGrid
            // 
            this.cbGrid.AutoSize = true;
            this.cbGrid.Checked = true;
            this.cbGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGrid.Location = new System.Drawing.Point(7, 109);
            this.cbGrid.Name = "cbGrid";
            this.cbGrid.Size = new System.Drawing.Size(45, 17);
            this.cbGrid.TabIndex = 2;
            this.cbGrid.Text = "Grid";
            this.cbGrid.UseVisualStyleBackColor = true;
            this.cbGrid.Click += new System.EventHandler(this.txLeft_TextChanged);
            // 
            // txFontsize
            // 
            this.txFontsize.Location = new System.Drawing.Point(149, 73);
            this.txFontsize.Name = "txFontsize";
            this.txFontsize.Size = new System.Drawing.Size(56, 20);
            this.txFontsize.TabIndex = 1;
            this.txFontsize.Text = "7";
            this.txFontsize.TextChanged += new System.EventHandler(this.txLeft_TextChanged);
            // 
            // txSpectra
            // 
            this.txSpectra.Location = new System.Drawing.Point(123, 457);
            this.txSpectra.Name = "txSpectra";
            this.txSpectra.ReadOnly = true;
            this.txSpectra.Size = new System.Drawing.Size(102, 20);
            this.txSpectra.TabIndex = 1;
            this.txSpectra.Text = "11";
            // 
            // txFolder
            // 
            this.txFolder.Location = new System.Drawing.Point(43, 114);
            this.txFolder.Multiline = true;
            this.txFolder.Name = "txFolder";
            this.txFolder.ReadOnly = true;
            this.txFolder.Size = new System.Drawing.Size(192, 42);
            this.txFolder.TabIndex = 1;
            this.txFolder.Text = "0";
            this.txFolder.DoubleClick += new System.EventHandler(this.txFolder_DoubleClick);
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(5, 117);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(36, 29);
            this.label22.TabIndex = 0;
            this.label22.Text = "Base Folder";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txExperiment
            // 
            this.txExperiment.Location = new System.Drawing.Point(43, 91);
            this.txExperiment.Name = "txExperiment";
            this.txExperiment.Size = new System.Drawing.Size(192, 20);
            this.txExperiment.TabIndex = 1;
            this.txExperiment.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 94);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 460);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Number of frames";
            // 
            // txCollectionTime
            // 
            this.txCollectionTime.Location = new System.Drawing.Point(123, 434);
            this.txCollectionTime.Name = "txCollectionTime";
            this.txCollectionTime.Size = new System.Drawing.Size(102, 20);
            this.txCollectionTime.TabIndex = 1;
            this.txCollectionTime.Text = "100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 437);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Collection time (ms)";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.sgMain);
            this.splitContainer2.Panel1.Controls.Add(this.stGraph);
            this.splitContainer2.Panel1.Controls.Add(this.toolStrip2);
            this.splitContainer2.Panel1.SizeChanged += new System.EventHandler(this.splitContainer2_Panel1_SizeChanged);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(this.pnDumpView);
            this.splitContainer2.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer2.Panel2.SizeChanged += new System.EventHandler(this.splitContainer2_Panel2_SizeChanged);
            this.splitContainer2.Size = new System.Drawing.Size(954, 733);
            this.splitContainer2.SplitterDistance = 632;
            this.splitContainer2.TabIndex = 0;
            // 
            // sgMain
            // 
            this.sgMain.ActCurve = 0;
            this.sgMain.ActExtra = 0;
            this.sgMain.ApartShift = 0.1D;
            this.sgMain.BackColor = System.Drawing.Color.White;
            this.sgMain.cboxloc = ((System.Drawing.PointF)(resources.GetObject("sgMain.cboxloc")));
            this.sgMain.cboxsiz = new System.Drawing.SizeF(0F, 0F);
            this.sgMain.CountLocation = new System.Drawing.Point(0, 0);
            this.sgMain.ctitloc = ((System.Drawing.PointF)(resources.GetObject("sgMain.ctitloc")));
            this.sgMain.dateloc = ((System.Drawing.PointF)(resources.GetObject("sgMain.dateloc")));
            this.sgMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgMain.GridColor = System.Drawing.Color.LightGray;
            this.sgMain.IndexIncrement = new System.Drawing.Point(0, 0);
            this.sgMain.LabelFontSize = 8F;
            this.sgMain.LabelPrecision = "g5";
            this.sgMain.Location = new System.Drawing.Point(0, 39);
            this.sgMain.Margin = new System.Windows.Forms.Padding(0);
            this.sgMain.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.sgMain.Name = "sgMain";
            this.sgMain.Offset = new System.Windows.Forms.Padding(80, 15, 20, 54);
            this.sgMain.Size = new System.Drawing.Size(632, 672);
            this.sgMain.TabIndex = 2;
            this.sgMain.TabStop = false;
            this.sgMain.titlloc = ((System.Drawing.PointF)(resources.GetObject("sgMain.titlloc")));
            this.sgMain.X = new Dgraph.DGraph.Axis(false, this.sgMain);
            this.sgMain.Y = new Dgraph.DGraph.Axis(true, this.sgMain);
            this.sgMain.Paint += new System.Windows.Forms.PaintEventHandler(this.sgMain_Paint);
            // 
            // stGraph
            // 
            this.stGraph.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbMarker});
            this.stGraph.Location = new System.Drawing.Point(0, 711);
            this.stGraph.Name = "stGraph";
            this.stGraph.Size = new System.Drawing.Size(632, 22);
            this.stGraph.SizingGrip = false;
            this.stGraph.TabIndex = 1;
            // 
            // lbMarker
            // 
            this.lbMarker.Name = "lbMarker";
            this.lbMarker.Size = new System.Drawing.Size(72, 17);
            this.lbMarker.Text = "Marker: N/A";
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnMarkerToggle,
            this.toolStripSeparator13,
            this.bnPrev,
            this.bnNext,
            this.toolStripSeparator14,
            this.bnXYnorm,
            this.bnYnorm,
            this.bnXnorm,
            this.toolStripSeparator15,
            this.bnDelete,
            this.bnDeleteAll});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(632, 39);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // bnMarkerToggle
            // 
            this.bnMarkerToggle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnMarkerToggle.Image = global::ThorMotor.Properties.Resources.BMarkerOff;
            this.bnMarkerToggle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnMarkerToggle.Name = "bnMarkerToggle";
            this.bnMarkerToggle.Size = new System.Drawing.Size(36, 36);
            this.bnMarkerToggle.Text = "Toggle Marker";
            this.bnMarkerToggle.Click += new System.EventHandler(this.bnMarker_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 39);
            // 
            // bnPrev
            // 
            this.bnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnPrev.Image = global::ThorMotor.Properties.Resources.BPrev;
            this.bnPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnPrev.Name = "bnPrev";
            this.bnPrev.Size = new System.Drawing.Size(36, 36);
            this.bnPrev.Text = "Previous Curve";
            this.bnPrev.Click += new System.EventHandler(this.bnPrev_Click);
            // 
            // bnNext
            // 
            this.bnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnNext.Image = global::ThorMotor.Properties.Resources.BNext;
            this.bnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnNext.Name = "bnNext";
            this.bnNext.Size = new System.Drawing.Size(36, 36);
            this.bnNext.Text = "Next Curve";
            this.bnNext.Click += new System.EventHandler(this.bnNext_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 39);
            // 
            // bnXYnorm
            // 
            this.bnXYnorm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnXYnorm.Image = global::ThorMotor.Properties.Resources.BNormAllXY;
            this.bnXYnorm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnXYnorm.Name = "bnXYnorm";
            this.bnXYnorm.Size = new System.Drawing.Size(36, 36);
            this.bnXYnorm.Text = "Scale all curves";
            this.bnXYnorm.Click += new System.EventHandler(this.bnXYnorm_Click);
            // 
            // bnYnorm
            // 
            this.bnYnorm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnYnorm.Image = global::ThorMotor.Properties.Resources.BNormAllY;
            this.bnYnorm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnYnorm.Name = "bnYnorm";
            this.bnYnorm.Size = new System.Drawing.Size(36, 36);
            this.bnYnorm.Text = "Scale Y-axis of all curves";
            this.bnYnorm.Click += new System.EventHandler(this.bnYnorm_Click);
            // 
            // bnXnorm
            // 
            this.bnXnorm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnXnorm.Image = global::ThorMotor.Properties.Resources.BNormAllX;
            this.bnXnorm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnXnorm.Name = "bnXnorm";
            this.bnXnorm.Size = new System.Drawing.Size(36, 36);
            this.bnXnorm.Text = "Scale X-axis of all curves";
            this.bnXnorm.Click += new System.EventHandler(this.bnXnorm_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 39);
            // 
            // bnDelete
            // 
            this.bnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnDelete.Image = global::ThorMotor.Properties.Resources.BDelete;
            this.bnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnDelete.Name = "bnDelete";
            this.bnDelete.Size = new System.Drawing.Size(36, 36);
            this.bnDelete.Text = "Delete the active curve";
            this.bnDelete.Click += new System.EventHandler(this.bnDelete_Click);
            // 
            // bnDeleteAll
            // 
            this.bnDeleteAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnDeleteAll.Image = global::ThorMotor.Properties.Resources.BDeleteAll;
            this.bnDeleteAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnDeleteAll.Name = "bnDeleteAll";
            this.bnDeleteAll.Size = new System.Drawing.Size(36, 36);
            this.bnDeleteAll.Text = "Delete all curves";
            this.bnDeleteAll.Click += new System.EventHandler(this.bnDeleteall_Click);
            // 
            // pnDumpView
            // 
            this.pnDumpView.AutoScroll = true;
            this.pnDumpView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnDumpView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDumpView.Location = new System.Drawing.Point(0, 0);
            this.pnDumpView.Name = "pnDumpView";
            this.pnDumpView.Size = new System.Drawing.Size(318, 711);
            this.pnDumpView.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbSpectrum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 711);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(318, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbSpectrum
            // 
            this.lbSpectrum.Name = "lbSpectrum";
            this.lbSpectrum.Size = new System.Drawing.Size(43, 17);
            this.lbSpectrum.Text = "Frame:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bkgWorker
            // 
            this.bkgWorker.WorkerReportsProgress = true;
            this.bkgWorker.WorkerSupportsCancellation = true;
            this.bkgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgWorker_DoWork);
            this.bkgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bkgWorker_ProgressChanged);
            this.bkgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgWorker_RunWorkerCompleted);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cbInclude3D
            // 
            this.cbInclude3D.AutoSize = true;
            this.cbInclude3D.Checked = true;
            this.cbInclude3D.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbInclude3D.Location = new System.Drawing.Point(3, 71);
            this.cbInclude3D.Name = "cbInclude3D";
            this.cbInclude3D.Size = new System.Drawing.Size(190, 17);
            this.cbInclude3D.TabIndex = 2;
            this.cbInclude3D.Text = "Include 3D presentation into profile";
            this.cbInclude3D.UseVisualStyleBackColor = true;
            // 
            // bnDXoptions
            // 
            this.bnDXoptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnDXoptions.Image = global::ThorMotor.Properties.Resources.BDXoptions;
            this.bnDXoptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnDXoptions.Name = "bnDXoptions";
            this.bnDXoptions.Size = new System.Drawing.Size(36, 36);
            this.bnDXoptions.Text = "Jcamp-DX save options";
            this.bnDXoptions.Click += new System.EventHandler(this.bnDXoptions_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 794);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.stMain);
            this.Controls.Add(this.MainStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Thormotor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainStrip.ResumeLayout(false);
            this.MainStrip.PerformLayout();
            this.stMain.ResumeLayout(false);
            this.stMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tcMotor.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            //this.tabPage2.ResumeLayout(false);
            //this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            //this.tabPage3.ResumeLayout(false);
            //this.tabPage3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.stGraph.ResumeLayout(false);
            this.stGraph.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip MainStrip;
        private System.Windows.Forms.StatusStrip stMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tcMotor;
        private System.Windows.Forms.TabPage tabPage1;
        //private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        //private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.StatusStrip stGraph;
        private System.Windows.Forms.ToolStripStatusLabel lbMarker;
        private System.Windows.Forms.ToolStripButton bnMarkerToggle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton bnPrev;
        private System.Windows.Forms.ToolStripButton bnNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton bnXYnorm;
        private System.Windows.Forms.ToolStripButton bnYnorm;
        private System.Windows.Forms.ToolStripButton bnXnorm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripButton bnDelete;
        private System.Windows.Forms.ToolStripButton bnDeleteAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bnRasterScan;
        private System.Windows.Forms.ToolStripButton bnStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton bn3Dview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbH10000;
        private System.Windows.Forms.Button bnHup;
        private System.Windows.Forms.Button bnHdown;
        private System.Windows.Forms.RadioButton rbH1000;
        private System.Windows.Forms.RadioButton rbH100;
        private System.Windows.Forms.RadioButton rbH10;
        private System.Windows.Forms.TextBox txHposition;
        private System.Windows.Forms.Label label1;
        private Dgraph.DGraph sgMain;
        //private System.Windows.Forms.Button bnHset;
        private System.Windows.Forms.Button bnGetPos;
        private System.Windows.Forms.Button bnHome;
        private System.Windows.Forms.Button bnHgoto;
        private System.Windows.Forms.TextBox txHgotopos;
        private System.Windows.Forms.TextBox txHsetpos;
        private System.Windows.Forms.RichTextBox rxView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbHfast;
        private System.Windows.Forms.TextBox txHpoints;
        private System.Windows.Forms.TextBox txHstep;
        private System.Windows.Forms.TextBox txHto;
        private System.Windows.Forms.TextBox txHfrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bnSetupAxis;
        private System.Windows.Forms.TextBox txSpectra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txCollectionTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txVpoints;
        private System.Windows.Forms.TextBox txVstep;
        private System.Windows.Forms.TextBox txVto;
        private System.Windows.Forms.TextBox txVfrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button bnVsetup;
        private System.Windows.Forms.Button bnVset;
        private System.Windows.Forms.Button bnVgoto;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbV10000;
        private System.Windows.Forms.Button bnVup;
        private System.Windows.Forms.Button bnVdown;
        private System.Windows.Forms.RadioButton rbV1000;
        private System.Windows.Forms.RadioButton rbV100;
        private System.Windows.Forms.RadioButton rbV10;
        private System.Windows.Forms.TextBox txVgotopos;
        private System.Windows.Forms.TextBox txVsetpos;
        private System.Windows.Forms.TextBox txVposition;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbD10000;
        private System.Windows.Forms.Button bnDup;
        private System.Windows.Forms.Button bnDdown;
        private System.Windows.Forms.RadioButton rbD1000;
        private System.Windows.Forms.RadioButton rbD100;
        private System.Windows.Forms.RadioButton rbD10;
        private System.Windows.Forms.TextBox txDgotopos;
        private System.Windows.Forms.TextBox txDsetpos;
        private System.Windows.Forms.TextBox txDposition;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbSpectrum;
        private System.Windows.Forms.ToolStripButton bnPark;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txBottom;
        private System.Windows.Forms.CheckBox cbTicks;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txLeft;
        private System.Windows.Forms.TextBox txFontsize;
        private System.Windows.Forms.CheckBox cbLabels;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txTop;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txRight;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cbAutonorm;
        private System.Windows.Forms.TextBox txYmax;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txYmin;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cbGrid;
        private System.Windows.Forms.Panel pnDumpView;
        private System.ComponentModel.BackgroundWorker bkgWorker;
        private System.Windows.Forms.ToolStripButton bnLoadProfile;
        private System.Windows.Forms.ToolStripButton bnSaveProfile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton bnLoadExperiment;
        private System.Windows.Forms.ToolStripButton bnSaveExperiment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.CheckBox cbSaveJcamp;
        private System.Windows.Forms.CheckBox cbDatebased;
        private System.Windows.Forms.CheckBox cbAutosave;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox cbZeronorm;
        private System.Windows.Forms.TextBox txFolder;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txExperiment;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox cbOverWrite;
        private System.Windows.Forms.CheckBox cbInclude3D;
        private System.Windows.Forms.ToolStripButton bnDXoptions;
    }
}


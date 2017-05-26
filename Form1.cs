using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Tonu.Windows.Forms;
using Dgraph;
using Microsoft.Win32;

namespace ThorMotor
{
    public partial class Form1 : Form
    {
        #region Global data
        public static bool Break = false;
        public string Mainkey = "Software\\TR Software\\Thormotor";         // Save/Restore location in HKey_CurrentUser 
        public string ProfileFolder = "";
        public int vfrom, vto, vstep, hfrom, hto, hstep, hpoints, vpoints;
        public int spectra;
        public double samplingtime = 100;
        public bool vdir, hdir, emulate = true;
        public bool noentrance;
        public bool Working = false;                                        // if true, rasterscan is working
        public DGraph[] SSG;                                                // Array of DGraphs
        public Thor Th;                                                     // Thor motor board object
        public BKG Bkg = new BKG();                                         // Helper class for RasterScan 
        public Random rd = new Random((int)(DateTime.Now.Ticks / 100000L)); // For emulation rasterscan
        #endregion
        //
        #region Form related events
        public Form1() 
        {
            noentrance = true;                                              // Form load sets size and calls DumpUpdate
            InitializeComponent();
            Th = new Thor();
            SetupSystemMenu();
            noentrance = false;
        }
        private void Form1_Load(object sender, EventArgs e) 
        {
            Text += IntPtr.Size == 8 ? " (64-bit)" : " (32-bit)";
            ReadFromRegistry();
            Parse();
            CreateDump(true);
            UpdateDump();
            if (Th.Motors < 1 || Thor.thormotor_lasterror != "")
            {
                emulate = true;
                rxView.AppendText("Form1_load: " + Thor.thormotor_lasterror + "\n");
            }
            lbStatus.Text = "Status: " + (emulate ? "Emulating" : "OK");
            bnMarkerToggle.Image = sgMain.MarkerOn ? Properties.Resources.BMarkerOn :
                                                        Properties.Resources.BMarkerOff;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToRegistry();
        }
        private void splitContainer2_Panel1_SizeChanged(object sender, EventArgs e)
        {
            sgMain.Invalidate();
        }
        private void splitContainer2_Panel2_SizeChanged(object sender, EventArgs e)
        {
            UpdateDump();
        }
        private void splitContainer1_Panel1_SizeChanged(object sender, EventArgs e)
        {
            rxView.Height = splitContainer1.Panel1.Height - txSpectra.Location.Y - txSpectra.Height - 3;
        }
        private void rxView_DoubleClick(object sender, EventArgs e)
        {
            rxView.Clear();
        }
        private void txFolder_DoubleClick(object sender, EventArgs e)
        {
            txFolder.Text = "";
        }
        private void cbSaveJcamp_CheckedChanged(object sender, EventArgs e)
        {
            if (noentrance) return;
            cbDatebased.Text = cbSaveJcamp.Checked ? "Include timestamp in experiment folder name" : "Include timestamp in SSolve file name";
            cbOverWrite.Text = cbSaveJcamp.Checked ? "Overwrite files without warning" : "Append frames into SSolve without warning";
        }
        private void txLeft_TextChanged(object sender, EventArgs e)         // Dump View common parameters changed 
        {
            if (timer1.Enabled) timer1.Stop();                              // Kill spurious timer messages
            timer1.Tag = "Update";
            timer1.Interval = 1000;
            timer1.Start();                                                 // Delayed action timer
        }
        private void txHfrom_TextChanged(object sender, EventArgs e)        // Rasterscan parameters changed 
        {
            if (timer1.Enabled) timer1.Stop();                              // Kill spurious timer messages
            timer1.Tag = "RSupdate";
            timer1.Interval = 1000;
            timer1.Start();                                                 // Delayed action timer
        }
        private void timer1_Tick(object sender, EventArgs e)                // Delayed update of dump view cboxes and txboxes 
        {
            timer1.Stop();                                                  // This is one-shot timer
            int Left, Right, Top, Bottom, Size;
            double ymin, ymax, xmin = 0, xmax = 1000;
            if (sender == null) xmax = Bkg.faststep * (Bkg.fastpoints - 1);
            if ((string)timer1.Tag == "Update")
            {
                if (!double.TryParse(txYmin.Text, out ymin)) ymin = 0;
                if (!double.TryParse(txYmax.Text, out ymax)) ymax = 1000;
                if (!int.TryParse(txTop.Text, out Top)) Top = 10;
                if (!int.TryParse(txRight.Text, out Right)) Right = 10;
                if (!int.TryParse(txBottom.Text, out Bottom)) Bottom = 25;
                if (!int.TryParse(txLeft.Text, out Left)) Left = 25;
                if (!int.TryParse(txFontsize.Text, out Size)) Size = 25;
                for (int i = 0; i < SSG.Length; i++)
                {
                    SSG[i].Offset = new Padding(Left, Top, Right, Bottom);
                    SSG[i].Y.labels = SSG[i].X.labels = cbLabels.Checked;
                    SSG[i].Y.ticks = SSG[i].X.ticks = cbTicks.Checked;
                    SSG[i].Y.grid = SSG[i].X.grid = cbGrid.Checked;
                    SSG[i].ZeroNorm = cbZeronorm.Checked;
                    SSG[i].Y.min = ymin;
                    SSG[i].Y.max = ymax;
                    if (sender == null)
                    {
                        SSG[i].X.min = xmin;
                        SSG[i].X.max = xmax;
                    }
                    SSG[i].LabelFontSize = SSG[i].TitleFontSize = Size;
                    SSG[i].NoboxZoom = true;
                    SSG[i].NormX();
                    if (cbAutonorm.Checked) SSG[i].NormY();
                    SSG[i].Invalidate();
                }
            }
            else if ((string)timer1.Tag == "RSupdate")
            {
                Parse();
            }
            else if ((string)timer1.Tag == "Fade")
            {
                lbStatus.Text = "Status: " + (emulate ? "Emulating" : "OK");
            }
        }
        public void Report(string message)
        {
            if (message == null || message == "") return;
            int len = message.Length - 1;
            if (message[len] != '\n') message += "\n";
            rxView.AppendText(message);
        }
        public void ReportException(string what, Exception ee)              // We want line number information where the exception took place, if possible
        {
            char[] sep = { '\n', '\r' };
            Report(what + ": " + ee.Message);
            string[] sp = ee.StackTrace.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < sp.Length; j++)
            {
                if (sp[j].Contains("unz")) continue;                        // First may point to ManagedCuda - these we avoid
                Report(sp[j] + "\n");
                return;
            }
        }
        #endregion
        #region Dialog data Parsing and Dump-View creation/update
        private void Parse()                                                // Parse RasterScan parameters 
        {
            int.TryParse(txVfrom.Text, out vfrom);
            int.TryParse(txHfrom.Text, out hfrom);
            int.TryParse(txVto.Text, out vto);
            int.TryParse(txHto.Text, out hto);
            int.TryParse(txVstep.Text, out vstep);
            int.TryParse(txHstep.Text, out hstep);
            //
            if (vstep == 0) vstep = 100;                                    // Do not allow zero or negative step
            if (vstep < 0) vstep = -vstep;
            txVstep.Text = vstep.ToString();                                // Write step back as a positive integer
            vdir = vto >= vfrom;                                            // from / to determines direction    
            vpoints = vdir ? (vto - vfrom) / vstep + 1 : (vfrom - vto) / vstep + 1;
            txVpoints.Text = vpoints.ToString();                            // always, vpoints > 0 
            if (!vdir) vstep = -vstep;

            if (hstep == 0) hstep = 100;
            if (hstep < 0) hstep = -hstep;
            txHstep.Text = hstep.ToString();
            hdir = hto >= hfrom;
            hpoints = hdir ? (hto - hfrom) / hstep + 1 : (hfrom - hto) / hstep + 1;
            txHpoints.Text = hpoints.ToString();
            if (!hdir) hstep = -hstep;
            //
            spectra = cbHfast.Checked ?  vpoints : hpoints;                 // spectra are always > 0
            txSpectra.Text = spectra.ToString();
            //
            if (!double.TryParse(txCollectionTime.Text, out samplingtime)) samplingtime = 100;
        }
        private void CreateDump(bool create)                                // Create individual SSolveGraphs 
        {
            if (SSG == null || SSG.Length != spectra) { SSG = new DGraph[spectra]; create = true; }
            pnDumpView.Controls.Clear();
            for (int i = 0; i < spectra; i++)
            {
                if (create) SSG[i] = new DGraph();                          // We skip creating when we load data
                SSG[i].Name = "Gr" + i.ToString("D2");
                SSG[i].Text = cbHfast.Checked ? "Vert: " + (vfrom + i * vstep).ToString("N0") : "Horz: " + (hfrom + i * hstep).ToString("N0");
                SSG[i].LabelFontSize = SSG[i].TitleFontSize = 6;
                SSG[i].CountAlpha = 0;
                SSG[i].Click +=new EventHandler(SSG_Click);                 // Here the mouse-event is linked dynamically 
                SSG[i].Offset = new Padding(30, 8, 8, 30);                  // LTRB
                pnDumpView.Controls.Add(SSG[i]);
            }
        }
        private void UpdateDump()                                           // Called from CreateDump and when window-size changes 
        {
            if (noentrance) return;                                         // Splitter position change in Form1 ctor calls this too
            int i, j, wid, hei, minwid = 200, minhei = 200, wcount = 1;
            int Spectra = spectra;
            wid = pnDumpView.Width;
            hei = pnDumpView.Height;
            if (wid < 1) return;
            wcount = wid / minwid;
            if (wcount < 1) wcount = 1;
            DGraph ssg;
            for (i = 0, j = 0; j < pnDumpView.Controls.Count; j++)
                if (pnDumpView.Controls[i].GetType() == typeof(DGraph))
                {
                    ssg = (DGraph)pnDumpView.Controls[i];
                    ssg.Width = minwid;
                    ssg.Height = minhei;
                    ssg.Top = (i / wcount) * (minhei + 3);
                    ssg.Left = (i % wcount) * (minwid + 3);
                    ssg.Invalidate();
                    i++;
                }
            pnDumpView.Invalidate();
        }
        #endregion
        /// <summary>
        /// /////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="thekey"></param>
        /// <param name="value"></param>
        #region Registry and Profile
        public void SaveEntry(string thekey, string value)                  // We can call this to save initial_directory from various Save/Open forms 
        {
            if (thekey == null || thekey == "" || Mainkey == null || Mainkey == "") return;
            RegistryKey rkTC = Registry.CurrentUser.CreateSubKey(Mainkey);
            if (rkTC == null) return;
            rkTC.SetValue(thekey, value);
        }
        public string ReadEntry(string thekey)                              // We can call this to read initial_directory from various Save/Open forms 
        {
            if (thekey == null || thekey == "" || Mainkey == null || Mainkey == "") return "";
            RegistryKey rkTC = Registry.CurrentUser.OpenSubKey(Mainkey);
            if (rkTC == null) return "";
            return (string)rkTC.GetValue(thekey, "");
        }
        public void SaveToRegistry()                                        // We save form position, size, and window mode 
        {
            try
            {
                RegistryKey rkTC = Registry.CurrentUser.CreateSubKey(Mainkey);         
                if (rkTC == null) return;
                int i;
                #region GUI state
                i = (int)WindowState;                                       // If windowstate is Max or Min then we do not want to 
                rkTC.SetValue("WindowState", i);                            // save the position values.
                if (WindowState == FormWindowState.Normal)                  // Save sizes only if form is not maximized or minimized 
                {
                    rkTC.SetValue("LocationX", Location.X);                 // Save position values
                    rkTC.SetValue("LocationY", Location.Y);
                    rkTC.SetValue("SizeX", this.Size.Width);                // Save size 
                    rkTC.SetValue("SizeY", this.Size.Height);
                }
                rkTC.SetValue("SplitterDistance1", this.splitContainer1.SplitterDistance);      // Main form left/right
                rkTC.SetValue("SplitterDistance2", this.splitContainer2.SplitterDistance);      // Spec view
                #endregion
                List<string> WL = WriteProfile("Thormotor Profile");
                Profile.SaveToRegistry(rkTC, WL);
            }
            catch { }                                                       // And if it went wrong, bother me not; we have no time to read this anyway as we are exiting 
        }
        public void ReadFromRegistry()                                      // We read form position, size, and windowstate 
        {
            try
            {
                RegistryKey rkTC = Registry.CurrentUser.OpenSubKey(Mainkey);
                if (rkTC == null) return;                                   // If this key does not exist...
                int x = -1, y = -1, sx = -1, sy = -1;                 // We have not been here before
                #region GUI state
                x = (int)rkTC.GetValue("WindowState", -1);
                if (x != -1)
                    WindowState = (FormWindowState)x;
                x = (int)rkTC.GetValue("LocationX", -1);
                y = (int)rkTC.GetValue("LocationY", -1);
                sx = (int)rkTC.GetValue("SizeX", -1);
                sy = (int)rkTC.GetValue("SizeY", -1);
                if (x != -1 && y != -1 && sx != -1 && sy != -1)
                    SetDesktopBounds(x, y, sx, sy);
                x = (int)rkTC.GetValue("SplitterDistance1", -1);
                if (x != -1 && x >= this.splitContainer1.Panel1MinSize &&
                    x <= (this.splitContainer1.Width - this.splitContainer1.Panel2MinSize))
                    this.splitContainer1.SplitterDistance = x;
                x = (int)rkTC.GetValue("SplitterDistance2", -1);
                if (x != -1 && x >= this.splitContainer2.Panel1MinSize &&
                    x <= (this.splitContainer2.Width - this.splitContainer2.Panel2MinSize))
                    this.splitContainer2.SplitterDistance = x;
                #endregion
                List<string> RL = Profile.ReadFromRegistry(rkTC, "Thormotor Profile");
                ReadProfile(RL, "Thormotor Profile");
            }
            catch (Exception ee)
            {
                ReportException("ReadFromRegistry", ee);
            }
        }
        private List<string> WriteProfile(string profilename)
        {
            List<string> WL = new List<string>(100);
            string blockid = profilename;
            WL.Add("[" + blockid + "]");                                    // "[Thormotor Profile]"
            int write_version = 1;                                          // This is Thormotor write version
            WL.Add("Profile_version= " + Profile.write_version);            // This profile_writer version
            WL.Add("Write_version= " + write_version);                      // For the future
            WL.Add("ProfileFolder= " + ProfileFolder);
            WL.Add("ExecutablePath= " + Application.ExecutablePath);
            #region Main page
            // Collection related
            WL.Add("CollectionTime= " + txCollectionTime.Text);               // We only write strings
            WL.Add("Experiment= " + txExperiment.Text);
            WL.Add("Folder= " + txFolder.Text);
            WL.Add("Autosave= " + cbAutosave.Checked);
            WL.Add("Datebased= " + cbDatebased.Checked);
            WL.Add("SaveJcamp= " + cbSaveJcamp.Checked);
            // Dump view
            WL.Add("Fontsize= " + txFontsize.Text);
            WL.Add("Bottom= " + txBottom.Text);
            WL.Add("Top= " + txTop.Text);
            WL.Add("Right= " + txRight.Text);
            WL.Add("Left= " + txLeft.Text);
            WL.Add("Ymax= " + txYmax.Text);
            WL.Add("Ymin= " + txYmin.Text);
            WL.Add("Autonorm= " + cbAutonorm.Checked);
            WL.Add("Zeronorm= " + cbZeronorm.Checked);
            WL.Add("Grid= " + cbGrid.Checked);
            WL.Add("Labels= " + cbLabels.Checked);
            WL.Add("Ticks= " + cbTicks.Checked);
            // Horizontal motor
            WL.Add("Hfrom= " + txHfrom.Text);
            WL.Add("Hstep= " + txHstep.Text);
            WL.Add("Hpoints= " + txHpoints.Text);
            WL.Add("Hto= " + txHto.Text);
            WL.Add("Hsetpos= " + txHsetpos.Text);
            WL.Add("Hgotopos= " + txHgotopos.Text);
            WL.Add("Hposition= " + txHposition.Text);
            WL.Add("H10= " + rbH10.Checked);
            WL.Add("H100= " + rbH100.Checked);
            WL.Add("H1000= " + rbH1000.Checked);
            WL.Add("H10000= " + rbH10000.Checked);
            WL.Add("Hfast= " + cbHfast.Checked);
            // Vertical motor
            WL.Add("Vfrom= " + txVfrom.Text);
            WL.Add("Vstep= " + txVstep.Text);
            WL.Add("Vpoints= " + txVpoints.Text);
            WL.Add("Vto= " + txVto.Text);
            WL.Add("Vsetpos= " + txVsetpos.Text);
            WL.Add("Vgotopos= " + txVgotopos.Text);
            WL.Add("Vposition= " + txVposition.Text);
            WL.Add("V10= " + rbV10.Checked);
            WL.Add("V100= " + rbV100.Checked);
            WL.Add("V1000= " + rbV1000.Checked);
            WL.Add("V10000= " + rbV10000.Checked);
            // Diagonal motor
            WL.Add("Dsetpos= " + txDsetpos.Text);
            WL.Add("Dgotopos= " + txDgotopos.Text);
            WL.Add("Dposition= " + txDposition.Text);
            WL.Add("D10= " + rbD10.Checked);
            WL.Add("D100= " + rbD100.Checked);
            WL.Add("D1000= " + rbD1000.Checked);
            WL.Add("D10000= " + rbD10000.Checked);
            #endregion
            WL.AddRange(sgMain.Write("sgMain", false));
            if (cbInclude3D.Checked)
            {
                GLMapControl glc = new GLMapControl();
                glc.ReadFromRegistry(Mainkey);                              // Read from registry
                WL.AddRange(glc.WriteProfile("HeightMap"));
            }
            WL.Add("[/" + blockid + "]");                                   // "[/Thormotor Profile]"   Block End signature
            return WL;
        }
        private bool ReadProfile(List<string> lines, string profilename)
        {
            bool b; string s; 
            int read_version;
            List<string> RL = Profile.FindBlock(lines, profilename);
            if (Profile.Parse(RL, "Profile_version", out read_version))     // This read version means Profile.Read is not compatible 
                if (!Profile.CanRead(read_version))
                { 
                    rxView.AppendText("Saved profile version (" + read_version + ") is incompatible with current reader.\n"); 
                    return false; 
                }
            if (!Profile.Parse(RL, "Write_version", out read_version))      // This read_version allows version check of the Thormotor Profiler
                read_version = 1;
            if (Profile.Parse(RL, "ProfileFolder", out s)) ProfileFolder = s;
            #region Main page
            // Collection related
            if (Profile.Parse(RL, "CollectionTime", out s)) txCollectionTime.Text = s;
            if (Profile.Parse(RL, "Experiment", out s)) txExperiment.Text = s;
            if (Profile.Parse(RL, "Folder", out s)) txFolder.Text = s;
            if (Profile.Parse(RL, "Autosave", out b))  cbAutosave.Checked = b;
            if (Profile.Parse(RL, "Datebased", out b)) cbDatebased.Checked = b;
            if (Profile.Parse(RL, "SaveJcamp", out b)) cbSaveJcamp.Checked = b;     
            // Dump view
            if (Profile.Parse(RL, "Fontsize", out s)) txFontsize.Text = s;
            if (Profile.Parse(RL, "Bottom", out s)) txBottom.Text = s;
            if (Profile.Parse(RL, "Top", out s)) txTop.Text = s;
            if (Profile.Parse(RL, "Right", out s)) txRight.Text = s;
            if (Profile.Parse(RL, "Left", out s)) txLeft.Text = s;
            if (Profile.Parse(RL, "Ymax", out s)) txYmax.Text = s;
            if (Profile.Parse(RL, "Ymin", out s)) txYmin.Text = s;
            if (Profile.Parse(RL, "Autonorm", out b)) cbAutonorm.Checked = b;
            if (Profile.Parse(RL, "Zeronorm", out b)) cbZeronorm.Checked = b;
            if (Profile.Parse(RL, "Grid", out b))   cbGrid.Checked = b;
            if (Profile.Parse(RL, "Labels", out b)) cbLabels.Checked = b;
            if (Profile.Parse(RL, "Ticks", out b))  cbTicks.Checked = b;
            // Horizontal motor
            if (Profile.Parse(RL, "Hfrom", out s)) txHfrom.Text = s;
            if (Profile.Parse(RL, "Hstep", out s)) txHstep.Text = s;
            if (Profile.Parse(RL, "Hto", out s)) txHto.Text = s;
            if (Profile.Parse(RL, "Hpoints", out s)) txHpoints.Text = s;
            if (Profile.Parse(RL, "Hsetpos", out s)) txHsetpos.Text = s;
            if (Profile.Parse(RL, "Hgotopos", out s)) txHgotopos.Text = s;
            if (Profile.Parse(RL, "Hposition", out s)) txHposition.Text = s;
            if (Profile.Parse(RL, "H10", out b)) rbH10.Checked = b;
            if (Profile.Parse(RL, "H100", out b)) rbH100.Checked = b;
            if (Profile.Parse(RL, "H1000", out b)) rbH1000.Checked = b;
            if (Profile.Parse(RL, "H10000", out b)) rbH10000.Checked = b;
            if (Profile.Parse(RL, "Hfast", out b)) cbHfast.Checked = b;
            // Vertical motor
            if (Profile.Parse(RL, "Vfrom", out s)) txVfrom.Text = s;
            if (Profile.Parse(RL, "Vstep", out s)) txVstep.Text = s;
            if (Profile.Parse(RL, "Vto", out s)) txVto.Text = s;
            if (Profile.Parse(RL, "Vpoints", out s)) txVpoints.Text = s;
            if (Profile.Parse(RL, "Vsetpos", out s)) txVsetpos.Text = s;
            if (Profile.Parse(RL, "Vgotopos", out s)) txVgotopos.Text = s;
            if (Profile.Parse(RL, "Vposition", out s)) txVposition.Text = s;
            if (Profile.Parse(RL, "V10", out b)) rbV10.Checked = b;
            if (Profile.Parse(RL, "V100", out b)) rbV100.Checked = b;
            if (Profile.Parse(RL, "V1000", out b)) rbV1000.Checked = b;
            if (Profile.Parse(RL, "V10000", out b)) rbV10000.Checked = b;
            // Diagonal motor
            if (Profile.Parse(RL, "Dsetpos", out s)) txDsetpos.Text = s;
            if (Profile.Parse(RL, "Dgotopos", out s)) txDgotopos.Text = s;
            if (Profile.Parse(RL, "Dposition", out s)) txDposition.Text = s;
            if (Profile.Parse(RL, "D10", out b)) rbD10.Checked = b;
            if (Profile.Parse(RL, "D100", out b)) rbD100.Checked = b;
            if (Profile.Parse(RL, "D1000", out b)) rbD1000.Checked = b;
            if (Profile.Parse(RL, "D10000", out b)) rbD10000.Checked = b;
            #endregion
            sgMain.Read(lines, "sgMain");
            if (cbInclude3D.Checked)
            {
                List<string> GL = Profile.FindBlock(lines, "HeightMap");
                if (GL.Count > 2)
                {
                    GLMapControl glc = new GLMapControl();
                    glc.ReadProfile(GL, "HeightMap");
                    glc.SaveToRegistry(Mainkey);                            // Save 3D presentation data into registry
                }
            }
            return true;
        }
        private void bnLoadProfile_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = "Profile*.ini";
                openFileDialog1.Title = "Load Profile from file";
                openFileDialog1.Filter = "ThorMotor ASCII profile file (*.ini)|*.INI|All files|*.*";
                if (ProfileFolder != "" && Directory.Exists(ProfileFolder)) 
                    openFileDialog1.InitialDirectory = ProfileFolder;
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.DefaultExt = ".INI";
                openFileDialog1.CheckFileExists = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string[] lines = File.ReadAllLines(openFileDialog1.FileName);
                    if (lines[0].Contains("Thormotor"))
                    {
                        Report("Loading Profile from: " + Path.GetFileName(openFileDialog1.FileName));
                        List<string> RL = new List<string>(lines.Length);
                        RL.AddRange(lines);
                        if (ReadProfile(RL, "Thormotor Profile"))
                            ProfileFolder = Path.GetDirectoryName(openFileDialog1.FileName);
                   }
                }
            }
            catch (Exception ee)
            {
                ReportException("bnLoadProfile_Click", ee);
            }
        }
        private void bnSaveProfile_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProfileFolder != "" && Directory.Exists(ProfileFolder))
                    saveFileDialog1.InitialDirectory = ProfileFolder;
                saveFileDialog1.FileName = "Profile " + GetToD(true) + ".ini";
                saveFileDialog1.Title = "Save everything in a Profile";
                saveFileDialog1.Filter = "Thormotor ASCII profile file (*.ini)|*.INI|All files|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.DefaultExt = ".INI";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ProfileFolder = Path.GetDirectoryName(saveFileDialog1.FileName);
                    List<string> WL = WriteProfile("Thormotor Profile");
                    if (WL.Count > 0)
                    {
                        if (File.Exists(saveFileDialog1.FileName)) File.Delete(saveFileDialog1.FileName);
                        File.WriteAllLines(saveFileDialog1.FileName, WL);
                    }
                }
            }
            catch (Exception ee)
            {
                ReportException("bnSaveProfile_Click", ee);
            }
        }
        private string GetToD(bool date)                                    // Get hierarchical Date'n'Time for standardized filenames or folders
        {
            DateTime dt = DateTime.Now;
            string st = "";
            if (date) st += dt.Year.ToString("D4") + "." + dt.Month.ToString("D2") + "." + dt.Day.ToString("D2") + " ";
            st += dt.Hour.ToString("D2") + "." + dt.Minute.ToString("D2") + "." + dt.Second.ToString("D2");
            return st;
        }
        #endregion
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        #region Common SSolveGraph events
        public DGraph Get_SGfromMain()                                      // Form->DGraph 
        {
            /*
            Control.ControlCollection dd = this.Controls;                   // This is too complicated for this short program, but for more complex programs with many SSolveGraphs  
            foreach (Control d in dd)                                       //  it is nice to have some automated way of getting a SSolvegraph object - so all the nice fireworks
                if (d.GetType() == typeof(DGraph))  //  like markers and prev/next curve selection will work with the same code
                    return (DGraph)d;               // I practically never rewrite the code that follows; I only tailor this subroutine to my application's Form design
            return null;                                                    // could not find any SSolveGraph - Text View is selected for example 
            */
            return sgMain;
        }
        private void bnMarker_Click(object sender, EventArgs e)
        {
            DGraph ssg = Get_SGfromMain();
            if (ssg == null) return;
            ToolStripButton B = sender as ToolStripButton;
            ssg.MarkerOn = ssg.MarkerOn ? false : true;
            B.Image = ssg.MarkerOn ? Properties.Resources.BMarkerOn :
                                        Properties.Resources.BMarkerOff;
            ssg.Invalidate();
        }
        private void bnPrev_Click(object sender, EventArgs e)
        {
            DGraph ssg = Get_SGfromMain();
            if (ssg == null) return;
            int i, j = ssg.Curves.Count;
            if (j < 2) return;
            i = ssg.ActCurve;
            if (--i < 0) i = ssg.Curves.Count - 1;
            ssg.ActCurve = i;
            ssg.Invalidate();
        }
        private void bnNext_Click(object sender, EventArgs e)
        {
            DGraph ssg = Get_SGfromMain();
            if (ssg == null) return;
            int i, j = ssg.Curves.Count;
            if (j < 2) return;
            i = ssg.ActCurve;
            if (++i >= ssg.Curves.Count) i = 0;
            ssg.ActCurve = i;
            ssg.Invalidate();
        }
        private void bnXYnorm_Click(object sender, EventArgs e)
        {
            DGraph ssg = Get_SGfromMain();
            if (ssg == null) return;
            ssg.Norm();
            //ssg.NormX();
            //if (ssg.Name.ToUpper()[ssg.Name.Length - 1] == 'H')
            //    ssg.SetYLimits(1.001, 1000.0);                                // Neglect the 0th bin for histograms ???  comment out if you want it
            //else
            //    ssg.NormY();
            ssg.Invalidate();
        }
        private void bnYnorm_Click(object sender, EventArgs e)
        {
            DGraph ssg = Get_SGfromMain();
            if (ssg == null) return;
            ssg.NormY();
            ssg.Invalidate();
        }
        private void bnXnorm_Click(object sender, EventArgs e)
        {
            DGraph ssg = Get_SGfromMain();
            if (ssg == null) return;
            ssg.NormX();
            ssg.Invalidate();
        }
        private void bnDelete_Click(object sender, EventArgs e)
        {
            DGraph ssg = Get_SGfromMain();
            if (ssg == null) return;
            ssg.RemoveAt(ssg.ActCurve);
            ssg.Invalidate();
        }
        private void bnDeleteall_Click(object sender, EventArgs e)
        {
            DGraph ssg = Get_SGfromMain();
            if (ssg == null) return;
            ssg.Kill();
            ssg.Invalidate();
        }
        public void sgMain_Paint(object sender, PaintEventArgs e)
        {
            DGraph gr = Get_SGfromMain();
            ToolStripStatusLabel lb = lbMarker;
            if (gr == null || gr.Curves == null || gr.Curves.Count < 1 || gr.ActCurve > gr.Curves.Count
                || gr.ActCurve < 0 || !gr.MarkerOn || gr.M == null || lb == null) return;
            Curve gc = gr.Curves[gr.ActCurve];
            lb.Text = gc.title + "  Ch:" + gr.M.ch.ToString();
            lb.Text += "   X:" + gr.M.xst;
            lb.Text += "   Y:" + gr.M.yst;
        }
        #endregion
        #region 3D and Help section 
        private void bn3Dview_Click(object sender, EventArgs e)
        {
            FImage F = new FImage();
            GetImage(ref F);
            Form3D H = new Form3D(F, Mainkey);
            H.MapTitle = txExperiment.Text;                             
            H.Show();
        }
        private bool GetImage(ref FImage F)                                 
        {
            if (SSG.Length < 2 || SSG[0].Curves.Count < 1 || SSG[0].Curves[0].Length < 2) return false;                               // No data
            int i, j = SSG.Length, k, l = SSG[0].Curves[0].Length;
            F.Create(l, j);
            float[] X = null, Y = null;
            SSG[0].Curves[0].GetData(ref X, ref Y, false, false);           // First line and X-axis creation
            F.Y[0] = 0;
            for (k = 0; k < l; k++)
            {
                F.X[k] = X[k];
                F.Img[k] = Y[k];
            }
            for (i = 1; i < j; i++)
            {
                F.Y[i] = (float)(cbHfast.Checked ? vstep * i : hstep * i);
                if (SSG[i].Curves.Count > 0) SSG[i].Curves[0].GetData(ref X, ref Y, false, false);
                else  Y = new float[l];                                     // In the case we canceled, there are no Curves in SSG[i]
                for (k = 0; k < l; k++) F.Img[k + i * l] = Y[k];
            }
            F.fullname = "";                                                // RAW image filename is empty
            F.title =  txExperiment.Text;
            return true;
        }
        #endregion
        private double Collect(double samplingtime)
        {
            double d = 0;
            if (emulate)
            {
                Thread.Sleep((int)Bkg.samplingtime);
                d = rd.NextDouble();
                if (d > 0.2 && d < 0.215) d *= rd.NextDouble() * 100; 
                d *= Bkg.samplingtime;
                return d;
            }
            else
            {
                       //  Signal collection code goes here
            }
            if (cbAutosave.Checked) bnSaveExperiment_Click(null, null);
            return d;
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Loading and Saving of the experiment data
        private void bnLoadExperiment_Click(object sender, EventArgs e)
        {
            try
            {
                double ymin, ymax;
                double.TryParse(txYmin.Text, out ymin);
                double.TryParse(txYmax.Text, out ymax);
                if (cbSaveJcamp.Checked)                                    // We create a sub-folder based on "txExperiment" and ToD 
                {
                    if (txFolder.Text != "" && Directory.Exists(txFolder.Text))
                        openFileDialog1.InitialDirectory = txFolder.Text;
                    openFileDialog1.Title = "Load an experiment from a set of Jcamp-DX files";
                    openFileDialog1.Filter = "Jcamp-DX files (*.dx)|*.DX|All files|*.*";
                    openFileDialog1.FileName = "*.dx";
                    openFileDialog1.FilterIndex = 1;
                    openFileDialog1.DefaultExt = ".DX";
                    openFileDialog1.Multiselect = true;
                    if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileNames.Length > 0)
                    {
                        sgMain.Kill();
                        int i, j, len = openFileDialog1.FileNames.Length;
                        string[] comm = null;
                        char[] sep = { ' ', '=' };
                        SSG = new DGraph[len];
                        spectra = len;
                        double[] X = null, Y = null;
                        for (i = 0; i < len; i++)
                        {
                            if (Jcampdx.Read(openFileDialog1.FileNames[i], ref X, ref Y))
                            {
                                Jcampdx.ReadComments(openFileDialog1.FileNames[i], 0, ref comm);
                                SSG[i] = new DGraph();
                                Curve cr = new Curve();
                                cr.Attach(Y, X);
                                cr.title = comm[0];                         // Title
                                SSG[i].Attach(cr);
                                SSG[i].NormX();
                                if (cbAutonorm.Checked) SSG[i].NormY();
                                else SSG[i].SetYLimits(ymin, ymax);
                            }
                            if (i == 0)                                     // We need to get the origin point values from 0-based data; it was written to all of them, but we use the 1st frame only
                                for (j = 0; j < comm.Length; j++)
                                {
                                    string st = comm[j].ToLower();
                                    if (st == "") continue;
                                    if (st[0] == 'h')
                                    {
                                        string[] sp = st.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                                        if (sp.Length < 2) continue;
                                        if (st.Contains("from")) txHfrom.Text = sp[1];
                                        else if (st.Contains("to")) txHto.Text = sp[1];
                                        else if (st.Contains("step")) txHstep.Text = sp[1];
                                    }
                                    else if (st[0] == 'v')
                                    {
                                        string[] sp = st.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                                        if (sp.Length < 2) continue;
                                        if (st.Contains("from")) txVfrom.Text = sp[1];
                                        else if (st.Contains("to")) txVto.Text = sp[1];
                                        else if (st.Contains("step")) txVstep.Text = sp[1];
                                    }
                                }
                        }
                        string folder = Path.GetDirectoryName(openFileDialog1.FileNames[0]);
                        txFolder.Text = Path.GetDirectoryName(folder);
                        txExperiment.Text = Path.GetFileNameWithoutExtension(folder);
                    }
                }
                else
                {
                    if (txFolder.Text != "" && Directory.Exists(txFolder.Text))
                        openFileDialog1.InitialDirectory = txFolder.Text;
                    openFileDialog1.Title = "Load an experiment from a SpectraSolve file";
                    openFileDialog1.Filter = "SpectraSolve file (*.spc)|*.SPC|All files|*.*";
                    openFileDialog1.FilterIndex = 1;
                    openFileDialog1.DefaultExt = ".SPC";
                    openFileDialog1.Multiselect = false;
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        List<SSpec> LS = new List<SSpec>();
                        SSolve.Read(openFileDialog1.FileName, ref LS);
                        int i, len = LS.Count;
                        SSG = new DGraph[len];
                        spectra = len;
                        double[] X = null, Y = null;
                        for (i = 0; i < len; i++)
                        {
                            LS[i].GetData(ref X, ref Y);
                            Curve cr = new Curve();
                            cr.Attach(Y, X);
                            cr.title = LS[i].comment;
                            SSG[i] = new DGraph();
                            SSG[i].Attach(cr);
                            SSG[i].NormX();
                            if (cbAutonorm.Checked) SSG[i].NormY();
                            else SSG[i].SetYLimits(ymin, ymax);
                            if (i == 0)                                       // Into the first spectrum comment we wrote From;To;Step  for H and V motors
                            {
                                char[] sep1 = { '@' };
                                char[] sep2 = { ';', ':' };                // Expect: SomeText @H:125,000;135,000;200 @V:100,000;101,000;100
                                string[] sp = cr.title.Split(sep1, StringSplitOptions.RemoveEmptyEntries);
                                if (sp.Length > 2)
                                {                                           // Expect: V:100,000;101,000;100
                                    string[] so = sp[1].Split(sep2, StringSplitOptions.RemoveEmptyEntries);
                                    if (so.Length > 3)
                                    {
                                        txHfrom.Text = so[1];
                                        txHto.Text = so[2];
                                        txHstep.Text = so[3];
                                    }
                                    so = sp[2].Split(sep2, StringSplitOptions.RemoveEmptyEntries);
                                    if (so.Length > 3)
                                    {
                                        txVfrom.Text = so[1];
                                        txVto.Text = so[2];
                                        txVstep.Text = so[3];
                                    }
                                }
                            }
                        }
                        txFolder.Text = Path.GetDirectoryName(openFileDialog1.FileName);
                        txExperiment.Text = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    }
                }
                CreateDump(false);
                UpdateDump();
                if (SSG.Length > 0 && SSG[0].Curves.Count > 0)
                {
                    sgMain.Kill();
                    sgMain.Attach(SSG[0].Curves[0]);
                    sgMain.NormX();
                    if (cbAutonorm.Checked) sgMain.NormY();
                    else sgMain.SetYLimits(ymin, ymax);
                    sgMain.Invalidate();
                }
                txSpectra.Text = spectra.ToString();
            }
            catch (Exception ee)
            {
                ReportException("bnLoadExperiment_Click", ee);
            }
        }
        private string GetJcampName(int i)
        {
            char[] sep = {' ', ':'};                                        // Expect: Horz: 100,000  or Vert: 100,100
            string[] sp = SSG[i].Text.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            if (sp.Length > 1 && SSG[i].Curves.Count > 0)
                return sp[0] + "_" + sp[1] + ".dx";
            else return "";
        }
        private void bnSaveExperiment_Click(object sender, EventArgs e)
        {
            try
            {
                char[] ic = Path.GetInvalidPathChars();
                char[] iv = Path.GetInvalidFileNameChars();
                if (txFolder.Text == "" || !Directory.Exists(txFolder.Text))
                {
                    folderBrowserDialog1.ShowNewFolderButton = true;
                    folderBrowserDialog1.Description = "Create/Browse to Base Folder for data saving";
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        txFolder.Text = folderBrowserDialog1.SelectedPath;
                    }
                    else return;
                }
                Directory.SetCurrentDirectory(txFolder.Text);
                string tod = cbDatebased.Checked ? GetToD(true) : "";
                int i;
                double[] X = null, Y = null;
                if (cbSaveJcamp.Checked)                                    // We create a sub-folder based on "txExperiment" and ToD 
                {
                    if (txExperiment.Text != "" && txExperiment.Text.IndexOfAny(ic) >= 0) 
                    {
                        Report("Invalid characters in the experiment name (becomes a part of the folder name)"); return;
                    }
                    string folder = txExperiment.Text;
                    if (folder != "" && tod != "") folder += " ";
                    folder += tod;
                    folder = txFolder.Text + "\\" + folder;
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);
                    Directory.SetCurrentDirectory(folder);
                    Jcampdx.WriteXunits = Jcampdx.XUnits.Arbitrary;
                    Jcampdx.WriteYunits = Jcampdx.YUnits.Arbitrary;
                    Jcampdx.WriteOptions = Jcampdx.Options.Dualcolumn | Jcampdx.Options.NoFactoring | Jcampdx.Options.Version5 | Jcampdx.Options.XYdata | Jcampdx.Options.TakeOwnership | Jcampdx.Options.TakeOrigin;
                    List<string> comment = new List<string>();
                    if (!cbOverWrite.Checked)
                        for (i = 0; i < spectra; i++)                       // At first we check overwriting
                        {
                            string name = GetJcampName(i);
                            if (name != "" && File.Exists(name))
                            {
                                if (MessageBox.Show("File: " + name + " exists, please press OK to overwrite all matching files, or Cancel to abort.", "Overwrite warning, some files exist!", MessageBoxButtons.OKCancel) != DialogResult.OK)
                                { Report("Change the experiment name"); return; }
                                else break;                                 // We got permission to trample over
                            }
                        }
                    for (i = 0; i < spectra; i++)                           // If we are here we do not care about overwriting 
                    {
                        string name = GetJcampName(i);
                        if (name != "")
                        {
                            SSG[i].Curves[0].GetData(ref X, ref Y, false, false);
                            comment = SSG[i].Curves[0].DXmakeHeader(name, "Frame: " + i + " of Thormotor Rasterscan", false, false);
                            comment.Add("##$Hfrom= " + txHfrom.Text);
                            comment.Add("##$Hto= " + txHto.Text);
                            comment.Add("##$Hstep= " + txHstep.Text);
                            comment.Add("##$Vfrom= " + txVfrom.Text);
                            comment.Add("##$Vto= " + txVto.Text);
                            comment.Add("##$Vstep= " + txVstep.Text);
                            Jcampdx.Write(name, X, Y, comment);
                        }
                    }
                    if (sender == null) Report("Saved " + spectra + " frames into folder: " + folder);
                }
                else                                                        // We write spectrasolve format file here
                {   
                    if (txExperiment.Text != "" && txExperiment.Text.IndexOfAny(iv) >= 0)
                    {
                        Report("Invalid characters in the experiment name (becomes a part of the file name)"); return;
                    }
                    string fname = txExperiment.Text;
                    if (fname != "" && tod != "") fname += " ";
                    fname += tod;
                    fname = txFolder.Text + "\\" + fname + ".spc";
                    if (File.Exists(fname) && !cbOverWrite.Checked)
                    {
                        if (MessageBox.Show("File exists, please press OK to append anyway.", "Append warning", MessageBoxButtons.OKCancel) != DialogResult.OK)
                        { Report("Change the experiment name"); return; }
                    }
                    for (i = 0; i < spectra; i++) if (SSG[i].Curves.Count > 0)
                        {
                            SSG[i].Curves[0].GetData(ref X, ref Y, false, false);
                            SSpec S = new SSpec(ref Y, ref X, X.Length);
                            S.comment = SSG[i].Text;
                            if (i == 0)                                     // The first curve's comment in SpectraSolve file contains origin info, between three '@' for later separation;
                            {                                               //  WSpec concatenates additional comments, so we need the ending @
                                S.comment += "@H:" + txHfrom.Text + ";" + txHto.Text + ";" + txHstep.Text + "@V:" + txVfrom.Text + ";" + txVto.Text + ";" + txVstep.Text + "@";
                            }
                            SSolve.Append(fname, ref S);
                        }
                    if (sender == null) Report("Saved " + spectra + " frames into: " + fname);

                }
            }
            catch (Exception ee)
            {
                ReportException("bnSaveExperiment_Click", ee);
            }
        }
        #endregion
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="motor"></param>
        /// <param name="step"></param>
        /// <param name="dir"></param>
        #region Various Button Clicks
        private void MoveMotor(int motor, int step, int dir) 
        {
            string[] Whm = {"Horizontal", "Vertical", "Diagonal", "Unknown" };
            motor &= 3;
            double cpos = 0, npos;
            if (emulate)
            {
                if (motor == 0) double.TryParse(txHposition.Text, out cpos);
                else if (motor == 1) double.TryParse(txVposition.Text, out cpos);
                else double.TryParse(txDposition.Text, out cpos);
            }
            else Th.GetCurPos(ref cpos, motor);
            npos = (dir == 1) ? cpos - step : cpos + step;
            MoveWithBackLash(npos, motor, 0);                        // No backlash here
            if (emulate)
                rxView.AppendText(Whm[motor] + " motor moved " + (dir == 0 ? "in by " : "out by ") + step + " steps\n");
            else
            {
                Th.MoveRelative(-step, motor, true);                        // If I remember correctly in-move increased encoder numbers !?!
            }
        }
        private void MoveWithBackLash(double pos, int motor, double backlash)
        {
            double cpos = 0;
            if (emulate)
            {
                if (motor == 0) txHposition.Text = pos.ToString("N0");
                else if (motor == 1) txVposition.Text = pos.ToString("N0");
                else txDposition.Text = pos.ToString("N0");
                return;                                                     // We are there
            }
            else Th.GetCurPos(ref cpos, motor);
            bool bl = (pos < cpos && backlash > 0) || (pos > cpos && backlash < 0); 
            if (bl) pos -= backlash;                                        // If true we need to run out backlash
            Th.GotoNewPos(pos, motor, true);
            Th.WaitonMotor(motor);
            if (bl)
            {
                Th.GotoNewPos(pos, motor, true);
                Th.WaitonMotor(motor);
            }
            Th.GetCurPos(ref cpos, motor);
        }
        private void bnRasterScan_Click(object sender, EventArgs e) // clicking on Rasterscan Button
        {
            double backlash = 200, vbl, hbl;
            Parse();
            vbl = vfrom < vto ? backlash : -backlash;
            hbl = hfrom < hto ? backlash : -backlash;
            CreateDump(true);
            UpdateDump();
            string title = cbHfast.Checked ? "R-Scan(H-fast), V = " : "R-Scan(V-fast), H = ";
            Bkg.Set(Th, cbHfast.Checked, emulate, samplingtime, title);
            if (cbHfast.Checked)
            {
                Bkg.SetFast(hfrom, hstep, hbl, hpoints, 0);
                Bkg.SetSlow(vfrom, vstep, vbl, vpoints, 1);
            }
            else
            {
                Bkg.SetFast(vfrom, vstep, vbl, vpoints, 1);
                Bkg.SetSlow(hfrom, hstep, hbl, hpoints, 0);
            }

            Working = true;
            timer1.Tag = "Update";
            timer1_Tick(null, null);                                        // Udate and Create Dumpview

            if (!bkgWorker.IsBusy) 
                bkgWorker.RunWorkerAsync(Bkg);
        }
        private void bnStop_Click(object sender, EventArgs e)
        {
            Th.Stop();
            if (Working) bkgWorker.CancelAsync();
        }
        private void bnPark_Click(object sender, EventArgs e)
        {
            Th.ParkAll(); //NB - this parks all motors - need to decouple from the spectrometer
        }
        private void bnMotorUpDown_Click(object sender, EventArgs e)
        {
            int step, motor, dir;
            Button bn = sender as Button;
            if (bn == null) return;
            if (bn.Name.Contains("H")) motor = 0;
            else if (bn.Name.Contains("V")) motor = 1;
            else motor = 2;
            dir = bn.Name.Contains("u") ? 1 : 0;
            if (motor == 0)
            {
                if (rbH10.Checked) step = 10;
                else if (rbH100.Checked) step = 100;
                else if (rbH10000.Checked) step = 10000;
                else step = 1000;
            }
            else if (motor == 1)
            {
                if (rbV10.Checked) step = 10;
                else if (rbV100.Checked) step = 100;
                else if (rbV10000.Checked) step = 10000;
                else step = 1000;
            }
            else
            {
                if (rbD10.Checked) step = 10;
                else if (rbD100.Checked) step = 100;
                else if (rbD10000.Checked) step = 10000;
                else step = 1000;
            }
            MoveMotor(motor, step, dir);
        }
        private void bnSet_Click(object sender, EventArgs e)
        {
            int motor;
            double npos = 0, cpos = 0;
            Button bn = sender as Button;
            if (bn == null) return;
            if (bn.Name.Contains("H"))
            {
                motor = 0;
                if (emulate) txHposition.Text = txHsetpos.Text;
                else
                {
                    Th.GetCurPos(ref cpos, 0); //last argument is axis
                    if (!double.TryParse(txHsetpos.Text, out npos)) npos = cpos;
                }
            }
            else if (bn.Name.Contains("V"))
            {
                motor = 1;
                if (emulate) txVposition.Text = txVsetpos.Text;
                else
                {
                    Th.GetCurPos(ref cpos, 1);
                    if (!double.TryParse(txVsetpos.Text, out npos)) npos = cpos;
                }
            }
            else
            {
                motor = 2;
                if (emulate) txDposition.Text = txDsetpos.Text;
                else
                {
                    Th.GetCurPos(ref cpos, 2);
                    if (!double.TryParse(txDsetpos.Text, out npos)) npos = cpos;
                }
            }
            if (!emulate) Th.SetCurPos(npos, motor);
        }
        private void bnGoto_Click(object sender, EventArgs e)
        {
            int motor;
            double npos = 0, cpos = 0;
            Button bn = sender as Button;
            if (bn == null) return;
            if (bn.Name.Contains("H"))
            {
                motor = 0;
                if (emulate) txHposition.Text = txHgotopos.Text;
                else
                {
                    Th.GetCurPos(ref cpos, 0);
                    if (!double.TryParse(txHgotopos.Text, out npos)) npos = cpos;
                }
            }
            else if (bn.Name.Contains("V"))
            {
                motor = 1;
                if (emulate) txVposition.Text = txVgotopos.Text;
                else
                {
                    Th.GetCurPos(ref cpos, 1);
                    if (!double.TryParse(txVgotopos.Text, out npos)) npos = cpos;
                }
            }
            else
            {
                motor = 2;
                if (emulate) txDposition.Text = txDgotopos.Text;
                else
                {
                    Th.GetCurPos(ref cpos, 2);
                    if (!double.TryParse(txDgotopos.Text, out npos)) npos = cpos;
                }
            }
            if (!emulate) Th.GotoNewPos(npos, motor, false);
        }
        private void bnSetupAxis_Click(object sender, EventArgs e)
        {
            int motor = 0;
            if (emulate)
            {
                rxView.AppendText("No Thormotors to setup.\n");
                return;
            }
            Button bn = sender as Button;
            if (bn == null) return;
            if (bn.Name.Contains("H"))
            {
                motor = 0;
            }
            else if (bn.Name.Contains("V"))
            {
                motor = 1;
            }
            Th.SetupAxis(this.Handle, motor);

        }
        private void SSG_Click(object sender, EventArgs e)                  // Mouse click on dump view 
        {
            if (!Working)
            {
                DGraph ssg = sender as DGraph;
                if (ssg != null && ssg.Curves.Count > 0)
                {
                    int i;
                    sgMain.Kill();
                    sgMain.Attach(ssg.Curves[0]);
                    sgMain.Invalidate();
                    lbSpectrum.Text = ssg.Curves[0].title;
                    for (i = 0; i < SSG.Length; i++) SSG[i].BackColor = Color.FromArgb(0xff, 0xfa, 0xff, 0xff);
                    ssg.BackColor = Color.FromArgb(0xff, 0xe0, 0xf0, 0xff);
                    for (i = 0; i < SSG.Length; i++) SSG[i].Invalidate();
                }
                else lbSpectrum.Text = "No data";
            }
        }
        private void bnDXoptions_Click(object sender, EventArgs e)
        {
            JcampDXoptions JO = new JcampDXoptions();
            JO.ShowDialog();
        }
        #endregion
        #region Raster Scan that works in the background
        public class BKG                                                    // Raster-scan class that is not modified by GUI while motors work in the background  
        {
            public double fastfrom, faststep, slowfrom, slowstep, slowbl, fastbl;
            public int fastmotor, slowmotor, fastpoints, slowpoints;
            public bool hfast;
            public string title, lbtitle;
            public double slowlocation, fastlocation;
            public double ypoint, samplingtime;
            public int loading, point;
            bool emulate;
            Thor Th;
            //
            public void Set(Thor th, bool horzisfast, bool emul, double stime, string tit)
            {
                Th = th;
                hfast = horzisfast;
                emulate = emul;
                title = tit;
                samplingtime = stime;
            }
            public void SetFast(double from, double step, double backlash, int points, int motor)
            {
                fastfrom = from;
                faststep = step;
                fastpoints = points;
                fastbl = backlash;
                fastmotor = motor;
            }
            public void SetSlow(double from, double step, double backlash, int points, int motor)
            {
                slowfrom = from;
                slowstep = step;
                slowpoints = points;
                slowbl = backlash;
                slowmotor = motor;
            }
            public void MoveWithBackLash(BackgroundWorker bw, bool slow) 
            {
                double cpos = 0;
                if (slow)  bw.ReportProgress(102);
                else bw.ReportProgress(103);
                if (emulate) return;                                            // We are there
                int motor = slow ? slowmotor : fastmotor;
                double backlash = slow ? slowbl : fastbl;
                double pos = slow ? slowlocation : fastlocation;
                Th.GetCurPos(ref cpos, motor);
                bool bl = (pos < cpos && backlash > 0) || (pos > cpos && backlash < 0);
                if (bl) pos -= backlash;                                        // If true we need to run out backlash
                Th.GotoNewPos(pos, motor, true);
                Th.WaitonMotor(motor);
                if (bl)
                {
                    Th.GotoNewPos(pos, motor, true);
                    Th.WaitonMotor(motor);
                }
                Th.GetCurPos(ref cpos, motor);
            }
        }
        private void bkgWorker_DoWork(object sender, DoWorkEventArgs e)     // We need this for cancellation; nothing called from this subroutine can access the Form1 controls directly 
        {
            int i, j, k;
            BackgroundWorker bw = sender as BackgroundWorker;
            BKG bk = e.Argument as BKG;
            if (bk == null || bw == null) return;
            Working = true;                                                 // This way we can check that BKG part is working and busy
            //
            timer1_Tick(null, null);
            double[] X = new double[bk.fastpoints];
            double[] Y = new double[bk.fastpoints];
            if (bk.samplingtime < 1) bk.samplingtime = 1;                   
            if (bk.samplingtime < 50) k = (int)(50 / bk.samplingtime);      // avoid furious updates more frequent than 50 ms
            else k = 1;
            for (i = 0; i < bk.fastpoints; i++) X[i] = i * bk.faststep;
            for (j = 0; j < bk.slowpoints; j++)
            {
                bk.loading = j;
                bk.slowlocation = bk.slowfrom + j * bk.slowstep;
                bk.MoveWithBackLash(bw, true);
                if (SSG[j].Curves.Count == 0 || SSG[j].Curves[0].dy != null || SSG[j].Curves[0].dy.Length != bk.fastpoints)
                {
                    SSG[j].Kill();
                    for (i = 0; i < bk.fastpoints; i++) Y[i] = 0;
                    Curve gc = new Curve();
                    gc.Attach(Y, X);
                    SSG[j].Attach(gc);
                }
                SSG[j].Curves[0].title = bk.lbtitle = bk.title + bk.slowlocation.ToString("N0");
                bw.ReportProgress(101);
                for (i = 0; i < bk.fastpoints; i++)
                {
                    bk.point = i;
                    if (bw.CancellationPending)                             // GUI sets this event up when Stop button is pressed
                    {
                        e.Cancel = true;
                        Working = false;
                        return;                                             // BKG thread finishes
                    }
                    bk.fastlocation = bk.fastfrom + i * bk.faststep;
                    bk.MoveWithBackLash(bw, false);
                    SSG[j].Curves[0].dy[i] = bk.ypoint = Collect(samplingtime);
                    if (k < 2 || (i % k) == 0) 
                        bw.ReportProgress(104);                             // Report new datapoint(s) in loaded curve
                }
                SSG[j].NormX();
                bw.ReportProgress(1000 + j);                                // Report that another curve j is finished
            }
            Working = false;
        }
        private void bkgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {                                                                   // This works in foreground and thus can access form controls
            switch (e.ProgressPercentage)
            {
                default: break;
                case 101:                                                   // Show curve title that is to start loading
                    lbStatus.Text = Bkg.lbtitle;
                    if (SSG.Length > Bkg.loading && SSG[0].Curves.Count > 0)
                    {
                        if (sgMain.Curves.Count < 1) sgMain.Attach(SSG[Bkg.loading].Curves[0]);
                        else sgMain.Curves[0] = SSG[Bkg.loading].Curves[0];
                        sgMain.Invalidate();
                    }
                    break;
                case 102:                                                   // Slow motor progressed
                    if (Bkg.hfast) txVposition.Text = Bkg.slowlocation.ToString("N0");
                    else txHposition.Text = Bkg.slowlocation.ToString("N0");
                    break;
                case 103:                                                   // Slow motor progressed
                    if (Bkg.hfast) txHposition.Text = Bkg.fastlocation.ToString("N0");
                    else txVposition.Text = Bkg.fastlocation.ToString("N0");
                    break;
                case 104:                                                   // Data point was received
                    sgMain.Invalidate();
                    break;
            }
            if (e.ProgressPercentage > 999)                                 // Curve j is finished -> event 1000+j was sent
            {
                int j = e.ProgressPercentage - 1000;
                if (j >= 0 && j < SSG.Length && SSG.Length > 0)
                {
                    if (cbAutonorm.Checked) SSG[j].NormY();
                    SSG[j].Invalidate();
                }
            }
        }
        private void bkgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {                                                                   // This works in foreground - can access forms
            Working = false;
            lbStatus.Text = "Status: Rasterscan " + (e.Cancelled ? "aborted" : "finished");
            timer1.Tag = "Fade";
            timer1.Interval = 5000;                                         // Clear finish message in 5 seconds
            timer1.Start();
        }
        #endregion
        #region Aboutbox in SysMenu
        internal class NativeMethods                                        // By M$ suggestions, all native methods need to be inserted into NativeMethods, SafeNativeMethods wrapper classes
        {
            [DllImport("user32.dll")]
            public static extern IntPtr GetSystemMenu(int hwnd, int bRevert);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern int AppendMenu(IntPtr hMenu, int Flagsw, UIntPtr IDNewItem, string lpNewItem);
        }
        private void SetupSystemMenu()
        {
            IntPtr menu = NativeMethods.GetSystemMenu(Handle.ToInt32(), 0);                     // get handle to system menu
            NativeMethods.AppendMenu(menu, 0xA00, (UIntPtr)0, null);                            // add a separator
            NativeMethods.AppendMenu(menu, 0, (UIntPtr)28838, "About " + Application.ProductName);     // add an item with a unique ID
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x112)                                                 // WM_SYSCOMMAND is 0x112
            {
                if (m.WParam.ToInt32() == 28838)
                {
                    Form2 af = new Form2();
                    af.ShowDialog();
                }
            }
        }
        #endregion
        public class Thor                                                   // ThorMotor card related class
        {
            public class ThorAxis                                           // Individual Thormotor related subroutines  
            {
                #region Axis data
                IntPtr fex = IntPtr.Zero;
                public MCAXISCONFIG ACF = new MCAXISCONFIG();	                
                public MCFILTEREX FLT = new MCFILTEREX();
                public MCMOTIONEX MTE = new MCMOTIONEX();
                public MCMOTIONEX tMTE = new MCMOTIONEX();                  // 
                public int SweepFrom, SweepTo, SweepStep, SetPos;
                public string lasterror;
                public double CurPos;
                public short index;                                         // motor + 1   if we have initialized this axis, -1 otherwise
                //
                #endregion
                #region Axis related subroutines
                public ThorAxis() //setup of parameters relared to axis
                {
                    CurPos = 0;
                    SetPos = 0;
                    SweepFrom = 120000;
                    SweepTo = 121000;
                    SweepStep = 100;
                    fex = IntPtr.Zero;
                    lasterror = "";
                    index = -1;
                }
                public bool ObtainInfo(int i)
                {
                    int res;
                    string st = "";
                    index = -1;                                             // Axis is invalid
                    if (Mcb == 0) return false;		                        // No cards or no motors
                    //
                    FLT.cbSize = Marshal.SizeOf(FLT);
                    fex = Marshal.AllocHGlobal(FLT.cbSize);
                    res = MCGetFilterConfigEx(Mcb, (short)(i + 1), fex);	// NB! The use of axis=0 means AllAxes, which is invalid for structure fetch	
                    if (res != 0)		    						        // If we fail we cannot park etc.								            	
                    {
                        GetError(res, ref st); 
                        thormotor_lasterror = "MCGetFilterConfig: " + st;
                        Marshal.FreeHGlobal(fex);
                        return false;
                    }
                    Marshal.PtrToStructure(fex, FLT);
                    Marshal.FreeHGlobal(fex);
                    //
                    MTE.cbSize = Marshal.SizeOf(MTE);
                    fex = Marshal.AllocHGlobal(MTE.cbSize);
                    res = MCGetMotionConfigEx(Mcb, (short)(i + 1), fex);
                    if (res != 0)
                    {
                        GetError(res, ref st); 
                        thormotor_lasterror = "MCGetMotionConfigEx: " + st;
                        Marshal.FreeHGlobal(fex);
                        return false;
                    }
                    Marshal.PtrToStructure(fex, MTE);
                    Marshal.FreeHGlobal(fex);
                    //
                    ACF.cbSize = Marshal.SizeOf(ACF);
                    fex = Marshal.AllocHGlobal(ACF.cbSize);
                    res = MCGetAxisConfiguration(Mcb, (short)(i + 1), fex);
                    if (res != 0)
                    {
                        GetError(res, ref st); 
                        thormotor_lasterror = "MCGetAxisConfig: " + st;
                        Marshal.FreeHGlobal(fex);
                        return false;
                    }
                    Marshal.PtrToStructure(fex, ACF);
                    Marshal.FreeHGlobal(fex);
                    index = (short)(i + 1);                                 // This axis is a valid axis
                    return true;
                }
                public bool GetCurPos(ref double pos)
                {
                    int res;
                    string st = "";
                    if (index < 0) return false;		                    // No cards or no motors
                    res = MCGetPositionEx(Mcb, index, ref pos);	            // Reports error number or 0 for success
                    if (res != 0)
                    {
                        GetError(res, ref st);
                        thormotor_lasterror = "MCGetPositionEx: " + st;
                        return false;
                    }
                    else CurPos = pos;				                        // Stores found position in ThorMotor and in pos
                    return true;
                }
                public bool SetCurPos(double pos)	                        // Fix a value to the current position of motor  
                {
                    if (Mcb == 0 || index < 1) return false;			    // No cards or no motors
                    MCSetPosition(Mcb, index, pos);
                    CurPos = pos;
                    return true;
                }
                public bool MoveRelative(double amount, bool usetmo) 
                {
                    int res;
                    double v, a, timo;
                    if (Mcb == 0 || index < 0) return false;
                    a = MTE.Acceleration; if (a < 10 || a > 1e9) a = 5e6;
                    v = MTE.Velocity; if (v < 10 || v > 1e9) v = 1e4;
                    if (usetmo) timo = Math.Abs(amount / v) + 2 * Math.Sqrt(Math.Abs(amount / a)) + .5;
                    else timo = 0;
                    MCEnableAxis(Mcb, index, true);
                    MCMoveRelative(Mcb, index, amount);
                    res = MCIsStopped(Mcb, index, timo);
                    if (usetmo) MCEnableAxis(Mcb, index, false);
                    return true;
                }
                public bool IsMoving()				                        // Check with no wait is this motor moving 
                {
                    if (Mcb == 0 || index < 1) return false;
                    return MCIsStopped(Mcb, index, (double)0) == 0;             // If IsStopped is false - motor is moving 
                }
                public bool WaittoStop()
                {
                    while (true)
                        if (Break || MCIsStopped(Mcb, index, 0.1) != 0) 
                            return true;                                        // Wait with a 0.1 s timeout for motor to be stopped 
                }
                //
                public bool Reconf()                                        // Reconfigure motors to set velocity to max and enable hardware limits
                {												                // Returns true if Get/SetMotionConfig's succeeded
                    int res = 0;
                    string st = "";
                    double v, a;
                    IntPtr fex;
                    if (Mcb == 0 || index < 1) return false;
                    MTE.cbSize = Marshal.SizeOf(MTE);
                    fex = Marshal.AllocHGlobal(MTE.cbSize);
                    res = MCGetMotionConfigEx(Mcb, index, fex);
                    if (res != 0)
                    {
                        GetError(res, ref st); 
                        thormotor_lasterror = "MCGetMotionConfigEx: " + st;
                        Marshal.FreeHGlobal(fex);
                        return false;
                    }
                    Marshal.PtrToStructure(fex, MTE);                           // MTE contains old values, tMTE has superfast values
                    Marshal.PtrToStructure(fex, tMTE);
                    tMTE.SoftLimitMode = 0;
                    tMTE.HardLimitMode = MC_LIMIT_MINUS | MC_LIMIT_PLUS | MC_LIMIT_ABRUPT;
                    a = tMTE.Acceleration;
                    v = tMTE.Velocity;
                    if (a < 10 || a > 1e7) a = 5e7;
                    if (v < 10 || v > 1e5) v = 1e4;
                    Marshal.StructureToPtr(tMTE, fex, true);
                    res = MCSetMotionConfigEx(Mcb, index, fex);	    // If res>0 we cannot get old values back
                    Marshal.FreeHGlobal(fex);
                    if (res != 0)
                    {
                        GetError(res, ref st); thormotor_lasterror = "MCSetMotionConfigEx: " + st;
                        Marshal.FreeHGlobal(fex);
                    }
                    return res == 0;
                }
                public bool Backconf()                                      // Substitute old configurations back 
                {												// 
                    if (Mcb == 0 || index < 0) return false;
                    MTE.cbSize = Marshal.SizeOf(MTE);
                    fex = Marshal.AllocHGlobal(MTE.cbSize);
                    Marshal.StructureToPtr(MTE, fex, true);
                    int res = MCSetMotionConfigEx(Mcb, index, fex);
                    Marshal.FreeHGlobal(fex);
                    if (res != 0)
                    {
                        string st = "";
                        GetError(res, ref st); 
                        thormotor_lasterror = "MCGetMotionConfigEx: " + st;
                    }
                    return res == 0;
                }
                #endregion
            } // end of Thor axis Class
            #region Thor Motor data & ctors
            private static short Mcb = 0;                                   // Board handle
            public static string thormotor_lasterror = "";
            public int Motors = 0;                                          // Total actual number of motors
            public ThorAxis[] Th;                                           // Each axis is a class
            public MCPARAMEX MCP = new MCPARAMEX();
            //
            public Thor() 
            {
                Th = new ThorAxis[8]; //set of 8 axis?
                for (int i = 0; i < 8; i++) Th[i] = new ThorAxis();             // Create motor/axis classes
                CreateThor();
            }
            ~Thor() 
            {
                CloseThor();
            }
            #endregion
            #region ThorMotor native calls interface
            const ushort MC_OPEN_ASCII = 1;
            const ushort MC_OPEN_BINARY = 2;
            const ushort MC_OPEN_EXCLUSIVE = 0x8000;
            const short MC_ALL_AXES = 0;
            const int MC_LIMIT_ABRUPT = 4;
            const int MC_LIMIT_BOTH = 3;
            const int MC_LIMIT_INVERT = 0x0080;
            const int MC_LIMIT_MINUS = 2;
            const int MC_LIMIT_OFF = 0;
            const int MC_LIMIT_PLUS = 1;
            const int MC_LIMIT_SMOOTH = 8;
            const int MC_LIMIT_HIGH = MC_LIMIT_PLUS;                        // use MC_LIMIT_PLUS in new code
            const int MC_LIMIT_LOW = MC_LIMIT_MINUS;                        // use MC_LIMIT_MINUS in new code
            const int MCDLG_PROMPT        =  0x0001;                        // save / restore
            const int MCDLG_NOMOTION      =  0x0002;                        // save / restore / configure
            const int MCDLG_NOFILTER      =  0x0004;                        // save / restore / configure
            const int MCDLG_NOPHASE       =  0x0008;                        // save / restore
            const int MCDLG_NOPOSITION    =  0x0010;                        // save / restore / configure
            const int MCDLG_NOSCALE       =  0x0020;                        // save / restore
            const int MCDLG_NOHARDLIMITS  =  0x0040;                        // configure
            const int MCDLG_NOSOFTLIMITS  =  0x0080;                        // configure
            const int MCDLG_NORATES       =  0x0100;                        // configure
            const int MCDLG_NOPROFILES    =  0x0200;                        // save / restore / configure
            const int MCDLG_NOMISC        =  0x0400;                        // configure
            const int MCDLG_CHECKACTIVE   =  0x0800;                        // configure / restore
            [StructLayout(LayoutKind.Sequential)]
            public class MCPARAMEX
            {
                public Int32 cbSize;
                public Int32 ID;
                public Int32 ControllerType;
                public Int32 NumberAxes;
                public Int32 MaximumAxes;
                public Int32 MaximumModules;
                public Int32 Precision;
                public Int32 DigitalIO;
                public Int32 AnalogInput;
                public Int32 AnalogOutput;
                public Int32 PointStorage;
                public Int32 CanDoScaling;
                public Int32 CanDoContouring;
                public Int32 CanChangeProfile;
                public Int32 CanChangeRates;
                public Int32 SoftLimits;
                public Int32 MultiTasking;
                public Int32 AmpFault;
                public double AnalogInpMin;			                        // added v3.4, motherboard analog inp min voltage	
                public double AnalogInpMax;			                        // added v3.4, motherboard analog inp max voltage	
                public Int32 AnalogInpRes;			                        // added v3.4, motherboard analog inp resolution (bits)
                public double AnalogOutMin;			                        // added v3.4, motherboard analog out min voltage	
                public double AnalogOutMax;			                        // added v3.4, motherboard analog out max voltage	
                public Int32 AnalogOutRes;			                        // added v3.4, motherboard analog out resolution (bits)
            }
            [StructLayout(LayoutKind.Sequential)]
            public class MCMOTIONEX
            {
                public Int32 cbSize;
                public double Acceleration;
                public double Deceleration;
                public double Velocity;
                public double MinVelocity;
                public Int32 Direction;
                public double Torque;
                public double Deadband;
                public double DeadbandDelay;
                public Int32 StepSize;
                public Int32 Current;
                public Int32 HardLimitMode;
                public Int32 SoftLimitMode;
                public double SoftLimitLow;
                public double SoftLimitHigh;
                public Int32 EnableAmpFault;
            }
            [StructLayout(LayoutKind.Sequential)]
            public class MCFILTEREX
            {
                public Int32 cbSize;
                public double Gain;
                public double IntegralGain;
                public double IntegrationLimit;
                public Int32 IntegralOption;
                public double DerivativeGain;
                public double DerSamplePeriod;
                public double FollowingError;
                public double VelocityGain;
                public double AccelGain;
                public double DecelGain;
                public double EncoderScaling;
                public Int32 UpdateRate;
            }
            [StructLayout(LayoutKind.Sequential)]
            public class MCAXISCONFIG
            {
                public Int32 cbSize;
                public Int32 ModuleType;
                public Int32 ModuleLocation;
                public Int32 MotorType;
                public Int32 CaptureModes;
                public Int32 CapturePoints;
                public Int32 CaptureAndCompare;
                public double HighRate;
                public double MediumRate;
                public double LowRate;
                public double HighStepMin;
                public double HighStepMax;
                public double MediumStepMin;
                public double MediumStepMax;
                public double LowStepMin;
                public double LowStepMax;
                public Int32 AuxEncoder;			// added v3.4, axis has auxiliary encoder input
            }
            const string ThorDriverName = "MCapi32.dll";
            [DllImport(ThorDriverName, EntryPoint = "MCTranslateErrorEx", CharSet = CharSet.Ansi)] //, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true
            public static extern Int32 MCTranslateErrorEx(Int32 err, IntPtr str, Int32 strlen);
            [DllImport(ThorDriverName, EntryPoint = "MCGetFilterConfigEx", CharSet = CharSet.Ansi)] //, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true
            public static extern Int32 MCGetFilterConfigEx(short board, short axis, IntPtr filterex);
            [DllImport(ThorDriverName, EntryPoint = "MCGetMotionConfigEx", CharSet = CharSet.Ansi)] //, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true
            public static extern Int32 MCGetMotionConfigEx(short board, short axis, IntPtr motionex);
            [DllImport(ThorDriverName, EntryPoint = "MCSetMotionConfigEx", CharSet = CharSet.Ansi)] //, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true
            public static extern Int32 MCSetMotionConfigEx(short board, short axis, IntPtr motionex);
            [DllImport(ThorDriverName, EntryPoint = "MCGetAxisConfiguration", CharSet = CharSet.Ansi)] //, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true
            public static extern Int32 MCGetAxisConfiguration(short board, short axis, IntPtr motionex);
            [DllImport(ThorDriverName, EntryPoint = "MCGetConfigurationEx", CharSet = CharSet.Ansi)] //, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true
            public static extern Int32 MCGetConfigurationEx(short board, IntPtr configex);
            //[DllImport(ThorDriverName, EntryPoint = "MCOpen", CharSet = CharSet.Ansi)]          //, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true
            [DllImport(ThorDriverName, EntryPoint = "MCOpen", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall, ExactSpelling = false)]
            public static extern short MCOpen(short nID, ushort mode, IntPtr lpszName);
            [DllImport(ThorDriverName, EntryPoint = "MCClose", CharSet = CharSet.Ansi)]         //, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true
            public static extern Int32 MCClose(short board);
            [DllImport(ThorDriverName, EntryPoint = "MCGetPositionEx", CharSet = CharSet.Ansi)] //, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true
            public static extern Int32 MCGetPositionEx(short board, short axis, ref double pos);
            [DllImport(ThorDriverName, EntryPoint = "MCSetPosition", CharSet = CharSet.Ansi)] //, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true
            public static extern void MCSetPosition(short board, short axis, double pos);
            [DllImport(ThorDriverName, EntryPoint = "MCEnableAxis", CharSet = CharSet.Ansi)] //, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true
            public static extern void MCEnableAxis(short board, short axis, bool state);
            [DllImport(ThorDriverName, EntryPoint = "MCMoveRelative", CharSet = CharSet.Ansi)] //, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true
            public static extern void MCMoveRelative(short board, short axis, double amount);
            [DllImport(ThorDriverName, EntryPoint = "MCIsStopped", CharSet = CharSet.Ansi)] //, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true
            public static extern Int32 MCIsStopped(short board, short axis, double tmo);
            //
            [DllImport("MCdlg32.dll", EntryPoint = "MCDLG_RestoreAxis", CharSet = CharSet.Ansi)] //, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true
            public static extern Int32 MCDLG_RestoreAxis(Int32 board, short axis, Int32 flags, IntPtr PrivateIniFile);
            [DllImport("MCdlg32.dll", EntryPoint = "MCDLG_SaveAxis", CharSet = CharSet.Ansi)] //, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true
            public static extern Int32 MCDLG_SaveAxis(Int32 board, short axis, Int32 flags, IntPtr PrivateIniFile);
            [DllImport("MCdlg32.dll", EntryPoint = "MCDLG_ConfigureAxis", CharSet = CharSet.Ansi)] //, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true
            public static extern Int32 MCDLG_ConfigureAxis(IntPtr hWnd, Int32 board, short axis, Int32 flags, IntPtr szTitle);
            #endregion
            #region ThorMotor motion subroutines
            public static bool GetError(int err, ref string s)
            {
                IntPtr st = Marshal.AllocHGlobal(128);
                MCTranslateErrorEx(err, st, 128);
                s = Marshal.PtrToStringAnsi(st);
                Marshal.FreeHGlobal(st);
                return true;
            }
            public bool CreateThor()
            {
                int res, i, size;
                string st = "";
                IntPtr name = IntPtr.Zero;
                try
                {
                    //Mcb = MCOpen((short)0, MC_OPEN_BINARY | MC_OPEN_EXCLUSIVE, null);	// Try to access the card via its driver	
                    Mcb=MCOpen(0, MC_OPEN_BINARY | MC_OPEN_EXCLUSIVE, name);
                    //Mcb = Mcb;
                }
                catch (Exception ee)
                {
                    thormotor_lasterror = "Thor.CreateThor: " + ee.Message;     // Dll not found most probably
                    Motors = 0;
                    Mcb = -1;
                    return false;
                }

                if (Mcb < 0)
                {
                    Motors = 0;
                    Mcb = -1;
                    thormotor_lasterror = "Thor.CreateThor.MCOpen: could not open ThorMotor board";
                    return false;
                }
                MCP.cbSize = size = Marshal.SizeOf(MCP);
                IntPtr mcp = Marshal.AllocHGlobal(size);
                res = MCGetConfigurationEx(Mcb, mcp);					        // Get Card configuration
                if (res != 0)
                {
                    GetError(res, ref st); thormotor_lasterror = "Thor.CreateThor.MCGetConfigurationEx: " + st;
                    Marshal.FreeHGlobal(mcp);
                    return false;
                }
                Marshal.PtrToStructure(mcp, MCP);
                Motors = MCP.NumberAxes;								        // Motors is valid for all runtime
                string FileName = "Thor_save.ini";                              // Read configuration in from specified file if found & applicability verified
                if (File.Exists(FileName))
                {
                    IntPtr fname = Marshal.AllocHGlobal(FileName.Length + 1);
                    fname = Marshal.StringToHGlobalAnsi("Thor_save.ini");
                    res = MCDLG_RestoreAxis(Mcb, MC_ALL_AXES, 0, fname);
                    if (res != 0)
                    {
                        GetError(res, ref st); thormotor_lasterror = "Thor.CreateThor.MCDLG_RestoreAxis: " + st;
                        Marshal.FreeHGlobal(fname);
                        return false;
                    }
                    Marshal.FreeHGlobal(fname);
                }
                for (i = 0; i < Motors; i++)								    // Read in filter data, acc vel, pid
                    if (!Th[i].ObtainInfo(i)) return false;
                return true;
            }
            public bool CloseThor()
            {
                int res = 0;
                string st = "";
                if (Mcb > 0)
                {
                    string FileName = "Thor_save.ini";
                    IntPtr fname = Marshal.AllocHGlobal(FileName.Length + 1);
                    fname = Marshal.StringToHGlobalAnsi("Thor_save.ini");
                    res = MCDLG_SaveAxis(Mcb, MC_ALL_AXES, 0, fname);
                    if (res != 0)
                    {
                        GetError(res, ref st); thormotor_lasterror = "MCDLG_SaveAxis: " + st;
                        Marshal.FreeHGlobal(fname);
                        return false;
                    }
                    Marshal.FreeHGlobal(fname);
                    res = MCClose(Mcb);
                    if (res != 0)
                    {
                        GetError(res, ref st); thormotor_lasterror = "MCClose: " + st;
                        return false;
                    }
                    Mcb = 0;
                }
                return true;
            }
            public bool GetCurPos(ref double pos, int motor)
            {
                if (Mcb == 0 || Motors < 1) return false;                   // No card or no motors
                if (motor < -1 || motor >= Motors) motor = -1;
                if (motor == -1)
                {
                    for (int i = 0; i < Motors; i++)					    // Do for all motors
                        if (!Th[i].GetCurPos(ref pos)) return false;
                    return true;
                }
                return Th[motor].GetCurPos(ref pos);
            }
            public bool SetCurPos(double pos, int motor)	                // Set the current position of a motor to a value  
            {
                if (Mcb == 0 || Motors < 1) return false;			        // No cards or no motors
                if (motor < -1 || motor >= Motors) motor = -1;	            // Motor -1 -> Set position for all motors
                if (motor == -1)
                {
                    for (int i = 0; i < Motors; i++)					    // Do for all motors
                        if (!Th[i].SetCurPos(pos)) return false;
                    return true;
                }
                return Th[motor].SetCurPos(pos);
            }
            public bool GotoNewPos(double newpos, int motor, bool usetmo)
            {
                double d = 0;
                if (motor < 0 || motor >= Motors) return false;
                if (!GetCurPos(ref d, motor)) return false;
                return Th[motor].MoveRelative(newpos - d, usetmo);
            }
            public bool MoveRelative(double amount, int motor, bool usetmo)
            {
                if (Mcb == 0 || Motors < 1 || motor < 1 || motor >= Motors) return false;
                return Th[motor].MoveRelative(amount, usetmo);
            }
            public bool Stop()								                // Unconditional off to all motors
            {
                if (Mcb == 0 || Motors < 1) return false;
                MCEnableAxis(Mcb, MC_ALL_AXES, false);
                return true;
            }
            public bool IsMoving(int motor)				                    // Check with no wait is this motor moving
            {
                if (Mcb == 0 || Motors < 1) return false;
                return Th[motor].IsMoving();
            }
            public bool WaitonMotor(int motor)				                // Wait for this or all motor(s) to stop 
            {
                if (Mcb == 0 || Motors < 1) return false;
                if (motor < 0 || motor >= Motors) motor = -1;		            // All motors
                if (motor == -1)
                {
                    bool done = true;
                    while (!Break && !done)
                    {
                        for (int i = 0; i < Motors; i++)
                            done &= Th[i].WaittoStop();
                    }
                    return true;
                }
                return Th[motor].WaittoStop();
            }
            //////////////////////////////////////////////////////////////////////////////////////////////
            #region Mirror Parking procedures
            //  We only park all motors together as there is less stress to springs and it is faster
            //	We turn off soft limits & enable hard limits and set Acceleration & Velocity to their max values
            public bool Reconf()                                            // Reconfigure motors for fast rewind 
            {												                    // Returns True if GetMotionConfigs succeeded 
                if (Mcb == 0 || Motors < 1) return false;
                for (int i = 0; i < Motors; i++) 
                    if (!Th[i].Reconf()) return false;
                return true;                                                    // We return true only if all motors were reconfigured 
            }
            public bool Backconf()                                          // Substitute the old and slower configuration back 
            {												
                if (Mcb == 0 || Motors < 1) return false;
                for (int i = 0; i < Motors; i++)
                    if (!Th[i].Backconf()) return false;
                return true;                                                   
            }
            public bool ParkAll()							                // Goto to positive hard limit, i.e. screw full in 
            {
                int i;										                    // Set position values to 300,000
                double timo;								                    // Come back to position: 150,000
                bool canredo = false;
                if (Mcb == 0 || Motors < 1) return false;
                canredo = Reconf();							                    // true if Backconf is possible
                timo = 35;									                    // Max move is ~330,000 steps, timeout 35 sec
                MCEnableAxis(Mcb, MC_ALL_AXES, true);
                for (i = 0; i < Motors; i++)
                    Th[i].MoveRelative(400000, true);			                // All axes go in
                MCIsStopped(Mcb, MC_ALL_AXES, timo);		                    // Give it another 35 sec
                for (i = 0; i < Motors; i++)
                    Th[i].SetCurPos(300000);							        // Set position of all motors to value 300,000
                MCEnableAxis(Mcb, MC_ALL_AXES, true);
                for (i = 0; i < Motors; i++)
                    Th[i].MoveRelative(-170000, true);			                // All axes go in
                MCIsStopped(Mcb, MC_ALL_AXES, timo);
                MCEnableAxis(Mcb, MC_ALL_AXES, false);
                return (canredo && Backconf());
            }
            #endregion
            public void SetupAxis(IntPtr hWnd, int motor)
            {
                double pos = 0;
                IntPtr szTitle = IntPtr.Zero;
                int flags = MCDLG_CHECKACTIVE | MCDLG_PROMPT;
                int res = MCDLG_ConfigureAxis(hWnd, Mcb, (short)(motor + 1), flags, szTitle);
                if (res == 0)						                        // IDOK
                {
                    Th[motor].ObtainInfo(motor);
                    Th[motor].GetCurPos(ref pos);
                }
            }
            #endregion
        }



    }
}

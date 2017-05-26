using System;
using System.Windows.Forms;
using Tonu.Windows.Forms;

namespace ThorMotor
{
    public partial class Form3D : Form
    {
        FImage FI;
        string Mainkey;
        public string MapTitle = "";
        public Form3D(FImage fi, string mk)
        {
            FI = fi;
            Mainkey = mk;
            InitializeComponent();
        }
        private void Form3D_Load(object sender, EventArgs e)
        {
            glControl.ReadFromRegistry(Mainkey);
            if (FI != null)
            {
                if (FI.fullname != "") Text = FI.fullname;
                glControl.MD.DD = FI;
                glControl.MD.MapTitle = MapTitle;
                glControl.MD.FromScratch = true;
                glControl.Rejuvenate();
            }
        }
        private void Form3D_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (glControl.NosaveExit) return;                               // Fuck off now mode
            glControl.SaveToRegistry(Mainkey);
        }

        private void Form3D_Paint(object sender, PaintEventArgs e)
        {
            float f, fx, fy;
            int x, y;
            if (glControl.GetMarker(out f, out x, out y, out fx, out fy))
                lbMarker.Text = "Marker at X,Y = " + fx.ToString("F3") + "," + fy.ToString("F3") + "   [" + x.ToString() + "," + y.ToString() +
                                "]    I = " + f.ToString("N1") + "  Log:" + Math.Log10(f).ToString("F4");
            else lbMarker.Text = "";
        }
    }
}

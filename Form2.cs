using System;
using System.Windows.Forms;

namespace ThorMotor
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:tonu.reinot@gmail.com");
        }

        public string AssemblyVersion
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lbVersion.Text = "Version: " + AssemblyVersion;
        }

    }
}

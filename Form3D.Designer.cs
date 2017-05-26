namespace ThorMotor
{
    partial class Form3D
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3D));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbMarker = new System.Windows.Forms.ToolStripStatusLabel();
            this.glControl = new Tonu.Windows.Forms.GLMapControl();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbMarker});
            this.statusStrip1.Location = new System.Drawing.Point(0, 609);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(833, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbMarker
            // 
            this.lbMarker.Name = "lbMarker";
            this.lbMarker.Size = new System.Drawing.Size(26, 17);
            this.lbMarker.Text = "OK:";
            // 
            // glControl
            // 
            this.glControl.Dfilterindex = 1;
            this.glControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl.FontName = "Calibri";
            this.glControl.Location = new System.Drawing.Point(0, 0);
            this.glControl.LogLabels = true;
            this.glControl.Mainkey = "Software\\TR Software\\OpenGLcontrol";
            this.glControl.MapTitle = "";
            this.glControl.MarkerVisible = true;
            this.glControl.Name = "glControl";
            this.glControl.Perspective = 60F;
            this.glControl.Size = new System.Drawing.Size(833, 609);
            this.glControl.TabIndex = 1;
            this.glControl.TiltHorizontal = 0F;
            this.glControl.TiltNormal = 0F;
            this.glControl.TiltSensitivityNormal = 0.01F;
            this.glControl.TiltVertical = 0F;
            this.glControl.TranslationDZ = 0.005F;
            this.glControl.TranslationX = 0F;
            this.glControl.TranslationY = -6F;
            this.glControl.TranslationZ = 0F;
            // 
            // Form3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 631);
            this.Controls.Add(this.glControl);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3D";
            this.Text = "Enjoy the 3D Image of your stuff";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3D_FormClosing);
            this.Load += new System.EventHandler(this.Form3D_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form3D_Paint);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbMarker;
        private Tonu.Windows.Forms.GLMapControl glControl;
        //private Tonu.Windows.Forms.GLMapControl glControl;
    }
}
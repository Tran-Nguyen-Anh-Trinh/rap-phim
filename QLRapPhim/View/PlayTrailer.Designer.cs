
namespace QLRapPhim
{
    partial class PlayTrailer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayTrailer));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.CCRegis = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(1062, 673);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // CCRegis
            // 
            this.CCRegis.BackColor = System.Drawing.Color.Black;
            this.CCRegis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CCRegis.FlatAppearance.BorderSize = 0;
            this.CCRegis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CCRegis.Image = ((System.Drawing.Image)(resources.GetObject("CCRegis.Image")));
            this.CCRegis.Location = new System.Drawing.Point(1020, 7);
            this.CCRegis.Name = "CCRegis";
            this.CCRegis.Size = new System.Drawing.Size(35, 31);
            this.CCRegis.TabIndex = 19;
            this.CCRegis.UseVisualStyleBackColor = false;
            this.CCRegis.Click += new System.EventHandler(this.CCRegis_Click_1);
            // 
            // PlayTrailer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.CCRegis);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlayTrailer";
            this.Text = "PlayTrailer";
            this.Load += new System.EventHandler(this.PlayTrailer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button CCRegis;
    }
}
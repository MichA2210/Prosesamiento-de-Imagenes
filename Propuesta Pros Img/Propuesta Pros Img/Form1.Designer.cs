namespace Propuesta_Pros_Img
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnCam = new System.Windows.Forms.Button();
            this.btnVideo = new System.Windows.Forms.Button();
            this.btnImgs = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelChild = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelSideMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelChild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelSideMenu.Controls.Add(this.btnCam);
            this.panelSideMenu.Controls.Add(this.btnVideo);
            this.panelSideMenu.Controls.Add(this.btnImgs);
            this.panelSideMenu.Controls.Add(this.panel1);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 764);
            this.panelSideMenu.TabIndex = 0;
            // 
            // btnCam
            // 
            this.btnCam.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCam.FlatAppearance.BorderSize = 0;
            this.btnCam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCam.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCam.Location = new System.Drawing.Point(0, 162);
            this.btnCam.Name = "btnCam";
            this.btnCam.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCam.Size = new System.Drawing.Size(250, 45);
            this.btnCam.TabIndex = 3;
            this.btnCam.Text = "Captura de Video";
            this.btnCam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCam.UseVisualStyleBackColor = true;
            this.btnCam.Click += new System.EventHandler(this.btnCam_Click);
            // 
            // btnVideo
            // 
            this.btnVideo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVideo.FlatAppearance.BorderSize = 0;
            this.btnVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVideo.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVideo.Location = new System.Drawing.Point(0, 117);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnVideo.Size = new System.Drawing.Size(250, 45);
            this.btnVideo.TabIndex = 2;
            this.btnVideo.Text = "Filtro Video";
            this.btnVideo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVideo.UseVisualStyleBackColor = true;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // btnImgs
            // 
            this.btnImgs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnImgs.FlatAppearance.BorderSize = 0;
            this.btnImgs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImgs.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnImgs.Location = new System.Drawing.Point(0, 72);
            this.btnImgs.Name = "btnImgs";
            this.btnImgs.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnImgs.Size = new System.Drawing.Size(250, 45);
            this.btnImgs.TabIndex = 0;
            this.btnImgs.Text = "Flitro Imagenes";
            this.btnImgs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImgs.UseVisualStyleBackColor = true;
            this.btnImgs.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 72);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("SimSun", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.label1.Size = new System.Drawing.Size(252, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Media PlayGround";
            // 
            // panelChild
            // 
            this.panelChild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelChild.Controls.Add(this.pictureBox1);
            this.panelChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChild.Location = new System.Drawing.Point(250, 0);
            this.panelChild.Name = "panelChild";
            this.panelChild.Size = new System.Drawing.Size(1166, 764);
            this.panelChild.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(293, 58);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(571, 667);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(571, 667);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 764);
            this.Controls.Add(this.panelChild);
            this.Controls.Add(this.panelSideMenu);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximumSize = new System.Drawing.Size(1434, 811);
            this.MinimumSize = new System.Drawing.Size(1434, 811);
            this.Name = "Form1";
            this.Text = "Prosesamiento de Imagenes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelChild.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelSideMenu;
        private Panel panel1;
        private Button btnImgs;
        private Button btnCam;
        private Button btnVideo;
        private Label label1;
        private Panel panelChild;
        private PictureBox pictureBox1;
    }
}
namespace Rain
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Elipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.PID = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.buttonsettings = new Guna.UI2.WinForms.Guna2Button();
            this.buttonVisual = new Guna.UI2.WinForms.Guna2Button();
            this.buttonaim = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.exit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.doiss = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ummm = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.kkktesxt = new System.Windows.Forms.Label();
            this.direitaseta = new Guna.UI2.WinForms.Guna2PictureBox();
            this.esquerdaseta = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2DragControl5 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl6 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.guna2DragControl7 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.aim1 = new Rain.Aim();
            this.config1 = new Rain.Config();
            this.visual1 = new Rain.Visual();
            this.aim2 = new Rain.Aim();
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl3 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl4 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl8 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl9 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl10 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doiss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ummm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.direitaseta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esquerdaseta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Elipse
            // 
            this.Elipse.BorderRadius = 3;
            this.Elipse.TargetControl = this;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.Location = new System.Drawing.Point(-3, 16);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(113, 62);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 37;
            this.guna2PictureBox1.TabStop = false;
            // 
            // PID
            // 
            this.PID.AutoSize = true;
            this.PID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PID.ForeColor = System.Drawing.Color.Red;
            this.PID.Location = new System.Drawing.Point(551, 567);
            this.PID.Name = "PID";
            this.PID.Size = new System.Drawing.Size(37, 21);
            this.PID.TabIndex = 19;
            this.PID.Text = "PID";
            this.PID.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this;
            // 
            // buttonsettings
            // 
            this.buttonsettings.Animated = true;
            this.buttonsettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.buttonsettings.BorderRadius = 7;
            this.buttonsettings.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.buttonsettings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.buttonsettings.CheckedState.FillColor = System.Drawing.Color.Indigo;
            this.buttonsettings.CheckedState.Parent = this.buttonsettings;
            this.buttonsettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonsettings.CustomImages.Parent = this.buttonsettings;
            this.buttonsettings.FillColor = System.Drawing.Color.Transparent;
            this.buttonsettings.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.buttonsettings.ForeColor = System.Drawing.Color.Indigo;
            this.buttonsettings.HoverState.Parent = this.buttonsettings;
            this.buttonsettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonsettings.Image")));
            this.buttonsettings.ImageSize = new System.Drawing.Size(30, 30);
            this.buttonsettings.Location = new System.Drawing.Point(681, 27);
            this.buttonsettings.Name = "buttonsettings";
            this.buttonsettings.PressedColor = System.Drawing.Color.Indigo;
            this.buttonsettings.ShadowDecoration.Color = System.Drawing.Color.Indigo;
            this.buttonsettings.ShadowDecoration.Parent = this.buttonsettings;
            this.buttonsettings.Size = new System.Drawing.Size(42, 34);
            this.buttonsettings.TabIndex = 51;
            this.buttonsettings.Click += new System.EventHandler(this.buttonsettings_Click);
            // 
            // buttonVisual
            // 
            this.buttonVisual.Animated = true;
            this.buttonVisual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.buttonVisual.BorderRadius = 7;
            this.buttonVisual.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.buttonVisual.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.buttonVisual.CheckedState.FillColor = System.Drawing.Color.Indigo;
            this.buttonVisual.CheckedState.Parent = this.buttonVisual;
            this.buttonVisual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonVisual.CustomImages.Parent = this.buttonVisual;
            this.buttonVisual.FillColor = System.Drawing.Color.Transparent;
            this.buttonVisual.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.buttonVisual.ForeColor = System.Drawing.Color.Indigo;
            this.buttonVisual.HoverState.Parent = this.buttonVisual;
            this.buttonVisual.Image = ((System.Drawing.Image)(resources.GetObject("buttonVisual.Image")));
            this.buttonVisual.ImageSize = new System.Drawing.Size(30, 30);
            this.buttonVisual.Location = new System.Drawing.Point(639, 27);
            this.buttonVisual.Name = "buttonVisual";
            this.buttonVisual.PressedColor = System.Drawing.Color.Indigo;
            this.buttonVisual.ShadowDecoration.Color = System.Drawing.Color.Indigo;
            this.buttonVisual.ShadowDecoration.Parent = this.buttonVisual;
            this.buttonVisual.Size = new System.Drawing.Size(40, 34);
            this.buttonVisual.TabIndex = 50;
            this.buttonVisual.Click += new System.EventHandler(this.buttonVisual_Click);
            // 
            // buttonaim
            // 
            this.buttonaim.Animated = true;
            this.buttonaim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.buttonaim.BorderRadius = 7;
            this.buttonaim.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.buttonaim.CheckedState.FillColor = System.Drawing.Color.Indigo;
            this.buttonaim.CheckedState.Parent = this.buttonaim;
            this.buttonaim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonaim.CustomImages.Parent = this.buttonaim;
            this.buttonaim.FillColor = System.Drawing.Color.Transparent;
            this.buttonaim.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.buttonaim.ForeColor = System.Drawing.Color.Indigo;
            this.buttonaim.HoverState.BorderColor = System.Drawing.Color.Black;
            this.buttonaim.HoverState.Parent = this.buttonaim;
            this.buttonaim.Image = ((System.Drawing.Image)(resources.GetObject("buttonaim.Image")));
            this.buttonaim.ImageSize = new System.Drawing.Size(30, 30);
            this.buttonaim.Location = new System.Drawing.Point(594, 27);
            this.buttonaim.Name = "buttonaim";
            this.buttonaim.PressedColor = System.Drawing.Color.Indigo;
            this.buttonaim.ShadowDecoration.Color = System.Drawing.Color.Indigo;
            this.buttonaim.ShadowDecoration.Parent = this.buttonaim;
            this.buttonaim.Size = new System.Drawing.Size(44, 34);
            this.buttonaim.TabIndex = 49;
            this.buttonaim.Click += new System.EventHandler(this.buttonaim_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(3, 533);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // exit
            // 
            this.exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exit.CustomIconSize = 5F;
            this.exit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.exit.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.exit.HoverState.Parent = this.exit;
            this.exit.IconColor = System.Drawing.Color.Indigo;
            this.exit.Location = new System.Drawing.Point(692, -1);
            this.exit.Margin = new System.Windows.Forms.Padding(9);
            this.exit.Name = "exit";
            this.exit.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.exit.ShadowDecoration.Parent = this.exit;
            this.exit.Size = new System.Drawing.Size(35, 20);
            this.exit.TabIndex = 44;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox1.CustomIconSize = 5F;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Indigo;
            this.guna2ControlBox1.Location = new System.Drawing.Point(658, -5);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(9);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(37, 29);
            this.guna2ControlBox1.TabIndex = 45;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // doiss
            // 
            this.doiss.Image = ((System.Drawing.Image)(resources.GetObject("doiss.Image")));
            this.doiss.Location = new System.Drawing.Point(-3, -84);
            this.doiss.Name = "doiss";
            this.doiss.ShadowDecoration.Parent = this.doiss;
            this.doiss.Size = new System.Drawing.Size(75, 99);
            this.doiss.TabIndex = 47;
            this.doiss.TabStop = false;
            // 
            // ummm
            // 
            this.ummm.Image = ((System.Drawing.Image)(resources.GetObject("ummm.Image")));
            this.ummm.Location = new System.Drawing.Point(67, -84);
            this.ummm.Name = "ummm";
            this.ummm.ShadowDecoration.Parent = this.ummm;
            this.ummm.Size = new System.Drawing.Size(577, 99);
            this.ummm.TabIndex = 48;
            this.ummm.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Indigo;
            this.label7.Location = new System.Drawing.Point(-2, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 32);
            this.label7.TabIndex = 59;
            this.label7.Text = "•";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // kkktesxt
            // 
            this.kkktesxt.AutoSize = true;
            this.kkktesxt.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kkktesxt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.kkktesxt.Location = new System.Drawing.Point(12, 88);
            this.kkktesxt.Name = "kkktesxt";
            this.kkktesxt.Size = new System.Drawing.Size(36, 20);
            this.kkktesxt.TabIndex = 58;
            this.kkktesxt.Text = "Aim";
            // 
            // direitaseta
            // 
            this.direitaseta.Image = ((System.Drawing.Image)(resources.GetObject("direitaseta.Image")));
            this.direitaseta.Location = new System.Drawing.Point(703, 254);
            this.direitaseta.Name = "direitaseta";
            this.direitaseta.ShadowDecoration.Parent = this.direitaseta;
            this.direitaseta.Size = new System.Drawing.Size(20, 46);
            this.direitaseta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.direitaseta.TabIndex = 60;
            this.direitaseta.TabStop = false;
            this.direitaseta.Click += new System.EventHandler(this.direitaseta_Click);
            // 
            // esquerdaseta
            // 
            this.esquerdaseta.Image = ((System.Drawing.Image)(resources.GetObject("esquerdaseta.Image")));
            this.esquerdaseta.Location = new System.Drawing.Point(1, 254);
            this.esquerdaseta.Name = "esquerdaseta";
            this.esquerdaseta.ShadowDecoration.Parent = this.esquerdaseta;
            this.esquerdaseta.Size = new System.Drawing.Size(20, 46);
            this.esquerdaseta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.esquerdaseta.TabIndex = 61;
            this.esquerdaseta.TabStop = false;
            this.esquerdaseta.Visible = false;
            this.esquerdaseta.Click += new System.EventHandler(this.esquerdaseta_Click);
            // 
            // guna2DragControl5
            // 
            this.guna2DragControl5.TargetControl = this.ummm;
            // 
            // guna2DragControl6
            // 
            this.guna2DragControl6.TargetControl = this.doiss;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 600;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(690, 532);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 62;
            this.label2.Text = "v2.2";
            // 
            // guna2DragControl7
            // 
            this.guna2DragControl7.TargetControl = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(269, 91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 64;
            this.pictureBox1.TabStop = false;
            // 
            // aim1
            // 
            this.aim1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.aim1.Location = new System.Drawing.Point(-3, 67);
            this.aim1.Name = "aim1";
            this.aim1.Size = new System.Drawing.Size(729, 456);
            this.aim1.TabIndex = 40;
            this.aim1.Load += new System.EventHandler(this.aim1_Load);
            // 
            // config1
            // 
            this.config1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.config1.Location = new System.Drawing.Point(-3, 67);
            this.config1.Name = "config1";
            this.config1.Size = new System.Drawing.Size(717, 460);
            this.config1.TabIndex = 42;
            this.config1.Load += new System.EventHandler(this.config1_Load);
            // 
            // visual1
            // 
            this.visual1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.visual1.Location = new System.Drawing.Point(-3, 67);
            this.visual1.Name = "visual1";
            this.visual1.Size = new System.Drawing.Size(717, 440);
            this.visual1.TabIndex = 41;
            // 
            // aim2
            // 
            this.aim2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.aim2.Location = new System.Drawing.Point(-3, 67);
            this.aim2.Name = "aim2";
            this.aim2.Size = new System.Drawing.Size(717, 450);
            this.aim2.TabIndex = 63;
            // 
            // guna2DragControl2
            // 
            this.guna2DragControl2.TargetControl = this.aim1;
            // 
            // guna2DragControl3
            // 
            this.guna2DragControl3.TargetControl = this.config1;
            // 
            // guna2DragControl4
            // 
            this.guna2DragControl4.TargetControl = this.visual1;
            // 
            // guna2DragControl8
            // 
            this.guna2DragControl8.TargetControl = this.aim1;
            // 
            // guna2DragControl9
            // 
            this.guna2DragControl9.TargetControl = this.pictureBox1;
            // 
            // guna2DragControl10
            // 
            this.guna2DragControl10.TargetControl = this.guna2PictureBox1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.ClientSize = new System.Drawing.Size(726, 552);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.direitaseta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kkktesxt);
            this.Controls.Add(this.esquerdaseta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonsettings);
            this.Controls.Add(this.buttonVisual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonaim);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.PID);
            this.Controls.Add(this.ummm);
            this.Controls.Add(this.doiss);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.aim1);
            this.Controls.Add(this.config1);
            this.Controls.Add(this.visual1);
            this.Controls.Add(this.aim2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doiss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ummm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.direitaseta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esquerdaseta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse Elipse;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label PID;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl4;
        private Guna.UI2.WinForms.Guna2Button buttonaim;
        private Guna.UI2.WinForms.Guna2Button buttonsettings;
        private Guna.UI2.WinForms.Guna2Button buttonVisual;
        private Visual visual1;
        private Aim aim1;
        private Config config1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox exit;
        private Guna.UI2.WinForms.Guna2PictureBox ummm;
        private Guna.UI2.WinForms.Guna2PictureBox doiss;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label kkktesxt;
        private Guna.UI2.WinForms.Guna2PictureBox esquerdaseta;
        private Guna.UI2.WinForms.Guna2PictureBox direitaseta;
        public Guna.UI2.WinForms.Guna2DragControl guna2DragControl3;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl5;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl6;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label2;
        private Aim aim2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl7;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl8;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl9;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl10;
    }
}


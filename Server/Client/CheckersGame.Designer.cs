namespace Client
{
    partial class CheckersGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckersGame));
            this.GameBoard = new System.Windows.Forms.PictureBox();
            this.GameVsText = new System.Windows.Forms.Label();
            this.GiveUp = new System.Windows.Forms.Button();
            this.KingButton = new System.Windows.Forms.Button();
            this.ActivePlayerUpdate = new System.Windows.Forms.Label();
            this.ActivePlayer = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RedChecker1 = new System.Windows.Forms.PictureBox();
            this.RedChecker2 = new System.Windows.Forms.PictureBox();
            this.RedChecker4 = new System.Windows.Forms.PictureBox();
            this.RedChecker3 = new System.Windows.Forms.PictureBox();
            this.RedChecker8 = new System.Windows.Forms.PictureBox();
            this.RedChecker7 = new System.Windows.Forms.PictureBox();
            this.RedChecker6 = new System.Windows.Forms.PictureBox();
            this.RedChecker5 = new System.Windows.Forms.PictureBox();
            this.RedChecker12 = new System.Windows.Forms.PictureBox();
            this.RedChecker11 = new System.Windows.Forms.PictureBox();
            this.RedChecker10 = new System.Windows.Forms.PictureBox();
            this.RedChecker9 = new System.Windows.Forms.PictureBox();
            this.GrayChecker4 = new System.Windows.Forms.PictureBox();
            this.GrayChecker3 = new System.Windows.Forms.PictureBox();
            this.GrayChecker2 = new System.Windows.Forms.PictureBox();
            this.GrayChecker1 = new System.Windows.Forms.PictureBox();
            this.GrayChecker8 = new System.Windows.Forms.PictureBox();
            this.GrayChecker7 = new System.Windows.Forms.PictureBox();
            this.GrayChecker6 = new System.Windows.Forms.PictureBox();
            this.GrayChecker5 = new System.Windows.Forms.PictureBox();
            this.GrayChecker12 = new System.Windows.Forms.PictureBox();
            this.GrayChecker11 = new System.Windows.Forms.PictureBox();
            this.GrayChecker10 = new System.Windows.Forms.PictureBox();
            this.GrayChecker9 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GameBoard)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker9)).BeginInit();
            this.SuspendLayout();
            // 
            // GameBoard
            // 
            this.GameBoard.BackColor = System.Drawing.Color.Black;
            this.GameBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GameBoard.Image = ((System.Drawing.Image)(resources.GetObject("GameBoard.Image")));
            this.GameBoard.Location = new System.Drawing.Point(7, 6);
            this.GameBoard.Name = "GameBoard";
            this.GameBoard.Size = new System.Drawing.Size(706, 656);
            this.GameBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GameBoard.TabIndex = 0;
            this.GameBoard.TabStop = false;
            // 
            // GameVsText
            // 
            this.GameVsText.AutoSize = true;
            this.GameVsText.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameVsText.Location = new System.Drawing.Point(23, 16);
            this.GameVsText.Name = "GameVsText";
            this.GameVsText.Size = new System.Drawing.Size(321, 45);
            this.GameVsText.TabIndex = 1;
            this.GameVsText.Text = "Player 1 VS Player 2";
            // 
            // GiveUp
            // 
            this.GiveUp.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GiveUp.Location = new System.Drawing.Point(0, 581);
            this.GiveUp.Name = "GiveUp";
            this.GiveUp.Size = new System.Drawing.Size(186, 75);
            this.GiveUp.TabIndex = 2;
            this.GiveUp.Text = "Give Up";
            this.GiveUp.UseVisualStyleBackColor = true;
            this.GiveUp.Click += new System.EventHandler(this.GiveUp_Click);
            // 
            // KingButton
            // 
            this.KingButton.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KingButton.Location = new System.Drawing.Point(185, 581);
            this.KingButton.Name = "KingButton";
            this.KingButton.Size = new System.Drawing.Size(177, 75);
            this.KingButton.TabIndex = 3;
            this.KingButton.Text = "King Current";
            this.KingButton.UseVisualStyleBackColor = true;
            // 
            // ActivePlayerUpdate
            // 
            this.ActivePlayerUpdate.AutoSize = true;
            this.ActivePlayerUpdate.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivePlayerUpdate.Location = new System.Drawing.Point(224, 91);
            this.ActivePlayerUpdate.Name = "ActivePlayerUpdate";
            this.ActivePlayerUpdate.Size = new System.Drawing.Size(88, 29);
            this.ActivePlayerUpdate.TabIndex = 4;
            this.ActivePlayerUpdate.Text = "Player 1";
            // 
            // ActivePlayer
            // 
            this.ActivePlayer.AutoSize = true;
            this.ActivePlayer.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivePlayer.Location = new System.Drawing.Point(26, 91);
            this.ActivePlayer.Name = "ActivePlayer";
            this.ActivePlayer.Size = new System.Drawing.Size(149, 29);
            this.ActivePlayer.TabIndex = 5;
            this.ActivePlayer.Text = "Active Player:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.ActivePlayer);
            this.groupBox1.Controls.Add(this.GameVsText);
            this.groupBox1.Controls.Add(this.KingButton);
            this.groupBox1.Controls.Add(this.ActivePlayerUpdate);
            this.groupBox1.Controls.Add(this.GiveUp);
            this.groupBox1.Location = new System.Drawing.Point(743, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 656);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // RedChecker1
            // 
            this.RedChecker1.BackColor = System.Drawing.Color.Transparent;
            this.RedChecker1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RedChecker1.Image = global::Client.Properties.Resources.player_1;
            this.RedChecker1.Location = new System.Drawing.Point(16, 419);
            this.RedChecker1.Name = "RedChecker1";
            this.RedChecker1.Size = new System.Drawing.Size(74, 73);
            this.RedChecker1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RedChecker1.TabIndex = 6;
            this.RedChecker1.TabStop = false;
            this.RedChecker1.Click += new System.EventHandler(this.RedChecker1_Click);
            this.RedChecker1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RedChecker1_MouseMove);
            // 
            // RedChecker2
            // 
            this.RedChecker2.BackColor = System.Drawing.Color.Transparent;
            this.RedChecker2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RedChecker2.Image = ((System.Drawing.Image)(resources.GetObject("RedChecker2.Image")));
            this.RedChecker2.Location = new System.Drawing.Point(191, 419);
            this.RedChecker2.Name = "RedChecker2";
            this.RedChecker2.Size = new System.Drawing.Size(74, 73);
            this.RedChecker2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RedChecker2.TabIndex = 7;
            this.RedChecker2.TabStop = false;
            this.RedChecker2.Click += new System.EventHandler(this.RedChecker2_Click);
            this.RedChecker2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RedChecker2_MouseMove);
            // 
            // RedChecker4
            // 
            this.RedChecker4.BackColor = System.Drawing.Color.Transparent;
            this.RedChecker4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RedChecker4.Image = ((System.Drawing.Image)(resources.GetObject("RedChecker4.Image")));
            this.RedChecker4.Location = new System.Drawing.Point(543, 419);
            this.RedChecker4.Name = "RedChecker4";
            this.RedChecker4.Size = new System.Drawing.Size(74, 73);
            this.RedChecker4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RedChecker4.TabIndex = 9;
            this.RedChecker4.TabStop = false;
            this.RedChecker4.Click += new System.EventHandler(this.RedChecker4_Click);
            this.RedChecker4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RedChecker4_MouseMove);
            // 
            // RedChecker3
            // 
            this.RedChecker3.BackColor = System.Drawing.Color.Transparent;
            this.RedChecker3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RedChecker3.Image = ((System.Drawing.Image)(resources.GetObject("RedChecker3.Image")));
            this.RedChecker3.Location = new System.Drawing.Point(367, 419);
            this.RedChecker3.Name = "RedChecker3";
            this.RedChecker3.Size = new System.Drawing.Size(74, 73);
            this.RedChecker3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RedChecker3.TabIndex = 8;
            this.RedChecker3.TabStop = false;
            this.RedChecker3.Click += new System.EventHandler(this.RedChecker3_Click);
            this.RedChecker3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RedChecker3_MouseMove);
            // 
            // RedChecker8
            // 
            this.RedChecker8.BackColor = System.Drawing.Color.Transparent;
            this.RedChecker8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RedChecker8.Image = ((System.Drawing.Image)(resources.GetObject("RedChecker8.Image")));
            this.RedChecker8.Location = new System.Drawing.Point(632, 500);
            this.RedChecker8.Name = "RedChecker8";
            this.RedChecker8.Size = new System.Drawing.Size(74, 73);
            this.RedChecker8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RedChecker8.TabIndex = 13;
            this.RedChecker8.TabStop = false;
            this.RedChecker8.Click += new System.EventHandler(this.RedChecker8_Click);
            this.RedChecker8.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RedChecker8_MouseMove);
            // 
            // RedChecker7
            // 
            this.RedChecker7.BackColor = System.Drawing.Color.Transparent;
            this.RedChecker7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RedChecker7.Image = ((System.Drawing.Image)(resources.GetObject("RedChecker7.Image")));
            this.RedChecker7.Location = new System.Drawing.Point(455, 501);
            this.RedChecker7.Name = "RedChecker7";
            this.RedChecker7.Size = new System.Drawing.Size(74, 73);
            this.RedChecker7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RedChecker7.TabIndex = 12;
            this.RedChecker7.TabStop = false;
            this.RedChecker7.Click += new System.EventHandler(this.RedChecker7_Click);
            this.RedChecker7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RedChecker7_MouseMove);
            // 
            // RedChecker6
            // 
            this.RedChecker6.BackColor = System.Drawing.Color.Transparent;
            this.RedChecker6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RedChecker6.Image = ((System.Drawing.Image)(resources.GetObject("RedChecker6.Image")));
            this.RedChecker6.Location = new System.Drawing.Point(280, 501);
            this.RedChecker6.Name = "RedChecker6";
            this.RedChecker6.Size = new System.Drawing.Size(74, 73);
            this.RedChecker6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RedChecker6.TabIndex = 11;
            this.RedChecker6.TabStop = false;
            this.RedChecker6.Click += new System.EventHandler(this.RedChecker6_Click);
            this.RedChecker6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RedChecker6_MouseMove);
            // 
            // RedChecker5
            // 
            this.RedChecker5.BackColor = System.Drawing.Color.Transparent;
            this.RedChecker5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RedChecker5.Image = ((System.Drawing.Image)(resources.GetObject("RedChecker5.Image")));
            this.RedChecker5.Location = new System.Drawing.Point(103, 501);
            this.RedChecker5.Name = "RedChecker5";
            this.RedChecker5.Size = new System.Drawing.Size(74, 73);
            this.RedChecker5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RedChecker5.TabIndex = 10;
            this.RedChecker5.TabStop = false;
            this.RedChecker5.Click += new System.EventHandler(this.RedChecker5_Click);
            this.RedChecker5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RedChecker5_MouseMove);
            // 
            // RedChecker12
            // 
            this.RedChecker12.BackColor = System.Drawing.Color.Transparent;
            this.RedChecker12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RedChecker12.Image = ((System.Drawing.Image)(resources.GetObject("RedChecker12.Image")));
            this.RedChecker12.Location = new System.Drawing.Point(544, 583);
            this.RedChecker12.Name = "RedChecker12";
            this.RedChecker12.Size = new System.Drawing.Size(74, 73);
            this.RedChecker12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RedChecker12.TabIndex = 17;
            this.RedChecker12.TabStop = false;
            this.RedChecker12.Click += new System.EventHandler(this.RedChecker12_Click);
            this.RedChecker12.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RedChecker12_MouseMove);
            // 
            // RedChecker11
            // 
            this.RedChecker11.BackColor = System.Drawing.Color.Transparent;
            this.RedChecker11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RedChecker11.Image = ((System.Drawing.Image)(resources.GetObject("RedChecker11.Image")));
            this.RedChecker11.Location = new System.Drawing.Point(367, 583);
            this.RedChecker11.Name = "RedChecker11";
            this.RedChecker11.Size = new System.Drawing.Size(74, 73);
            this.RedChecker11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RedChecker11.TabIndex = 16;
            this.RedChecker11.TabStop = false;
            this.RedChecker11.Click += new System.EventHandler(this.RedChecker11_Click);
            this.RedChecker11.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RedChecker11_MouseMove);
            // 
            // RedChecker10
            // 
            this.RedChecker10.BackColor = System.Drawing.Color.Transparent;
            this.RedChecker10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RedChecker10.Image = ((System.Drawing.Image)(resources.GetObject("RedChecker10.Image")));
            this.RedChecker10.Location = new System.Drawing.Point(191, 583);
            this.RedChecker10.Name = "RedChecker10";
            this.RedChecker10.Size = new System.Drawing.Size(74, 73);
            this.RedChecker10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RedChecker10.TabIndex = 15;
            this.RedChecker10.TabStop = false;
            this.RedChecker10.Click += new System.EventHandler(this.RedChecker10_Click);
            this.RedChecker10.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RedChecker10_MouseMove);
            // 
            // RedChecker9
            // 
            this.RedChecker9.BackColor = System.Drawing.Color.Transparent;
            this.RedChecker9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RedChecker9.Image = ((System.Drawing.Image)(resources.GetObject("RedChecker9.Image")));
            this.RedChecker9.Location = new System.Drawing.Point(16, 583);
            this.RedChecker9.Name = "RedChecker9";
            this.RedChecker9.Size = new System.Drawing.Size(74, 73);
            this.RedChecker9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RedChecker9.TabIndex = 14;
            this.RedChecker9.TabStop = false;
            this.RedChecker9.Click += new System.EventHandler(this.RedChecker9_Click);
            this.RedChecker9.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RedChecker9_MouseMove);
            // 
            // GrayChecker4
            // 
            this.GrayChecker4.BackColor = System.Drawing.Color.Transparent;
            this.GrayChecker4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GrayChecker4.Image = ((System.Drawing.Image)(resources.GetObject("GrayChecker4.Image")));
            this.GrayChecker4.Location = new System.Drawing.Point(631, 10);
            this.GrayChecker4.Name = "GrayChecker4";
            this.GrayChecker4.Size = new System.Drawing.Size(74, 73);
            this.GrayChecker4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GrayChecker4.TabIndex = 21;
            this.GrayChecker4.TabStop = false;
            // 
            // GrayChecker3
            // 
            this.GrayChecker3.BackColor = System.Drawing.Color.Transparent;
            this.GrayChecker3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GrayChecker3.Image = ((System.Drawing.Image)(resources.GetObject("GrayChecker3.Image")));
            this.GrayChecker3.Location = new System.Drawing.Point(455, 10);
            this.GrayChecker3.Name = "GrayChecker3";
            this.GrayChecker3.Size = new System.Drawing.Size(74, 73);
            this.GrayChecker3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GrayChecker3.TabIndex = 20;
            this.GrayChecker3.TabStop = false;
            // 
            // GrayChecker2
            // 
            this.GrayChecker2.BackColor = System.Drawing.Color.Transparent;
            this.GrayChecker2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GrayChecker2.Image = ((System.Drawing.Image)(resources.GetObject("GrayChecker2.Image")));
            this.GrayChecker2.Location = new System.Drawing.Point(279, 10);
            this.GrayChecker2.Name = "GrayChecker2";
            this.GrayChecker2.Size = new System.Drawing.Size(74, 73);
            this.GrayChecker2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GrayChecker2.TabIndex = 19;
            this.GrayChecker2.TabStop = false;
            // 
            // GrayChecker1
            // 
            this.GrayChecker1.BackColor = System.Drawing.Color.Transparent;
            this.GrayChecker1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GrayChecker1.Image = ((System.Drawing.Image)(resources.GetObject("GrayChecker1.Image")));
            this.GrayChecker1.Location = new System.Drawing.Point(104, 10);
            this.GrayChecker1.Name = "GrayChecker1";
            this.GrayChecker1.Size = new System.Drawing.Size(74, 73);
            this.GrayChecker1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GrayChecker1.TabIndex = 18;
            this.GrayChecker1.TabStop = false;
            // 
            // GrayChecker8
            // 
            this.GrayChecker8.BackColor = System.Drawing.Color.Transparent;
            this.GrayChecker8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GrayChecker8.Image = ((System.Drawing.Image)(resources.GetObject("GrayChecker8.Image")));
            this.GrayChecker8.Location = new System.Drawing.Point(543, 93);
            this.GrayChecker8.Name = "GrayChecker8";
            this.GrayChecker8.Size = new System.Drawing.Size(74, 73);
            this.GrayChecker8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GrayChecker8.TabIndex = 25;
            this.GrayChecker8.TabStop = false;
            // 
            // GrayChecker7
            // 
            this.GrayChecker7.BackColor = System.Drawing.Color.Transparent;
            this.GrayChecker7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GrayChecker7.Image = ((System.Drawing.Image)(resources.GetObject("GrayChecker7.Image")));
            this.GrayChecker7.Location = new System.Drawing.Point(367, 93);
            this.GrayChecker7.Name = "GrayChecker7";
            this.GrayChecker7.Size = new System.Drawing.Size(74, 73);
            this.GrayChecker7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GrayChecker7.TabIndex = 24;
            this.GrayChecker7.TabStop = false;
            // 
            // GrayChecker6
            // 
            this.GrayChecker6.BackColor = System.Drawing.Color.Transparent;
            this.GrayChecker6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GrayChecker6.Image = ((System.Drawing.Image)(resources.GetObject("GrayChecker6.Image")));
            this.GrayChecker6.Location = new System.Drawing.Point(191, 93);
            this.GrayChecker6.Name = "GrayChecker6";
            this.GrayChecker6.Size = new System.Drawing.Size(74, 73);
            this.GrayChecker6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GrayChecker6.TabIndex = 23;
            this.GrayChecker6.TabStop = false;
            // 
            // GrayChecker5
            // 
            this.GrayChecker5.BackColor = System.Drawing.Color.Transparent;
            this.GrayChecker5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GrayChecker5.Image = ((System.Drawing.Image)(resources.GetObject("GrayChecker5.Image")));
            this.GrayChecker5.Location = new System.Drawing.Point(16, 93);
            this.GrayChecker5.Name = "GrayChecker5";
            this.GrayChecker5.Size = new System.Drawing.Size(74, 73);
            this.GrayChecker5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GrayChecker5.TabIndex = 22;
            this.GrayChecker5.TabStop = false;
            // 
            // GrayChecker12
            // 
            this.GrayChecker12.BackColor = System.Drawing.Color.Transparent;
            this.GrayChecker12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GrayChecker12.Image = ((System.Drawing.Image)(resources.GetObject("GrayChecker12.Image")));
            this.GrayChecker12.Location = new System.Drawing.Point(631, 174);
            this.GrayChecker12.Name = "GrayChecker12";
            this.GrayChecker12.Size = new System.Drawing.Size(74, 73);
            this.GrayChecker12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GrayChecker12.TabIndex = 29;
            this.GrayChecker12.TabStop = false;
            // 
            // GrayChecker11
            // 
            this.GrayChecker11.BackColor = System.Drawing.Color.Transparent;
            this.GrayChecker11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GrayChecker11.Image = ((System.Drawing.Image)(resources.GetObject("GrayChecker11.Image")));
            this.GrayChecker11.Location = new System.Drawing.Point(455, 174);
            this.GrayChecker11.Name = "GrayChecker11";
            this.GrayChecker11.Size = new System.Drawing.Size(74, 73);
            this.GrayChecker11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GrayChecker11.TabIndex = 28;
            this.GrayChecker11.TabStop = false;
            // 
            // GrayChecker10
            // 
            this.GrayChecker10.BackColor = System.Drawing.Color.Transparent;
            this.GrayChecker10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GrayChecker10.Image = ((System.Drawing.Image)(resources.GetObject("GrayChecker10.Image")));
            this.GrayChecker10.Location = new System.Drawing.Point(279, 174);
            this.GrayChecker10.Name = "GrayChecker10";
            this.GrayChecker10.Size = new System.Drawing.Size(74, 73);
            this.GrayChecker10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GrayChecker10.TabIndex = 27;
            this.GrayChecker10.TabStop = false;
            // 
            // GrayChecker9
            // 
            this.GrayChecker9.BackColor = System.Drawing.Color.Transparent;
            this.GrayChecker9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GrayChecker9.Image = ((System.Drawing.Image)(resources.GetObject("GrayChecker9.Image")));
            this.GrayChecker9.Location = new System.Drawing.Point(104, 174);
            this.GrayChecker9.Name = "GrayChecker9";
            this.GrayChecker9.Size = new System.Drawing.Size(74, 73);
            this.GrayChecker9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GrayChecker9.TabIndex = 26;
            this.GrayChecker9.TabStop = false;
            // 
            // CheckersGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 668);
            this.Controls.Add(this.GrayChecker12);
            this.Controls.Add(this.GrayChecker11);
            this.Controls.Add(this.GrayChecker10);
            this.Controls.Add(this.GrayChecker9);
            this.Controls.Add(this.GrayChecker8);
            this.Controls.Add(this.GrayChecker7);
            this.Controls.Add(this.GrayChecker6);
            this.Controls.Add(this.GrayChecker5);
            this.Controls.Add(this.GrayChecker4);
            this.Controls.Add(this.GrayChecker3);
            this.Controls.Add(this.GrayChecker2);
            this.Controls.Add(this.GrayChecker1);
            this.Controls.Add(this.RedChecker12);
            this.Controls.Add(this.RedChecker11);
            this.Controls.Add(this.RedChecker10);
            this.Controls.Add(this.RedChecker9);
            this.Controls.Add(this.RedChecker8);
            this.Controls.Add(this.RedChecker7);
            this.Controls.Add(this.RedChecker6);
            this.Controls.Add(this.RedChecker5);
            this.Controls.Add(this.RedChecker4);
            this.Controls.Add(this.RedChecker3);
            this.Controls.Add(this.RedChecker2);
            this.Controls.Add(this.RedChecker1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GameBoard);
            this.Name = "CheckersGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckersGame_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.GameBoard)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayChecker9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox GameBoard;
        private System.Windows.Forms.Label GameVsText;
        private System.Windows.Forms.Button GiveUp;
        private System.Windows.Forms.Button KingButton;
        private System.Windows.Forms.Label ActivePlayerUpdate;
        private System.Windows.Forms.Label ActivePlayer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox RedChecker1;
        private System.Windows.Forms.PictureBox RedChecker2;
        private System.Windows.Forms.PictureBox RedChecker4;
        private System.Windows.Forms.PictureBox RedChecker3;
        private System.Windows.Forms.PictureBox RedChecker8;
        private System.Windows.Forms.PictureBox RedChecker7;
        private System.Windows.Forms.PictureBox RedChecker6;
        private System.Windows.Forms.PictureBox RedChecker5;
        private System.Windows.Forms.PictureBox RedChecker12;
        private System.Windows.Forms.PictureBox RedChecker11;
        private System.Windows.Forms.PictureBox RedChecker10;
        private System.Windows.Forms.PictureBox RedChecker9;
        private System.Windows.Forms.PictureBox GrayChecker4;
        private System.Windows.Forms.PictureBox GrayChecker3;
        private System.Windows.Forms.PictureBox GrayChecker2;
        private System.Windows.Forms.PictureBox GrayChecker1;
        private System.Windows.Forms.PictureBox GrayChecker8;
        private System.Windows.Forms.PictureBox GrayChecker7;
        private System.Windows.Forms.PictureBox GrayChecker6;
        private System.Windows.Forms.PictureBox GrayChecker5;
        private System.Windows.Forms.PictureBox GrayChecker12;
        private System.Windows.Forms.PictureBox GrayChecker11;
        private System.Windows.Forms.PictureBox GrayChecker10;
        private System.Windows.Forms.PictureBox GrayChecker9;
    }
}
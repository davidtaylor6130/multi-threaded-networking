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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GameVsText = new System.Windows.Forms.Label();
            this.GiveUp = new System.Windows.Forms.Button();
            this.KingButton = new System.Windows.Forms.Button();
            this.ActivePlayerUpdate = new System.Windows.Forms.Label();
            this.ActivePlayer = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RedChecker1 = new System.Windows.Forms.PictureBox();
            this.RedChecker2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(775, 668);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // GameVsText
            // 
            this.GameVsText.AutoSize = true;
            this.GameVsText.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameVsText.Location = new System.Drawing.Point(6, 16);
            this.GameVsText.Name = "GameVsText";
            this.GameVsText.Size = new System.Drawing.Size(321, 45);
            this.GameVsText.TabIndex = 1;
            this.GameVsText.Text = "Player 1 VS Player 2";
            // 
            // GiveUp
            // 
            this.GiveUp.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GiveUp.Location = new System.Drawing.Point(0, 569);
            this.GiveUp.Name = "GiveUp";
            this.GiveUp.Size = new System.Drawing.Size(166, 75);
            this.GiveUp.TabIndex = 2;
            this.GiveUp.Text = "Give Up";
            this.GiveUp.UseVisualStyleBackColor = true;
            // 
            // KingButton
            // 
            this.KingButton.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KingButton.Location = new System.Drawing.Point(163, 569);
            this.KingButton.Name = "KingButton";
            this.KingButton.Size = new System.Drawing.Size(170, 75);
            this.KingButton.TabIndex = 3;
            this.KingButton.Text = "King Current";
            this.KingButton.UseVisualStyleBackColor = true;
            // 
            // ActivePlayerUpdate
            // 
            this.ActivePlayerUpdate.AutoSize = true;
            this.ActivePlayerUpdate.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivePlayerUpdate.Location = new System.Drawing.Point(195, 91);
            this.ActivePlayerUpdate.Name = "ActivePlayerUpdate";
            this.ActivePlayerUpdate.Size = new System.Drawing.Size(88, 29);
            this.ActivePlayerUpdate.TabIndex = 4;
            this.ActivePlayerUpdate.Text = "Player 1";
            // 
            // ActivePlayer
            // 
            this.ActivePlayer.AutoSize = true;
            this.ActivePlayer.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivePlayer.Location = new System.Drawing.Point(17, 91);
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
            this.groupBox1.Location = new System.Drawing.Point(790, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 644);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // RedChecker1
            // 
            this.RedChecker1.BackColor = System.Drawing.Color.Transparent;
            this.RedChecker1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RedChecker1.Image = ((System.Drawing.Image)(resources.GetObject("RedChecker1.Image")));
            this.RedChecker1.Location = new System.Drawing.Point(12, 420);
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
            this.RedChecker2.Location = new System.Drawing.Point(206, 420);
            this.RedChecker2.Name = "RedChecker2";
            this.RedChecker2.Size = new System.Drawing.Size(74, 73);
            this.RedChecker2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RedChecker2.TabIndex = 7;
            this.RedChecker2.TabStop = false;
            this.RedChecker2.Click += new System.EventHandler(this.RedChecker2_Click);
            this.RedChecker2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RedChecker2_MouseMove);
            // 
            // CheckersGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 668);
            this.Controls.Add(this.RedChecker2);
            this.Controls.Add(this.RedChecker1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CheckersGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckersGame_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedChecker2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label GameVsText;
        private System.Windows.Forms.Button GiveUp;
        private System.Windows.Forms.Button KingButton;
        private System.Windows.Forms.Label ActivePlayerUpdate;
        private System.Windows.Forms.Label ActivePlayer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox RedChecker1;
        private System.Windows.Forms.PictureBox RedChecker2;
    }
}
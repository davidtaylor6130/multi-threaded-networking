namespace Client
{
    partial class ClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.UserInput = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.OnlineNamesDisplay = new System.Windows.Forms.RichTextBox();
            this.SelectServer = new System.Windows.Forms.Label();
            this.ServerSelectDropDown = new System.Windows.Forms.ComboBox();
            this.LeaveChat = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.UserIcon = new System.Windows.Forms.PictureBox();
            this.EnterChat = new System.Windows.Forms.Button();
            this.NameButton = new System.Windows.Forms.Button();
            this.NameInput = new System.Windows.Forms.RichTextBox();
            this.EnterButton = new System.Windows.Forms.Button();
            this.serverInput = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // UserInput
            // 
            this.UserInput.Location = new System.Drawing.Point(16, 487);
            this.UserInput.Multiline = false;
            this.UserInput.Name = "UserInput";
            this.UserInput.Size = new System.Drawing.Size(236, 23);
            this.UserInput.TabIndex = 2;
            this.UserInput.Text = "";
            this.UserInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserInput_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.OnlineNamesDisplay);
            this.splitContainer1.Panel1.Controls.Add(this.SelectServer);
            this.splitContainer1.Panel1.Controls.Add(this.ServerSelectDropDown);
            this.splitContainer1.Panel1.Controls.Add(this.LeaveChat);
            this.splitContainer1.Panel1.Controls.Add(this.NameLabel);
            this.splitContainer1.Panel1.Controls.Add(this.UserIcon);
            this.splitContainer1.Panel1.Controls.Add(this.EnterChat);
            this.splitContainer1.Panel1.Controls.Add(this.NameButton);
            this.splitContainer1.Panel1.Controls.Add(this.NameInput);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainer1.Panel2.Controls.Add(this.EnterButton);
            this.splitContainer1.Panel2.Controls.Add(this.UserInput);
            this.splitContainer1.Panel2.Controls.Add(this.serverInput);
            this.splitContainer1.Size = new System.Drawing.Size(547, 531);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(30, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Users In Chat";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OnlineNamesDisplay
            // 
            this.OnlineNamesDisplay.Location = new System.Drawing.Point(30, 266);
            this.OnlineNamesDisplay.Name = "OnlineNamesDisplay";
            this.OnlineNamesDisplay.Size = new System.Drawing.Size(111, 145);
            this.OnlineNamesDisplay.TabIndex = 7;
            this.OnlineNamesDisplay.Text = "Please Enter Name \nto see whos online";
            // 
            // SelectServer
            // 
            this.SelectServer.Location = new System.Drawing.Point(29, 193);
            this.SelectServer.Name = "SelectServer";
            this.SelectServer.Size = new System.Drawing.Size(111, 18);
            this.SelectServer.TabIndex = 4;
            this.SelectServer.Text = "Select Server";
            this.SelectServer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServerSelectDropDown
            // 
            this.ServerSelectDropDown.FormattingEnabled = true;
            this.ServerSelectDropDown.Items.AddRange(new object[] {
            "Server 1",
            "Server 2",
            "Server 3",
            "Server 4",
            "Server 5",
            "Game Room 1",
            "Game Room 2",
            "Game Room 3",
            "Game Room 4",
            "Game Room 5",
            "Welcome Room"});
            this.ServerSelectDropDown.Location = new System.Drawing.Point(30, 214);
            this.ServerSelectDropDown.Name = "ServerSelectDropDown";
            this.ServerSelectDropDown.Size = new System.Drawing.Size(111, 23);
            this.ServerSelectDropDown.TabIndex = 4;
            this.ServerSelectDropDown.Text = "Welcome Room";
            this.ServerSelectDropDown.SelectedIndexChanged += new System.EventHandler(this.ServerSelectDropDown_SelectedIndexChanged);
            // 
            // LeaveChat
            // 
            this.LeaveChat.Location = new System.Drawing.Point(10, 474);
            this.LeaveChat.Name = "LeaveChat";
            this.LeaveChat.Size = new System.Drawing.Size(160, 47);
            this.LeaveChat.TabIndex = 6;
            this.LeaveChat.Text = "Leave Chat";
            this.LeaveChat.UseVisualStyleBackColor = true;
            this.LeaveChat.Click += new System.EventHandler(this.LeaveChat_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.Location = new System.Drawing.Point(7, 134);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NameLabel.Size = new System.Drawing.Size(163, 18);
            this.NameLabel.TabIndex = 5;
            this.NameLabel.Text = "ENTER USERNAME";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserIcon
            // 
            this.UserIcon.ErrorImage = ((System.Drawing.Image)(resources.GetObject("UserIcon.ErrorImage")));
            this.UserIcon.Image = ((System.Drawing.Image)(resources.GetObject("UserIcon.Image")));
            this.UserIcon.InitialImage = ((System.Drawing.Image)(resources.GetObject("UserIcon.InitialImage")));
            this.UserIcon.Location = new System.Drawing.Point(32, 15);
            this.UserIcon.Name = "UserIcon";
            this.UserIcon.Size = new System.Drawing.Size(105, 109);
            this.UserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserIcon.TabIndex = 4;
            this.UserIcon.TabStop = false;
            // 
            // EnterChat
            // 
            this.EnterChat.Location = new System.Drawing.Point(10, 420);
            this.EnterChat.Name = "EnterChat";
            this.EnterChat.Size = new System.Drawing.Size(160, 47);
            this.EnterChat.TabIndex = 2;
            this.EnterChat.Text = "Enter Chat";
            this.EnterChat.UseVisualStyleBackColor = true;
            this.EnterChat.Click += new System.EventHandler(this.EnterChat_Click);
            // 
            // NameButton
            // 
            this.NameButton.Location = new System.Drawing.Point(124, 155);
            this.NameButton.Name = "NameButton";
            this.NameButton.Size = new System.Drawing.Size(46, 30);
            this.NameButton.TabIndex = 1;
            this.NameButton.Text = "Enter";
            this.NameButton.UseVisualStyleBackColor = true;
            this.NameButton.Click += new System.EventHandler(this.NameButton_Click);
            // 
            // NameInput
            // 
            this.NameInput.Location = new System.Drawing.Point(7, 160);
            this.NameInput.Multiline = false;
            this.NameInput.Name = "NameInput";
            this.NameInput.Size = new System.Drawing.Size(111, 22);
            this.NameInput.TabIndex = 0;
            this.NameInput.Text = "Enter Name";
            this.NameInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NameInput_KeyDown);
            // 
            // EnterButton
            // 
            this.EnterButton.Location = new System.Drawing.Point(258, 473);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(91, 48);
            this.EnterButton.TabIndex = 0;
            this.EnterButton.Text = "Enter";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // serverInput
            // 
            this.serverInput.Location = new System.Drawing.Point(16, 15);
            this.serverInput.Name = "serverInput";
            this.serverInput.Size = new System.Drawing.Size(333, 452);
            this.serverInput.TabIndex = 3;
            this.serverInput.Text = "";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(571, 555);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ClientForm";
            this.Text = "whatsChat";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox UserInput;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox serverInput;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.Button EnterChat;
        private System.Windows.Forms.Button NameButton;
        private System.Windows.Forms.RichTextBox NameInput;
        private System.Windows.Forms.PictureBox UserIcon;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button LeaveChat;
        private System.Windows.Forms.ComboBox ServerSelectDropDown;
        private System.Windows.Forms.Label SelectServer;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RichTextBox OnlineNamesDisplay;
    }
}
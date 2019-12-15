using System;
using System.Windows.Forms;
using Packets;

namespace Client
{
    public partial class ClientForm : Form
    { 

        public SimpleClient.SimpleClient simpleclient;

        private delegate void UpdateChatWindowDelegate(string message, string From);
        private UpdateChatWindowDelegate _updateChatWindowDelgate;

        public delegate void UpdateWhosOnlineDelegate(NickNamePacket message);
        public UpdateWhosOnlineDelegate _updateWhosOnline;

        public delegate void UpdateNameDelegate(bool IsInUse);
        public UpdateNameDelegate _updateName;

        public delegate void updateServerLocation();
        public updateServerLocation _UpdateServerLocation;


        public string YourName = "";
        public string TempName = "";

        public ClientForm(SimpleClient.SimpleClient simpleclientPassIn)
        {
            simpleclient = simpleclientPassIn;
            InitializeComponent();
            _updateChatWindowDelgate = new UpdateChatWindowDelegate(UpdateChatWindow);
            _updateWhosOnline = new UpdateWhosOnlineDelegate(updateWhosOnline);
            _updateName = new UpdateNameDelegate(UpdateName);
            _UpdateServerLocation = new updateServerLocation(UpdateServerLocation);
        }

        public void UpdateServerLocation()
        {
            if (InvokeRequired)
                Invoke(_UpdateServerLocation);
            else
                ServerSelectDropDown.SelectedItem = "Server 1";
        }

        public void UpdateName(bool IsInUse)
        {
            if (InvokeRequired)
                Invoke(_updateName, IsInUse);
            else
            {
                if (IsInUse == true)
                {
                    serverInput.Text += "That Name Is In Use Please Select Another One" + Environment.NewLine;
                }
                else
                {
                    NameLabel.Text = TempName;
                }
            }
        }

        public void updateWhosOnline(NickNamePacket message)
        {
            if (OnlineNamesDisplay.InvokeRequired)
            {
                Invoke(_updateWhosOnline, message);
            }
            else
            {
                OnlineNamesDisplay.Clear();
                for (int i = 0; i < 10; i++)
                {
                    OnlineNamesDisplay.Text += message.Name[i] + Environment.NewLine;
                }

                DirectMessageBox.Items.Insert(0, "Server");
                DirectMessageBox.SelectedItem = "Server";

                for (int i = 1; i <= 10; i++)
                {
                    DirectMessageBox.Items.Insert(i, message.Name[i - 1]);
                }

                YourName = NameLabel.Text;
            }
        }

        public void UpdateChatWindow(string message, string From)
        {
            if (serverInput.InvokeRequired)
            {
                Invoke(_updateChatWindowDelgate, message, From);
            }
            else
            { 
                if (message != "un")
                {
                    serverInput.Text += From + ": " + message + Environment.NewLine;
                    serverInput.SelectionStart = serverInput.Text.Length;
                    serverInput.ScrollToCaret();
                }
            }
            
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            simpleclient.Run();
        }

        private void ClientForm_Close(object sender, EventArgs e)
        {
            simpleclient.Stop();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            if (UserInput.Text != "")
            {
                if (simpleclient.clientLocation != -1)
                {
                    if (ServerSelectDropDown.SelectedItem.ToString() != "Game Room 4" && ServerSelectDropDown.SelectedItem.ToString() != "Game Room 5")
                    {
                        string userInput = UserInput.Text;
                        if (UserInput.Text != "") //&& UserInput.Text[0] != '/')
                        {
                            ChatMessagePacket packet = new ChatMessagePacket(UserInput.Text, NameLabel.Text,
                                DirectMessageBox.SelectedItem.ToString());
                            simpleclient.TcpSend(packet);
                            UserInput.Text = "";
                        }

                        if (userInput[0] == '/')
                        {
                            ServerCommand packet = new ServerCommand(UserInput.Text);
                            simpleclient.TcpSend(packet);
                            UserInput.Text = "";
                        }
                    }
                    else
                    {
                        if (UserInput.Text != "")
                        {
                            RockPaperScissors packet = new RockPaperScissors(UserInput.Text);
                            simpleclient.TcpSend(packet);
                            UserInput.Text = "";
                        }
                    }
                }
                else
                {
                    serverInput.Text += "Please Enter a Channel" + Environment.NewLine;
                }
            }
            else
            {
                serverInput.Text += "Please Enter a Message" + Environment.NewLine;
            }
        }

        private void NameButton_Click(object sender, EventArgs e)
        {
            if (simpleclient.clientLocation != -1)
            {
                if (NameInput.Text != "")
                {
                    NickNamePacket packet = new NickNamePacket(NameInput.Text,0);
                    simpleclient.TcpSend(packet);
                    TempName = NameInput.Text;
                    NameInput.Text = "";
                }
            }
            else
            {
                serverInput.Text += "Please Enter a Channel" + Environment.NewLine;
            }
            
        }

        private void NameInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (simpleclient.clientLocation != -1)
            {
                if (e.KeyCode == Keys.Enter && NameInput.Text != "")
                {
                    NickNamePacket packet = new NickNamePacket(NameInput.Text, 0);
                    simpleclient.TcpSend(packet);
                    TempName = NameInput.Text;
                    NameInput.Text = "";
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            else
            {
                serverInput.Text += Environment.NewLine + "Please Enter a Channel";
            }
        }

        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (simpleclient.clientLocation != -1)
            {
                if (ServerSelectDropDown.SelectedItem.ToString() != "Game Room 4" && ServerSelectDropDown.SelectedItem.ToString() != "Game Room 5")
                {
                    string userInput = UserInput.Text;
                    if (e.KeyCode == Keys.Enter && UserInput.Text != "" && userInput[0] != '/')
                    {
                        ChatMessagePacket packet = new ChatMessagePacket(UserInput.Text, NameLabel.Text, DirectMessageBox.SelectedItem.ToString());
                        simpleclient.TcpSend(packet);
                        UserInput.Text = "";
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }

                    if (e.KeyCode == Keys.Enter && userInput[0] == '/')
                    {
                        ServerCommand packet = new ServerCommand(UserInput.Text);
                        simpleclient.TcpSend(packet);
                        UserInput.Text = "";
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && UserInput.Text != "")
                    {
                        RockPaperScissors packet = new RockPaperScissors(UserInput.Text);
                        simpleclient.TcpSend(packet);
                        UserInput.Text = "";
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                }
            }
            else
            {
                serverInput.Text += Environment.NewLine + "Please Enter a Channel";
            }
            
        }

        private void LeaveChat_Click(object sender, EventArgs e)
        {
            if (simpleclient.clientLocation != -1)
            {
                simpleclient.clientLocation = -1;
                LeaveChat.Text = "Close Client";
                OnlineNamesDisplay.Clear();
                NameInput.Text = "Enter Name";
                serverInput.Clear();
            }
            else
            {
                EndConnectionPacket Packet = new EndConnectionPacket("True");
                simpleclient.TcpSend(Packet);
                simpleclient.ShutDown = true;
                simpleclient.Stop();
                this.Close();
            }
        }

        private void EnterChat_Click(object sender, EventArgs e)
        { 
            ServerLocationPacket packet = new ServerLocationPacket(ServerSelectDropDown.SelectedItem.ToString(), ServerSelectDropDown.SelectedIndex);
            simpleclient.TcpSend(packet);
            LeaveChat.Text = "Leave Channel";
        }

        private void UserIcon_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UserIcon.ImageLocation = openFileDialog1.FileName;
        }

        private void ShowGameClick(object sender, EventArgs e)
        {
            simpleclient.game.ShowDialog();
        }
    }
}

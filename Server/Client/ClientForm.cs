using System;
using System.Windows.Forms;
using Packets;

namespace Client
{
    public partial class ClientForm : Form
    { 

        public SimpleClient.SimpleClient simpleclient;

        private delegate void UpdateChatWindowDelegate(string message);
        private UpdateChatWindowDelegate _updateChatWindowDelgate;

        public delegate void UpdateWhosOnlineDelegate(NickNamePacket message);
        public UpdateWhosOnlineDelegate _updateWhosOnline;

        public ClientForm(SimpleClient.SimpleClient simpleclientPassIn)
        {
            simpleclient = simpleclientPassIn;
            InitializeComponent();
            _updateChatWindowDelgate = new UpdateChatWindowDelegate(UpdateChatWindow);
            _updateWhosOnline = new UpdateWhosOnlineDelegate(updateWhosOnline);

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
            }
        }

        public void UpdateChatWindow(string message)
        {
            if (serverInput.InvokeRequired)
            {
                Invoke(_updateChatWindowDelgate, message);
            }
            else
            {
                if (message != "un")
                {
                    serverInput.Text += message + Environment.NewLine;
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
                    ChatMessagePacket packet = new ChatMessagePacket(UserInput.Text);
                    simpleclient.Send(packet);
                    UserInput.Text = "";
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
                    simpleclient.Send(packet);
                    NameLabel.Text = NameInput.Text;
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
                    simpleclient.Send(packet);
                    NameLabel.Text = NameInput.Text;
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
                if (e.KeyCode == Keys.Enter && UserInput.Text != "")
                {
                    ChatMessagePacket packet = new ChatMessagePacket(UserInput.Text);
                    simpleclient.Send(packet);
                    UserInput.Text = "";
                    e.Handled = true;
                    e.SuppressKeyPress = true;
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
                simpleclient.ShutDown = true;
                simpleclient.Stop();
                this.Close();
            }
        }

        private void EnterChat_Click(object sender, EventArgs e)
        {
            //simpleclient.SendMessage(("ssi" + ServerSelectDropDown.SelectedItem.ToString() + "|" + ServerSelectDropDown.SelectedIndex.ToString())); //ssi server selected index
            ServerLocationPacket packet = new ServerLocationPacket(ServerSelectDropDown.SelectedItem.ToString(), ServerSelectDropDown.SelectedIndex);
            simpleclient.Send(packet);
            LeaveChat.Text = "Leave Channel";
            //simpleclient.InputName(NameLabel.Text);
        }

        private void UserIcon_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                serverInput.Text = "worked";
            }
        }
    }
}

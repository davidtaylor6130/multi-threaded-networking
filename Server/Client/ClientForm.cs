using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleClient;
using System.Threading;

namespace Client
{

    public partial class ClientForm : Form
    {
        public SimpleClient.SimpleClient simpleclient;

        private delegate void UpdateChatWindowDelegate(string message);
        private UpdateChatWindowDelegate _updateChatWindowDelgate;

        public delegate void UpdateWhosOnlineDelegate(string message);
        public UpdateWhosOnlineDelegate _updateWhosOnline;

        public ClientForm(SimpleClient.SimpleClient simpleclientPassIn)
        {
            simpleclient = simpleclientPassIn;
            InitializeComponent();
            _updateChatWindowDelgate = new UpdateChatWindowDelegate(UpdateChatWindow);
            _updateWhosOnline = new UpdateWhosOnlineDelegate(updateWhosOnline);

        }

        public void updateWhosOnline(string message)
        {
            if (OnlineNamesDisplay.InvokeRequired)
            {
                Invoke(_updateWhosOnline, message);
            }
            else
            {
                OnlineNamesDisplay.Clear();
                message = message.Remove(0, 3);
                string nameToSend = message;
                int lastTrigger = 0;
                for (int i = 0; i < message.Length; i++)
                {
                    if (message[i] == '|')
                    {
                        nameToSend = message.Remove(i, message.Length - i);
                        nameToSend = nameToSend.Remove(0, lastTrigger);
                        lastTrigger = i;
                        OnlineNamesDisplay.Text += nameToSend + Environment.NewLine;
                    }
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
                    simpleclient.SendMessage(UserInput.Text);
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
                    simpleclient.InputName(NameInput.Text);
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
                    simpleclient.InputName(NameInput.Text);
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
                    simpleclient.SendMessage(UserInput.Text);
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
            simpleclient.SendMessage(("ssi" + ServerSelectDropDown.SelectedItem.ToString() + "|" + ServerSelectDropDown.SelectedIndex.ToString())); //ssi server selected index
            LeaveChat.Text = "Leave Channel";
            //simpleclient.InputName(NameLabel.Text);
        }
    }
}

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

        public ClientForm(SimpleClient.SimpleClient simpleclientPassIn)
        {
            simpleclient = simpleclientPassIn;
            InitializeComponent();
            _updateChatWindowDelgate = new UpdateChatWindowDelegate(UpdateChatWindow);
        }

        public void UpdateChatWindow(string message)
        {
            if (serverInput.InvokeRequired)
            {
                Invoke(_updateChatWindowDelgate, message);
            }
            else
            {
                serverInput.Text += Environment.NewLine + message;
                serverInput.SelectionStart = serverInput.Text.Length;
                serverInput.ScrollToCaret();
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
            if (simpleclient.clientLocation != -1 && UserInput.Text != "")
            {
                simpleclient.SendMessage(UserInput.Text);
                UserInput.Text = "";
            }
            else
            {
                serverInput.Text += Environment.NewLine + "Please Enter a Channel / Message";
            }
        }

        private void NameButton_Click(object sender, EventArgs e)
        {
            if (simpleclient.clientLocation != -1)
            {
                simpleclient.InputName(NameInput.Text);
                NameLabel.Text = NameInput.Text;
                NameInput.Text = "";
            }
            else
            {
                serverInput.Text += Environment.NewLine + "Please Enter a Channel";
            }
        }

        private void NameInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && simpleclient.clientLocation != -1)
            {
                if (NameInput.Text != "")
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
            if (e.KeyCode == Keys.Enter && simpleclient.clientLocation != -1 && UserInput.Text != "")
            {
                    simpleclient.SendMessage(UserInput.Text);
                    UserInput.Text = "";
                    e.Handled = true;
                    e.SuppressKeyPress = true;
            }
            else
            {
                serverInput.Text += Environment.NewLine + "Please Enter a Channel / message";
            }
        }

        private void LeaveChat_Click(object sender, EventArgs e)
        {
            if (simpleclient.clientLocation != -1)
            {
                simpleclient.clientLocation = -1;
                LeaveChat.Text = "Close Client";
            }
            else
            {
                simpleclient.ShutDown = true;
                simpleclient.Stop();
                this.Close();
            }
        }

        private void ServerSelectDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
           simpleclient.SendMessage( ("ssi" + ServerSelectDropDown.SelectedItem.ToString() + "|" + ServerSelectDropDown.SelectedIndex.ToString())); //ssi server selected index
           LeaveChat.Text = "Leave Channel";
        }
    }
}

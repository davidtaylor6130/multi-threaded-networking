using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class CheckersGame : Form
    {
        private SimpleClient.SimpleClient client;
        CheckersLogic checkersLogic = new CheckersLogic();

        private bool[,] nowMoving = new bool[2,12];

        public CheckersGame(SimpleClient.SimpleClient clientPassIn)
        {
            client = clientPassIn;
            InitializeComponent();
            RedChecker1.BackColor = Color.Transparent;
            RedChecker1.BorderStyle = BorderStyle.None;
            this.Hide();
        }

        private void CheckersGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void RedChecker1_MouseMove(object sender, MouseEventArgs e)
        {
            if (nowMoving[0,0] == true)
            {
                RedChecker1.Location = PointToClient(new Point(Cursor.Position.X - 30, Cursor.Position.Y - 30));
            }
        }

        private void RedChecker1_Click(object sender, EventArgs e)
        {
            if (nowMoving[0,0] == false)
            {
                nowMoving[0, 0] = true;
            }
            else
            {
                nowMoving[0, 0] = false;
            }
        }

        private void RedChecker2_Click(object sender, EventArgs e)
        {
            if (nowMoving[0, 1] == false)
            {
                nowMoving[0, 1] = true;
            }
            else
            {
                nowMoving[0, 1] = false;
            }
        }

        private void RedChecker2_MouseMove(object sender, MouseEventArgs e)
        {
            if (nowMoving[0, 1] == true)
            {
                RedChecker2.Location = PointToClient(new Point(Cursor.Position.X - 30, Cursor.Position.Y - 30));
            }
        }
    }
}

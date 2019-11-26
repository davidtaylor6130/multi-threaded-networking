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
using Packets;


namespace Client
{
    public partial class CheckersGame : Form
    {

        private delegate void UpdateOponentDelegate();
        private UpdateOponentDelegate _updateOponentDelegate;

        private SimpleClient.SimpleClient client;
        public Checkers game = new Checkers();

        public CheckersGame(SimpleClient.SimpleClient clientPassIn)
        {
            client = clientPassIn;
            InitializeComponent();
            RedChecker1.BackColor = Color.Transparent;
            RedChecker1.BorderStyle = BorderStyle.None;

            _updateOponentDelegate = new UpdateOponentDelegate(UpdateOponents);

            this.Hide();
        }

        private void CheckersGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            game.resetPosition();
            e.Cancel = true;
        }

        private void GiveUp_Click(object sender, EventArgs e)
        {
            game.resetPosition();
            this.Hide();
        }

        public void UpdateOponents()
        {
            if (InvokeRequired)
            {
                Invoke(_updateOponentDelegate);
            }
            else
            {
                GrayChecker1.Location = game.positions[1, 0];
            }
        }

        //--1--//
        private void RedChecker1_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.nowMoving[0,0] == true)
            {
                game.positions[0, 0] = RedChecker1.Location = PointToClient(new Point(Cursor.Position.X - 30, Cursor.Position.Y - 30));
                Packet temp = new GamePacket(game);
                client.UdpSend(temp);
            }
        }
        private void RedChecker1_Click(object sender, EventArgs e)
        {
            if (game.nowMoving[0, 0] == false)
            {
                game.nowMoving[0, 0] = true;
                if (game.King[0, 0] == false)
                {
                    RedChecker1.Image = Properties.Resources.player_1_Selected;
                }
                else
                {
                    RedChecker1.Image = Properties.Resources.player_1_King_Selected;
                }
            }
            else
            {
                game.nowMoving[0, 0] = false;
                if (game.King[0, 0] == false)
                {
                    RedChecker1.Image = Properties.Resources.player_1;
                }
                else
                {
                    RedChecker1.Image = Properties.Resources.player_1_King;
                }
            }
        }

        //--2--//
        private void RedChecker2_Click(object sender, EventArgs e)
        {
            if (game.nowMoving[0, 1] == false)
            {
                game.nowMoving[0, 1] = true;
                if (game.King[0, 1] == false)
                {
                    RedChecker2.Image = Properties.Resources.player_1_Selected;
                }
                else
                {
                    RedChecker2.Image = Properties.Resources.player_1_King_Selected;
                }
            }
            else
            {
                game.nowMoving[0, 1] = false;
                if (game.King[0, 1] == false)
                {
                    RedChecker2.Image = Properties.Resources.player_1;
                }
                else
                {
                    RedChecker2.Image = Properties.Resources.player_1_King;
                }
            }
        }
        private void RedChecker2_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.nowMoving[0, 1] == true)
            {
                game.positions[0, 1] = RedChecker2.Location = PointToClient(new Point(Cursor.Position.X - 30, Cursor.Position.Y - 30));
            }
        }

        //--3--//
        private void RedChecker3_Click(object sender, EventArgs e)
        {
            if (game.nowMoving[0, 2] == false)
            {
                game.nowMoving[0, 2] = true;
                if (game.King[0, 2] == false)
                {
                    RedChecker3.Image = Properties.Resources.player_1_Selected;
                }
                else
                {
                    RedChecker3.Image = Properties.Resources.player_1_King_Selected;
                }
            }
            else
            {
                game.nowMoving[0, 2] = false;
                if (game.King[0, 2] == false)
                {
                    RedChecker3.Image = Properties.Resources.player_1;
                }
                else
                {
                    RedChecker3.Image = Properties.Resources.player_1_King;
                }
            }
        }
        private void RedChecker3_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.nowMoving[0, 2] == true)
            {
                game.positions[0, 2] = RedChecker3.Location = PointToClient(new Point(Cursor.Position.X - 30, Cursor.Position.Y - 30));
            }
        }

        //--4--//
        private void RedChecker4_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.nowMoving[0, 3] == true)
            {
                game.positions[0, 3] = RedChecker4.Location = PointToClient(new Point(Cursor.Position.X - 30, Cursor.Position.Y - 30));
            }
        }
        private void RedChecker4_Click(object sender, EventArgs e)
        {
            if (game.nowMoving[0, 3] == false)
            {
                game.nowMoving[0, 3] = true;
                if (game.King[0, 3] == false)
                {
                    RedChecker4.Image = Properties.Resources.player_1_Selected;
                }
                else
                {
                    RedChecker4.Image = Properties.Resources.player_1_King_Selected;
                }
            }
            else
            {
                game.nowMoving[0, 3] = false;
                if (game.King[0, 3] == false)
                {
                    RedChecker4.Image = Properties.Resources.player_1;
                }
                else
                {
                    RedChecker4.Image = Properties.Resources.player_1_King;
                }
            }
        }

        //--5--//
        private void RedChecker5_Click(object sender, EventArgs e)
        {
            if (game.nowMoving[0, 4] == false)
            {
                game.nowMoving[0, 4] = true;
                if (game.King[0, 4] == false)
                {
                    RedChecker5.Image = Properties.Resources.player_1_Selected;
                }
                else
                {
                    RedChecker5.Image = Properties.Resources.player_1_King_Selected;
                }
            }
            else
            { 
                game.nowMoving[0, 4] = false;
                if (game.King[0, 4] == false)
                {
                    RedChecker5.Image = Properties.Resources.player_1;
                }
                else
                {
                    RedChecker5.Image = Properties.Resources.player_1_King;
                }
            }
        }
        private void RedChecker5_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.nowMoving[0, 4] == true)
            {
                game.positions[0, 4] = RedChecker5.Location = PointToClient(new Point(Cursor.Position.X - 30, Cursor.Position.Y - 30));
            }
        }

        //--6--//
        private void RedChecker6_Click(object sender, EventArgs e)
        {
            if (game.nowMoving[0, 5] == false)
            {
                game.nowMoving[0, 5] = true;
                if (game.King[0, 5] == false)
                {
                    RedChecker6.Image = Properties.Resources.player_1_Selected;
                }
                else
                {
                    RedChecker6.Image = Properties.Resources.player_1_King_Selected;
                }
            }
            else
            {
                game.nowMoving[0, 5] = false;
                if (game.King[0, 5] == false)
                {
                    RedChecker6.Image = Properties.Resources.player_1;
                }
                else
                {
                    RedChecker6.Image = Properties.Resources.player_1_King;
                }
            }
        }
        private void RedChecker6_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.nowMoving[0, 5] == true)
            {
                game.positions[0, 5] = RedChecker6.Location = PointToClient(new Point(Cursor.Position.X - 30, Cursor.Position.Y - 30));
            }
        }

        //--7--//
        private void RedChecker7_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.nowMoving[0, 6] == true)
            {
                game.positions[0, 6] = RedChecker7.Location = PointToClient(new Point(Cursor.Position.X - 30, Cursor.Position.Y - 30));
            }
        }
        private void RedChecker7_Click(object sender, EventArgs e)
        {
            if (game.nowMoving[0, 6] == false)
            {
                game.nowMoving[0, 6] = true;
                if (game.King[0, 6] == false)
                {
                    RedChecker7.Image = Properties.Resources.player_1_Selected;
                }
                else
                {
                    RedChecker7.Image = Properties.Resources.player_1_King_Selected;
                }
            }
            else
            {
                game.nowMoving[0, 6] = false;
                if (game.King[0, 6] == false)
                {
                    RedChecker7.Image = Properties.Resources.player_1;
                }
                else
                {
                    RedChecker7.Image = Properties.Resources.player_1_King;
                }
            }
        }

        //--8--//
        private void RedChecker8_Click(object sender, EventArgs e)
        {
            if (game.nowMoving[0, 7] == false)
            {
                game.nowMoving[0, 7] = true;
                if (game.King[0, 7] == false)
                {
                    RedChecker8.Image = Properties.Resources.player_1_Selected;
                }
                else
                {
                    RedChecker8.Image = Properties.Resources.player_1_King_Selected;
                }
            }
            else
            {
                game.nowMoving[0, 7] = false;
                if (game.King[0, 7] == false)
                {
                    RedChecker8.Image = Properties.Resources.player_1;
                }
                else
                {
                    RedChecker8.Image = Properties.Resources.player_1_King;
                }
            }
        }
        private void RedChecker8_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.nowMoving[0, 7] == true)
            {
                game.positions[0, 7] = RedChecker8.Location = PointToClient(new Point(Cursor.Position.X - 30, Cursor.Position.Y - 30));
            }
        }

        //--9--//
        private void RedChecker9_Click(object sender, EventArgs e)
        {
            if (game.nowMoving[0, 8] == false)
            {
                game.nowMoving[0, 8] = true;
                if (game.King[0, 8] == false)
                {
                    RedChecker9.Image = Properties.Resources.player_1_Selected;
                }
                else
                {
                    RedChecker9.Image = Properties.Resources.player_1_King_Selected;
                }
            }
            else
            {
                game.nowMoving[0, 8] = false;
                if (game.King[0, 8] == false)
                {
                    RedChecker9.Image = Properties.Resources.player_1;
                }
                else
                {
                    RedChecker9.Image = Properties.Resources.player_1_King;
                }
            }
        }
        private void RedChecker9_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.nowMoving[0, 8] == true)
            {
                game.positions[0, 8] = RedChecker9.Location = PointToClient(new Point(Cursor.Position.X - 30, Cursor.Position.Y - 30));
            }
        }

        //--10--//
        private void RedChecker10_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.nowMoving[0, 9] == true)
            {
                game.positions[0, 9] = RedChecker10.Location = PointToClient(new Point(Cursor.Position.X - 30, Cursor.Position.Y - 30));
            }
        }
        private void RedChecker10_Click(object sender, EventArgs e)
        {
            if (game.nowMoving[0, 9] == false)
            {
                game.nowMoving[0, 9] = true;
                if (game.King[0, 9] == false)
                {
                    RedChecker10.Image = Properties.Resources.player_1_Selected;
                }
                else
                {
                    RedChecker10.Image = Properties.Resources.player_1_King_Selected;
                }
            }
            else
            {
                game.nowMoving[0, 9] = false;
                if (game.King[0, 9] == false)
                {
                    RedChecker10.Image = Properties.Resources.player_1;
                }
                else
                {
                    RedChecker10.Image = Properties.Resources.player_1_King;
                }
            }
        }

        //--11--//
        private void RedChecker11_Click(object sender, EventArgs e)
        {
            if (game.nowMoving[0, 10] == false)
            {
                game.nowMoving[0, 10] = true;
                if (game.King[0, 10] == false)
                {
                    RedChecker11.Image = Properties.Resources.player_1_Selected;
                }
                else
                {
                    RedChecker11.Image = Properties.Resources.player_1_King_Selected;
                }
            }
            else
            {
                game.nowMoving[0, 10] = false;
                if (game.King[0, 10] == false)
                {
                    RedChecker11.Image = Properties.Resources.player_1;
                }
                else
                {
                    RedChecker11.Image = Properties.Resources.player_1_King;
                }
            }
        }
        private void RedChecker11_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.nowMoving[0, 10] == true)
            {
                game.positions[0, 10] = RedChecker11.Location = PointToClient(new Point(Cursor.Position.X - 30, Cursor.Position.Y - 30));
            }
        }

        //--12--//
        private void RedChecker12_Click(object sender, EventArgs e)
        {
            if (game.nowMoving[0, 11] == false)
            {
                game.nowMoving[0, 11] = true;
                if (game.King[0, 11] == false)
                {
                    RedChecker12.Image = Properties.Resources.player_1_Selected;
                }
                else
                {
                    RedChecker12.Image = Properties.Resources.player_1_King_Selected;
                }
            }
            else
            {
                game.nowMoving[0, 11] = false;
                if (game.King[0, 11] == false)
                {
                    RedChecker12.Image = Properties.Resources.player_1;
                }
                else
                {
                    RedChecker12.Image = Properties.Resources.player_1_King;
                }
            }
        }
        private void RedChecker12_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.nowMoving[0, 11] == true)
            {
                game.positions[0, 11] = RedChecker12.Location = PointToClient(new Point(Cursor.Position.X - 30, Cursor.Position.Y - 30));
            }
        }
    }
}

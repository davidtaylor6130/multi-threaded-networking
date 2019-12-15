using System;
using System.Drawing;
using System.Windows.Forms;
using Packets;


namespace Client
{
    public partial class CheckersGame : Form
    {
        public string player1Name, player2Name;
        private delegate void UpdateOponentDelegate();
        private UpdateOponentDelegate _updateOponentDelegate;

        private delegate void UpdateNamesDeligate();
        private UpdateNamesDeligate _updateNamesDeligate;

        public string WhosGoUsername = "";
        public string YourName = "";
        private SimpleClient.SimpleClient client;
        public Checkers game = new Checkers();
        public PictureBox[,] img = new PictureBox[2,12];
        private Point lastMousePoint = new Point(0,0);

        public CheckersGame(SimpleClient.SimpleClient clientPassIn)
        {
            client = clientPassIn;
            InitializeComponent();
            RedChecker1.BackColor = Color.Transparent;
            RedChecker1.BorderStyle = BorderStyle.None;

            _updateOponentDelegate = new UpdateOponentDelegate(UpdateOponents);
            _updateNamesDeligate = new UpdateNamesDeligate(UpdateNames);

            img[0, 0] = RedChecker1;
            img[0, 1] = RedChecker2;
            img[0, 2] = RedChecker3;
            img[0, 3] = RedChecker4;
            img[0, 4] = RedChecker5;
            img[0, 5] = RedChecker6;
            img[0, 6] = RedChecker7;
            img[0, 7] = RedChecker8;
            img[0, 8] = RedChecker9;
            img[0, 9] = RedChecker10;
            img[0, 10] = RedChecker11;
            img[0, 11] = RedChecker12;
            
            img[1, 0] = GrayChecker1;
            img[1, 1] = GrayChecker2;
            img[1, 2] = GrayChecker3;
            img[1, 3] = GrayChecker4;
            img[1, 4] = GrayChecker5;
            img[1, 5] = GrayChecker6;
            img[1, 6] = GrayChecker7;
            img[1, 7] = GrayChecker8;
            img[1, 8] = GrayChecker9;
            img[1, 9] = GrayChecker10;
            img[1, 10] = GrayChecker11;
            img[1, 11] = GrayChecker12;

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 12; j++)
                {
                    game.positions[i, j] = img[i, j].Location;
                }

            game.sizeOfBoard = new Point(GameBoard.Width, GameBoard.Height);

            Hide();
        }

        public void UpdateNames()
        {
            if (InvokeRequired)
                Invoke(_updateNamesDeligate);
            else
            {
                Gamer1Name.Text = player1Name;
                Gamer2Name.Text = player2Name;
                WhosGo.Text = WhosGoUsername;
            }
        }

        private void CheckersGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            game.resetPosition();
            
            e.Cancel = true;
        }

        private void GiveUp_Click(object sender, EventArgs e)
        {
            game.resetPosition();
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 12; j++)
                {
                    img[i, j].Location = game.positions[i, j];
                } 
            Hide();
        }

        public void UpdateOponents()
        {
            if (InvokeRequired)
                Invoke(_updateOponentDelegate);
            else
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 12; j++)
                    {
                        if (game.nowMoving[i, j] == true)
                            img[i, j].Location = game.positions[i, j];
                    }
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            Point currentMousePoint = PointToClient(new Point(Cursor.Position.X - 30, Cursor.Position.Y - 30));
            Point mouseMovementVector = new Point(lastMousePoint.X - currentMousePoint.X, lastMousePoint.Y - currentMousePoint.Y);

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 12; j++)
                    if (sender.Equals(img[i, j]))
                      if (game.nowMoving[i, j] == true)
                      {
                          game.MovementVectors[i, j] = mouseMovementVector; 
                          img[i,j].Location = new Point(img[i, j].Location.X - mouseMovementVector.X, img[i, j].Location.Y - mouseMovementVector.Y);
                          Packet temp = new GamePacket(game);
                          client.UdpSend(temp);
                      }

            lastMousePoint = currentMousePoint;
            Console.WriteLine(lastMousePoint + ":" + currentMousePoint + ":" + mouseMovementVector);

            currentMousePoint.X = 0;
            currentMousePoint.Y = 0;
            mouseMovementVector.X = 0;
            mouseMovementVector.Y = 0;
        }

        private void DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 12; j++)
                    if (sender.Equals(img[i, j]))
                    {
                        if (game.King[i, j] == false)
                        {
                            game.King[i, j] = true;
                            img[i, j].Image = Properties.Resources.player_1_King;
                        }
                        else
                        {
                            game.King[i, j] = false;
                            img[i, j].Image = Properties.Resources.player_1;
                        }
                    }
        }

        private void FinishGo_Click(object sender, EventArgs e)
        { 
            game.YourTurnTrue = false;
            game.ThereTurnTure = true;
            if (player1Name == YourName)
            {
                WhosGo.Text = player2Name;
                Packet packet = new TurnToggle(true, player2Name);
                client.UdpSend(packet);
            }
            else if (player2Name == YourName)
            {
                WhosGo.Text = player1Name;
                Packet packet = new TurnToggle(true, player1Name);
                client.UdpSend(packet);
            }
        }

        //private void CheckersGame_Load(object sender, EventArgs e)
        //{
        //   // RedChecker1.Parent = GameBoard;
        //   // RedChecker1.BackColor = Color.Transparent;
            
        //}

        private void click(object sender, EventArgs e)
        {
            if (game.YourTurnTrue)
            {
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 12; j++)
                        if (sender.Equals(img[i, j]))
                            if (game.nowMoving[i, j] == false)
                            {
                                img[i, j].BringToFront();
                                game.nowMoving[i, j] = true;
                                if (game.King[i, j] == false)
                                    img[i, j].Image = Properties.Resources.player_1_Selected;
                                else
                                    img[i, j].Image = Properties.Resources.player_1_King_Selected;
                            }
                            else
                            {
                                img[i, j].BringToFront();
                                game.nowMoving[i, j] = false;
                                if (game.King[i, j] == false)
                                    img[i, j].Image = Properties.Resources.player_1;
                                else
                                    img[i, j].Image = Properties.Resources.player_1_King;
                            }
            }
        }
    }
}

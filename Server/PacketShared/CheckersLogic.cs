using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client
{
    [Serializable]
    public class Checkers
    {
        public bool[,] nowMoving = new bool[2, 12];
        public bool[,] King = new bool[2, 12];
        public Point[,] positions = new Point[2, 12];
        public Point[,] MovementVectors = new Point[2, 12];
        public Point sizeOfBoard = new Point(0,0);
        public bool YourTurnTrue = false;
        public bool ThereTurnTure = false;

        public Checkers()
        {
            for (int i = 0; i < 2; i++)
                for (int k = 0; k < 12; k++)
                {
                    nowMoving[i, k] = false;
                    King[i, k] = false;
                }
            resetPosition();
        }

        public void resetPosition()
        {
            positions[0, 0] = new Point(16, 419);
            positions[0, 1] = new Point(191, 419);
            positions[0, 2] = new Point(367, 419);
            positions[0, 3] = new Point(544, 419);

            positions[0, 4] = new Point(103, 501);
            positions[0, 5] = new Point(280, 501);
            positions[0, 6] = new Point(455, 501);
            positions[0, 7] = new Point(632, 501);

            positions[0, 8] = new Point(16, 583);
            positions[0, 9] = new Point(191, 583);
            positions[0, 10] = new Point(367, 583);
            positions[0, 11] = new Point(544, 583);

            positions[1, 0] = new Point(103, 10);
            positions[1, 1] = new Point(280, 10);
            positions[1, 2] = new Point(455, 10);
            positions[1, 3] = new Point(632, 10);

            positions[1, 4] = new Point(16, 93);
            positions[1, 5] = new Point(191, 93);
            positions[1, 6] = new Point(367, 93);
            positions[1, 7] = new Point(544, 93);

            positions[1, 8] = new Point(103, 174);
            positions[1, 9] = new Point(280, 174);
            positions[1, 10] = new Point(455, 174);
            positions[1, 11] = new Point(632, 174);
        }

        public void updatePositions (Checkers passIn)
        {
            int reverse = 11;
            for (int i = 0; i < 12; i++)
            {
                positions[1,reverse] = new Point(positions[1, reverse].X - (-(passIn.MovementVectors[0,i].X)), positions[1, reverse].Y - (-(passIn.MovementVectors[0, i].Y)));
                //Console.WriteLine(passIn.positions[1,11]);
                nowMoving[1, reverse] = passIn.nowMoving[0, i];
                King[1, reverse] = passIn.King[0, i];
                reverse--;
            }
        }
    }
}

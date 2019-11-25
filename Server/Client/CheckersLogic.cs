using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    class CheckersLogic
    {

        public void moveWithMouse(PictureBox follower)
        {
            follower.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
        }

    }
}

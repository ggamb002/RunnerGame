using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace RunnerGame
{
    public class Collision
    {
        Vector2 topRight;
        //More points for more precision

        public Collision(Rectangle ship)
        {
            topRight = new Vector2(ship.X + ship.Width, ship.Y);
        }

        public void Update(Vector2 newPos)
        {
            topRight = newPos;                                                 
        }

        public bool checkCollision(Rectangle obstacle)
        {
            return (topRight.X > obstacle.X 
                && topRight.X < obstacle.X + obstacle.Width
                && topRight.Y < obstacle.Y + obstacle.Height 
                && topRight.Y > obstacle.Y);
        }

    }
}

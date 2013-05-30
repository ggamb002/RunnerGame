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
        Rectangle player;

        /// <summary>
        /// Collision checker for player and current obstacle
        /// </summary>
        /// <param name="ship"></param>
        public Collision(Rectangle ship)
        {
            player   = ship;
        }

        /// <summary>
        /// Updates the position of points to check
        /// </summary>
        /// <param name="newPos"></param>
        public void Update(Point loc)
        {
            player.Location = loc;                                      
        }

        /// <summary>
        /// Checks whether collision has occured
        /// </summary>
        /// <param name="obstacle"></param>
        /// <returns></returns>
        public bool checkCollision(Rectangle obstacle)
        {
            if (obstacle.Center.X - player.Center.X > 
                obstacle.Width/2 + player.Width/2)
                return false;
            else
                return player.Intersects(obstacle);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace RunnerGame
{
    public class Ship
    {
        public Texture2D Texture { get; set; }
        public Rectangle box;
        public int Rows { get; set; }
        public int Columns { get; set; }
        //private int currentFrame;
        private int totalFrames;
        private Vector2 prevLocation;
        public Vector2 location;
        private Vector2 windowDimensions;
        private int speed;
        private bool alive;
        private double scale;

        public Ship(Texture2D texture, int rows, int columns, Vector2 loc, Vector2 win)
        {
            Texture          = texture;
            Rows             = rows;
            Columns          = columns;
            //currentFrame   = 0;
            totalFrames      = columns;
            location         = loc;
            windowDimensions = win;
            speed            = 7;
            alive            = true;
            scale            = .5;
            box              = new Rectangle((int)location.X, (int)location.Y, 
                                (int)(texture.Width * scale), 
                                (int)(texture.Height * scale));
        }

        /// <summary>
        /// Initialize the ship at start point
        /// </summary>
        public void Initialize()
        {
            location = new Vector2(50, windowDimensions.Y / 2);
            box.Location = new Point((int)location.X, (int)location.Y);
            alive = true;
        }
        
        /// <summary>
        /// Currently does nothing, maybe something later
        /// </summary>
 
        public void Update()
        {
            //Debug.WriteLine(location.X + "," + location.Y);
            //Debug.WriteLine(windowDimensions.X + "," + windowDimensions.Y);
        }

        /// <summary>
        /// Moves the ship up and stops at the top of the visible game window
        /// </summary>
        public void goUp()
        {
            if (alive)
            {
                prevLocation = location;
                location.Y -= speed;
                box.Location = new Point((int)location.X,(int)location.Y);
            }

            if (location.Y <= 0)
                undoMove();
        }

        /// <summary>
        /// Moves the ship down and stops at the bottom of the visible game window
        /// </summary>
        public void goDown()
        {
            if (alive)
            {
                prevLocation = location;
                location.Y += speed;
                box.Location = new Point((int)location.X, (int)location.Y);
            }

            if (location.Y + box.Height >= windowDimensions.Y)
                undoMove();
        }

        /// <summary>
        /// Moves the ship right within bounds, should not be used
        /// </summary>
        public void goRight()
        {
            if (alive)
            {
                prevLocation = location;
                location.X += speed;
            }
            if (location.X + Texture.Width >= windowDimensions.X)
                undoMove();

        }

        /// <summary>
        /// Moves the ship left within bounds, should not be used
        /// </summary>
 
        public void goLeft()
        {
            if (alive)
            {
                prevLocation = location;
                location.X -= speed;
            }
            if (location.X <= 0)
                undoMove();
        }

        /// <summary>
        /// Moves the ship back if crosses the game window bounds
        /// </summary>
        private void undoMove()
        {
            location = prevLocation;
        }

        /// <summary>
        /// Draws the sprite to the destRectangle member of this class
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture,box,Color.White);
            spriteBatch.End();
        }

        /// <summary>
        /// Kills the ship, probably unnecessary right now, maybe does more later
        /// </summary>
        public void Die()
        {
            alive = false;
        }

    }
}

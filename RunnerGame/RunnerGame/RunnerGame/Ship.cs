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
        public Texture2D Texture {get; set;}
        public int Rows {get; set; }
        public int Columns {get; set; }
        //private int currentFrame;
        private int totalFrames;
        private Vector2 prevLocation;
        public Vector2 location;
        private Vector2 windowDimensions;
        private int speed;
        private bool alive;
       
        public Ship(Texture2D texture, int rows, int columns, Vector2 loc, Vector2 win )
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            //currentFrame = 0;
            totalFrames = columns;
            location = loc;
            windowDimensions = win;
            speed = 5;
            alive = true;
        }
       
        public void Update()
        {
            //Debug.WriteLine(location.X + "," + location.Y);
            //Debug.WriteLine(windowDimensions.X + "," + windowDimensions.Y);
        }

        public void goUp()
        {
            if (alive)
            {
                prevLocation = location;
                location.Y -= speed;
            }

            if (location.Y <= 0)
                undoMove();
        }

        public void goDown()
        {
            if (alive)
            {
                prevLocation = location;
                location.Y += speed;
            }

            if (location.Y + Texture.Height >= windowDimensions.Y)
                undoMove();
        }

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
        
        private void undoMove()
        {
            location = prevLocation;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, new Rectangle((int)location.X, (int)location.Y, Texture.Width, Texture.Height), Color.White);
            spriteBatch.End();
        }

        public void Die()
        {
            alive = false;
        }

    }
}

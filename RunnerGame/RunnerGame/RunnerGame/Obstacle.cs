using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace RunnerGame
{
    public class Obstacle
    {
        public Texture2D Texture;
        public Rectangle box;
        public Vector2 location;
        private Vector2 windowDimensions;
        public int movSpeed;
        public bool moving;
        private double scale;

        /// <summary>
        /// Obstacle object used by generator
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="win"></param>
        /// <param name="type"></param>
        /// <param name="mov"></param>
        public Obstacle(Texture2D texture, Vector2 win, int type, int mov)
        {
            Texture           = texture;
            windowDimensions  = win;
            location          = setType(type);
            movSpeed          = mov;
            moving            = true;
            scale             = .5;
            box               = new Rectangle((int)location.X, (int)location.Y,
                                (int)(texture.Width * scale),
                                (int)(texture.Height * scale));
        }

        /// <summary>
        /// Moves the obstacle to the left at the current speed
        /// </summary>
        private void moveLeft()
        {
            location.X -= movSpeed;
            box.Location = new Point((int)location.X,(int)location.Y);
        }

        /// <summary>
        /// Increases the speed of movement, not used
        /// </summary>
        /// <param name="inc"></param>
        public void upSpeed(int inc)
        {
            movSpeed += inc;
        }

        /// <summary>
        /// Returns the position of an obstacle based on
        /// results of RNG
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private Vector2 setType(int type)
        {
            Vector2 loc;
            switch (type)
            {
                case 0:
                    loc = new Vector2(800, 200);
                    break;
                case 1:
                    loc = new Vector2(800, 240);
                    break;
                case 2:
                    loc = new Vector2(800, 300);
                    break;
                case 3:
                    loc = new Vector2(800, 0);
                    break;
                case 4:
                    loc = new Vector2(800, -100);
                    break;
                case 5:
                    loc = new Vector2(800, -150);
                    break;
                default:
                    Debug.WriteLine("Invalid Block Type");
                    loc = new Vector2(800, 0);
                    break;
            }
            return loc;
        }

        /// <summary>
        /// Updates the position of the obstacle on the screen
        /// </summary>
        public void Update()
        {
            //Debug.WriteLine(location.X);

            if (location.X >= -box.Width)
                moveLeft();
            else
                moving = false;
        }

        /// <summary>
        /// Draws the sprite to the destRect
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, box, Color.White);
        }
    }
}

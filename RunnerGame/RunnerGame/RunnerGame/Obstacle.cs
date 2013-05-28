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

        public Obstacle(Texture2D texture, Vector2 win, int type, int mov)
        {
            Texture          = texture;
            windowDimensions = win;
            location         = setType(type);
            movSpeed         = mov;
            moving           = true;
        }

        //Moves the obstacle to the left at the current speed
        private void moveLeft()
        {
            location.X -= movSpeed;
        }

        //Increases the speed of movement, not used
        public void upSpeed(int inc)
        {
            movSpeed += inc;
        }

        //Returns
        private Vector2 setType(int type)
        {
            Vector2 loc;
            switch (type)
            {
                case 0:
                    loc = new Vector2(800, 120);
                    break;
                case 1:
                    loc = new Vector2(800, 240);
                    break;
                case 2:
                    loc = new Vector2(800, 300);
                    break;
                case 3:
                    loc = new Vector2(800, -300);
                    break;
                case 4:
                    loc = new Vector2(800, -440);
                    break;
                case 5:
                    loc = new Vector2(800, -550);
                    break;
                default:
                    Debug.WriteLine("Invalid Block Type");
                    loc = new Vector2(800, 0);
                    break;
            }
            return loc;
        }

        public void Update()
        {
            //Debug.WriteLine(location.X);

            if (location.X >= -Texture.Width)
                moveLeft();
            else
                moving = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, 
                new Rectangle((int)location.X, (int)location.Y, 
                    (int)(Texture.Width),(int)(Texture.Height)), 
                Color.White);
        }
    }
}

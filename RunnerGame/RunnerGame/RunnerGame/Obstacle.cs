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
        private Vector2 location;
        private Vector2 windowDimensions;
        public bool moving;

        public Obstacle(Texture2D texture, Vector2 win, int type)
        {
            Texture = texture;
            windowDimensions = win;
            location = setType(type);
            moving = true;
        }

        private void moveLeft()
        {
            location.X -= 5;
        }

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
            //spriteBatch.Begin();
            spriteBatch.Draw(Texture,new Rectangle((int)location.X,(int)location.Y,Texture.Width,Texture.Height),Color.White);
            //spriteBatch.End();
        }
    }
}

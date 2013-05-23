using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace RunnerGame
{
    class Generator
    {
        private List<Obstacle> walls;
        private Texture2D texture;
        private Vector2 windowDimensions;
        private Random rand;
        private bool run;
        public int numWalls;
        private int currentSpeed;

        public Generator(Texture2D tex, Vector2 win)
        {
            walls            = new List<Obstacle>(5);
            texture          = tex;
            windowDimensions = win;
            rand             = new Random();
            run              = true;
            numWalls         = 0;
            currentSpeed     = 0;
            this.populate(texture, windowDimensions);
        }

        public void Initialize()
        {
            walls.RemoveAt(0);
            this.newWall();
            run = true;
        }

        private void populate(Texture2D texture, Vector2 win)
        {
            while (walls.Count() < walls.Capacity)
            {
                int type = rand.Next(0, 5);
                walls.Add(new Obstacle(texture, win, type, 2));
            }
        }

        private void newWall()
        {
            int type = rand.Next(0, 5);
            if (numWalls % 5 == 0)
            {
                currentSpeed += (int)(currentSpeed*.2)+2;
            }
            Debug.WriteLine(currentSpeed);
            walls.Add(new Obstacle(texture, 
                        windowDimensions, 
                        type,
                        currentSpeed));
        }

        public void Update()
        {
            if (!run)
                return;

            walls[0].Update();
            if (!walls[0].moving)
            {
                walls.RemoveAt(0);
                this.newWall();
                numWalls++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            walls[0].Draw(spriteBatch);
            spriteBatch.End();
        }

        public Rectangle getWall()
        {
            return new Rectangle((int)walls[0].location.X, 
                (int)walls[0].location.Y, 
                walls[0].Texture.Width, 
                walls[0].Texture.Height);
        }

        public void Stop()
        {
            run = false;
            numWalls = 0;
            walls.Clear();
            this.populate(texture,windowDimensions);
        }
    }
}

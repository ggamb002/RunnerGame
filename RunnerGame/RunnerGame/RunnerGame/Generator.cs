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

        public Generator(Texture2D tex,Vector2 win)
        {
            rand = new Random();
            walls = new List<Obstacle>(10);
            texture = tex;
            windowDimensions = win;
            run = true;
            this.populate(texture,windowDimensions);
        }

        private void populate(Texture2D texture, Vector2 win)
        {
            //Random rand = new Random();
            while (walls.Count() < walls.Capacity)
            {
                int type = rand.Next(0,5);
                //Debug.WriteLine(type);
                walls.Add(new Obstacle(texture, win,type));
            }
        }

        private void newWall()
        {
            //Random rand = new Random();
            int type = rand.Next(0, 5);
            //Debug.WriteLine(type);
            walls.Add(new Obstacle(texture, windowDimensions, type));
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
            return new Rectangle( (int)walls[0].location.X, (int)walls[0].location.Y, walls[0].Texture.Width, walls[0].Texture.Height);
        }

        public void Stop()
        {
            run = false; 
        }
    }
}

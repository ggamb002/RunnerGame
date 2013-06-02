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

        /// <summary>
        /// Generates and updates a list of obstacles used in the game
        /// </summary>
        /// <param name="tex"></param>
        /// <param name="win"></param>
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

        /// <summary>
        /// Resets the generator to its initial state
        /// </summary>
        public void Initialize()
        {
            walls.Clear();
            this.populate(texture, windowDimensions);
            run = true;
        }

        /// <summary>
        /// Populates the obstacle list with an initial amount of obstacles
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="win"></param>
        private void populate(Texture2D texture, Vector2 win)
        {
            while (walls.Count() < walls.Capacity)
            {
                int type = rand.Next(0, 5);
                walls.Add(new Obstacle(texture, win, type, 2));
            }
        }

        /// <summary>
        /// Creates a random obstacle and adds it to list
        /// Checks num of passed obstacles and speeds up if necessary
        /// </summary>
        private void newWall()
        {
            int type = rand.Next(0, 5);
            if (numWalls % 5 == 0)
            {
                currentSpeed += 4;
            }
            Debug.WriteLine(currentSpeed);
            walls.Add(new Obstacle(texture, 
                        windowDimensions, 
                        type,
                        currentSpeed));
        }

        /// <summary>
        /// Checks if game is running and updates the current obstacle and list
        /// </summary>
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

        /// <summary>
        /// Draws the front of the list to the screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            walls[0].Draw(spriteBatch);
            spriteBatch.End();
        }

        /// <summary>
        /// Gets the rectangle of current obstacle being used
        /// </summary>
        /// <returns></returns>
        public Rectangle getWall()
        {
            return walls[0].box;
        }

        /// <summary>
        /// Stops the generator from running or creating new obstacles
        /// </summary>
        public void Stop()
        {
            run = false;
            numWalls = 0;
        }
    }
}

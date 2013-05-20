using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace RunnerGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Ship ship;
        private Generator generator;
        private Collision collider;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Vector2 windowDimensions = new Vector2(this.GraphicsDevice.Viewport.Width,this.GraphicsDevice.Viewport.Height);

            Texture2D textureShip = Content.Load<Texture2D>("ship1");
            ship = new Ship(textureShip, 1, 1, new Vector2(50,240), windowDimensions );

            Texture2D textureObstacle = Content.Load<Texture2D>("sprite2");
            generator = new Generator(textureObstacle, windowDimensions);

            collider = new Collision(new Rectangle((int)ship.location.X,(int)ship.location.Y,ship.Texture.Width,ship.Texture.Height));
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            KeyboardState state = Keyboard.GetState();

            //Allow user to exit game
            if (state.IsKeyDown(Keys.Escape))
                this.Exit();

            //Move the Ship if U/D/L/R
            if (state.IsKeyDown(Keys.Up))
                ship.goUp();
            if (state.IsKeyDown(Keys.Down))
                ship.goDown();
            if (state.IsKeyDown(Keys.Left))
                ship.goLeft();
            if (state.IsKeyDown(Keys.Right))
                ship.goRight();

            //Update the ship
            ship.Update();
            //Check for collisions 
            collider.Update(new Vector2(ship.location.X + ship.Texture.Width, ship.location.Y));
            //Update the generator and create new obstacles if necessary
            generator.Update();

            //If a collision has occured then kill the ship and stop the generator
            if (collider.checkCollision(generator.getWall()))
            {
                Debug.WriteLine("Colliding");
                ship.Die();
                generator.Stop();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            ship.Draw(spriteBatch);
            generator.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Arkanoid
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public int X0, Y0, Width, Height;
        public GameProcess gameProcess;
        UserInterface userInterface;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameProcess = new GameProcess();
            userInterface = new UserInterface();
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
            //graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            //graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            Width = 1024;
            Height = GraphicsDevice.DisplayMode.Height;
            X0 = (GraphicsDevice.DisplayMode.Width/ 2)-(Height/2)-32*3;
            Y0 = 0;
            gameProcess.Initialize(this);
            userInterface.Initialize(this);
            Mouse.SetCursor(MouseCursor.Arrow);
            IsMouseVisible = true;
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
            gameProcess.LoadContent();
            userInterface.LoadContent();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            gameProcess.UnloadContent();
            userInterface.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            KeyboardState kstate = Keyboard.GetState();
            gameProcess.Update(kstate, gameTime);
            userInterface.Update(kstate, gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSlateBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            gameProcess.Draw(spriteBatch);
            userInterface.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

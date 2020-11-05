using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arkanoid
{
    public class GameProcess
    {
        
        internal Paddle paddle;
        internal Ball ball;        
        internal Level level;
        private Game1 game;
        bool active = false;
        bool visible = false;
        public int numberLevel = 1;
        public int helth = 3;
        Texture2D Rect;
        Vector2 gbr = new Vector2(2.4f, 2.2f);

        public GameProcess()
        {
            
        }

        public void Initialize(Game1 game)
        {
            this.game = game;
            ball = new Ball(game, game.Content.Load<Texture2D>("png/ballBlue"), new Vector2(0, 0));
            paddle = new Paddle(game, game.Content.Load<Texture2D>("png/paddleRed"), new Vector2(0, 0));
            level = new Level(game, numberLevel);
            Rect = new Texture2D(game.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            Rect.SetData<Color>(new Color[] { Color.Bisque });
        }

        public void LoadContent()
        {

        }

        public void Run()
        {
            active = true;
            visible = true;
        }

        public void Pause()
        {
            active = false;
        }

        public void Stop()
        {
            active = false;
            visible = false;
        }

        public void UnloadContent()
        {

        }

        public void Update(KeyboardState kstate, GameTime gameTime)
        {
            if (active)
            {
                paddle.Update(kstate, gameTime, ball);
                ball.Update(kstate, gameTime, level, paddle);
                level.Delete();
                if (level.blocks.Count == 0) {
                    numberLevel++;
                    if (numberLevel >= 10) {
                        numberLevel = 1;
                    }
                    ball = new Ball(game, game.Content.Load<Texture2D>("png/ballBlue"), new Vector2(0, 0));
                    paddle = new Paddle(game, game.Content.Load<Texture2D>("png/paddleRed"), new Vector2(0, 0));
                    level = new Level(game, numberLevel);
                }
            }
        }



        public void Reset()
        {
            numberLevel = 1;
            helth = 3;
            ball = new Ball(game, game.Content.Load<Texture2D>("png/ballBlue"), new Vector2(0, 0));
            paddle = new Paddle(game, game.Content.Load<Texture2D>("png/paddleRed"), new Vector2(0, 0));
            level = new Level(game, numberLevel);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                spriteBatch.Draw(Rect, new Rectangle(game.X0, game.Y0, game.Width, game.Height), Color.White);
                paddle.Draw(spriteBatch);
                ball.Draw(spriteBatch);
                level.Draw(spriteBatch);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arkanoid
{
    class Ball:Sprite
    {
        public bool Launc = false;
        public Vector2 vector;
        public float speed = 700f;
        private Game1 game;
        public Ball(Game1 game, Texture2D image, Vector2 position):base(image, position) {
            MoveTo(game.GraphicsDevice.DisplayMode.Width / 2 - Width / 2, game.GraphicsDevice.DisplayMode.Height - Height* 2);
            vector = new Vector2(0, 0);
            this.game = game;
        }

        public void Update(KeyboardState kstate, GameTime gameTime, Level level, Paddle paddle)
        {
            if (kstate.IsKeyDown(Keys.Space)) {
                Launc = true;
                vector.Y = -1;
                vector.Normalize();
            }
            Move(vector.X * speed * (float)gameTime.ElapsedGameTime.TotalSeconds, vector.Y * speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            if (Launc)
            {
                if ((GetPosition().Y) <= 32)
                {
                    vector.Y = -vector.Y;
                    Move(vector.X * speed * (float)gameTime.ElapsedGameTime.TotalSeconds, vector.Y * speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (((GetPosition().X + Width) >= (game.Width + game.X0)) || (GetPosition().X <= game.X0))
                {
                    vector.X = -vector.X;
                    Move(vector.X * speed * (float)gameTime.ElapsedGameTime.TotalSeconds, vector.Y * speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (GetPosition().Y >= game.GraphicsDevice.DisplayMode.Height)
                {
                    vector.X = 0;
                    vector.Y = 0;
                    Launc = false;
                    game.gameProcess.helth--;
                    if (game.gameProcess.helth<=0) game.gameProcess.Reset();
                }

                if (CheckCollided(paddle))
                {
                                     
                    MoveTo(GetPosition().X, paddle.GetPosition().Y - Height);
                    float racketCenter = paddle.GetPosition().X + (paddle.Width / 2);
                    float ballCenter = GetPosition().X + (Width / 2);
                    float normalizedDistance = Math.Abs(ballCenter - racketCenter) / (paddle.Width / 2);

                    if (vector.X < 0)
                        vector.X = -normalizedDistance;
                    else
                        vector.X = normalizedDistance;

                    vector.Y =  -1*vector.Y;
                    vector.Normalize();
                    Move(vector.X * speed * (float)gameTime.ElapsedGameTime.TotalSeconds, vector.Y * speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                foreach (Block block in level) {
                    if (CheckCollided(block))
                    {
                        if (((block.GetPosition().X + block.Width) >= (GetPosition().X + Width))
                           && (block.GetPosition().X <= GetPosition().X))
                        {
                            vector.Y = -vector.Y;
                        }
                        else
                        if (((block.GetPosition().Y + block.Height) >= (GetPosition().Y + Height))
                            && ((block.GetPosition().Y) <= (GetPosition().Y)))
                        {
                            vector.X = -vector.X;
                        }
                        else {
                            vector.X = -vector.X;
                            vector.Y = -vector.Y;
                        }
                        block.Hit();
                        vector.Normalize();
                        Move(vector.X * speed * (float)gameTime.ElapsedGameTime.TotalSeconds, vector.Y * speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                    }
                }
            }
        }
    }
}

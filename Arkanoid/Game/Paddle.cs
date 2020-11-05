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
    class Paddle:Sprite
    {
        Game1 game;
        public float SpeedPaddle = 600f;

        public Paddle(Game1 game, Texture2D image, Vector2 position):base(image, position) {
            MoveTo(game.GraphicsDevice.DisplayMode.Width / 2 - Width / 2, game.GraphicsDevice.DisplayMode.Height - Height * 2);
            this.game = game;
        }

        public void Update(KeyboardState kstate, GameTime gameTime, Ball ball) {
                       
            if (kstate.IsKeyDown(Keys.Left))
                Move(-SpeedPaddle * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);

            if (kstate.IsKeyDown(Keys.Right))
                Move(SpeedPaddle * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            MoveTo(Math.Min(Math.Max(game.X0, GetPosition().X), game.X0 + game.Width - Width));
            if (!ball.Launc)
            {
                ball.MoveTo(GetPosition().X+Width/2-ball.Width/2, GetPosition().Y-ball.Height);
            }
        }

    }
}

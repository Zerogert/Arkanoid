using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arkanoid
{
    class Bonus:Sprite
    {
        public Vector2 vector;
        public float speed = 500f;
        private Game1 game;
        public Bonus(Game1 game, Texture2D image, Vector2 position) : base(image, position)
        {
            MoveTo(game.GraphicsDevice.DisplayMode.Width / 2 - Width / 2, game.GraphicsDevice.DisplayMode.Height - Height * 2);
            vector = new Vector2(0, 0);
            this.game = game;
        }
    }
}

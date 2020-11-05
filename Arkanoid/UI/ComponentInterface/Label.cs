using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arkanoid
{
    public class Label
    {
        public Point position;
        public bool visible = true;
        public bool enable = true;
        public Color color;
        public string text = "";
        public SpriteFont font;

        public Label(Game1 game, Point position, string text, Color color, string font = "Standart")
        {
            this.position = position;
            this.text = text;
            this.font = game.Content.Load<SpriteFont>(font);
            this.color = color;
            
        }

        public void Draw(SpriteBatch spriteBatch)//Вывод на экран
        {
            if (visible)
            {
                spriteBatch.DrawString(font, text, position.ToVector2(), color);
            }
        }

    }
}
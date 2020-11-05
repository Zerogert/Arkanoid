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
   public class Panel
    {
        public Rectangle rectangle;
        private Color color = Color.White;
        public bool visible=true;
        public bool enable = true;
        private Texture2D rect;

        public Panel(Game1 game1, Point position, int width, int height, Color color) 
        {
            rectangle = new Rectangle(position, new Point(width, height));
            rect = new Texture2D(game1.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            this.color = color;
            rect.SetData<Color>(new Color[] { color });
            
        }

        public void Draw(SpriteBatch spriteBatch)//Вывод на экран
        {
            if (visible) spriteBatch.Draw(this.rect, this.rectangle, Color.White);
        }
    }
}

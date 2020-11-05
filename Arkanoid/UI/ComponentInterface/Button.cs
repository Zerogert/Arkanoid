using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arkanoid
{
    public class Button
    {
        public Rectangle rectangle;
        public Color color = Color.Azure;
        public bool visible = true;
        public bool enable = true;
        private Texture2D image;
        private Label label;
        public bool LeftClickMouse = false;

        public Button(Game1 game1, Point position, int width, int height, string text = "" )
        {
            rectangle = new Rectangle(position, new Point(width, height));
            image = new Texture2D(game1.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            image.SetData<Color>(new Color[] { Color.Bisque });
            label = new Label(game1, rectangle.Center, text, Color.LawnGreen, "text");
        }

        public Button(Game1 game1, Point position, Texture2D image, string text = "")
        {
            this.image = image;
            rectangle = new Rectangle(position, new Point(image.Width, image.Height));
            label = new Label(game1, new Point(rectangle.X+rectangle.Width/12, rectangle.Y +rectangle.Height / 6), text, Color.DarkGray, "text");
        }

        public void Draw(SpriteBatch spriteBatch)//Вывод на экран
        {
            if (visible)
            {
                spriteBatch.Draw(this.image, this.rectangle, Color.White);
                label.Draw(spriteBatch);
            }
        }

        public void Update(KeyboardState kstate, GameTime gameTime) {
            Point MousePosition = Mouse.GetState().Position;
            bool LeftButton = ButtonState.Pressed == Mouse.GetState().LeftButton;
            bool intersects = rectangle.Intersects(new Rectangle(MousePosition, new Point(1, 1)));
            if (intersects && LeftButton)
            {
                LeftClickMouse = true;
            }
        }

        public virtual void LeftClick()
        {
            LeftClickMouse = false;
        }
    }
}
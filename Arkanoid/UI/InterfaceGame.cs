using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arkanoid
{
    public class InterfaceGame:Panel
    {
        public bool active = true;
        private Label title;
        private Label Helth;
        private Label Level;
        private Game1 game;
        UserInterface userInterface;

        public InterfaceGame(UserInterface userInterface, Game1 game, Point position, int Width, int Height) : base(game, position, Width, Height, Color.Bisque)
        {
            this.userInterface = userInterface;
            this.game = game;
            title = new Label(game, new Point(position.X + (Width / 20), position.Y + (Height / 20)), "Arkanoid", Color.DarkGray);
            Helth = new Label(game, new Point(position.X + (Width / 20), position.Y + (Height / 10)+20), "Количество шаров:", Color.DarkGray, "text");
            Level = new Label(game, new Point(position.X + (Width / 20), position.Y + (Height / 10)+80), "Текущий уровень:", Color.DarkGray, "text");

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            title.Draw(spriteBatch);
            Helth.Draw(spriteBatch);
            Level.Draw(spriteBatch);
        }

        public void Update(KeyboardState kstate, GameTime gameTime)
        {
            Helth.text = string.Format("Количество шаров: {0}", game.gameProcess.helth);
            Level.text = string.Format("Текущий уровень: {0}", game.gameProcess.numberLevel);
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Arkanoid
{
    public class MenuPause : Panel
    {
        public bool active = true;
        private Label title;
        private Button start;
        private Button exit;
        private Game1 game;
        UserInterface userInterface;

        public MenuPause(UserInterface userInterface, Game1 game, Point position, int Width, int Height) : base(game, position, Width, Height, Color.DarkSlateGray)
        {
            this.userInterface = userInterface;
            this.game = game;
            title = new Label(game, new Point(position.X + (Width / 5), position.Y + (Height / 10)), "ПАУЗА", Color.DarkGray);
            start = new Button(game, new Point(position.X + (Width / 9), position.Y + (Height / 9)+60), game.Content.Load<Texture2D>("png/buttonDefault"), "Продолжить");
            exit = new Button(game, new Point(position.X + (Width / 9), position.Y + (Height / 9) + 120), game.Content.Load<Texture2D>("png/buttonDefault"), "Выйти в меню");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            title.Draw(spriteBatch);
            start.Draw(spriteBatch);
            exit.Draw(spriteBatch);
        }

        public void Update(KeyboardState kstate, GameTime gameTime)
        {
            start.Update(kstate, gameTime);
            exit.Update(kstate, gameTime);
            if (start.LeftClickMouse)
            {
                userInterface.gameState = EGameState.Game;
                start.LeftClick();
            }
            if (exit.LeftClickMouse)
            {
                userInterface.gameState = EGameState.MainMenu;
                game.gameProcess.Reset();
                game.gameProcess.Stop();
                exit.LeftClick();
            }
        }
    }
}
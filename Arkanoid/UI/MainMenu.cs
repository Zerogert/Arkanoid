using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Arkanoid
{   //Describes the main game menu
    public class MainMenu : Panel
    {
        private Label title;//Name of the game
        private Button start;//Start Button
        private Button exit;//exit button
        private Game1 game;//link to games to control the game
        UserInterface userInterface;//reference to the class describing the interface for managing states

        public MainMenu(UserInterface userInterface, Game1 game, Point position, int Width, int Height) : base(game, position, Width, Height, Color.Bisque)
        {
            this.userInterface = userInterface;
            this.game = game;
            title = new Label(game, new Point(position.X+(Width/8), position.Y + (Height / 8)), "Arkanoid classic", Color.DarkGray);
            start = new Button(game, new Point(position.X + (Width / 8), position.Y + (Height / 5) + 120), game.Content.Load<Texture2D>("png/buttonDefault"), "Начать игру");
            exit = new Button(game, new Point(position.X + (Width / 8), position.Y + (Height / 5) + 180), game.Content.Load<Texture2D>("png/buttonDefault"), "Выйти из игры");
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
                userInterface.gameState = EGameState.Exit;
                exit.LeftClick();
            }
        }
    }
}
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
    /*Общий класс для всех игровых объектов*/
    class Sprite
    {
        /*Блок описания полей*/
        private static int count;
        public Texture2D image;
        private bool visible = true;
        private Vector2 Position;

        /*Блок описания свойств*/
        public static int Count
        {
            get => count;
        }

        public int Width { get; }

        public int Height { get; }

        /*Блок описания методов*/
        public Sprite(Texture2D image, Vector2 position)
        {
            this.image = image;
            Position = position;
            Width = image.Width;
            Height = image.Height;
            count++;
        }

        public void Move(float dx, float dy)
        {
            Position.X += dx;
            Position.Y += dy;
        }

        public void MoveTo(float x, float y)
        {
            Position.X = x;
            Position.Y = y;
        }

        public void MoveTo(float x)
        {
            Position.X = x;
        }

        public Vector2 GetPosition()
        {
            return Position;
        }

        public bool CheckCollided(Sprite sprite)
        {
            Rectangle rectangle;
            Rectangle rectangle1;
            rectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)Width, (int)Height);
            rectangle1 = new Rectangle((int)sprite.Position.X, (int)sprite.Position.Y, (int)sprite.Width, (int)sprite.Height);
            return rectangle.Intersects(rectangle1);
        }

        public void Draw(SpriteBatch spriteBatch)//Вывод на экран
        {
            if (visible) spriteBatch.Draw(this.image, this.Position, Color.White);
        }
        

        ~Sprite()
        {
            count--;
        }
    }
}

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
    class Block : Sprite
    {
        private Game1 game;
        public bool Destroy = false;
        private int helth;
        private Texture2D[] images;
        private bool destroed = true;

        public Block(Game1 game, Texture2D[] images, Vector2 position, int helth, bool destroed = true) : base(images[helth - 1], position)
        {
            this.images = images;
            this.helth = helth;
            this.destroed = destroed;
            this.game = game;
        }

        public void Hit()
        {
            helth--;
            if ((helth <= 0)&&destroed)
            {
                Destroy = true;
            }
            else
            {
                base.image = images[helth-1];
            }
        }
        
    }
}

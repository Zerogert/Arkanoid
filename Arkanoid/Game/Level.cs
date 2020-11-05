using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arkanoid
{
    class Level : IEnumerable<Block>
    {
        public List<Block> blocks = new List<Block>();
        private Texture2D[] images = new Texture2D[6];
        private int WidthN;
        private int HeightN;
        private Map map;
        public bool delete = false;
        private Texture2D[] DecorBlock = new Texture2D[1];
        public List<Block> DecorBlocks = new List<Block>();

        public Level(Game1 game, int numberLevel) {
            WidthN = 1024/64;
            HeightN = 1024/64;
            map.map = new int[HeightN, WidthN];
            string path = String.Format("level{0}.lev", numberLevel);
            using (StreamReader sw = new StreamReader(path))
            {
                map.name = sw.ReadLine();
                for (int i = 0; i < map.map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.map.GetLength(1); j++)
                    {
                        int val = (int)Char.GetNumericValue((char)sw.Read());
                        map.map[i, j] = val;
                    }
                    sw.ReadLine();
                }
            }
            images[0] = game.Content.Load<Texture2D>("png/element_yellow_rectangle");
            images[1]= game.Content.Load<Texture2D>("png/element_red_rectangle");
            images[2] = game.Content.Load<Texture2D>("png/element_purple_rectangle");
            images[3] = game.Content.Load<Texture2D>("png/element_grey_rectangle");
            images[4] = game.Content.Load<Texture2D>("png/element_green_rectangle");
            images[5] = game.Content.Load<Texture2D>("png/element_blue_rectangle");
            DecorBlock[0] = game.Content.Load<Texture2D>("png/element_grey_square");
            for (int i = 0; i < HeightN; i++) {
                for (int j=0; j<WidthN; j++) {
                    if (map.map[i, j] > 0)
                    {
                        blocks.Add(new Block(game, images, new Vector2(j * 64 + game.X0, i * 32+game.Y0+32), map.map[i, j]));
                    }
                }
            }
            for (int i = 0; i <= (1080/32); i++)
            {
                DecorBlocks.Add(new Block(game, DecorBlock, new Vector2(game.X0-32, i*32), 1, false));//вертикальные полосы
                DecorBlocks.Add(new Block(game, DecorBlock, new Vector2(game.X0+game.Width, i * 32), 1, false));
                DecorBlocks.Add(new Block(game, DecorBlock, new Vector2(game.X0 + game.Width+9*32, i * 32), 1, false));
            }
            for (int i = 0; i <= (40); i++)
            {
                DecorBlocks.Add(new Block(game, DecorBlock, new Vector2(game.X0+i*32, 0), 1, false));//горизонтальные полосы
            }
        }

        /// <summary>
        /// Draw in screen
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)//Вывод на экран
        {
            foreach (Block block in blocks)
            {
                if (!block.Destroy)
                {
                    block.Draw(spriteBatch);
                }
                else
                {
                    delete = true;
                }
            }
            foreach (Block item in DecorBlocks)
            {
                item.Draw(spriteBatch);
            }

        }

        public IEnumerator<Block> GetEnumerator()
        {
            foreach (Block block in blocks) {
                if (!block.Destroy)
                {
                    yield return block;
                }                
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Block this[int index]
        {
            get
            {
                return blocks[index];
            }

            set
            {
                blocks[index] = value;
            }
        }

        public void Delete()
        {
            if (delete)
            {
                blocks.RemoveAll(block => block.Destroy);
                delete=!delete;
            }
        }
    }
}

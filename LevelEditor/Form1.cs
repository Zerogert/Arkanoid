using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LevelEditor
{
    public partial class LevelEditor : Form
    {
        public Graphics DrawHandle;
        public Pen pen = new Pen(Color.Black);
        public bool AddOrDelete;
        public int KindBlock;
        public Map level;

        public LevelEditor()
        {
            InitializeComponent();
            DrawHandle = pictureBox1.CreateGraphics();
            toolStripButton1.Checked = false;
            init();
        }

        private void init()
        {
            level = new Map();
            level.name = "Name";
            level.map = new int[1024 / 64, 1024 / (2 * 32)];
            DrawGrid();
        }

        private void DrawGrid()
        {
            DrawHandle.Clear(Color.LightYellow);
            int CellWidthN = 1024/64;
            int CellHeightN = 1024/(2*32);
            int CellWidth = (pictureBox1.Width-10) / CellWidthN;
            int CellHeigth = (pictureBox1.Height-10) / CellHeightN;
            for (int i = 0; i <= CellHeightN; i++)
            {
                DrawHandle.DrawLine(pen, new Point(5, i*CellHeigth+5), new Point(CellWidthN*CellWidth+5, i*CellHeigth+5));
            }
            for (int i = 0; i <= CellWidthN; i++)
            {
                DrawHandle.DrawLine(pen, new Point(i*CellWidth+5, 5), new Point(i * CellWidth+5, CellHeightN * CellHeigth+5));
            }
            for (int i = 0; i < CellHeightN; i++)
            {
                for (int j = 0; j < CellWidthN; j++)
                {
                   if (level.map[i, j] > 0)
                   {
                        DrawHandle.FillRectangle(Brushes.Blue, new Rectangle(new Point(j * CellWidth+5, i * CellHeigth+5),new Size(CellWidth,CellHeigth)));
                   }                  
                   DrawHandle.DrawString(Convert.ToString(level.map[i, j]), Font, Brushes.Black, new Point(j * CellWidth+CellWidth/2, i * CellHeigth+CellHeigth/2));
                }
            }
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            DrawHandle = pictureBox1.CreateGraphics();
        }

        private void LevelEditor_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            KindBlock = listBox1.SelectedIndex+1;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddOrDelete = true;
            toolStripButton2.Checked = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AddOrDelete = false;
            toolStripButton1.Checked = false;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int CellWidthN = 1024 / 64;
            int CellHeightN = 1024 / (2 * 32);
            int CellWidth = (pictureBox1.Width - 10) / CellWidthN;
            int CellHeigth = (pictureBox1.Height - 10) / CellHeightN;
            if (AddOrDelete)
            {
                level.map[((e.Y-5)/CellHeigth), ((e.X-5)/CellWidth)] = KindBlock;
            }
            else
            {
                level.map[((e.Y - 5) / CellHeigth), ((e.X - 5) / CellWidth)] = 0;
            }
            DrawGrid();
        }

        public string path;

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            path = saveFileDialog1.FileName;
            сохранитьToolStripMenuItem.Enabled = true;
            //сохранение в файл
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(level.name);
                for (int i = 0; i < level.map.GetLength(0); i++)
                {
                    for (int j = 0; j < level.map.GetLength(1); j++)
                    {
                        sw.Write(level.map[i,j]);
                    }
                    sw.Write("\n");
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            path = openFileDialog1.FileName;
            сохранитьToolStripMenuItem.Enabled = true;
            //чтение из файлы
            using (StreamReader sw = new StreamReader(path))
            {
                level.name=sw.ReadLine();
                for (int i = 0; i < level.map.GetLength(0); i++)
                {
                    for (int j = 0; j < level.map.GetLength(1); j++)
                    {
                        int val = (int)Char.GetNumericValue((char)sw.Read());
                        level.map[i, j]= val;
                    }
                    sw.Peek();
                }
            }
            DrawGrid();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = path;
            //сохранение в файл
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(level.name);
                for (int i = 0; i < level.map.GetLength(0); i++)
                {
                    for (int j = 0; j < level.map.GetLength(1); j++)
                    {
                        sw.Write(level.map[i, j]);
                    }
                    sw.Write("\n");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class LevelEditor : UserControl
    {
        const int tileSize = 16;
        int levelWidth;
        int levelHeight;
        Bitmap bitmap;
        Bitmap bitmapOstacles;

        int[,] blocNums;
        bool[,] obstacles;
        int currentSelectedBloc = 1;

        public LevelEditor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            levelWidth = int.Parse(textBoxWidth.Text);
            levelHeight = int.Parse(textBoxHeight.Text);

            blocNums = new int[levelHeight, levelWidth];
            obstacles = new bool[levelHeight, levelWidth];
            pictureBoxLevel.Width = levelWidth * tileSize;
            pictureBoxLevel.Height = levelHeight * tileSize;

            bitmapOstacles = new Bitmap(levelWidth * tileSize, levelHeight * tileSize);
            bitmap = new Bitmap(levelWidth * tileSize, levelHeight * tileSize);
            pictureBoxLevel.Image = bitmap;

            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.SkyBlue);
            g.Dispose();

            g = Graphics.FromImage(bitmapOstacles);
            g.Clear(Color.White);
            g.Dispose();

            pictureBoxLevel.Refresh();

            updateScrollBar();

            button1.Enabled = false;
        }

        private void pictureBoxLevel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxLevel_MouseDown(object sender, MouseEventArgs e)
        {
            int poxBlocX = e.X / tileSize;
            int poxBlocY = e.Y / tileSize;

            MouseWork(e.Button, poxBlocX, poxBlocY);
        }

        private void MouseWork(MouseButtons button, int poxBlocX, int poxBlocY)
        {
            if (!checkBoxObstacles.Checked)
            {
                blocNums[poxBlocY, poxBlocX] = currentSelectedBloc;
                updateTile(poxBlocX, poxBlocY);
            }
            else
            {
                if (button == System.Windows.Forms.MouseButtons.Left)
                {
                    obstacles[poxBlocY, poxBlocX] = true;
                    updateObstacle(poxBlocX, poxBlocY, true);
                }
                else
                {
                    obstacles[poxBlocY, poxBlocX] = false;
                    updateObstacle(poxBlocX, poxBlocY, false);
                }
                pictureBoxLevel.Refresh();
            }
        }

        private void updateObstacle(int poxBlocX, int poxBlocY, bool value)
        {
            if (!value)
            {
                Graphics g = Graphics.FromImage(bitmapOstacles);
                var b = new SolidBrush(Color.White);
                g.FillRectangle(b, new Rectangle(poxBlocX * tileSize, poxBlocY * tileSize, tileSize, tileSize));
                g.Dispose();
            }
            else
            {
                Graphics g = Graphics.FromImage(bitmapOstacles);
                var b = new SolidBrush(Color.Black);
                g.FillRectangle(b, new Rectangle(poxBlocX * tileSize, poxBlocY * tileSize, tileSize, tileSize));
                g.Dispose();
            }
        }

        private void updateTile(int poxBlocX, int poxBlocY)
        {
            setTile(poxBlocX, poxBlocY, currentSelectedBloc);
            pictureBoxLevel.Refresh();
        }

        private void setTile(int poxBlocX, int poxBlocY, int value)
        {
            if (value > 0)
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(pictureBoxTiles.Image, new Rectangle(poxBlocX * tileSize, poxBlocY * tileSize, tileSize, tileSize), new Rectangle(tileSize * (value - 1), 0, tileSize, tileSize), GraphicsUnit.Pixel);
                g.Dispose();
            }
            else
            {
                Graphics g = Graphics.FromImage(bitmap);
                var b = new SolidBrush(Color.SkyBlue);
                g.FillRectangle(b, new Rectangle(poxBlocX * tileSize, poxBlocY * tileSize, tileSize, tileSize));
                g.Dispose();
            }
        }

        private void pictureBoxTiles_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X > pictureBoxTiles.Image.Width)
            {
                currentSelectedBloc = 0;
            }
            else
            {
                currentSelectedBloc = (e.X / tileSize) + 1;
            }
        }

        public string getText()
        {
            string result = "";
            result += "const uint16_t levelWidth = " + levelWidth.ToString() + ";\r\n";
            result += "const uint16_t levelHeight = " + levelHeight.ToString() + ";\r\n";
            result += "const uint8_t levelTile[" + blocNums.Length.ToString() + "] = \r\n";
            result += "{\r\n";
            for(int y = 0;y < levelHeight;y++)
            {
                for(int x = 0;x < levelWidth;x++)
                {
                    result += "\t0x" + blocNums[y,x].ToString("X") + ",\r\n";
                }
            }
            result += "}; \r\n";
            result += "const uint8_t levelObstacle[" + blocNums.Length.ToString() + "] = \r\n";
            result += "{\r\n";
            for (int y = 0; y < levelHeight; y++)
            {
                for (int x = 0; x < levelWidth; x++)
                {
                    if (obstacles[y,x])
                    {
                        result += "\t0x01,\r\n";
                    }
                    else
                    {
                        result += "\t0x00,\r\n";
                    }
                }
            }
            result += "}; \r\n";
            return result;
        }

        private void updateScrollBar()
        {
            if (pictureBoxLevel.Left < pictureBoxLevel.Width - panel1.Width)
            {
                pictureBoxLevel.Left = pictureBoxLevel.Width - panel1.Width;
            }
            if (pictureBoxLevel.Left > 0)
            {
                pictureBoxLevel.Left = 0;
            }
            hScrollBar1.Maximum = (panel1.Width - pictureBoxLevel.Width) * -1;
            hScrollBar1.Minimum = 0;
            hScrollBar1.Value = pictureBoxLevel.Left * -1;
        }

        private void LevelEditor_Resize(object sender, EventArgs e)
        {
            updateScrollBar();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBoxLevel.Left = hScrollBar1.Value * -1;
        }

        private void pictureBoxLevel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            int poxBlocX = e.X / tileSize;
            int poxBlocY = e.Y / tileSize;

            if (!(poxBlocX < levelWidth && poxBlocY < levelHeight))
            {
                return;
            }

            if (blocNums[poxBlocY, poxBlocX] == currentSelectedBloc)
            {
                return;
            }

            MouseWork(e.Button, poxBlocX, poxBlocY);
        }

        private void checkBoxObstacles_CheckedChanged(object sender, EventArgs e)
        {
            if (pictureBoxLevel.Image == bitmapOstacles)
            {
                pictureBoxLevel.Image = bitmap;
            }
            else
            {
                pictureBoxLevel.Image = bitmapOstacles;
            }
            pictureBoxLevel.Refresh();
        }

        private void buttonGetFromClipBoard_Click(object sender, EventArgs e)
        {
            string data = Clipboard.GetText();
            List<int> blocData = new List<int>();
            List<bool> obstaclesData = new List<bool>();
            bool modeBloc = false;
            bool modeObstacle = false;

            foreach(var line in data.Split("\n".ToArray()))
            {
                if (modeBloc)
                {
                    if(line.Contains("};"))
                    {
                        modeBloc = false;
                    }
                    else if (!line.Contains("{"))
                    {
                        string Value = line.Replace("	", "").Replace("0x", "").Replace(",", "").Replace("\r", "");
                        blocData.Add((int)Convert.ToByte(Value, 16));
                    }
                }
                else if (modeObstacle)
                {
                    string Value = line.Replace("	", "").Replace("0x", "").Replace(",", "").Replace("\r", "");
                    if (line.Contains("};"))
                    {
                        modeBloc = false;
                    }
                    else if (!line.Contains("{"))
                    {
                        obstaclesData.Add(line.Contains("0x01"));
                    }
                }
                else
                {
                    if (line.Contains("levelTile"))
                    {
                        modeBloc = true;
                    }
                    if (line.Contains("levelObstacle"))
                    {
                        modeObstacle = true;
                    }
                }
            }

            for (int y = 0; y < levelHeight; y++)
            {
                for (int x = 0; x < levelWidth; x++)
                {
                    blocNums[y, x] = blocData[y * levelWidth + x];
                    setTile(x, y, blocNums[y, x]);

                    if (obstaclesData.Count > y * levelWidth + x)
                    {
                        obstacles[y, x] = obstaclesData[y * levelWidth + x];
                        updateObstacle(x, y, obstacles[y, x]);
                    }
                }
            }
            pictureBoxTiles.Refresh();
        }
    }
}

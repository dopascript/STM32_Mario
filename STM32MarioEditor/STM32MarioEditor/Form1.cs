using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Properties.Settings.Default.Reload();

            textBoxFileToConvert.Text = (string)Properties.Settings.Default["FileToConvert"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBoxFileToConvert.Text))
            {
                return;
            }
            Properties.Settings.Default["FileToConvert"] = textBoxFileToConvert.Text;
            Properties.Settings.Default.Save();

            string strResult = "";
            var files = (new DirectoryInfo(textBoxFileToConvert.Text)).GetFiles("*.png");
            foreach(var file in files)
            {
                AddImage(file.FullName, ref strResult);
            }

            File.WriteAllText(textBoxFileToConvert.Text + "\\images.h", strResult);
        }

        private void AddImage(string file, ref string data)
        {
            Bitmap img = (Bitmap)Image.FromFile(file);
            List<ushort> result = new List<ushort>();
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = img.Height - 1; y >= 0; y--)
                {
                    Color color = img.GetPixel(x, y);
                    result.Add(colorToUshort(color));
                }
            }
            string fileName = Path.GetFileNameWithoutExtension(file);

            data += "const uint16_t " + fileName + "_width = " + img.Width.ToString() + ";\r\n";
            data += "const uint16_t " + fileName + "_height = " + img.Height.ToString() + ";\r\n";
            data += "const uint16_t " + fileName + "[" + result.Count + "] = \r\n";
            data += "{\r\n";
            foreach (var c in result)
            {
                data += "\t0x" + c.ToString("X") + ",\r\n";
            }
            data += "};\r\n\r\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color color = System.Drawing.ColorTranslator.FromHtml(textBoxHTMLColor.Text);
            textBoxShortColor.Text = colorToUshort(color).ToString();
        }

        private ushort colorToUshort(Color color)
        {
            return (ushort)(((color.R >> 3) << 11) | ((color.G >> 2) << 5) | (color.B >> 3));
        }

        private void buttonSaveLevel_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\level.h", levelEditor1.getText());
        }
    }
}

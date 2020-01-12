using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace galerie
{
    public partial class Form2 : Form
    {
        private string[] folderFile = null;
        private int selected = 0;
        private int begin = 0;
        private int end = 0;
        public PictureBox boxovaciObraz;

        public Form2(string[] folderFile, ref int selected,ref int  end)
        {
            InitializeComponent();
            this.folderFile = folderFile;
            this.selected = selected;
            this.end = end;

        }
        public void prevImage()
        {
            if (selected == 0)
            {
                selected = folderFile.Length - 1;
                showImage(folderFile[selected]);
            }
            else
            {
                selected = selected - 1;
                showImage(folderFile[selected]);
            }
        }

        public void nextImage()
        {
            if (selected == folderFile.Length - 1)
            {
                selected = 0;
                showImage(folderFile[selected]);
            }
            else
            {
                selected = selected + 1;
                showImage(folderFile[selected]);
            }
        }
        private void showImage(string path)
        {
            if (path != "")
            {
                Image imgtemp = Image.FromFile(path);                    
                pictureBox1.Image = imgtemp;
                pictureBox1.Location = new Point((Width - pictureBox1.Width) / 2, (Height - pictureBox1.Height) / 2);
                

            }

        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            boxovaciObraz = pictureBox1;
            pictureBox1.Width = Width;
            pictureBox1.Height = Height;
            //pictureBox1.Location = new Point((this.Width - pictureBox1.Width) / 2, (this.Height - pictureBox1.Height) / 2);
            //PictureBox1.Location = New Point((Me.Width - PictureBox1.Width) \ 2, (Me.Height - PictureBox1.Height) \ 2)
            //toggle = True
        }

        private void klik(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
            if (e.KeyCode == Keys.Left) prevImage();
            if (e.KeyCode == Keys.Right) nextImage();
            if (e.KeyCode == Keys.Space) Form1.stopke.Enabled = !Form1.stopke.Enabled;
        }
    }
}

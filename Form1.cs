using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace galerie
{
    public partial class Form1 : Form
    {
        private string[] folderFile = null;
        private int selected = 0;
        private int begin = 0;
        private int end = 0;
        Image imgtemp = null;
        Form2 nekdy = null;
        static public Timer stopke;


        public Form1()
        {
            InitializeComponent();
            stopke = timer1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prevImage();
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
                imgtemp = Image.FromFile(path);
                pictureBox1.Width = imgtemp.Width / 2;
                pictureBox1.Height = imgtemp.Height / 2;
                pictureBox1.Image = imgtemp;
                /*int imgWidth= imgtemp.Width;
                int imgHeight= imgtemp.Height;
                if (nekdy != null)
                {
                    if((double)nekdy.Width/ imgWidth < 0)
                    {
                        double koeficient = (double)nekdy.Width / imgtemp.Width;
                        imgWidth = (int)(koeficient * imgWidth);
                        imgHeight= (int)(koeficient * imgHeight);
                    }
                    if((double)nekdy.Height / imgHeight < 0)
                    {
                        double koeficient = (double)nekdy.Height / imgtemp.Width;
                        imgWidth = (int)(koeficient * imgWidth);
                        imgHeight = (int)(koeficient * imgHeight);
                    }*/
                if (nekdy != null)
                {
                    nekdy.boxovaciObraz.Width = nekdy.Width;
                    nekdy.boxovaciObraz.Height = nekdy.Height;
                    nekdy.boxovaciObraz.Image = imgtemp;
                    nekdy.boxovaciObraz.Location = new Point((nekdy.Width - nekdy.boxovaciObraz.Width) / 2, (nekdy.Height - nekdy.boxovaciObraz.Height) / 2);
                    }
                
            }
            
        }
        void shuffle(string[] data)
        {
            
            Random rnd = new Random();
            for(int max = data.Length; max > 1; max--)
            {
                int pozice = rnd.Next(0, max);
                string loklani = data[pozice];
                data[pozice] = data[max - 1];
                data[max - 1] = loklani;

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                 string[] part1 = null, part2 = null, part3 = null;
                 part1 = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.jpg");
                 part2 = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.jpeg");
                 part3 = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.bmp");

                 folderFile = new string[part1.Length + part2.Length + part3.Length];

                 Array.Copy(part1, 0, folderFile, 0, part1.Length);
                 Array.Copy(part2, 0, folderFile, part1.Length, part2.Length);
                 Array.Copy(part3, 0, folderFile, part1.Length + part2.Length, part3.Length);

                 selected = 0;
                 begin = 0;
                 end = folderFile.Length;
                shuffle(folderFile);
                MessageBox.Show("ve složce bylo: " + folderFile.Length + " Obrázků");

                 showImage(folderFile[selected]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            nekdy = new Form2(folderFile,ref selected,ref end);
            nekdy.Show();
            if(folderFile!=null) showImage(folderFile[selected]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nextImage();
        }
        bool jedeShow = false;

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (jedeShow)
            {
                ((Button)sender).Text = "Start Show";
                timer1.Enabled = false;
            }
            else
            {
                int casovyInterva = 0;
                if (int.TryParse(textBox1.Text, out casovyInterva))
                {
                    ((Button)sender).Text = "Stop Show";
                    timer1.Enabled = true;
                    timer1.Interval = casovyInterva;
                }
                
            }
            jedeShow = !jedeShow;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            nextImage();

        }
    }



}

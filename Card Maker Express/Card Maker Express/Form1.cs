using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Card_Maker_Express
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap Finished = new Bitmap(800, 800);
       Bitmap[] Images = new Bitmap[4];

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF*.PNG)|*.BMP;*.JPG;*.GIF*.PNG|" +
        "All files (*.*)|*.*";
            ofd.Multiselect = false;
            ofd.ShowDialog();

            if (ofd.FileName != "")
            {
                Images[0] = (Bitmap)Bitmap.FromFile(ofd.FileName);

                pictureBox1.Image = Images[0];
            }
            GenerateImage();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF*.PNG)|*.BMP;*.JPG;*.GIF*.PNG|" +
        "All files (*.*)|*.*";
            ofd.Multiselect = false;
            ofd.ShowDialog();

            if (ofd.FileName != "")
            {

                Images[1] = (Bitmap)Bitmap.FromFile(ofd.FileName);

                pictureBox2.Image = Images[1];
            }
            GenerateImage();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF*.PNG)|*.BMP;*.JPG;*.GIF*.PNG|" +
        "All files (*.*)|*.*";
            ofd.Multiselect = false;
            ofd.ShowDialog();

            if (ofd.FileName != "")
            {

                Images[2] = (Bitmap)Bitmap.FromFile(ofd.FileName);

                pictureBox3.Image = Images[2];
            }
            GenerateImage();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF*.PNG)|*.BMP;*.JPG;*.GIF*.PNG|" +
        "All files (*.*)|*.*";
            ofd.Multiselect = false;
            ofd.ShowDialog();

            if (ofd.FileName != "")
            {

                Images[3] = (Bitmap)Bitmap.FromFile(ofd.FileName);

                pictureBox4.Image = Images[3];
            }

            GenerateImage();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            GenerateImage();
        }

        private void GenerateImage()
        {

            Size SmallestSize = Images[0].Size;

            for (int i = 1; i < 4; i++)
            {
                if (Images[i].Width < SmallestSize.Width)
                    SmallestSize.Width = Images[i].Width;
                if (Images[i].Height < SmallestSize.Height)
                    SmallestSize.Height = Images[i].Height;
            }

            Bitmap NewImage = new Bitmap(SmallestSize.Width * 2, SmallestSize.Height * 2);

            using (Graphics g = Graphics.FromImage(NewImage))
            {
                Bitmap image1 = Images[0].Clone(new Rectangle(0, 0, Images[0].Width, Images[0].Height), Images[0].PixelFormat);
                image1.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                g.DrawImage(image1, new Rectangle(0, 0, NewImage.Width / 2, NewImage.Height / 2));

                Bitmap image2 = Images[1].Clone(new Rectangle(0, 0, Images[1].Width, Images[1].Height), Images[1].PixelFormat);
                image2.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                g.DrawImage(image2, new Rectangle(NewImage.Width / 2, 0, NewImage.Width / 2, NewImage.Height / 2));

                Bitmap image3 = Images[2].Clone(new Rectangle(0, 0, Images[2].Width, Images[2].Height), Images[2].PixelFormat);
                //image3.RotateFlip(RotateFlipType.Rotate270FlipNone);
                g.DrawImage(image3, new Rectangle(0, NewImage.Height / 2, NewImage.Width / 2, NewImage.Height / 2));

                Bitmap image4 = Images[3].Clone(new Rectangle(0, 0, Images[3].Width, Images[3].Height), Images[3].PixelFormat);
                //image4.RotateFlip(RotateFlipType.Rotate270FlipNone);
                g.DrawImage(image4, new Rectangle(NewImage.Width / 2, NewImage.Height / 2, NewImage.Width / 2, NewImage.Height / 2));

                g.DrawLine(new Pen(Color.Black, 3), new Point(0, NewImage.Height / 2), new Point(NewImage.Width, NewImage.Height / 2));
                g.DrawLine(new Pen(Color.Black, 3), new Point(NewImage.Width / 2, 0), new Point(NewImage.Width / 2, NewImage.Height / 2));
            }
            Finished = NewImage;

            pictureBox5.Image = NewImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                Images[i] = new Bitmap(800, 800);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();

            if (sfd.FileName.Contains('.'))
            {
                Finished.Save(sfd.FileName);
            }
            else
                Finished.Save(sfd.FileName + ".png");
        }


    }
}

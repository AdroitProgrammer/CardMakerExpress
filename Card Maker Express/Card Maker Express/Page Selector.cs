using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Card_Maker_Express
{
    public partial class Page_Selector : UserControl
    {
        public Page_Selector()
        {
            InitializeComponent();
        }

        Rectangle[] Boxes = new Rectangle[4];

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int width = this.Width;
            int height = this.Height;

            e.Graphics.DrawRectangle(new Pen(Color.BlueViolet,4),new Rectangle(0,0,width,height));

            int boxwidth = width / 5;
            int boxHeight = height / 2;

            Color c = Color.FromArgb(140, 200, 36);

            for (int i = 0; i < 5; i++)
            {
                int border = boxwidth / 4;
                Rectangle rec = new Rectangle((i * boxwidth) + boxwidth / 5 * i, boxHeight / 2, boxwidth, boxHeight);
                Boxes[i] = rec;   
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(c.R + i * 10,c.G + i * 2,c.B + i * 5),3), rec);
            }
        }
    }
}

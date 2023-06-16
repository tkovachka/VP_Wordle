using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wordle
{
    public class Square
    {
        public Point Center { get; set; }
        public int Size { get; set; }
        public Color Color { get; set; }

        public Square(Point center)
        {
            Center = center;
            Size = 40;
            Color = Color.White;
        }
        public void Draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            g.DrawRectangle(p, Center.X- Size/2, Center.Y-Size/2, Size, Size);
            p.Dispose();

        }
    }
}

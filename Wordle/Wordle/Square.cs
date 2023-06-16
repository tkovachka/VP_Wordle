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
        public bool Empty { get; set; }
        public string Letter { get; set; }

        public Square(Point center)
        {
            Center = center;
            Size = 40;
            Empty = true;
            Color = Color.White;
            Letter = "";
        }
        public void Draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            g.DrawRectangle(p, Center.X- Size/2, Center.Y-Size/2, Size, Size);
            Font font = new Font("Arial", 16);
            Brush b = new SolidBrush(Color.Black);
            StringFormat format = new StringFormat();
            if (Letter != "")
            {
                g.DrawString(Letter, font, b, new Point(Center.X-10,Center.Y-10), format);
            }
            b.Dispose();
            font.Dispose();
            p.Dispose();

        }
        public void AddLetter(string letter)
        {
            Letter = letter;
        }
    }
}

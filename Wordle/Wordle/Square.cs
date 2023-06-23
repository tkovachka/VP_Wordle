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

        public int Status { get; set; } // 0-white 1-yellow 2-green 3-gray

        public Square(Point center)
        {
            Center = center;
            Size = 40;
            Empty = true;
            Color = Color.White;
            Letter = "";
            Status = 0;
        }

        public void ChangeStatus(int n)
        {
            Status = n;
        }
        public void Draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            g.DrawRectangle(p, Center.X- Size/2, Center.Y-Size/2, Size, Size);
            Font font = new Font("Arial", 16);
            Brush b = new SolidBrush(Color.Black);
            StringFormat format = new StringFormat();
            Brush brush = new SolidBrush(Color.White);
            if (Status == 1)
            {
                brush = new SolidBrush(Color.Yellow);
                Empty = false;
            } else if(Status == 2)
            {
                brush = new SolidBrush(Color.Green);
                Empty = false;
            }
            else if (Status == 3)
            {
                brush = new SolidBrush(Color.Gray);
                Empty = false;
            }
            g.FillRectangle(brush, Center.X - Size / 2, Center.Y - Size / 2, Size, Size);
            if ((!Empty)&&(Status==1||Status==2||Status==3))
            {
                b = new SolidBrush(Color.White);
            }
            if (Letter != "")
            {
                
                g.DrawString(Letter, font, b, new Point(Center.X - 10, Center.Y - 10), format);
            }
            b.Dispose();
            brush.Dispose();
            font.Dispose();
            p.Dispose();

        }
        public void AddLetter(string letter)
        {
            Letter = letter;
        }
    }
}

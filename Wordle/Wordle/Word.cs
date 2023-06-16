using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wordle
{
    public class Word
    {
        public List<Square> Squares { get; set; }
        public int NumSquares { get; set; }
        public bool IsFull { get; set; }
        public Word(Point Center,int Num)
        {
            Squares = new List<Square>();
            NumSquares= Num;
            IsFull = false;
            for(int i = 0; i < Num; i++)
            {
                Squares.Add(new Square(Center));
                Center.X += 60;
            }
        }
        public void Draw(Graphics g)
        {
            foreach(var square in Squares)
            {
                square.Draw(g);
            }
        }

        public void AddLetter(string letter)
        {
            int count = 0;
            foreach(Square s in Squares)
            {
                count++;
                if (s.Empty)
                {
                    s.Empty = false;
                    s.AddLetter(letter);
                    if (count == NumSquares)
                        IsFull = true;
                    return;
                }
            }
        }
    }
}

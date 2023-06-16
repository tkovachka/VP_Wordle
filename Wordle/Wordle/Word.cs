using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    public class Word
    {
        public List<Square> Squares { get; set; }
        public int NumSquares { get; set; }
        public Word(Point Center,int Num)
        {
            Squares = new List<Square>();
            NumSquares= Num;
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
    }
}

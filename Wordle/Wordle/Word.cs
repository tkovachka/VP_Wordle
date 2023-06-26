using System;
using System.Collections;
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

        public StringBuilder sb { get; set; }
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
            sb = new StringBuilder();

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
                    sb.Append(letter);
                    if (count == NumSquares)
                        IsFull = true;
                    return;
                }
            }
          
        }

        public void checkLetters(string word)
        {
           foreach(Square s in Squares)
            {
                s.ChangeStatus(3);
            }
                    for (int i = 0; i < Squares.Count; i++)
                    {
                        for (int j = 0; j < word.Length; j++)
                        {
                            if (Squares[i].Letter == word[j].ToString())
                            {
                                if (i == j)
                                {
                                    Squares[i].ChangeStatus(2);
                                }
                                else
                                {
                                    Squares[i].ChangeStatus(1);
                                }
                    }
                    
                        
                }
            }
        }

        public bool IsCorrect()
        {
            foreach (Square s in Squares)
            {
                if (s.Status == 0 || s.Status == 1 || s.Status ==3) return false;
            }
            return true;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        //TODO: Implement logic if the word to be guessed has duplicate letters
        public void checkLetters(string word)
        {
            bool hasDuplicates = false;
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    if (word[i] == word[j] && i != j)
                    {
                        hasDuplicates = true;
                    }
                }
            }
            if (!hasDuplicates)
            {
                List<GuessedLetter> duplicates = new List<GuessedLetter>();
                List<string> duplicateLetters = new List<string>();
                for (int i = 0; i < Squares.Count; i++)
                {
                    for (int j = 0; j < Squares.Count; j++)
                    {
                        if ((Squares[i].Letter == Squares[j].Letter) && (i != j) && (!duplicateLetters.Contains(Squares[i].Letter)))
                        {
                            duplicateLetters.Add(Squares[i].Letter);
                        }
                    }
                }
                foreach (string l in duplicateLetters)
                {
                    duplicates.Add(new GuessedLetter(l));
                }
                foreach (Square s in Squares)
                {
                    s.ChangeStatus(3);
                }

                bool IsGuessed = false;
                for (int i = 0; i < Squares.Count; i++)
                {
                    for (int j = 0; j < Squares.Count; j++)
                    {
                        if (Squares[i].Letter == word[j].ToString() && i == j)
                        {
                            IsGuessed = true;
                        }
                    }
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
                                if (duplicateLetters.Contains(Squares[i].Letter))
                                {
                                    foreach (GuessedLetter guessedLetter in duplicates)
                                    {
                                        if (Squares[i].Letter == guessedLetter.Letter)
                                        {
                                            guessedLetter.Found = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (duplicateLetters.Contains(Squares[i].Letter))
                                {
                                    foreach (GuessedLetter guessedLetter in duplicates)
                                    {
                                        if (Squares[i].Letter == guessedLetter.Letter)
                                        {
                                            if (guessedLetter.Found == true || IsGuessed)
                                            {
                                                Squares[i].ChangeStatus(3);
                                            }
                                            else
                                            {
                                                Squares[i].ChangeStatus(1);
                                                guessedLetter.Found = true;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Squares[i].ChangeStatus(1);
                                }

                            }
                        }
                    }
                }
            }
            else
            {/*
                List<GuessedLetter> duplicates = new List<GuessedLetter>();
                List<string> duplicateLetters = new List<string>();
                List<string> allLetters = new List<string>();
                for (int i = 0; i < word.Length; i++)
                {
                    allLetters.Add(word[i].ToString());
                    
                    for (int j = 0; j < word.Length; j++)
                    {
                        if ((word[i].ToString() == word[j].ToString()) && (i != j) && (!duplicateLetters.Contains(word[i].ToString())))
                        {
                            duplicateLetters.Add(word[i].ToString());
                           
                        }
                    }
                }

           

                foreach (string l in duplicateLetters)
                {
                    int Count = 0;
                    foreach(string letter in allLetters)
                    {
                        if (letter == l)
                        {
                            Count += 1;
                        }
                    }
              
                    duplicates.Add(new GuessedLetter(l,Count));
                }

                /*foreach (Square s in Squares)
                {
                    s.ChangeStatus(3);
                }

                for (int j = 0; j < word.Length; j++) // NUMBER
                {
                    for (int i = 0; i < Squares.Count; i++) // BUBBLE 
                    {
                        if (Squares[i].Letter == word[j].ToString()) //B
                        {
                            
                                if (duplicateLetters.Contains(Squares[i].Letter))
                                {
                                    foreach(GuessedLetter guessedLetter in duplicates) //(B,3)
                                    {
                                        if (guessedLetter.Letter == Squares[i].Letter)
                                        {
                                        
                                            if (guessedLetter.Count > 0)
                                            {
                                           
                                            if (i == j)
                                            {
                                                Squares[i].ChangeStatus(2);
                                            }
                                            else
                                            {
                                                Squares[i].ChangeStatus(1);
                                            }
                                            guessedLetter.Count -= 1; 
                                        }
                                       /* else
                                        {
                                            Squares[i].ChangeStatus(3);
                                        }
                                        }
                                    }
                            }
                            else
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
                        else
                        {
                            Squares[i].ChangeStatus(3);
                        }
                    }
                }


                */
                foreach (Square s in Squares)
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

                for (int i = 0, j = 0; i < Squares.Count; i++, j++)
                {
                    if (Squares[i].Letter == word[j].ToString())
                    {

                       
                            Squares[i].ChangeStatus(2);
                        
                        
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

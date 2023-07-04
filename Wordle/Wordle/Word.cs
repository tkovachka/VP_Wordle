using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
        public Word(Point Center, int Num)
        {
            Squares = new List<Square>();
            NumSquares = Num;
            IsFull = false;
            for (int i = 0; i < Num; i++)
            {
                Squares.Add(new Square(Center));
                Center.X += 60;
            }
            sb = new StringBuilder();

        }
        public void Draw(Graphics g)
        {
            foreach (var square in Squares)
            {
                square.Draw(g);
            }
        }

        public void AddLetter(string letter)
        {
            int count = 0;
            foreach (Square s in Squares)
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

        public int CountAppearances(string letter, string word)
        {
            int Count = 0;
            foreach (char s in word)
            {
                if (s.ToString() == letter)
                {
                    Count += 1;
                }
            }
            return Count;
        }

        public void checkLetters(string word)
        {
            string guessedWord = GuessedWord(Squares);

            List<string> duplicateLettersInWord = DuplicateLetters(word); 
            List<string> duplicateLettersInGuessed = DuplicateLetters(guessedWord); 

            //list of objects (letter,count)
            List<GuessedLetter> duplicatesInWord = FillList(word); 
            List<GuessedLetter> duplicatesInGuessed = FillList(guessedWord); 

            // set all squares grey
            foreach (Square s in Squares)
            {
                s.ChangeStatus(3);
            }

            // set the guessed green
            for (int i = 0; i < Squares.Count; i++) 
            {
                if (Squares[i].Letter == word[i].ToString())
                {
                    Squares[i].ChangeStatus(2);
                }
            }

            for (int i = 0; i < Squares.Count; i++)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    if (Squares[i].Letter == word[j].ToString())
                    {
                            if (duplicateLettersInWord.Contains(Squares[i].Letter)) // check if it is a duplicate in the word to guess
                            {
                                foreach (GuessedLetter l in duplicatesInWord)
                                {
                                    if (l.Letter == Squares[i].Letter)
                                    {
                                        if (CanWrite(Squares[i].Letter, word, guessedWord, i)) // if the appearances are more in the word then in our guess, can color yellow
                                        {
                                            Squares[i].ChangeStatus(1);
                                        }
                                    }
                                    }
                        }
                        else
                        {
                            if (duplicateLettersInGuessed.Contains(Squares[i].Letter)) // if it's a duplicate only in the guess
                            {
                                bool green = false;
                                foreach(Square s in Squares) // check if it is guessed once 
                                {
                                    if (s.Status == 2)
                                    {
                                        green = true;
                                    }
                                }

                                if (!IsGuessed(Squares[i].Letter,guessedWord,i)&&!green) // if it isn't guessed, color yellow
                                {
                                    if(i!=j)
                                        Squares[i].ChangeStatus(1);
                                }
                            }
                            else
                            {
                                if(i!=j) // if it isn't a duplicate in neither words 
                                Squares[i].ChangeStatus(1);
                            }
                        } 
                    }
                }
            }
        }

        // check if it is guessed until now 
        public bool IsGuessed(string l, string w, int n)
        {
             for(int i=0; i<n; i++)
            {
                if (l == w[i].ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public bool CanWrite(string l, string w1, string w2, int n)
        {
            return CountAppearances(l, w1) > CountAppearancesUntilNow(l, w2, n) &&  CountAppearances(l, w1) >= CountAppearances(l, w2); 
        }


        public int CountAppearancesUntilNow(string letter, string word, int n)
        {
            int Count = 0;
            for(int i=0; i<n; i++)
            {
                if (word[i].ToString() == letter)
                {
                    Count += 1;
                }
            }
            return Count;
        }

        // a string of the guessed letters 
        public string GuessedWord(List<Square> squares)
        {
            StringBuilder GuessedWord = new StringBuilder();
            foreach (Square s in Squares)
            {
                GuessedWord.Append(s.Letter);
            }
            return GuessedWord.ToString();
        }
    

        public List<string> DuplicateLetters(string word)
        {
  
            List<string> duplicateLetters = new List<string>();  
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    if ((word[i].ToString() == word[j].ToString()) && (i != j) && (!duplicateLetters.Contains(word[i].ToString())))
                    {
                        duplicateLetters.Add(word[i].ToString());

                    }
                }
            }
            return duplicateLetters;
        }

        public List<string> AllLetters(string word)
        {
            List<string> allLetters = new List<string>();
            for(int i=0; i<word.Length; i++)
            {
                allLetters.Add(word[i].ToString());
            }
            return allLetters;
        }

        public List<GuessedLetter> FillList(string word)
        {
            List<string> duplicateLetters = DuplicateLetters(word);
            List<string> allLetters = AllLetters(word);
            List<GuessedLetter> duplicates = new List<GuessedLetter>();
            foreach (string l in duplicateLetters)
            {
                int Count = 0;
                foreach (string letter in allLetters)
                {
                    if (letter == l)
                    {
                        Count += 1;
                    }
                }
                duplicates.Add(new GuessedLetter(l, Count));
            }
            return duplicates;
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

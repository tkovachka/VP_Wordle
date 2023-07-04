using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wordle
{
    public class Scene
    {
        public List<Word> Words { get; set; }

        Dictionary dictionary { get; set; }

        public String WordToGuess { get; set; }
        public bool GameOver { get; set; }

        Random random = new Random();

        public bool full { get; set; }

        public List<string> lettersGuessed { get; set; } = new List<string>();
        public Scene(Point Center, int num)
        {
            GameOver = false;
            full = false;
            Words = new List<Word>();
            for (int i = 0; i < 5; i++)
            {
                Words.Add(new Word(Center, num));
                Center.Y += 60;
            }
            dictionary = new Dictionary();
           
            switch (num)
            {
                case 5: //WordToGuess = dictionary.FiveLetters[random.Next(0,dictionary.FiveLetters.Count)]; break;
                    WordToGuess = "CLOSE"; break;
                case 6: //WordToGuess = dictionary.SixLetters[random.Next(0, dictionary.SixLetters.Count)]; break;
                    WordToGuess = "BANANA"; break;
                default: WordToGuess = dictionary.SevenLetters[random.Next(0, dictionary.SevenLetters.Count)]; break;
            }

        }

        public string lettersLeft()
        {
            foreach (Word w in Words)
            {
                foreach (Square s in w.Squares)
                {
                    if (s.Status == 3)
                    {
                        lettersGuessed.Add(s.Letter);
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            for(char c='A';c<='Z'; c++)
            {
                if (lettersGuessed.Contains(c.ToString()))
                {
                    sb.Append(" ");
                }
                else
                {
                    sb.Append(c);
                }
                sb.Append(" ");
            }
            return sb.ToString();
        }

       
        public void Draw(Graphics g)
        {
            foreach (Word word in Words)
            {
                word.Draw(g);
            }
        }

       

        public void AddLetter(string letter)
        {
            //lettersGuessed.Add(letter);
            foreach (Word w in Words)
            {
                if (!w.IsFull)
                {
                    w.AddLetter(letter);
                   return;
                }
               
                
            }
        }

        public bool Check()
        {
            foreach(Word w in Words)
            {
                if (w.IsFull)
                {
                    if (w == Words[Words.Count() - 1])
                    {
                        GameOver = true;
                    }
                    w.checkLetters(WordToGuess);
                    if (w.IsCorrect())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool SceneIsFull()
        {
            
                foreach (Word w in Words)
                {
                    if (!w.IsFull)
                    {
                        return false;
                    }
                }
                return true;
        }

       
    }
}


﻿using System;
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

        Random random = new Random();

       
        public Scene(Point Center, int num)
        {
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
                    WordToGuess = "TABLE"; break;
                case 6: WordToGuess = dictionary.SixLetters[random.Next(0, dictionary.SixLetters.Count)]; break;
                default: WordToGuess = dictionary.SevenLetters[random.Next(0, dictionary.SevenLetters.Count)]; break;
            }

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
                    w.checkLetters(WordToGuess);
                    if (w.IsCorrect())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

       
    }
}


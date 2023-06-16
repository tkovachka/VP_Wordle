using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    public class Scene
    {
        public List<Word> Words { get; set; }
        public Scene(Point Center,int num) { 
            Words = new List<Word>();
            for(int i = 0; i < 5; i++)
            {
                Words.Add(new Word(Center, num));
                Center.Y += 60;
            }

        }
        public void Draw(Graphics g)
        {
            foreach(Word word in Words)
            {
                word.Draw(g);
            }
        }
    }
}

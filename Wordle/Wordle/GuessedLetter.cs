using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    public class GuessedLetter
    {
        public string Letter { get; set; }

        public bool Found { get; set; }

        public int Count { get; set; }

        public GuessedLetter(string l)
        {
            Found = false;
            Letter = l;
            Count = 0;
        }

        public GuessedLetter(string l, int c)
        {
            Found = false;
            Letter = l;
            Count = c;
        }


    }
}

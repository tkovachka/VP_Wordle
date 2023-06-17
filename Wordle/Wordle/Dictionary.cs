using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    public class Dictionary
    {
        public List<string> FiveLetters { get; set; }
        public List<string> SixLetters { get; set; }
        public List<string> SevenLetters { get; set; }

        public Dictionary()
        {
            FiveLetters = new List<string>() { "BRISK", "CRANK", "DREAM", "ELITE", "FLAME", "GHOST", "HUMPS", "IVORY", "JUMPS", "KINGS", "LUNCH", "MAGIC", "NINJA", "OLIVE", "PUNCH", "QUACK", "ROAST", "SHARK", "THUMP", "UPPER", "VENUS", "WACKY", "XYLOP", "YUMMY", "ZEBRA" };
            SixLetters = new List<string>() { "MIRROR", "WALRUS", "GUITAR", "DRAGON", "COWBOY", "JUNGLE", "SUNSET", "VICTOR", "BANANA", "ZEBRA", "POLICE", "EXOTIC", "FABRIC", "MARBLE", "PEPPER", "QUARTZ", "SIZZLE", "WIZARD", "TONGUE", "YELLOW" };
            SevenLetters = new List<string>() { "VICTORY", "CHARGER", "JUMPING", "WIZARDS", "CONQUER", "FANTASY", "MIRACLE", "BANANAS", "ZEBRAS", "EXPLORE", "JOURNEY", "SHADOWS", "GLITTER", "MARVELS", "QUICKLY", "SPRINGS", "YELLING" };
        }
    }
}

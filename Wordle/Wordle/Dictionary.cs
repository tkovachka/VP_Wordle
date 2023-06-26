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
            FiveLetters = new List<string>() { "APPLE", "BINGO", "CARAT", "DAISY", "EMAIL", "FANCY", "GIANT", 
                "HOBBY", "IVORY", "JELLY", "KARMA", "LEMON", "MANGO", "NOBLE", "OASIS", "PIANO", "QUIRK",
                "RADAR", "SALAD", "TANGO", "URBAN", "VIVID", "WALTZ", 
                "XEROX", "YACHT", "ZESTY","BRISK", "CRANK", "DREAM", "ELITE", "FLAME", "GHOST", 
                "HUMPS", "IVORY", "JUMPS", "KINGS", "LUNCH", "MAGIC", "NINJA", "OLIVE", "PUNCH", "QUACK", 
                "ROAST", "SHARK", "THUMP", "UPPER", "VENUS", "WACKY", "XYLOP", "YUMMY", "ZEBRA" };
            SixLetters = new List<string>() { "MIRROR", "WALRUS", "GUITAR", 
                "DRAGON", "COWBOY", "JUNGLE", "SUNSET", "VICTOR", 
                "BANANA", "ZEBRA", "POLICE", "EXOTIC", "FABRIC", 
                "MARBLE", "PEPPER", "QUARTZ", "SIZZLE", "WIZARD", "TONGUE", "YELLOW",
                "ALPHAS", "BEACON", "CATTLE", "DOLLAR", "ESCAPE", "FOLLOW", 
                "GALAXY", "HEALTH", "INVENT", "JUMPER", "KITTEN", "LEGACY", 
                "MOTION", "NATURE", "ORANGE", "PEOPLE", "QUENCH", "ROBUST", 
                "SALUTE", "TROPHY", "UNIQUE", "VELVET", "WIZARD", "XENIAL", "YELLOW", "ZENITH"
            };
            SevenLetters = new List<string>() { "VICTORY", "CHARGER", "JUMPING", "WIZARDS", 
                "CONQUER", "FANTASY", "MIRACLE", "BANANAS", "ZEBRAS", "EXPLORE", 
                "JOURNEY", "SHADOWS", "GLITTER", "MARVELS", "QUICKLY", "SPRINGS", "YELLING",
                "ANALYZE", "BOTTLES", "CONTROL", "DYNAMIC", "EXPLORE", "FACTORY", 
                "GARBAGE", "HARMONY", "INVOICE", "JOURNAL", "KITCHEN", "LANDLORD", "MOMENTS", "NETWORK", 
                "OUTDOOR", "PASSAGE", "QUALITY", "RESCUED", "SYMBOLS",
                "TENSION", "UNIFIED", "VALUATE", "WONDERS", "XEROXED", "YOUNGER", "ZEPPELIN"
            };
        }
    }
}

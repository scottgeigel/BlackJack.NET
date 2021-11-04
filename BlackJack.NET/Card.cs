using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.NET
{
    public enum Suite
    {
        Spade,
        Club,
        Heart,
        Diamond
    }

    public enum Face
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public class Card
    {
        public Suite Suite { get; set; }
        public Face Face { get; set; }
    }
}

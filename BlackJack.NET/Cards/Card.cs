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

        public override int GetHashCode()
        {
            return ((int)Face << 2) + ((int)Suite);
        }

        public override bool Equals(object obj)
        {
            Card other = obj as Card;
            if (obj == null)
            {
                return false;
            }
            return other.Face == Face && other.Suite == Suite;
        }

        public override string ToString()
        {
            return $"{Face} of {Suite}";
        }
    }
}

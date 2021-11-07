using BlackJack.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class CardTest
    {
        [Fact(DisplayName = "card hashes are unique")]
        public void CheckHash()
        {
            Suite[] suites = (Suite[])Enum.GetValues(typeof(Suite));
            Face[] faces = (Face[])Enum.GetValues(typeof(Face));
            HashSet<Card> history = new();
            foreach(Suite suite in suites)
            {
                foreach(Face face in faces)
                {
                    Card card = new() { Face = face, Suite = suite };
                    if (history.Count > 0)
                    {
                        Assert.DoesNotContain(card, history);
                    }
                    history.Add(card);
                }
            }
        }
    }
}

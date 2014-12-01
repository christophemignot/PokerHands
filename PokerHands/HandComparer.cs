using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class HandComparer : IComparer<Card[]>, IComparer<string[]>
    {
        public int Compare(Card[] handOne, Card[] handTwo)
        {
            var cardComparer = new CardComparer();
            var handOneAsHand = new Hand(handOne);
            var handTwoAsHand = new Hand(handTwo);
            return handOneAsHand.Value.CompareTo(handTwoAsHand.Value);
        }

        public int Compare(string[] handOne, string[] handTwo)
        {
            var handCardsOne = new Card[5];
            var handCardsTwo = new Card[5];
            for (int i = 0; i < 5; i++)
            {
                handCardsOne[i] = new Card(handOne[i]);
                handCardsTwo[i] = new Card(handTwo[i]);
            }
            return this.Compare(handCardsOne, handCardsTwo);
        }
    }
}

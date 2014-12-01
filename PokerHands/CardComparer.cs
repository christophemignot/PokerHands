using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class CardComparer : IComparer<Card>, IComparer<string>
    {
        public int Compare(Card cardOne, Card cardTwo)
        {
            return cardOne.Value.CompareTo(cardTwo.Value);
        }

        public int Compare(string cardOne, string cardTwo)
        {
            return this.Compare(new Card(cardOne), new Card(cardTwo));
        }
    }
}

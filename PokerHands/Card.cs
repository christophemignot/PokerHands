using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    using System.Configuration;

    public class Card
    {
        public Card(string card)
        {
            this.Value = GetCardValue(card);
        }

        private static double GetCardValue(string card)
        {
            string cardValue = card.Substring(0, 1);
            int result;
            if (Int32.TryParse(cardValue, out result))
                return Math.Pow(2, result);
            switch (cardValue)
            {
                case "T":
                    return Math.Pow(2, 10);
                case "J":
                    return Math.Pow(2, 11);
                case "Q":
                    return Math.Pow(2, 12);
                case "K":
                    return Math.Pow(2, 13);
                case "A":
                    return Math.Pow(2, 14);
                default:
                    return 0;
            }
        }

        public double Value { get; set; }
    }
}

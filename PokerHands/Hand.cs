using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    using System.ComponentModel;
    using System.Text.RegularExpressions;

    public class Hand
    {
        public Hand(string[] cards)
        {
            var handCards = new Card[5];
            for (int i = 0; i < 5; i++)
            {
                handCards[i] = new Card(cards[i]);
            }
            this.sortedCards = handCards;
            Array.Sort(this.sortedCards, new CardComparer());
            this.Value = GetHandValue();
        }

        public Hand(Card[] sortedCards)
        {
            this.sortedCards = sortedCards;
            Array.Sort(this.sortedCards, new CardComparer());
            this.Value = GetHandValue();
        }
        public double Value { get; set; }
        private Card[] sortedCards;

        private double GetHandValue()
        {
            double result = this.sortedCards.Sum(card => card.Value);
            result += SameValuesScore();
            result += StraightScore();
            result += FlushScore();
            return result;
        }

        private double SameValuesScore()
        {
            var groupedValues =
                this.sortedCards.GroupBy(card => card.Value)
                    .Select(g => new { Value = g.Key, Count = g.ToList().Count })
                    .OrderByDescending(item => item.Count)
                    .ToList();
            if (groupedValues[0].Count == 4) //Four
            {
                return Math.Pow(2, 20);
            }
            if (groupedValues[0].Count == 3)
            {
                if (groupedValues[1].Count == 2) //Full
                {
                    return Math.Pow(2, 19);
                }
                else
                {
                    return Math.Pow(2, 16); //Three of a kind
                }
            }
            if (groupedValues[0].Count == 2)
            {
                {
                    if (groupedValues[1].Count == 2) //2 pairs
                    {
                        return 2 * Math.Pow(2, 15)-1; //-1 to avoid miss comparision of 3 of a kind
                    }
                    else
                    {
                        return 2 * Math.Pow(2, 15); //1 Pair
                    }
                }
            }
            return 0;
        }

        private double StraightScore()
        {
            for (int i = 1; i < 5; i++)
            {
                if (Math.Abs(sortedCards[i].Value - sortedCards[i - 1].Value - 1) > double.Epsilon) //Epsilon avoids rounding error on double comparison
                {
                    return 0;
                }
            }
            return Math.Pow(2, 17);
        }

        private double FlushScore()
        {
            //Need to compute flush score => need to add suit to card
            //
            //Program give points to Straigth and flush separatly
            //How is straight flush vs Four or Full score?
            return 0;
        }
    }
}

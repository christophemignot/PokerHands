namespace PokerHandsTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PokerHands;

    [TestClass]
    public class PokerHandsTest
    {
        [TestMethod]
        public void WhenTwoCardsThenHigherIsBetter()
        {
            var cardComparer = new CardComparer();
            int result = cardComparer.Compare("2C", "1C");
            Assert.AreEqual(1, result);

            result = cardComparer.Compare("TC", "1C");
            Assert.AreEqual(1, result);

            result = cardComparer.Compare("JC", "QC");
            Assert.AreEqual(-1, result);

            result = cardComparer.Compare("KC", "AH");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void WhenHighCardThenHigherWins()
        {
            var handComparer = new HandComparer();

            int result = handComparer.Compare(
                new [] { "2C", "AC", "1C", "3C", "KC" },
                new [] { "2C", "KC", "1C", "3C", "QC"});
            Assert.AreEqual(1, result);


            result = handComparer.Compare(
                new[] { "1C", "2C", "6C", "4C", "5C" },
                new[] { "7H", "1H", "2H", "3H", "4H" });
            Assert.AreEqual(-1, result);

            result = handComparer.Compare(
                new[] { "1C", "2C", "3C", "4C", "7C" },
                new[] { "7H", "1H", "2H", "3H", "4H" });
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void WhenPairThenHigherWins()
        {
            var handComparer = new HandComparer();

            int result = handComparer.Compare(
                new[] { "2C", "AC", "1C", "3C", "KC" },
                new[] { "2H", "2S", "1H", "3H", "QH" });
            Assert.AreEqual(-1, result);


            result = handComparer.Compare(
                new[] { "2C", "2D", "6C", "4C", "5C" },
                new[] { "TH", "TS", "2H", "3H", "4H" });
            Assert.AreEqual(-1, result);

            result = handComparer.Compare(
                new[] { "AC", "AD", "3C", "4C", "7C" },
                new[] { "AH", "AS", "2H", "3H", "4H" });
            Assert.AreEqual(1, result);
        }
    }
}

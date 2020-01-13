using System;
using ExtensibleTennis.Tennis;
using NUnit.Framework;

namespace ExtensibleTennis.Tests
{
    [TestFixture]
    public class TennisPlayerShould
    {
        [Test]
        public void HaveAName()
        {
            var sut = new TennisPlayer(2);
            Assert.IsNotNull(sut.Name);
            Assert.IsNotEmpty(sut.Name);
        }

        [Test]
        public void SetScoreToZeroAsDefault()
        {
            var sut = new TennisPlayer(2);
            Assert.AreEqual(TennisScore.Love, sut.GetScore());
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void IncrementScoreByOne(int currentScore)
        {
            var sut = new TennisPlayer(currentScore, 2);
            sut.IncrementScore();
            var expectedScore = (TennisScore)(currentScore + 1);
            Assert.AreEqual(expectedScore, sut.GetScore());
        }

        [TestCase(5)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void DecreaseScoreByOne(int currentScore)
        {
            var sut = new TennisPlayer(currentScore, 2);
            sut.DecreaseScore();
            var expectedScore = (TennisScore)(currentScore - 1);
            Assert.AreEqual(expectedScore, sut.GetScore());
        }

        [Test]
        public void ThrowExceptionWhenInvalidScore()
        {
            var sut = new TennisPlayer(5, 2);
            Assert.Throws<IndexOutOfRangeException>(() => sut.IncrementScore());
        }
    }
}

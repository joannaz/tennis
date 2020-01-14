using System;
using ExtensibleTennis.Base;
using ExtensibleTennis.Tennis;
using Moq;
using NUnit.Framework;

namespace ExtensibleTennis.Tests
{
    [TestFixture]
    public class TennisGameShould
    {
        private Mock<IPlayer> _player1;
        private Mock<IPlayer> _player2;

        [SetUp]
        public void SetUp()
        {
            _player1 = new Mock<IPlayer>();
            _player2 = new Mock<IPlayer>();
        }

        [Test]
        public void BeConstructable()
        {
            var sut = new TennisGame(_player1.Object, _player2.Object);
            Assert.IsNotNull(sut);
        }

        [Test]
        public void ThrowExceptionOnWrongScore()
        {
            _player1.Setup(x => x.Score).Returns(-1);
            _player2.Setup(x => x.Score).Returns(-1);

            var sut = new TennisGame(_player1.Object, _player2.Object);

            Assert.Throws<IndexOutOfRangeException>(() => sut.Play());
        }

        [Test]
        public void IncrementScoreUnderCorrectConditions()
        {
            _player1.Setup(x => x.Score).Returns(0);
            _player2.Setup(x => x.Score).Returns(1);

            var sut = new TennisGame(_player1.Object, _player2.Object);
            sut.Score(_player1.Object, _player2.Object);

            _player1.Verify(mock => mock.IncrementScore(), Times.Once());
        }

        [Test]
        public void WinGameWhenScoreIsCorrect()
        {
            _player1.Setup(x => x.Score).Returns(0);
            _player2.Setup(x => x.Score).Returns(3);

            var sut = new TennisGame(_player2.Object, _player1.Object);
            sut.Score(_player2.Object, _player1.Object);

            _player2.Verify(mock => mock.SetScoreToGame(), Times.Once);
        }

        [Test]
        [TestCase(0, 0, true,  1, 0)]
        [TestCase(0, 0, false, 0, 1)]
        [TestCase(1, 0, false, 1, 1)]
        [TestCase(1, 0, true,  2, 0)]
        [TestCase(0, 1, true,  1, 1)]
        [TestCase(0, 1, false, 0, 2)]
        [TestCase(2, 3, true,  3, 3)]
        [TestCase(2, 3, false, 2, 5)]
        [TestCase(3, 3, false, 3, 4)]
        [TestCase(4, 3, false, 3, 3)]
        public void IncrementScoreCorrectly(int player1, int player2, bool player1Win, int player1Outcome, int player2Outcome)
        {
            // Set up original score
            var tennisPlayer1 = new TennisPlayerBuilder().WithScore(player1).Build();
            var tennisPlayer2 = new TennisPlayerBuilder().WithScore(player2).Build();
            
            var sut = new TennisGame(_player1.Object, _player2.Object);

            if (player1Win)
            {
                sut.Score(tennisPlayer1, tennisPlayer2);
            }
            else
            {
                sut.Score(tennisPlayer2, tennisPlayer1);
            }

            Assert.AreEqual(player1Outcome, tennisPlayer1.Score);
            Assert.AreEqual(player2Outcome, tennisPlayer2.Score);
        }


        private class TennisPlayerBuilder
        {
            private int _score;
            private string _name;

            public TennisPlayerBuilder WithScore(int score)
            {
                _score = score;
                return this;
            }

            public TennisPlayerBuilder WithName(string name)
            {
                _name = name;
                return this;
            }

            public TennisPlayer Build()
            {
                return new TennisPlayer(_score, _name);
            }
        }
    }
}

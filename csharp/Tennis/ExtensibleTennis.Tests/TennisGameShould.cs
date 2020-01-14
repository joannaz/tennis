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

            var sut = new TennisGame(_player1.Object, _player2.Object);

            Assert.Throws<IndexOutOfRangeException>(() => sut.Play());
        }

        [Test]
        public void IncrementScoreUnderCorrectConditions()
        {
            _player1.Setup(x => x.Score).Returns(2);
            _player2.Setup(x => x.Score).Returns(3);

            var sut = new TennisGame(_player1.Object, _player2.Object);
            sut.Score(_player1.Object, _player2.Object);

            _player1.Verify(mock => mock.IncrementScore(), Times.Once());
        }

        [Test]
        public void WinGameWhenScoreIsCorrect()
        {

        }
    }
}

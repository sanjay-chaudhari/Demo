using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingFixtures
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void Validate_ZeroScore()
        {
            Bowling.Game g = new Bowling.Game();
            for (int i = 0; i < 20; i++)
                g.Roll(0);
            Assert.AreEqual(0, g.GetScore());
        }

        [TestMethod]
        public void Check_CorrectSpareScore()
        {
            Bowling.Game g = new Bowling.Game();
            g.Roll(5);
            g.Roll(5);
            g.Roll(3);
            Assert.AreEqual(13, g.GetScore());
        }

        [TestMethod]
        public void Check_CorrectStrikeScore()
        {
            Bowling.Game g = new Bowling.Game();
            g.Roll(10);
            g.Roll(5);
            g.Roll(6);
            Assert.AreEqual(21, g.GetScore());
        }

        [TestMethod]
        public void Check_AllStrikes()
        {
            Bowling.Game g = new Bowling.Game();
            for (int i = 0; i < 10; i++)
            {
                g.Roll(10);
            }
            Assert.AreEqual(300, g.GetScore());
        }

        [TestMethod]
        public void Check_AllOnes()
        {
            Bowling.Game g = new Bowling.Game();
            for (int i = 0; i < 20; i++)
            {
                g.Roll(1);
            }
            Assert.AreEqual(20, g.GetScore());
        }

        [TestMethod]
        public void Check_AllCommonRecords()
        {
            Bowling.Game g = new Bowling.Game();
            g.Roll(3);
            g.Roll(3);
            g.Roll(3);
            g.Roll(3);
            g.Roll(4);
            g.Roll(4);
            g.Roll(4);
            g.Roll(4);
            g.Roll(5);
            g.Roll(5);
            g.Roll(5);
            g.Roll(5);
            g.Roll(6);
            g.Roll(6);
            g.Roll(6);
            g.Roll(6);
            g.Roll(7);
            g.Roll(7);
            g.Roll(7);
            g.Roll(7);
            Assert.AreEqual(111, g.GetScore());
        }


        [TestMethod]
        public void Check_NormalsCount()
        {
            Bowling.Game g = new Bowling.Game();
            g.Roll(1);
            g.Roll(4);

            g.Roll(4);
            g.Roll(5);

            g.Roll(6);
            g.Roll(4);

            g.Roll(5);
            g.Roll(5);

            g.Roll(10);

            g.Roll(0);
            g.Roll(1);

            g.Roll(7);
            g.Roll(3);

            g.Roll(6);
            g.Roll(4);

            g.Roll(10);

            g.Roll(2);
            g.Roll(8);
            g.Roll(6);

            Assert.AreEqual(133, g.GetScore());
        }

        [TestMethod]
        public void Check_ActualScenarioForAssignment()
        {
            Bowling.Game g = new Bowling.Game();
            // 1 Set
            g.Roll(10);

            // 2 Set
            g.Roll(9);
            g.Roll(1);

            // 3 Set
            g.Roll(5);
            g.Roll(5);

            // 4 Set
            g.Roll(7);
            g.Roll(2);

            // 5 Set
            g.Roll(10);

            // 6 Set
            g.Roll(10);

            // 7 Set
            g.Roll(10);

            // 8 Set
            g.Roll(9);
            g.Roll(0);

            // 9 Set
            g.Roll(8);
            g.Roll(2);

            // 10 Set
            g.Roll(9);
            g.Roll(1);
            g.Roll(10);

            Assert.AreEqual(187, g.GetScore());
        }


        [TestMethod]
        public void Check_RandomGameNoExtraRoll()
        {
            Bowling.Game g = new Bowling.Game();
            g.Roll(1);
            g.Roll(3);
            g.Roll(7);
            g.Roll(3);
            g.Roll(10);
            g.Roll(1);
            g.Roll(7);
            g.Roll(5);
            g.Roll(2);
            g.Roll(5);
            g.Roll(3);
            g.Roll(8);
            g.Roll(2);
            g.Roll(8);
            g.Roll(2);
            g.Roll(10);
            g.Roll(9);
            g.Roll(0);
            Assert.AreEqual(122, g.GetScore());
        }

        [TestMethod]
        public void Check_RandomGameWithSpareThenStrikeAtEnd()
        {
            Bowling.Game g = new Bowling.Game();
            g.Roll(1);
            g.Roll(3);
            g.Roll(7);
            g.Roll(3);
            g.Roll(10);
            g.Roll(1);
            g.Roll(7);
            g.Roll(5);  
            g.Roll(2);
            g.Roll(5);
            g.Roll(3);
            g.Roll(8);
            g.Roll(2);
            g.Roll(8);
            g.Roll(2);
            g.Roll(10);
            g.Roll(9);
            g.Roll(1);
            g.Roll(10);
            Assert.AreEqual(143, g.GetScore());
        }

        [TestMethod]
        public void Check_RandomGameWithThreeStrikesAtEnd()
        {
            Bowling.Game g = new Bowling.Game();
            g.Roll(1);
            g.Roll(3);
            g.Roll(7);
            g.Roll(3);
            g.Roll(10);
            g.Roll(1);
            g.Roll(7);
            g.Roll(5);
            g.Roll(2);
            g.Roll(5);
            g.Roll(3);
            g.Roll(8);
            g.Roll(2);
            g.Roll(8);
            g.Roll(2);
            g.Roll(10);
            g.Roll(10);
            g.Roll(10);
            g.Roll(10);
            Assert.AreEqual(163, g.GetScore());
        }
    }
}

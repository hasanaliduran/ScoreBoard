using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScoreBoard_CaseStudy;


namespace ScoreBoard_Test
{
    [TestClass]
    public class MatchTest
    {

        private Team homeTeam;
        private Team awayTeam;
        private Match testMatch;

        [TestInitialize()]
        public void Startup()
        {
            homeTeam = new Team("home team");
            awayTeam = new Team("away team");
            testMatch = new Match(homeTeam,awayTeam);
            
        }
        [TestMethod]
        public void TestValidUpdateScore()
        {

            var result = testMatch.UpdateMatchScore(2, 2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestInValidUpdateScore()
        {
            var result = testMatch.UpdateMatchScore(-1, 2);
            Assert.IsFalse(result);
        }
    }
}

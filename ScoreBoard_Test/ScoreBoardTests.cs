using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScoreBoard_CaseStudy;
using System.Linq;


namespace ScoreBoard_Test
{
    [TestClass]
    public class ScoreBoardTests
    {

        private Team homeTeam;
        private Team awayTeam;
        private ScoreBoard scoreBoard;
        private Match testMatch;

        [TestInitialize()]
        public void Startup()
        {
            homeTeam = new Team("home team");
            awayTeam = new Team("away team");
            scoreBoard = new ScoreBoard();
            
        }
        [TestMethod]
        public void TestStartMatch()
        {
            var matchId = scoreBoard.StartMatch(homeTeam, awayTeam);
            var results = scoreBoard.GetSummaryofScoreBoard().ToList();

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(matchId, results[0].PmatchId);
       
        }

        [TestMethod]
        public void TestFinishMatch()
        {
            var matchId = scoreBoard.StartMatch(homeTeam, awayTeam);
            var resultFinish = scoreBoard.FinishMatch(matchId);
            Assert.IsTrue(resultFinish);

            var results = scoreBoard.GetSummaryofScoreBoard().ToList();
            Assert.AreEqual(0, results.Count);

        }



        [TestMethod]
        public void TestSortedMatch()
        {
            var homeTeam2 = new Team("home team2");
            var awayTeam2 = new Team("away team2");
            var matchId = scoreBoard.StartMatch(homeTeam, awayTeam);
            var matchId2 = scoreBoard.StartMatch(homeTeam2, awayTeam2);
            var results = scoreBoard.GetSummaryofScoreBoard().ToList();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(matchId2, results[0].PmatchId);
            Assert.AreEqual(matchId, results[1].PmatchId);

            scoreBoard.UpdateScore(matchId, 1, 0);
            results = scoreBoard.GetSummaryofScoreBoard().ToList();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(matchId, results[0].PmatchId);
            Assert.AreEqual(matchId2, results[1].PmatchId);
        }


        [TestMethod]
        public void TestSameScoreMatchSort()
        {
            var homeTeam2 = new Team("home team2");
            var awayTeam2 = new Team("away team2");
            var matchId = scoreBoard.StartMatch(homeTeam, awayTeam);
            var matchId2 = scoreBoard.StartMatch(homeTeam2, awayTeam2);
            var results = scoreBoard.GetSummaryofScoreBoard().ToList();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(matchId2, results[0].PmatchId);
            Assert.AreEqual(matchId, results[1].PmatchId);

            scoreBoard.UpdateScore(matchId, 2, 2);
            results = scoreBoard.GetSummaryofScoreBoard().ToList();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(matchId, results[0].PmatchId);
            Assert.AreEqual(matchId2, results[1].PmatchId);

            scoreBoard.UpdateScore(matchId2, 3, 1);
            results = scoreBoard.GetSummaryofScoreBoard().ToList();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(matchId2, results[0].PmatchId);
            Assert.AreEqual(matchId, results[1].PmatchId);
        }
    }
}

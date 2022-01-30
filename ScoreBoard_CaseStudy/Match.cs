using System;
namespace ScoreBoard_CaseStudy
{
    public class Match
    {
        public Team PhomeTeam { get; private set; }
        public Team PawayTeam { get; private set; }
        public int PhomeTeamScore { get; private set; }
        public int PawayTeamScore { get; private set; }
        public DateTime PstartTime { get; private set; }
        public Guid PmatchId { get; private set; }

        public Match(Team homeTeam, Team awayTeam)
        {
            PhomeTeam = homeTeam;
            PawayTeam = awayTeam;
            PhomeTeamScore = 0;
            PawayTeamScore = 0;
            PstartTime = DateTime.Now;
            PmatchId = Guid.NewGuid();
        }


        public int GetTotalScore()
        {
            return PhomeTeamScore + PawayTeamScore;
        }

        /// <summary>
        /// This method returns false in case of an invalid score update request 
        /// </summary>
        /// <param name="homeTeamScore"></param>
        /// <param name="awayTeamScore"></param>
        /// <returns></returns>
        public bool UpdateMatchScore(int homeTeamScore, int awayTeamScore)
        {
            if (homeTeamScore < 0 || awayTeamScore < 0)
                return false;

            PhomeTeamScore = homeTeamScore;
            PawayTeamScore = awayTeamScore;

            return true;
        }

        // Equals is overriden so that matches can be stored in sorted set
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Match))
            {
                return false;
            }
            return this.PmatchId == ((Match)obj).PmatchId;
        }

        public override int GetHashCode()
        {
            return PmatchId.GetHashCode();
        }
    }
}

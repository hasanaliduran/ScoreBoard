using System;
using System.Collections.Generic;

namespace ScoreBoard_CaseStudy
{
    public class ScoreBoard : IScoreBoard 
    {
     
        private Dictionary<Guid, Match> dictMatches = new Dictionary<Guid, Match>();
        private SortedSet<Match> sortedMatches = new SortedSet<Match>(new MatchComparer());
        private object objLock = new object();


        public ScoreBoard()
        {
        }

        public Guid StartMatch(Team homeTeam, Team awayTeam)
        {
            var newMatch = new Match(homeTeam, awayTeam);
            var matchId = newMatch.PmatchId;
            lock (objLock)
            {
                dictMatches.Add(matchId, newMatch);
                sortedMatches.Add(newMatch);
            }
            
            return matchId;
        }

        public bool FinishMatch(Guid matchId)
        {
            lock (objLock)
            {
                if (!dictMatches.ContainsKey(matchId))
                    return false;

                dictMatches.TryGetValue(matchId, out var removedMatch);
                
                sortedMatches.Remove(removedMatch);
                dictMatches.Remove(matchId);

                return true;
            }
            

        }

        public IEnumerable<Match> GetSummaryofScoreBoard()
        {
            lock (objLock)
            {
                var sortedMatchesClone = new Match[sortedMatches.Count];
                sortedMatches.CopyTo(sortedMatchesClone);
                return sortedMatchesClone;
            }
        }

        public bool UpdateScore(Guid matchId, int homeTeamScore, int awayTeamScore)
        {
            lock (objLock)
            {
                var result = dictMatches.TryGetValue(matchId, out var updatedMatch);
                if (!result)
                    return false;

                result = updatedMatch.UpdateMatchScore(homeTeamScore, awayTeamScore);
                if (!result)
                    return false;

                // dictMatches[matchId] = updatedMatch;
                sortedMatches.Remove(updatedMatch);
                sortedMatches.Add(updatedMatch);

                return true;
            }
        }
    }
}

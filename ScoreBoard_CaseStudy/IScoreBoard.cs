using System;
using System.Collections.Generic;

namespace ScoreBoard_CaseStudy
{
    public interface IScoreBoard
    {
        /// <summary>
        /// This method is used in order to start the match 
        /// It return GUID of the new started match
        /// </summary>
        /// <param name="homeTeam">home team</param>
        /// <param name="awayTeam">away team</param>
        /// <returns></returns>
        Guid StartMatch(Team homeTeam, Team awayTeam);

        /// <summary>
        /// This method is used in order to finish the match 
        /// It returns whether this operation is successfull or not
        /// </summary>
        /// <param name="matchId">the desired match id to finish</param>
        /// <returns></returns>
        bool FinishMatch(Guid matchId);

        /// <summary>
        /// This method is used in order to update the match score   
        /// It returns whether this operation is successfull or not
        /// </summary>
        /// <param name="matchId">the desired match id to update</param>
        /// <param name="homeTeamScore">the desired score of home team </param>
        /// <param name="awayTeamScore">the desired score of away team </param>
        /// <returns></returns>
        bool UpdateScore(Guid matchId ,int homeTeamScore, int awayTeamScore);

        /// <summary>
        /// This method returns active matches list with the desired order
        /// </summary>
        /// <returns></returns>
        IEnumerable<Match> GetSummaryofScoreBoard();
    }
}
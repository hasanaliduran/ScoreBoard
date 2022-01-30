using System.Collections.Generic;

namespace ScoreBoard_CaseStudy
{

    // Customized comparer method for matches stored in sorted set
    public class MatchComparer : IComparer<Match>
    {
        public int Compare(Match m1, Match m2)
        {
            if(m1.GetTotalScore() == m2.GetTotalScore())
            {
                return m2.PstartTime.CompareTo(m1.PstartTime);
            }
            return m2.GetTotalScore().CompareTo(m1.GetTotalScore());


        }
    }
}

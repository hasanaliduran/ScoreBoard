using System;
namespace ScoreBoard_CaseStudy
{
    public class Team
    {
        public string PteamName { get; private set; }

        public Team(string teamName)
        {
            PteamName = teamName;
        }
    }
}

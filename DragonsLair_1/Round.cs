using System.Collections.Generic;

namespace DragonsLair_1
{
    public class Round
    {
        private List<Match> matches = new List<Match>();
        
        public void AddMatch(Match m)
        {
            matches.Add(m);
        }

        public Match GetMatch(string teamName1, string teamName2)
        {
            
            return null;
        }

        public bool IsMatchesFinished()
        {
            //bool MatchesFinished = false;
            //for (int i = false;) //dont know what to do

            return false;
        }

        public List<Team> GetWinningTeams()
        {
            List<Team> winningTeams = new List<Team>();
            foreach(Match match in matches)
            {
                winningTeams.Add(match.Winner);
            }

            return winningTeams;
        }

        public List<Team> GetLosingTeams()
        {
            List<Team> loosingTeams = new List<Team>();
            foreach(Match match in matches)
            {
                loosingTeams.Add(match.Winner);
            }
            return loosingTeams;
        }
    }
}

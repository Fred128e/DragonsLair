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
            bool areMatchesFinished = true;
            foreach(Match match in matches)
            {
                if (match.Winner==null)
                {
                    areMatchesFinished = false;
                }
            }

                return areMatchesFinished;
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
                
                if(match.FirstOpponent == match.Winner)
                {
                    loosingTeams.Add(match.SecondOpponent);
                }

                else
                {
                    loosingTeams.Add(match.FirstOpponent);
                }

            }
            return loosingTeams;
        }
    }
}

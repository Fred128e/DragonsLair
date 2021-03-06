﻿using System.Collections.Generic;

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

        public bool IsMatchesFinished() //Bestemmer om kampen er færdig
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

        public List<Team> GetWinningTeams() // Finder alle vinderne, og putter dem i en liste
        {
            List<Team> winningTeams = new List<Team>();
            foreach(Match match in matches)
            {
                winningTeams.Add(match.Winner);
            }

            return winningTeams;
        }

        public List<Team> GetLosingTeams() //Finder alle taberne, og putter dem i en seperart liste
        {
            List<Team> loosingTeams = new List<Team>();
            foreach(Match match in matches)
            {
                
                if(match.FirstOpponent.Name == match.Winner.Name)
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

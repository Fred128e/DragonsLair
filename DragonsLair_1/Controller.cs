using System;
using System.Collections.Generic;

namespace DragonsLair_1
{
    public class Controller
    {
        private TournamentRepo tournamentRepo = new TournamentRepo();

        public void ShowScore(string tournamentName)
        {
            int winnerpoint = 0;
            Tournament t = tournamentRepo.GetTournament(tournamentName);
            for(int i = 0; i < t.GetNumberOfRounds();i++)
            {
                Round currentRound = t.GetRound(i);
                List<Team> winningTeams = currentRound.GetWinningTeams();
                Dictionary<Team,int> scoreList = new Dictionary<Team,int>();
                foreach (Team winningTeam in winningTeams)
                {
                    int updateNumber = 1;
                    if(scoreList.TryGetValue(winningTeam, out int number))
                    {
                        updateNumber = number + 1;
                        scoreList.Remove(winningTeam);
                    }
                     scoreList.Add(winningTeam,updateNumber);

                }
                foreach (Team loosingTeam in winningTeams)
                {
                    if(scoreList.TryGetValue(loosingTeam,out int number))
                    {
                        scoreList.Remove(loosingTeam);
                    }
                }
                
            }



            /*
             * TODO: Calculate for each team how many times they have won
             * Sort based on number of matches won (descending)
             */
            //Console.WriteLine("Implement this method!");
        }

        public void ScheduleNewRound(string tournamentName, bool printNewMatches = true)
        {
            // Do not implement this method
        }

        public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
        {
            // Do not implement this method
        }
    }
}

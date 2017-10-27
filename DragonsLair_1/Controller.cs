using System;

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

                foreach (Team winningTeam in winningTeams)
                {
                    Console.WriteLine(winningTeam.Name);
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

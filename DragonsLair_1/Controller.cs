using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonsLair_1
{
    public class Controller
    {
        private TournamentRepo tournamentRepo = new TournamentRepo();

        public void ShowScore(string tournamentName)
        {
            int winnerpoint = 0;
            Tournament t = tournamentRepo.GetTournament(tournamentName);
            if(t == null)
            {
                Console.WriteLine("Turnering fandtes ikke");
                return;
            }
            Dictionary<string,int> scoreList = new Dictionary<string,int>();

            for(int i = 0;i < t.GetNumberOfRounds();i++)
            {
                Round currentRound = t.GetRound(i);
                List<Team> winningTeams = currentRound.GetWinningTeams();
                foreach(Team winningTeam in winningTeams)
                {
                    int updateNumber = 1;
                    if(scoreList.ContainsKey(winningTeam.Name))
                    {
                        if(scoreList.TryGetValue(winningTeam.Name,out int number))
                        {
                            updateNumber = number + 1;
                            scoreList.Remove(winningTeam.Name);
                        }
                    }
                    scoreList.Add(winningTeam.Name,updateNumber);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Status in round ");
            //sort scorelist ?!?
            var sortedList = scoreList.OrderByDescending(x => x.Value);
            
            foreach(var key in sortedList)
            {
                Console.WriteLine("Team: {0}: Won : {1}",key.Key,key.Value);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("done");
            /*
             * TODO: Calculate for each team how many times they have won
             * Sort based on number of matches won (descending)
             */
            //Console.WriteLine("Implement this method!");
        }

        public void ScheduleNewRound(string tournamentName,bool printNewMatches = true)
        {
            // Do not implement this method yet
        }

        public void SaveMatch(string tournamentName,int roundNumber,string team1,string team2,string winningTeam)
        {
            // Do not implement this method yet
        }
    }
}

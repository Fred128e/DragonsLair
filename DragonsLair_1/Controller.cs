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
            //sort scorelist 
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
            
            {
                Tournament tournament = tournamentRepo.GetTournament(tournamentName);

                int numberOfRound = tournament.GetNumberOfRounds();
                if(numberOfRound == 0)

                {
                    List<Team> teams = tournament.GetTeams();
                }
                else
                {
                    Round lastRound = tournament.GetRound(numberOfRound - 1);
                    bool isRoundFinished = lastRound.IsMatchesFinished();
                    if(isRoundFinished)
                    {
                        List<Team> teams = lastRound.GetWinningTeams();
                        if(teams.Count >= 2)
                        {
                            teams = ShuffleList(teams); // iFixit later
                            Round newRound = new Round();
                            if(teams.Count % 2 == 1) // If uneven number of teams
                            {
                                Team oldFreeRider = lastRound.GetFreeRider(); // Fix later
                                Team newFreeRider = teams[0];
                                while(newFreeRider == oldFreeRider)
                                {
                                    newFreeRider = teams[1];
                                }
                                teams.Remove(newFreeRider);
                                newRound.Add(newFreeRider);
                            }
                            while(teams.Count > 0) // Så længe der er én eller flere hold i teams listen
                            {
                                Match match = new Match();
                                match.FirstOpponent = teams[0];
                                teams.RemoveAt(0);
                                match.SecondOpponent = teams[0];
                                teams.RemoveAt(0);
                                newRound.AddMatch(match);
                            }
                            tournament.Add(newRound);
                        }
                        else
                        {
                            tournament.SetStatus("finished");//SetSatus metode fix later
                        }
                    }
                    else
                    {
                        Console.WriteLine("Round is not finished");
                    }
                }

            }

            //Tournament t = tournamentRepo.GetTournament(tournamentName);
            //if(t == null)
            //{
            //    Console.WriteLine("Turnering fandtes ikke");
            //    return;
            //}
            //int numberOfRounds = t.GetNumberOfRounds();

            //List<Team> teams = new List<Team>();
            //Round r = new Round();
            //bool isRoundFinished = r.IsMatchesFinished();
            //for(int i = 0;i < numberOfRounds;i++)
            //{
            //    if(i==0)
            //    {
            //        t.GetRound(i);
            //        teams = t.GetTeams();
            //    }
            //    if(isRoundFinished)
            //    {
            //        teams = r.GetWinningTeams();
            //        Random rnd = new Random();
            //        if(teams.Count >= 2)
            //        {
            //            var result = teams.OrderBy(team => rnd.Next());
            //        }
            //    }
            //}

            //////List<Team> teams = new List<Team>();
            //Round r = new Round();
            //bool isRoundFinished = r.IsMatchesFinished();
            //if(numberOfRounds == 3)
            //{
            //    //teams = t.GetTeams();
            //    r = t.GetRound(numberOfRounds - 1);

            //}
            //else
            //{
            //    r = t.GetRound(numberOfRounds - 1);

            //}

            //if(isRoundFinished)
            //{
            //    teams = r.GetWinningTeams();
            //    Random rnd = new Random();
            //    if(teams.Count >= 2)
            //    {
            //        var result = teams.OrderBy(team => rnd.Next());
            //    }
            //}


        }

        public void SaveMatch(string tournamentName,int roundNumber,string team1,string team2,string winningTeam)
        {
            

        }
    }
}

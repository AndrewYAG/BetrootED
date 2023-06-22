using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsHW
{
    public static class VoteTopicController
    {
        public static void StartVoteProcess(VoteTopic vote)
        {
            while (true)
            {
                PrintMenu();

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        vote.ShowVoteOptions();

                        Console.Write("Enter vote num to vote for: ");
                        int numOfTopic = int.Parse(Console.ReadLine());

                        try
                        {
                            vote.MakeVote(numOfTopic);
                        }
                        catch(ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case ConsoleKey.D2:
                        vote.ShowVoteResults();
                        break;

                    case ConsoleKey.D3:
                        vote.ShowVoteOptions();

                        Console.Write("Enter vote option to add: ");
                        var newOption = Console.ReadLine();

                        try
                        {
                        vote.AddVoteOption(newOption);
                        }
                        catch(ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case ConsoleKey.D4:
                        return;

                    default:
                        throw new ArgumentOutOfRangeException($"You pressed wrong button. It must be in range 1-4!");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Welcome to vote menu! Press button to choose option from the list bellow:");
            Console.WriteLine("1. Make Vote\n2. Show Vote Results\n3. Add Vote Option\n4. Exit");
        }
    }
}

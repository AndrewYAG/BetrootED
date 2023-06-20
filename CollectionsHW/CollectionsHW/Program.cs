namespace CollectionsHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // hint: maybe add a voter class and make sure that only unique persons can vote
            // add printing of vote results (num of votes, etc.)
            VoteTopic test = new VoteTopic("The Best Car Brand Vote.");

            test.AddVoteOption("Skoda");
            test.AddVoteOption("Volkswagen ");
            test.AddVoteOption("Renault");
            test.AddVoteOption("BMW");

            /*            test.ShowVoteOptions();

                        test.MakeVote(2);
                        test.MakeVote(2);
                        test.MakeVote(4);
                        test.MakeVote(4);
                        test.MakeVote(4);

                        test.ShowVoteResults();*/

            VoteTopicController.StartVoteProcess(test);
        }
    }
}
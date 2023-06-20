namespace CollectionsHW
{
    public class VoteTopic : IChangableTitle
    {
        public string Title { get; private set; }
        public Dictionary<int, Vote> VoteList { get; private set; }

        public VoteTopic(string title, Dictionary<int, Vote> voteList)
        {
            Title = title;
            VoteList = voteList;
        }
        public VoteTopic(string title) : this(title, new Dictionary<int, Vote>())
        {
        }

        public Vote this[int index]
        {
            get { return VoteList[index]; }
            private set { VoteList[index] = value; }
        }

        public void AddVoteOption(Vote newVoteVariant)
        {
            int nextKey = VoteList.Count + 1;
            VoteList.Add(nextKey, newVoteVariant);
        }

        public void AddVoteOption(string newVoteVariantTitle)
        {
            int nextKey = VoteList.Count + 1;
            VoteList.Add(nextKey, new Vote(newVoteVariantTitle));
        }

        public void ShowVoteOptions()
        {
            Console.WriteLine($"\nYou entered vote topic: {Title}\n");
            Console.WriteLine("You have following vote options:");
            foreach (var voteVariant in VoteList)
            {
                Console.WriteLine($"{voteVariant.Key} -- " + voteVariant.Value.Title);
            }
        }

        public void ShowVoteResults()
        {
            Console.WriteLine("\nVote results:");
            foreach (var voteVariant in VoteList)
            {
                Console.WriteLine($"№{voteVariant.Key} -- " + voteVariant.Value.Title + 
                    $" [{voteVariant.Value.NumOfVotes} Votes]");
            }
        }

        public void MakeVote(int numOfVoteOptionToVote) => VoteList[numOfVoteOptionToVote].IncreaseNumOfVotesByOne();

        public void ChangeTitle(string newTitle) => Title = newTitle;
    }
}
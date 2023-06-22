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
            if (String.IsNullOrWhiteSpace(newVoteVariantTitle))
                throw new ArgumentException("New vote option is null, empty or whitespace. It must contain a value!");

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

        public void MakeVote(int numOfVoteOptionToVote)
        {

            if (numOfVoteOptionToVote <= 0 || numOfVoteOptionToVote > (VoteList.Count))
                throw new ArgumentException("Invalid num of vote topic to vote for. " +
                    $"It must be in range [0; {VoteList.Count}]");

            VoteList[numOfVoteOptionToVote].IncreaseNumOfVotesByOne();
        }
        public void ChangeTitle(string newTitle) => Title = newTitle;
    }
}
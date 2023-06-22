namespace CollectionsHW
{
    public class Vote : IChangableTitle
    {
        public int NumOfVotes { get; private set; }
        public string Title { get; private set; }

        public Vote(string title, int numOfVotes = 0)
        {
            NumOfVotes = numOfVotes;
            Title = title;
        }

        public void ChangeTitle(string newTitle) => Title = newTitle;

        public void IncreaseNumOfVotesByOne() => NumOfVotes++;
    }
}
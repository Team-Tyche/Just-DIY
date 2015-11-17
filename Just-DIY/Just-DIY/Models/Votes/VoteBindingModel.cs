namespace Just_DIY.Models.Votes
{
    public class VoteBindingModel
    {
        public int UserId { get; set; }
        
        public int ProjectId { get; set; }

        public int Value { get; set; }
    }
}
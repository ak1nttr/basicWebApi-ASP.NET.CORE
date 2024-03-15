namespace WebApi_01.Entities
{
    public class Comment
    {
        public long Id { get; set; }
        public string Context { get; set; }
        public long PostId { get; set; } // destination
        public long UserId { get; set; } // origin


    }
}

namespace WebApi_01.Entities
{
    public class Post
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long FoodId { get; set; }
        public long UserId { get; set; }//many to one
            
         
    }
}




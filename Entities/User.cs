using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_01.Entities
{
    
    public class User
    {
        [Key]
        public long Id { get; set; }//auto increment
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }//hashed password
        public long CountryId { get; set; }



    }
}

using System.ComponentModel.DataAnnotations;

namespace PubAPI.Model
{
    public class AuthorModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings =true)]
        public string LastName { get; set; }
    }
}

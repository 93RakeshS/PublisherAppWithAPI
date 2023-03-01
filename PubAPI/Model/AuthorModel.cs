using System.ComponentModel.DataAnnotations;

namespace PubAPI.Model
{
    public class AuthorModel
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [MinLength(1,ErrorMessage ="Last Name can not be empty")]
        public string LastName { get; set; }
    }
}

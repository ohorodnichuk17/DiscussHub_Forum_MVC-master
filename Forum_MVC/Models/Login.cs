using System.ComponentModel.DataAnnotations;

namespace Forum_MVC.Models
{
    public class Login
    {
         public string Email { get; set; }

         [DataType(DataType.Password)]
         public string Password { get; set; }
    }
}

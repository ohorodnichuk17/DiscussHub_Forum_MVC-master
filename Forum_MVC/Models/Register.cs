using System.ComponentModel.DataAnnotations;

namespace Forum_MVC.Models
{
    public class Register
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class LoginModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please Fill User Id")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

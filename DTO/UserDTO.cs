using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }

        [EmailAddress(ErrorMessage = "the mail is not vaild")]
        public string Email { get; set; } = null!;

       [MinLength(2, ErrorMessage = "Min Length in name is 2 letters"), MaxLength(20, ErrorMessage = "Max Length in name is 20 letters")]
        public string FirstName { get; set; } = null!;

        [MinLength(2, ErrorMessage = "Min Length in name is 2 letters"), MaxLength(20, ErrorMessage = "Max Length in name is 20 letters")]
        public string LastName { get; set; } = null!;

        [MinLength(1, ErrorMessage = "Min Length in password is 1 letters"), MaxLength(10, ErrorMessage = "Max Length in password is 20 letters")]
        public string Password { get; set; } = null!;
    }
}

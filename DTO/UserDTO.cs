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

        [StringLength(4, ErrorMessage = "Length in cod is 4 letters"), MinLength(4, ErrorMessage = "Min Length in name is 2 letters")]
        public string Password { get; set; } = null!;
    }
}

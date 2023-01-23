namespace Entities
{
    using System.ComponentModel.DataAnnotations;
    public class UserValidations
    {
        public int Id { get; set; }

        [MinLength(2, ErrorMessage = "Min Length in name is 2 letters"), MaxLength(20, ErrorMessage = "Max Length in name is 20 letters")]
        public string UserName { get; set; }
        [StringLength(4, ErrorMessage = "Length in cod is 4 letters"), MinLength(4, ErrorMessage = "Min Length in name is 2 letters")]
        public string Cod { get; set; }
        [EmailAddress(ErrorMessage = "the mail is not vaild")]

        public string Mail { get; set; }
        [StringLength(10, ErrorMessage = "Length in phone is 10 numbers"), MinLength(9, ErrorMessage = "Min Length in name is 2 letters")]
        public string Phone { get; set; }
        [MinLength(2, ErrorMessage = "Min Length in name is 2 letters"), MaxLength(20, ErrorMessage = "Max Length in name is 20 letters")]
        public string FirstName { get; set; }
        [MinLength(2, ErrorMessage = "Min Length in name is 2 letters"), MaxLength(20, ErrorMessage = "Max Length in name is 20 letters")]
        public string LastName { get; set; }


    }
}
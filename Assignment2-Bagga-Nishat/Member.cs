using System.ComponentModel.DataAnnotations;

namespace Assignment2_Bagga_Nishat
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Provide First Name",AllowEmptyStrings = false), StringLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Provide Last Name", AllowEmptyStrings = false), StringLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Provide Address", AllowEmptyStrings = false)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Select Your City", AllowEmptyStrings = false)]
        public string City { get; set; }

        [Required(ErrorMessage = "Select Province", AllowEmptyStrings = false)]
        public string Province { get; set; }

        [Required(ErrorMessage = "Please Provide Your Postal Code", AllowEmptyStrings = false)]
        public string Postal_Code { get; set; }

        [Required(ErrorMessage = "Mention your Age", AllowEmptyStrings = false)]
        public string Age { get; set; }

        [Required(ErrorMessage = "Please Provide Password", AllowEmptyStrings = false)
            ,/*RegularExpression("^^(?=(.*\d){2})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{8,}$")*/]
        [StringLength(50,MinimumLength =7,ErrorMessage ="Password Must Be 7 Characters Long")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Password Does not Match")]
        public string ConfirmPassword { get; set; }

        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"+ "@"+ @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"
            , ErrorMessage ="Please Provide a Valid EmailAddress")]
        [Required(ErrorMessage ="Please Enter Your Email ID")]
        public string Email { get; set; }

        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"
            , ErrorMessage = "Please Provide a Valid EmailAddress")]
        public string AlternativeEmail { get; set; }

        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Please Provide a Valid PhoneNumber")]
        public string Phone { get; set; }
    }
}
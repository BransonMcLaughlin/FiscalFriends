using System.ComponentModel.DataAnnotations;

namespace FiscalFriendsWeb.Pages.UserModel

{
    public class User
    {

        public int Userid { get; set; }

        // First Name
        [Required(ErrorMessage = "A First Name is required.")]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }

        // Last Name
        [Required(ErrorMessage = "A Last Name is required.")]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }

        // Email
        [Required(ErrorMessage = "A Email is required.")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        // Phone Number
        [Required(ErrorMessage = "A Phone Number is required.")]
        [Display(Name = "Phone Number: ")]
        public int PhoneNumber { get; set; }

        // UserName
        [Required(ErrorMessage = "A Username is required.")]
        [Display(Name = "Username: ")]
        public string UserName { get; set; }

        // Password
        [Required(ErrorMessage = "A Password is required.")]
        [Display(Name = "Password: ")]
        public string Password { get; set; }

        // ZipCode
        [Required(ErrorMessage = "A Zipcode is required.")]
        [Display(Name = "Zipcode: ")]
        public string ZipCode { get; set; }

        // Birthday
        [Required(ErrorMessage = "A Birthday is required.")]
        [Display(Name = "Birthday: ")]
        public DateOnly Birthday { get; set; }
        public DateTime AccountMadeDate { get; set; }
        public DateTime LastLoggedIn { get; set; }

        public string ProfilePicture { get; set; }

        // Preferred Language
        [Required(ErrorMessage = "A Preferred Language is required.")]
        [Display(Name = "Preferred Language: ")]
        public string PreferredLanguage { get; set; }

        // Timezone
        [Required(ErrorMessage = "A Timezone is required.")]
        [Display(Name = "Timezone: ")]
        public string Timezone { get; set; }
        public DateTime RegisterDate { get; set; }

    }
}
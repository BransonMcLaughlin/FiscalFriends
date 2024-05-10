using System.ComponentModel.DataAnnotations;


namespace FiscalFriendsWeb.Pages.ProfileModel
{
    public class Profile
    {
        
        // need to create an instance of class Profile here !!!!!!
        //public Profile UserProfile { get; set; }

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

        public String PhoneNumber { get; set; }

        // Phone Number

        public int? PersonID { get; set; }

        // UserName
        [Required(ErrorMessage = "A Username is required.")]
        [Display(Name = "Username: ")]
        public string UserName { get; set; }

        // Password
        [Required(ErrorMessage = "A Password is required.")]
        [Display(Name = "Password: ")]
        [MinLength(10, ErrorMessage = "Minimum length of 10 characters is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Password Requirements Not Met! You must have at least 1 number, 1 uppercase letter, and one lowercase number.")]
        public string Password { get; set; }

        // Birthday

        public DateOnly Birthday { get; set; }
        public DateTime AccountMade { get; set; }
        public DateTime LastLoggedIn { get; set; }

        // public string ProfilePicture { get; set; }

        /*
        // Preferred Language
        [Required(ErrorMessage = "A Preferred Language is required.")]
        [Display(Name = "Preferred Language: ")]
        public string PreferredLanguage { get; set; }
        */

        // Timezone

        // public string Timezone { get; set; }
        public DateTime RegisterDate { get; set; }

        public bool rememberMe { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;

namespace FiscalFriendsWeb.Pages.Model
{
    public class DailyExpense
    {
        [Display(Name = "Date")]
        public DateTime date { get; set; }
        [Display(Name ="Category")]
        public int Category {  get; set; }
        [Display(Name = "Vendor")]
        [Required]
        public string vendor {  get; set; }
        [Required]
        public string paymentMethod {  get; set; }
        [Required]
        public double amount { get; set; }
        public string description {  get; set; }

    }
}

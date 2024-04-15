using System.ComponentModel.DataAnnotations;

namespace FiscalFriendsWeb.Pages.Model
{
    public class DailyExpense

    {
        public int ExpenseId {  get; set; }

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
        public Decimal amount { get; set; }
        public string description {  get; set; }

    }
}

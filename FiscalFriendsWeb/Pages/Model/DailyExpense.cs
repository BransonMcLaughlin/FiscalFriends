using System.ComponentModel.DataAnnotations;

namespace FiscalFriendsWeb.Pages.Model
{
    public class DailyExpense
    {
        public int DailyExpenseID { get; set; }
        [Display(Name = "Date")]
        public DateTime date { get; set; }
        [Display(Name ="Category")]
        public int Category {  get; set; }
        [Display(Name = "Vendor")]
        public string vendor {  get; set; }
        public string status {  get; set; }
        public string paymentMethod {  get; set; }
        public double amount { get; set; }
        public string recurring {  get; set; }
        public string reciept {  get; set; }

    }
}

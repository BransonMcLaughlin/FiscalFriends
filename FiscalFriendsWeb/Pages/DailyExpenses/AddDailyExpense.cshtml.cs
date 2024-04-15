using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using FiscalFriendsWeb.Pages.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FiscalFriendsWeb.Pages.DailyExpenses
{
    [BindProperties]
    public class AddDailyExpenseModel : PageModel
    {
        
        public DailyExpense newDailyExpense { get; set; } = new DailyExpense();

        // place holder for drop down
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public void OnGet()
        {
            PopulateCategoryDDL();
        }

        private void PopulateCategoryDDL()
        {
          // using cmdText = "SELECT "
        }
    }
}

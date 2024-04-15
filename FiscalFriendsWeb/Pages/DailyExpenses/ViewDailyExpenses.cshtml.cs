using FiscalFriendsWeb.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FiscalFriendsWeb.Pages.DailyExpenses
{
    [BindProperties]
    public class ViewDailyExpensesModel : PageModel
    {

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public List<DailyExpense> DailyExpenses { get; set; } = new List<DailyExpense>();
        public int selectedCategory;
        public void OnGet()
        {
        }
    }
}

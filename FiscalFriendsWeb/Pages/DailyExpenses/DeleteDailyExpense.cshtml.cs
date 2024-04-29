using FiscalFriendsBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace FiscalFriendsWeb.Pages.DailyExpenses
{
    [Authorize]
    public class DeleteDailyExpenseModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                String cmdText = "DELETE FROM DailyExpenses WHERE ExpenseId=@expenseId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@expenseId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return RedirectToPage("ViewDailyExpenses");
            }
        }
    }
}

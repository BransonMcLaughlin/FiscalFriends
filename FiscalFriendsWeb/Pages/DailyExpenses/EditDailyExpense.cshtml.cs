using FiscalFriendsBusiness;
using FiscalFriendsWeb.Pages.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace FiscalFriendsWeb.Pages.DailyExpenses
{
    [BindProperties]
    [Authorize]
    public class EditDailyExpenseModel : PageModel
    {
        
        public DailyExpense Expense { get; set; } = new DailyExpense();

        // place holder for drop down
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();

        public void OnGet(int id)
        {
            PopulateDailyExpense(id);
            PopulateCategoryDDL();
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "UPDATE DailyExpenses SET Amount=@amount, Description=@description, PaymentMethod=@paymentMethod, Vendor=@vendor, Date=@date, Category=@category WHERE ExpenseId=@expenseId";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@amount", Expense.amount);
                    cmd.Parameters.AddWithValue("@description", Expense.description);
                    cmd.Parameters.AddWithValue("@paymentMethod", Expense.paymentMethod);
                    cmd.Parameters.AddWithValue("@expenseId", id);
                    cmd.Parameters.AddWithValue("@vendor", Expense.vendor);
                    if (Expense.date == DateTime.MinValue)
                    {
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@date", Expense.date);
                    }
                    cmd.Parameters.AddWithValue("@category", Expense.Category);
                    //3. open the database
                    conn.Open();
                    //4. execute the command
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("ViewDailyExpenses");
                }
            }
            else
            {
                return Page();
            }
        
    }

        private void PopulateCategoryDDL()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                String cmdText = "SELECT CategoryId, CategoryDescription FROM ExpenseCategories ORDER BY CategoryDescription";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var Category = new SelectListItem();
                        Category.Value = reader.GetInt32(0).ToString();
                        Category.Text = reader.GetString(1);
                        if(Category.Value == Expense.Category.ToString())
                        {
                            Category.Selected = true;
                        }
                        Categories.Add(Category);
                    }
                }
            }
        }

        private void PopulateDailyExpense(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                String cmdText = "SELECT amount, description, paymentMethod, vendor, date, category FROM DailyExpenses WHERE expenseID=@ExpenseID";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@expenseID", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Expense.amount = reader.GetDecimal(0);
                    Expense.description = reader.GetString(1);
                    Expense.paymentMethod = reader.GetString(2);
                    Expense.vendor = reader.GetString(3);
                    Expense.date = reader.GetDateTime(4);
                    Expense.Category = reader.GetInt32(5);
                }
            }
        }
    }
}

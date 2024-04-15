using FiscalFriendsBusiness;
using FiscalFriendsWeb.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace FiscalFriendsWeb.Pages.DailyExpenses
{
    [BindProperties]
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
                    string cmdText = "UPDATE DailyExpenses(Amount=@amount, Description=@description, PaymentMethod=@paymentMethod, Vendor=@vendor, Date=@date, Category=@category)" +
                                              "WHERE DailyExpenseId=@expenseId";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@amount", Expense.amount);
                    cmd.Parameters.AddWithValue("@description", Expense.description);
                    cmd.Parameters.AddWithValue("@paymentMethod", Expense.paymentMethod);

                    cmd.Parameters.AddWithValue("@vendor", Expense.vendor);
                    cmd.Parameters.AddWithValue("@expenseId", id);
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
                String cmdText = "SELECT CategoryId, CategoryDescription FROM ExpenseCategories WHERE CategoryId=@categoryId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@categoryId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    //create the Expense.DailyExpenseId = id;
                    /// .
                    /// ..
                }
            }
        }
    }
}

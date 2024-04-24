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
    public class ViewDailyExpensesModel : PageModel
    {

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public List<DailyExpense> DailyExpenses { get; set; } = new List<DailyExpense>();
        public int SelectedCategoryId { get; set; }
        public void OnGet()
        {
            PopulateCategoryDDL();
            PopulateDailyExpense(0);
        }

        public void OnPost()
        {
            PopulateDailyExpense(SelectedCategoryId);
            PopulateCategoryDDL();
        }

        private void PopulateDailyExpense(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                String cmdText = "SELECT amount, description, paymentMethod, vendor, date, category, ExpenseId FROM DailyExpenses WHERE Category=@Category";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@Category", id );
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var Expense = new DailyExpense();
                        Expense.amount = reader.GetDecimal(0);
                        Expense.description = reader.GetString(1);
                        Expense.paymentMethod = reader.GetString(2);
                        Expense.vendor = reader.GetString(3);
                        Expense.date = reader.GetDateTime(4);
                        Expense.Category = reader.GetInt32(5);
                        Expense.ExpenseId = reader.GetInt32(6);
                        DailyExpenses.Add(Expense);
                    }
                }
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
                        if (Category.Value == SelectedCategoryId.ToString())
                        {
                            Category.Selected = true;   
                        }
                        Categories.Add(Category);
                    }
                }
            }
        }
    }
}

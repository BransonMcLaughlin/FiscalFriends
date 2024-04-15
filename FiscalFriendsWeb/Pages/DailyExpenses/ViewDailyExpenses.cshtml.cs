using FiscalFriendsBusiness;
using FiscalFriendsWeb.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace FiscalFriendsWeb.Pages.DailyExpenses
{
    [BindProperties]
    public class ViewDailyExpensesModel : PageModel
    {

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public List<DailyExpense> DailyExpenses { get; set; } = new List<DailyExpense>();
        public int SelectedCategoryId { get; set; }
        public void OnGet()
        {
            PopulateCategoryDDL();
        }

        public void onPost()
        {
            PopulateDailyExpense(SelectedCategoryId);
            PopulateCategoryDDL();
        }

        private void PopulateDailyExpense(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                String cmdText = "SELECT CategoryId, CategoryDescription FROM ExpenseCategories WHERE CategoryId=@categoryId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@categoryId", id );
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var Expense = new DailyExpense();
                        
                        if(Expense.Value == SelectedCategoryId.ToString())
                        {
                            Expense.Selected = true;
                        }
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

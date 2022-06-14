using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheNorthwind.DataAccess;

namespace TheNorthwind.Categories
{
    public partial class CategoryGridForm : Form
    {
        public CategoryGridForm()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var dbContext = new NorthWindContext();
            //var dbQuery = from cat in dbContext.Categories
            //              where cat.CategoryName.Contains(txtSearch.Text.Trim())

            //              select cat;

            //grdCategoryGridForm.DataSource = dbQuery.ToList();

            Func<Category, bool> whereCondition = 
                (cat) => cat.CategoryName.Contains(txtSearch.Text.Trim());

            var categories = dbContext.Categories
                .Where(cat => cat.CategoryName.Contains(txtSearch.Text.Trim()))
                .ToList();

            grdCategoryGridForm.DataSource = categories;
        }

        private void CategoryGridForm_Load(object sender, EventArgs e)
        {
            var dbContext = new NorthWindContext();
            grdCategoryGridForm.DataSource = dbContext.Categories.ToList();
        }

        private void grdCategoryGridForm_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                grdCategoryGridForm.Rows[e.RowIndex].Selected = true;
            }

           

           
        }

        public void RefreshGrid()
        {
            var dbContext = new NorthWindContext();
            grdCategoryGridForm.DataSource = dbContext.Categories.ToList();
        }

        private void deleteCategory_Click(object sender, EventArgs e)
        {
            var categoryId = (Category)grdCategoryGridForm.SelectedRows[0].DataBoundItem;

            var context = new NorthWindContext();

            try
            {
                var category = context.Categories.Find(categoryId.CategoryId);

                if (category != null)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                    MessageBox.Show("Kayıt silindi gitti!!!");

                    RefreshGrid();
                }

                #region Klasik Yöntem 
                //Klasik yöntem 
                //var category = context.Categories.Find(categoryId);
                //if (category!=null)
                //{
                //    context.Categories.Remove(category);
                //    context.SaveChanges();
                //    MessageBox.Show("silindi ");

                //}
                //else
                //{
                //    MessageBox.Show("silinmedi");
                //} 
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt silinemedi!\n\r{ex.Message}");
            }


        }

        private void updateCategory_Click(object sender, EventArgs e)
        {
            if (grdCategoryGridForm.SelectedRows.Count > 0)
            {
                var category = (Category)grdCategoryGridForm.SelectedRows[0].DataBoundItem;
                var categoryUpdateForm = new CategoryUpdateForm(category.CategoryId);
                categoryUpdateForm.Show();

                categoryUpdateForm.FormClosed += CategoryUpdateForm_FormClosed;
            }
        }

        private void CategoryUpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshGrid();
        }
    }
}

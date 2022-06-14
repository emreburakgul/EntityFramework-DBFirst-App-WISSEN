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
    public partial class CategoryCreateForm : Form
    {
        public CategoryCreateForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var context = new NorthWindContext();
            context.Categories.Add(CategoryCreat());
            try
            {
                context.SaveChanges();
                MessageBox.Show("Kayıt Başarılı :D");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Kydetme başarısız!!!"+ex.Message);
            }
          

        }

        private Category CategoryCreat() 
        {
            var category = new Category()
            {
                CategoryName = txtCatName.Text.Trim(),
                Description = txtCatDesc.Text.Trim(),
            };
            return category;
        }
    }
}

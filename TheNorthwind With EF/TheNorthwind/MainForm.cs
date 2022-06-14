using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheNorthwind.Categories;
using TheNorthwind.Orders;
using TheNorthwind.Products;

namespace TheNorthwind
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void NewCat_Click(object sender, EventArgs e)
        {
            var categoryCreatForm = new CategoryCreateForm();
            categoryCreatForm.Owner = this;
            categoryCreatForm.FormClosed += CategoryCreatForm_FormClosed;
            categoryCreatForm.Show();
        }

        private void CategoryCreatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var ownedForm in OwnedForms)
            {
                if (ownedForm is CategoryGridForm)
                {
                    var categoryGridForm = (CategoryGridForm)ownedForm;
                    categoryGridForm.RefreshGrid();
                }

            }
        }

        private void AllCat_Click(object sender, EventArgs e)
        {
            var categoryGridForm = new CategoryGridForm();
            categoryGridForm.Owner = this;
            categoryGridForm.Show();
        }

        private void NewProd_Click(object sender, EventArgs e)
        {
            var productCreatForm = new ProductCreateForm();
            productCreatForm.Show();
        }

        private void AllProd_Click(object sender, EventArgs e)
        {
            var productGirdForm = new ProductGridForm();
            productGirdForm.Show();
        }

        private void NewOrder_Click(object sender, EventArgs e)
        {
            var orderEditForm = new OrderEditForm();
            orderEditForm.Show();
        }

        private void AllOrder_Click(object sender, EventArgs e)
        {
            var orderGridForm = new OrderGridForm();
            orderGridForm.Show();
        }
    }
}

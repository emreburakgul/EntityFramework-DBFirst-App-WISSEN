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

namespace TheNorthwind.Products
{
    public partial class ProductCreateForm : Form
    {
        public ProductCreateForm()
        {
            InitializeComponent();
        }

        private void ProductCreateForm_Load(object sender, EventArgs e)
        {
            FillSuppliersCombobox();
            FillCategoryCombobox();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var context = new NorthWindContext();

            context.Products.Add(CreateProductFromInputs());

            context.SaveChanges();
        }
        private void FillSuppliersCombobox()
        {

            var context = new NorthWindContext();

            var dbQuery = from sup in context.Suppliers
                          select sup;

            cmbSuppliers.DisplayMember = "CompanyName";
            cmbSuppliers.ValueMember = "SupplierId";
            cmbSuppliers.DataSource = dbQuery.ToList();
        }

        private void FillCategoryCombobox()
        {
            var context = new NorthWindContext();
            var dbQuery = from cat in context.Categories
                          select cat;
            cmbCategoryName.DisplayMember = "CategoryName";
            cmbCategoryName.ValueMember = "CategoryId";

            cmbCategoryName.DataSource =dbQuery.ToList();

        }
        private Product CreateProductFromInputs()
        {
            var product = new Product();
            product.ProductName = txtProductName.Text.Trim();
            product.SupplierId = cmbSuppliers.SelectedItem != null
                ? (int)cmbSuppliers.SelectedValue
                : default;
            product.CategoryId = cmbCategoryName.SelectedItem != null
                ? (int)cmbCategoryName.SelectedValue
                : default;
            product.QuantityPerUnit = txtQuantityPerUnit.Text.Trim();
            product.UnitPrice = numUnitPrice.Value != 0 ? numUnitPrice.Value : default(decimal?);
            product.UnitsInStock = !string.IsNullOrWhiteSpace(txtUnitsInStock.Text)
                ? short.Parse(txtUnitsInStock.Text)
                : default(short?);
            product.UnitsOnOrder = !string.IsNullOrWhiteSpace(txtUnitsOnOrder.Text)
                ? short.Parse(txtUnitsOnOrder.Text)
                : default(short?);
            product.ReorderLevel = !string.IsNullOrWhiteSpace(txtReorderLevel.Text)
                ? short.Parse(txtReorderLevel.Text)
                : default(short?);
            product.Discontinued = chkDiscontinued.Checked;

            return product;
        }
    }
}

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
    public partial class ProductUpdateForm : Form
    {
        private int _productId;
        public ProductUpdateForm(int productId)
        {
            InitializeComponent();
            _productId = productId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var context = new NorthWindContext();

            context.Products.Update(UpdateProductFromInputs());
            try
            {
                context.SaveChanges();

                MessageBox.Show("Kayıt Başarılı");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata!!!" + ex.Message);
            }


        }

        private void ProductUpdateForm_Load(object sender, EventArgs e)
        {
            FillCategoryCombobox();
            FillSuppliersCombobox();

            var context = new NorthWindContext();
            var product= context.Products.Find(_productId);

            if (product!=null)
            {
                lblProductId.Text = product.ProductId.ToString();
                txtProductName.Text = product.ProductName;
                txtQuantityPerUnit.Text = product.QuantityPerUnit;
                txtReorderLevel.Text = product.ReorderLevel.ToString();
                txtUnitsInStock.Text = product.UnitsInStock.ToString();
                txtUnitsOnOrder.Text = product.UnitsOnOrder.ToString();
                numUnitPrice.Value = (decimal)product.UnitPrice;
                cmbCategoryName.SelectedValue = product.CategoryId;
                cmbSuppliers.SelectedValue = product.SupplierId;
                chkDiscontinued.Checked = product.Discontinued;
            }
            else
            {
                MessageBox.Show("Güncellenmek istenen kayıt bulunamadı!!");
                Close();
            }

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

            cmbCategoryName.DataSource = dbQuery.ToList();

        }
        private Product UpdateProductFromInputs()
        {
            var product = new Product();

            product.ProductId = _productId;
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

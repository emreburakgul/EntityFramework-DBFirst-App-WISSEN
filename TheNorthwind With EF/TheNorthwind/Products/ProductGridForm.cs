using Microsoft.EntityFrameworkCore;
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
using TheNorthwind.DTO;

namespace TheNorthwind.Products
{
    public partial class ProductGridForm : Form
    {
        public ProductGridForm()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void ProductGridForm_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void grdProductGridForm_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                grdProductGridForm.Rows[e.RowIndex].Selected = true;

            }
        }

        private void DeleteProduct_Click(object sender, EventArgs e)
        {
            var productModel = (ProductJoinedModel)grdProductGridForm.SelectedRows[0].DataBoundItem;

            var context = new NorthWindContext();
            try
            {
                var product = context.Products.Find(productModel.ProductId);

                // yada dbden okumak yerine PK değeri set edilmiş kendinizde oluşturabilirsiniz
                //var product = new Product()
                //{
                //    ProductId = productModel.ProductId
                //};


                if (product != null)
                {
                    context.Products.Remove(product);

                    context.SaveChanges();
                    MessageBox.Show("Kayıt silindi gitti!!!");
                    FillGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt silinemedi!\n\r{ex.Message}");
            }

        }

        private void UpdateProduct_Click(object sender, EventArgs e)
        {
            if (grdProductGridForm.SelectedRows.Count > 0)
            {
                var product = (ProductJoinedModel)grdProductGridForm.SelectedRows[0].DataBoundItem;
                var updateProductForm = new ProductUpdateForm(product.ProductId);
                updateProductForm.Show();
                updateProductForm.FormClosed += UpdateProductForm_FormClosed;

            }
        }

        private void UpdateProductForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FillGrid();
        }

        public void FillGrid()
        {
            var dbContext = new NorthWindContext();


            var dbQuery = from prod in dbContext.Products.AsNoTracking()
                          join cat in dbContext.Categories.AsNoTracking() on prod.CategoryId equals cat.CategoryId
                          join sup in dbContext.Suppliers.AsNoTracking() on prod.SupplierId equals sup.SupplierId
                          select new ProductJoinedModel()
                          {
                              // bu şekilde oluşturulduğunda prod. dan sonra gelen isme eşiteme oto olrak yapılır 

                              ProductId = prod.ProductId,
                              ProductName = prod.ProductName,
                              QuantityPerUnit = prod.QuantityPerUnit,
                              UnitsInStock = prod.UnitsInStock,
                              CategoryName = cat.CategoryName,
                              SupplierName = sup.CompanyName, // istersen böylede devam edebilirsin . 
                              UnitsOnOrder = prod.UnitsOnOrder,
                              ReorderLevel = prod.ReorderLevel,
                              UnitPrice = prod.UnitPrice,
                          };

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                dbQuery = dbQuery.Where(prod =>
                prod.ProductName.Contains(txtSearch.Text.Trim()));
            }

            grdProductGridForm.DataSource = dbQuery.ToList();
        }


    }
}

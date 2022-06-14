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

namespace TheNorthwind.Orders
{
    public partial class OrderGridForm : Form
    {
        public OrderGridForm()
        {
            InitializeComponent();
        }

        private void OrderGridForm_Load(object sender, EventArgs e)
        {
            FillCustomerAndOrder();
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var customerId = (string)cmbCustomer.SelectedValue;
            //var dbContext = new NorthWindContext();
            //var dbQuery = from ord in dbContext.Orders
            //              where ord.CustomerId.Contains(customerId)
            //              select ord;

            OrderFilter();
        }

        private void FillCustomerAndOrder()
        {
            var customerId = (string)cmbCustomer.SelectedValue;

            var dbContext = new NorthWindContext();

            var dbQuery = from ord in dbContext.Orders
                           join cus in dbContext.Customers on ord.CustomerId equals cus.CustomerId
                           select new 
                           {
                               OrderId = ord.OrderId,
                               CompanyName = cus.CompanyName,
                               EmployeeId = ord.EmployeeId,
                               OrderDate = ord.OrderDate,
                               RequiredDate = ord.RequiredDate,
                               ShippedDate = ord.ShippedDate,
                               ShipVia = ord.ShipVia,
                               Freight = ord.Freight,
                               ShipName = ord.ShipName,
                               ShipAddress = ord.ShipAddress,
                               ShipCity = ord.ShipCity,
                               ShipRegion = ord.ShipRegion,
                               ShipPostalCode = ord.ShipPostalCode,
                               ShipCountry = ord.ShipCountry,

                           };


            var customer = from cus in dbContext.Customers
                           select cus;

            cmbCustomer.DisplayMember = "CompanyName";
            cmbCustomer.ValueMember = "CustomerId";
            cmbCustomer.DataSource = customer.ToList();

            grdOrderGridForm.DataSource = dbQuery.ToList();
        }

        private void OrderFilter()
        {
            var customerId = (string)cmbCustomer.SelectedValue;
            var dbContext = new NorthWindContext();
            var dbQuery = from ord in dbContext.Orders
                          join cus in dbContext.Customers on ord.CustomerId equals cus.CustomerId
                          where ord.CustomerId.Contains(customerId)
                          select new
                          {
                              OrderId = ord.OrderId,
                              CompanyName = cus.CompanyName,
                              EmployeeId = ord.EmployeeId,
                              OrderDate = ord.OrderDate,
                              RequiredDate = ord.RequiredDate,
                              ShippedDate = ord.ShippedDate,
                              ShipVia = ord.ShipVia,
                              Freight = ord.Freight,
                              ShipName = ord.ShipName,
                              ShipAddress = ord.ShipAddress,
                              ShipCity = ord.ShipCity,
                              ShipRegion = ord.ShipRegion,
                              ShipPostalCode = ord.ShipPostalCode,
                              ShipCountry = ord.ShipCountry,

                          };


            grdOrderGridForm.DataSource = dbQuery.ToList();
        }

        private void DeleteOrder_Click(object sender, EventArgs e)
        {
            if (grdOrderGridForm.SelectedRows.Count > 0)
            {
                var dialogResult = MessageBox.Show(
                    "Bu kaydı silmek istediğinize emin misiniz?",
                    "Dikkat!!",
                    MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    var orderId = (int)grdOrderGridForm
                        .SelectedRows[0]
                        .Cells["OrderID"]
                        .Value;

                    
                    try
                    {
                        var context = new NorthWindContext();
                        var getOrder = context.Orders.Find(orderId);

                        context.Orders.Remove(getOrder);
                        refreshGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kayıt Silinemedi!!" + ex.Message);
                    }
                }
            }

        }

        private void UpdateOrder_Click(object sender, EventArgs e)
        {

            if (grdOrderGridForm.SelectedRows.Count>0)
            {
                var order = grdOrderGridForm.SelectedRows[0].Cells["OrderId"].Value.ToString();
                var orderId = int.Parse(order);

                if (order != null)
                {
                    var updateEdit = new OrderEditForm(orderId);
                    updateEdit.Show();
                }
               
            }
        }

        private void grdOrderGridForm_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                grdOrderGridForm.Rows[e.RowIndex].Selected = true;
            }
                       
        }
        private void refreshGrid()
        {
            FillCustomerAndOrder();
        }
    }
}

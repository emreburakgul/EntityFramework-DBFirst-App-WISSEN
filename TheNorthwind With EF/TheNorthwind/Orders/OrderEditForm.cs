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

namespace TheNorthwind.Orders
{
    public partial class OrderEditForm : Form
    {
        private readonly List<OrderDetail> _orderDetailInputs = new List<OrderDetail>();
        private int _orderId;

        public OrderEditForm()
        {
            InitializeComponent();
        }

        public OrderEditForm(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;
        }

        private Order GetOrderFromInputs()
        {
            var order = new Order()
            {
                OrderId = _orderId,
                CustomerId = cmbCustomerID.SelectedItem != null
                ? (string)cmbCustomerID.SelectedValue
                : default,
                EmployeeId = cmbEmployeeID.SelectedItem != null
                ? (int)cmbEmployeeID.SelectedValue
                : default,
                OrderDate = dtpOrderDate.Value,
                RequiredDate = dtpRequiredDate.Value,
                ShippedDate = dtpShippedDate.Value,
                ShipVia = cmbShipperID.SelectedItem != null
                ? (int)cmbShipperID.SelectedValue
                : default,
                ShipName = txtShipName.Text.Trim(),
                Freight = !string.IsNullOrWhiteSpace(txtFreight.Text)
                ? decimal.Parse(txtFreight.Text)
                : default(decimal),
                ShipAddress = txtShipAddress.Text.Trim(),
                ShipCity = txtShipCity.Text.Trim(),
                ShipRegion = txtShipRegion.Text.Trim(),
                ShipPostalCode = txtShipPostalCode.Text.Trim(),
                ShipCountry = txtShipCountry.Text.Trim(),

            };

            foreach (var item in _orderDetailInputs)
            {
                order.OrderDetails.Add(item);
            }


            return order;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            var context = new NorthWindContext();
            var order = GetOrderFromInputs();
            try
            {
                if (_orderId != default)
                {
                    var currentOrderDetails = context.OrderDetails
                        .Where(od => od.OrderId == _orderId)
                        .ToList();

                    context.OrderDetails.RemoveRange(currentOrderDetails);// removerange koleksiyon yipinde silme 
                    context.Orders.Update(order);

                   
                }
                else
                {
                    context.Orders.Add(order);      
                }

                //retalitonshipten kaynaklı orderdetail içinde product oluşur ve add metodu çalıştığında
                // productda ekleeye çalışıyor bunu emgelledik 
                

                foreach (var entry in context.ChangeTracker.Entries())
                {
                    // Context'in ,zleeye başladığı tüm entry'leri (girdileri) geziip
                    // Order yada orderDetail olmayan tüm kayıtları DEĞİŞTİRMİŞTİR olarak işaretliyorum
                    if (!(entry.Entity is Order)&&!(entry.Entity is OrderDetail))
                    {
                        entry.State = EntityState.Unchanged;
                    }

                }

                // Aşağıdaki kayıtlarda yaparsam, context izlemeye başladığı kayıtlardan sadece
                // product olanları product Unchanged olarak işaretliyorum . 
                //foreach (var orderDetail in order.OrderDetails)
                //{
                //    if (orderDetail.Product!=null)
                //    {
                //        context.Entry(orderDetail.Product).State = EntityState.Unchanged;
                //    }
                //}
                context.SaveChanges();


                MessageBox.Show("Kaydedildi.");
                 Form.ActiveForm.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydetme sırasında bir hata meydana geldi \n\r" + ex.Message);
            }
        }

        private void ActiveForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            RefreshOrderDetailsGrid();
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (cmbProductID.SelectedItem != null &&
                short.TryParse(txtQuantity.Text.Trim(), out short quantity) &&
                quantity > 0)
            {
                float.TryParse(txtDiscount.Text.Trim(), out float discount);

                var orderDetail = new OrderDetail()
                {
                    Product = cmbProductID.SelectedItem != null
                        ? (Product)cmbProductID.SelectedItem
                        : default,
                    UnitPrice = numUnitPrice.Value,
                    Quantity = quantity,
                    Discount = discount >= 0 && discount <= 1
                        ? discount
                        : default
                };

                // flag yöntemi
                bool productFound = false;

                foreach (var detailInput in _orderDetailInputs)
                {
                    // product karşılaştıası yapıyoruz productID leri çekmedik 
                    // include ile productlara erişebildik 
                    if (detailInput.Product?.ProductId == orderDetail.Product?.ProductId)
                    {
                        detailInput.Quantity += orderDetail.Quantity;
                        productFound = true;
                        break;
                    }
                }

                if (!productFound)
                {
                    _orderDetailInputs.Add(orderDetail);
                }

                RefreshOrderDetailsGrid();
            }
            else
            {
                MessageBox.Show("Lütfen ürünü ve adedi eksiksiz belirtin");
            }
        }

      
        private void OrderEditForm_Load(object sender, EventArgs e)
        {
            FillCustomerCombobox();
            FillEmployeeComboBox();
            FillProductCombobox();
            FillShipperComboBox();
            SetupGrid();


            if (_orderId != default)
            {
                FillOrderFormInputs();
              //  FillOrderDetail();
            }
        }


        private void FillCustomerCombobox()
        {
            var context = new NorthWindContext();

            try
            {
                var customer = from cus in context.Customers
                               select cus;

                cmbCustomerID.ValueMember = "CustomerID";
                cmbCustomerID.DisplayMember = "CompanyName";
                cmbCustomerID.DataSource = customer.ToList(); ;
            }
            catch (Exception)
            {
                MessageBox.Show("Customer kayıtları getirilemedi.");
            }

        }

        private void FillEmployeeComboBox()
        {
            var context = new NorthWindContext();

            try
            {
                var employee = from emp in context.Employees
                               select new
                               {
                                   EmployeeId = emp.EmployeeId,
                                   FirstName = emp.FirstName
                               };

                cmbEmployeeID.ValueMember = "EmployeeId";
                cmbEmployeeID.DisplayMember = "FirstName";
                cmbEmployeeID.DataSource = employee.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Employee kayıtları getirilemedi." + ex.Message);
            }
        }

        private void FillProductCombobox()
        {
            var context = new NorthWindContext();

            var product = from pro in context.Products
                          select pro;
            cmbProductID.DisplayMember = "ProductName";
            cmbProductID.ValueMember = "ProductId";
            cmbProductID.DataSource = product.ToList();

        }


        private void FillShipperComboBox()
        {
            var context = new NorthWindContext();

            var shipper = from ship in context.Shippers
                          select ship;

            cmbShipperID.ValueMember = "ShipperID";
            cmbShipperID.DisplayMember = "CompanyName";
            cmbShipperID.DataSource = shipper.ToList(); ;

        }

        private void DeleteOrderDetail_Click(object sender, EventArgs e)
        {
            if (datagridOrderDetails.SelectedRows.Count > 0)
            {
                var dialogResult = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    var orderDetails = (OrderDetail)datagridOrderDetails.SelectedRows[0].DataBoundItem;
                    try
                    {
                        _orderDetailInputs.Remove(orderDetails);
                        RefreshOrderDetailsGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme sırasında bir hata meydana geldi \n\r" + ex.Message);
                    }


                }
            }
        }

        private void RefreshOrderDetailsGrid()
        {
            datagridOrderDetails.DataSource = null;
            datagridOrderDetails.DataSource = _orderDetailInputs;
        }
        private void SetupGrid()
        {
            datagridOrderDetails.AutoGenerateColumns = false;
        }

        private void cmbProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductID.SelectedItem != null)
            {
                var selectedProduct = (Product)cmbProductID.SelectedItem;
                numUnitPrice.Value = selectedProduct.UnitPrice.HasValue
                    ? selectedProduct.UnitPrice.Value
                    : default;
            }
            else
            {
                numUnitPrice.Value = default;
            }
        }
        private void datagridOrderDetails_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex != -1)
                {
                    this.datagridOrderDetails.ClearSelection();
                    this.datagridOrderDetails.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void FillOrderFormInputs()
        {
            try
            {
                var context = new NorthWindContext();
                // var order = context.Orders.Find(_orderId);

                // orderı okurken orderdetails i de dahil et 
                // orderdetaili okurkende productları dahil et 
                // Eğer bir entity sınıf üzerinde FK bağlantıı navigation proprtyşler yer alıyorsa 
                // bu navgation propertyleri ullnarak inculede metodu sayesinde pratik jon yapılailir.

                // loading related data
                // eager loading 

                var order = context.Orders
                    //.Include(ord=>ord.OrderDetails)
                    //.ThenInclude(det=>det.Product)
                    .Include("OrderDetails")
                    .Include("OrderDetails.Product")
                    .SingleOrDefault(ord => ord.OrderId == _orderId);

                if (order != null)
                {
                    cmbCustomerID.SelectedValue = !string.IsNullOrWhiteSpace(order.CustomerId)
                        ? order.CustomerId
                        : string.Empty;
                    cmbEmployeeID.SelectedValue = order.EmployeeId.HasValue
                        ? order.EmployeeId.Value
                        : string.Empty;

                    dtpOrderDate.Value = order.OrderDate.Value;
                    dtpRequiredDate.Value = order.RequiredDate.Value;
                    dtpShippedDate.Value = order.ShippedDate.Value;
                    cmbShipperID.SelectedValue = order.ShipVia;
                    txtShipName.Text = order.ShipName;
                    txtFreight.Text = order.Freight.ToString();
                    txtShipAddress.Text = order.ShipAddress;
                    txtShipCity.Text = order.ShipCity;
                    txtShipRegion.Text = order.ShipRegion;
                    txtShipPostalCode.Text = order.ShipPostalCode;
                    txtShipCountry.Text = order.ShipCountry;

                    // buda olur 

                    foreach (var detail in order.OrderDetails)
                    {
                        _orderDetailInputs.Add(detail);
                    }

                    RefreshOrderDetailsGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sipariş bilgileri yüklenemedi" + ex.Message);
            }
        }
        private void FillOrderDetail()
        {
            var context = new NorthWindContext();

            if (_orderId != default)
            {
                var orderDetailQuery = from od in context.OrderDetails
                                  join pro in context.Products on od.ProductId equals pro.ProductId
                                  where od.OrderId == _orderId

                                  select new OrderDetail()
                                  {
                                      OrderId = od.OrderId,
                                     // ProductName = pro.ProductName,
                                      UnitPrice = od.UnitPrice,
                                      Quantity = od.Quantity,
                                      Discount = od.Discount,
                                      Product=pro
                                    //  TotalPrice = oD.TotalPrice
                                  };

                foreach (var detail in orderDetailQuery.ToList())
                {
                    _orderDetailInputs.Add(detail);
                }
                RefreshOrderDetailsGrid();
                //datagridOrderDetails.DataSource = orderDetailQuery.ToList();

            }

        }
    }
}

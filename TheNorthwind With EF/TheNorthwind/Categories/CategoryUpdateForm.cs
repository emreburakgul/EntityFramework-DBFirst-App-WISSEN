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
    public partial class CategoryUpdateForm : Form
    {
        private int _categoryId;
        public CategoryUpdateForm(int category)
        {
            InitializeComponent();

            _categoryId = category;
        }

        private void CategoryUpdateForm_Load(object sender, EventArgs e)
        {
            var dbContext = new NorthWindContext();
            //var category = (from cat in dbContext.Categories
            //                where cat.CategoryId == _categoryid
            //                select cat).SingleOrDefault();


            // Tek bir kaydı Primary Key değerine öre getirmek için
            //Find metodunu da kullanabilirim

            // Unutmayın DbSet<> koleksiyonları aslında birer Repository

            var category = dbContext.Categories.Find(_categoryId);

            if (category != null)
            {
                txtCatName.Text = category.CategoryName;
                txtCatDesc.Text = category.Description;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var context = new NorthWindContext();

            // ChangeTracker özelliği sayesinde , dbContext üzerinden okunan veriler 
            // EF tarafından izlenmeye başlar, Eğer entity üzerinde herhangi bir değişiklik 
            // varsa, bir sonraki SaveChanges çağrımında işle (güncelleme) otomatik yapılır. 


            //var category = context.Categories.Find(_categoryId);

            //category.CategoryName = txtCatName.Text.Trim();
            //category.Description = txtCatDescription.Text.Trim();

            //context.SaveChanges();

            // iğer yöntem 

            //Eğer picture için ekrandan değer almıyorsanuz aşağıdaki yöntemler ilenebilir 
            // image güncellenmeyecekse bu nesne veritabnından okunup güncellenirse daha tatlı olur 

            //var category = context.Categories.Find(_categoryId);
            //category.CategoryName = txtCatName.Text.Trim();
            //category.Description = txtCatDesc.Text.Trim();

            // veya 



            var category = new Category()
            {
                CategoryId = _categoryId,
                CategoryName = txtCatName.Text.Trim(),
                Description = txtCatDesc.Text.Trim()
            };
            
            var entry= context.Categories.Update(category);
            // Changetracker entity nesneleri izlediği ibi aynı zamanda izlediği nesnelerin 
            // propertylerini de izler, ayro ayro hangi property(kolonun) gncellenip güncellenmeyeceğini
            // ChangeTracker' bildirebilirz.
            entry.Property("Picture").IsModified = false; // resim kalır ... 
            try
            {
                context.SaveChanges();

                MessageBox.Show("Kayıt Başarılı");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata!!!"+ex.Message);
            }
          
        }
    }
}

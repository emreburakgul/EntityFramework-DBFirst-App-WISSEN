
namespace TheNorthwind.Categories
{
    partial class CategoryGridForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grdCategoryGridForm = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.updateCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdCategoryGridForm)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCategoryGridForm
            // 
            this.grdCategoryGridForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCategoryGridForm.Location = new System.Drawing.Point(-1, 69);
            this.grdCategoryGridForm.MultiSelect = false;
            this.grdCategoryGridForm.Name = "grdCategoryGridForm";
            this.grdCategoryGridForm.RowTemplate.ContextMenuStrip = this.contextMenuStrip1;
            this.grdCategoryGridForm.RowTemplate.Height = 25;
            this.grdCategoryGridForm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCategoryGridForm.Size = new System.Drawing.Size(764, 367);
            this.grdCategoryGridForm.TabIndex = 5;
            this.grdCategoryGridForm.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdCategoryGridForm_CellMouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteCategory,
            this.updateCategory});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 48);
            // 
            // deleteCategory
            // 
            this.deleteCategory.Name = "deleteCategory";
            this.deleteCategory.Size = new System.Drawing.Size(120, 22);
            this.deleteCategory.Text = "Sil";
            this.deleteCategory.Click += new System.EventHandler(this.deleteCategory_Click);
            // 
            // updateCategory
            // 
            this.updateCategory.Name = "updateCategory";
            this.updateCategory.Size = new System.Drawing.Size(120, 22);
            this.updateCategory.Text = "Güncelle";
            this.updateCategory.Click += new System.EventHandler(this.updateCategory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kategori Adı: ";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(85, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(418, 23);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // CategoryGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 450);
            this.Controls.Add(this.grdCategoryGridForm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Name = "CategoryGridForm";
            this.Text = "CategoryGridForm";
            this.Load += new System.EventHandler(this.CategoryGridForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCategoryGridForm)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCategoryGridForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteCategory;
        private System.Windows.Forms.ToolStripMenuItem updateCategory;
    }
}
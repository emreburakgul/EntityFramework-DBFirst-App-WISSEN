
namespace TheNorthwind.Orders
{
    partial class OrderGridForm
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
            this.grdOrderGridForm = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateOrder = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderGridForm)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdOrderGridForm
            // 
            this.grdOrderGridForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOrderGridForm.Location = new System.Drawing.Point(18, 69);
            this.grdOrderGridForm.MultiSelect = false;
            this.grdOrderGridForm.Name = "grdOrderGridForm";
            this.grdOrderGridForm.RowTemplate.ContextMenuStrip = this.contextMenuStrip1;
            this.grdOrderGridForm.RowTemplate.Height = 25;
            this.grdOrderGridForm.Size = new System.Drawing.Size(764, 367);
            this.grdOrderGridForm.TabIndex = 5;
            this.grdOrderGridForm.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdOrderGridForm_CellMouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Müşteri Adı: ";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(112, 13);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(168, 23);
            this.cmbCustomer.TabIndex = 6;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteOrder,
            this.UpdateOrder});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 48);
            // 
            // DeleteOrder
            // 
            this.DeleteOrder.Name = "DeleteOrder";
            this.DeleteOrder.Size = new System.Drawing.Size(180, 22);
            this.DeleteOrder.Text = "Sil";
            this.DeleteOrder.Click += new System.EventHandler(this.DeleteOrder_Click);
            // 
            // UpdateOrder
            // 
            this.UpdateOrder.Name = "UpdateOrder";
            this.UpdateOrder.Size = new System.Drawing.Size(180, 22);
            this.UpdateOrder.Text = "Güncelle";
            this.UpdateOrder.Click += new System.EventHandler(this.UpdateOrder_Click);
            // 
            // OrderGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.grdOrderGridForm);
            this.Controls.Add(this.label1);
            this.Name = "OrderGridForm";
            this.Text = "OrderGridForm";
            this.Load += new System.EventHandler(this.OrderGridForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderGridForm)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdOrderGridForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem güncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteOrder;
        private System.Windows.Forms.ToolStripMenuItem UpdateOrder;
    }
}
namespace Minisuper
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CatalogoProductos = new System.Windows.Forms.Button();
            this.Ventas = new System.Windows.Forms.Button();
            this.Compras = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NuevoProducto = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.Compras);
            this.panel.Controls.Add(this.Ventas);
            this.panel.Controls.Add(this.CatalogoProductos);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(200, 452);
            this.panel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Minisuper El Ahorro";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CatalogoProductos
            // 
            this.CatalogoProductos.Location = new System.Drawing.Point(23, 66);
            this.CatalogoProductos.Name = "CatalogoProductos";
            this.CatalogoProductos.Size = new System.Drawing.Size(108, 23);
            this.CatalogoProductos.TabIndex = 1;
            this.CatalogoProductos.Text = "Catálogo Productos";
            this.CatalogoProductos.UseVisualStyleBackColor = true;
            // 
            // Ventas
            // 
            this.Ventas.Location = new System.Drawing.Point(34, 107);
            this.Ventas.Name = "Ventas";
            this.Ventas.Size = new System.Drawing.Size(75, 23);
            this.Ventas.TabIndex = 1;
            this.Ventas.Text = "Ventas";
            this.Ventas.UseVisualStyleBackColor = true;
            // 
            // Compras
            // 
            this.Compras.Location = new System.Drawing.Point(34, 145);
            this.Compras.Name = "Compras";
            this.Compras.Size = new System.Drawing.Size(75, 23);
            this.Compras.TabIndex = 1;
            this.Compras.Text = "Compras";
            this.Compras.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Catálogo de Productos";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CCodigo,
            this.CNombre,
            this.CPrecio,
            this.CStock});
            this.dataGridView1.Location = new System.Drawing.Point(224, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // CCodigo
            // 
            this.CCodigo.HeaderText = "Código";
            this.CCodigo.Name = "CCodigo";
            // 
            // CNombre
            // 
            this.CNombre.HeaderText = "Nombre";
            this.CNombre.Name = "CNombre";
            // 
            // CPrecio
            // 
            this.CPrecio.HeaderText = "Precio";
            this.CPrecio.Name = "CPrecio";
            // 
            // CStock
            // 
            this.CStock.HeaderText = "Stock";
            this.CStock.Name = "CStock";
            // 
            // NuevoProducto
            // 
            this.NuevoProducto.BackColor = System.Drawing.SystemColors.Highlight;
            this.NuevoProducto.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NuevoProducto.Location = new System.Drawing.Point(653, 20);
            this.NuevoProducto.Name = "NuevoProducto";
            this.NuevoProducto.Size = new System.Drawing.Size(108, 23);
            this.NuevoProducto.TabIndex = 1;
            this.NuevoProducto.Text = "+ Nuevo Producto";
            this.NuevoProducto.UseVisualStyleBackColor = false;
            this.NuevoProducto.Click += new System.EventHandler(this.NuevoProducto_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.NuevoProducto);
            this.Name = "Form1";
            this.Text = "Catálogo de Productos";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Compras;
        private System.Windows.Forms.Button Ventas;
        private System.Windows.Forms.Button CatalogoProductos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CStock;
        private System.Windows.Forms.Button NuevoProducto;
    }
}


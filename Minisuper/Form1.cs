using Minisuper.Datos;
using Minisuper.Modelos;
using System;
using System.Drawing;
using System.Windows.Forms;
using Minisuper.Datos;
using Minisuper.Modelos;

namespace Minisuper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(30, 41, 59);

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            CargarProductos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void NuevoProducto_Click(object sender, EventArgs e)
        {
            FrmNuevoProducto frm = new FrmNuevoProducto();

            frm.ShowDialog();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
            Color.FromArgb(30, 41, 59);

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
            Color.White;
        }
        private void Ventas_MouseEnter(object sender, EventArgs e)
        {
            Ventas.BackColor = Color.FromArgb(59, 130, 246);

        }

        private void Ventas_MouseLeave(object sender, EventArgs e)
        {
            Ventas.BackColor = Color.FromArgb(30, 41, 59);
        }

        private void Ventas_Click_1(object sender, EventArgs e)
        {
            FrmVentas frmVentas = new FrmVentas();

            frmVentas.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FrmReportes frm = new FrmReportes();
            frm.ShowDialog();

        }
        private void CargarProductos()
        {
            ProductoDAO dao = new ProductoDAO();

            dataGridView1.Rows.Clear();

            foreach (Producto producto in dao.ObtenerProductos())
            {
                dataGridView1.Rows.Add(
                    producto.Id,
                    producto.Nombre,
                    producto.Precio,
                    producto.Stock);
            }
        }
    }
}

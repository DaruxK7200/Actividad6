using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void CatalogoProductos_MouseHover(object sender, EventArgs e)
        {
        }

        private void CatalogoProductos_MouseEnter(object sender, EventArgs e)
        {
            CatalogoProductos.BackColor = Color.FromArgb(59, 130, 246);
        }

        private void CatalogoProductos_MouseLeave(object sender, EventArgs e)
        {
            CatalogoProductos.BackColor = Color.FromArgb(30, 41, 59);
        }

        private void Ventas_MouseEnter(object sender, EventArgs e)
        {
            Ventas.BackColor = Color.FromArgb(59, 130, 246);

        }

        private void Ventas_MouseLeave(object sender, EventArgs e)
        {
            Ventas.BackColor = Color.FromArgb(30, 41, 59);
        }

        private void Compras_MouseEnter(object sender, EventArgs e)
        {
            Compras.BackColor = Color.FromArgb(59, 130, 246);

        }

        private void Compras_MouseLeave(object sender, EventArgs e)
        {
            Compras.BackColor = Color.FromArgb(30, 41, 59);

        }

        private void Ventas_Click_1(object sender, EventArgs e)
        {
            FrmVentas frmVentas = new FrmVentas();

            frmVentas.ShowDialog();
        }
    }
}

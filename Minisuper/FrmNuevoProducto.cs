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
    public partial class FrmNuevoProducto : Form
    {
        public FrmNuevoProducto()
        {
            InitializeComponent();
            this.AcceptButton = btnGuardar;
            this.CancelButton = btnCancelar;
        }

        private void FrmNuevoProducto_Load(object sender, EventArgs e)
        {
            txtPrecio.Text = "1.00";
            txtStock.Text = "1";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show(
                    "El código de barras es obligatorio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCodigo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Ingrese el nombre del producto.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombre.Focus();
                return;
            }

            decimal precio;

            if (!decimal.TryParse(txtPrecio.Text, out precio) || precio <= 0)
            {
                MessageBox.Show(
                    "El precio debe ser mayor a 0.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPrecio.Focus();
                return;
            }

            int stock;

            if (!int.TryParse(txtStock.Text, out stock) || stock < 0)
            {
                MessageBox.Show(
                    "El stock no puede ser negativo.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtStock.Focus();
                return;
            }

            MessageBox.Show(
                "Producto registrado correctamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Desea cancelar el registro del producto?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

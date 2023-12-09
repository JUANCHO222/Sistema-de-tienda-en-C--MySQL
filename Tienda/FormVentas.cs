using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tienda
{
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            ConexionMaestra.conectar();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            ConexionMaestra.ejecutar(
              " CALL insertaVentaJuan('" +
              textBox1.Text + "', '" +
              textBox2.Text + "', '" +
              textBox3.Text + "')"
               );
            ConexionMaestra.leer.Close();
            MessageBox.Show("Registro exitoso");
        }

        private void comboProducto_Click(object sender, EventArgs e)
        {
            ConexionMaestra.llenaCombo(comboProducto, "SELECT nombre_producto FROM producto ORDER BY nombre_producto");
        }

        private void comboVenta_Click(object sender, EventArgs e)
        {
            ConexionMaestra.llenaCombo(comboVenta, "SELECT clv_venta FROM venta ORDER BY fecha");
        }

        private void btnDVenta_Click(object sender, EventArgs e)
        {
            ConexionMaestra.ejecutar(
              " CALL insertaDetalleVentaJuan('" +
              textBox4.Text + "', '" +
              comboProducto.Text + "', '" +
              comboVenta.Text + "', '" +
              textBox5.Text + "', '" +
              textBox6.Text + "')"
               );
            ConexionMaestra.leer.Close();
            MessageBox.Show("Registro exitoso");
        }
    }
}

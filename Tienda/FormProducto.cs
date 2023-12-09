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
    public partial class FormProducto : Form
    {
        public FormProducto()
        {
            InitializeComponent();
        }

        private void FormProducto_Load(object sender, EventArgs e)
        {
            ConexionMaestra.conectar();
        }

        private void comboCategoria_Click(object sender, EventArgs e)
        {
            ConexionMaestra.llenaCombo(comboCategoria, "SELECT nombre_categoria FROM categoria ORDER BY nombre_categoria");
        }

        private void comboMarca_Click(object sender, EventArgs e)
        {
            ConexionMaestra.llenaCombo(comboMarca, "SELECT nombre_marca FROM marca ORDER BY nombre_marca");
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ConexionMaestra.ejecutar(
               " CALL insertaProductoJuan('" +
               textBox1.Text + "', '" +
               textBox2.Text + "', '" +
               textBox3.Text + "', '" +
               textBox4.Text + "', '" +
               comboCategoria.Text + "', '" +
               comboMarca.Text + "', '" +
               textBox5.Text + "')"
                );
            ConexionMaestra.leer.Close();
            MessageBox.Show("Registro exitoso");
        }
    }
}

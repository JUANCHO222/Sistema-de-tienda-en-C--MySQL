using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            ConexionMaestra.conectar();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            ConexionMaestra.ejecutar(textBox1.Text);
            ConexionMaestra.gred(dataGridView1, "select*from marca2");
        }

        private void btnLlenar_Click(object sender, EventArgs e)
        {
            ConexionMaestra.llenaCombo(listaDespelgable, textBox1.Text);
            ConexionMaestra.gred(dataGridView1, "select nombre_producto from producto");
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            ConexionMaestra.ejecutar("insert provedor values('" + textBox2.Text + "','"
                + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')");
            ConexionMaestra.leer.Close();
            MessageBox.Show("Inserccion Exitosa");
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            ConexionMaestra.ejecutar("insert producto values('" + textBox6.Text + "','"
               + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','"
               + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "')");
            ConexionMaestra.leer.Close();
            MessageBox.Show("Inserccion Exitosa");
        }

        private void textBox13_KeyUp(object sender, KeyEventArgs e)
        {
            ConexionMaestra.gred(dataGridView2,"call buscar_producto('%"
                + textBox13.Text + "%')");
        }
    }
}

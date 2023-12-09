using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda
{
    internal class ConexionMaestra
    {
        //Variable en donde se escribiran las consultas SQL
        public static OdbcCommand consulta;
        //Variable para almacenar el resultado de la consulta
        public static OdbcDataReader leer;
        //Variable para realizar la conexion a la base de datos
        public static OdbcConnection conexion;
        //Varaible para realizar cuadriculas
        DataSet ds;
        //Nos permite a partir de una consulta poner los resultados a una tabla
        DataSet cuadricula = new DataSet();
        //Variable de cadena de conexion
        public static string str_Con
        = "DRIVER={MySQL ODBC 5.3 ANSI Driver}; USER=root; PASSWORD=12345; PORT=3306; DATABASE=tienditajuanmanuel";
        //Metodo para conectarnos a la base de datos para sacar 10

        //static---->para poder hacer una referencia desde cualquier parte del proyecto
        public static void conectar()
        {
            //Se crea un objeto para la conexion
            conexion = new OdbcConnection(str_Con);
            //Se abre la cponexion
            conexion.Open();
            consulta = new OdbcCommand();
            consulta.Connection = conexion;

            //Enviar mensaje de confirmacion
            MessageBox.Show("conectado");
        }

        //Metodo para ejecutar cualquier consulta SQL
        //
        public static void ejecutar(string SQL)
        {
            consulta.CommandType = CommandType.Text;
            //Assignar al query al sql
            consulta.CommandText = SQL;
            //Ejecutar la consulta SQL y guarde la consulta
            leer = consulta.ExecuteReader();

        }
        public static void gred(DataGridView tabla, string SQL)
        {

            ejecutar(SQL);
            //para cada ejecutar se necesita un leer.close
            leer.Close();
            DataSet cuadricula = new DataSet();
            OdbcDataAdapter adaptador = new OdbcDataAdapter(consulta);
            //Fill ----> llenar
            adaptador.Fill(cuadricula, "DATOS");
            //source --> puente
            tabla.DataSource = cuadricula;
            //
            tabla.DataMember = "DATOS";

            //tabla.DataBindingComplete();
        }
        public static void llenaCombo(ComboBox lista, string SQL)
        {
            ejecutar(SQL);
            //un while no se sabe cuanto se va ejecutar a diferencia de un for
            lista.Items.Clear();
            while (leer.Read())
            {
                /*Tomamos el parametro del combo, .items es para llenar los elementos 
                 * y el add para agregarlos, lo que hacer el [0] es tomar la primera columna de la matriz
                 y el to string es para cuando tomamos un valor null*/
                lista.Items.Add(leer[0].ToString());
            }
            //el leer es para cerrar la conexion
            leer.Close();

        }
    }
}

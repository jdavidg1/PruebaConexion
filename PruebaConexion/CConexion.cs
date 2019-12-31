using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//se agregan 3 using para manejo de base de datos:
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace PruebaConexion
{
    class CConexion
    {
        //Crear las instancias del SQL Conection, variables

        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        //Constructor de la clase.

        public CConexion()
        {   //Conexión a la base de datos laptop-9vn6qt9r\sqlexpress
            try 
            {
                cn = new SqlConnection("Data Source=laptop-9vn6qt9r\\sqlexpress;Initial Catalog=Tutorial;Integrated Security=True");
                cn.Open();
                //El Message necesita: using System.Windows.Forms;
                MessageBox.Show("Conectado...");

            }
            catch(Exception ex) //En "ex" se captura el posible error
            {
                MessageBox.Show("No se conecto con la base de datos: " +ex.ToString());
            }

            


        }

        public string insertar(int id, string nombre, string apellido, string fecha)
        {
            string salida = "Si se inserto";
            try
            {
                cmd = new SqlCommand("Insert into Persona(Id, Nombre,Apellido,FechaNacimiento)values(" + id + ",'" + nombre + "','" + apellido + "','" + fecha + "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se conectó: " + ex.ToString();
            }

            return salida;
        }



    }
}

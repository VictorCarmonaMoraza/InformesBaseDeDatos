using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInformes
{
    public class Conexion
    {
        public string CadenaConexion { get; set; }

        public List<Persona> ObtenerConexion()
        {
            List<Persona> lista = new List<Persona>();
            var conection = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            lista = HacerConsulta(conection);
            return lista;
        }

        public List<Persona> HacerConsulta(string cadena)
        {
            SqlConnection conection = new SqlConnection();
            conection.ConnectionString = cadena;
            conection.Open();
            List<Persona> lista = new List<Persona>();
            string query = "Select * from Personas";
            SqlCommand comando = new SqlCommand(query, conection);
            SqlDataReader lector = comando.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Persona x = new Persona()
                    {
                        Id = lector.GetInt32(0),
                        Nombre = lector.GetString(1),
                        Apellido = lector.GetString(2),
                        Edad = lector.GetInt32(3)
                    };
                    lista.Add(x);
                }
            }
            return lista;


        }

    }
}

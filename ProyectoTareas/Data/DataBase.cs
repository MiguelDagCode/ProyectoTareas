using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoTareas.Data
{
    public class DataBase
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnectionStringBuilder generadorCadenaCnx = new SqlConnectionStringBuilder();
            generadorCadenaCnx.DataSource = "localhost";
            generadorCadenaCnx.InitialCatalog = "RegistroTareas";
            generadorCadenaCnx.UserID = "sa";
            generadorCadenaCnx.Password = "sql";

            string cadenaCnx = generadorCadenaCnx.ConnectionString;
            SqlConnection cnx = new SqlConnection(cadenaCnx);

            return cnx;
        }
    }
}
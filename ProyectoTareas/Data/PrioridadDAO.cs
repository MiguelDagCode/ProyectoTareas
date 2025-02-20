using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProyectoTareas.Data.InterFaces;
using ProyectoTareas.Models;

namespace ProyectoTareas.Data
{
    public class PrioridadDAO : IPrioridad
    {
        public List<PrioridadTarea> ListarTodo()
        {
            List<PrioridadTarea> listaPrioridad = new List<PrioridadTarea>();
            // Obtener objeto de conexion
            SqlConnection cnx = DataBase.ObtenerConexion();
            // Iniciar conexion
            cnx.Open();
            // Crear comando para ejecutar sentencia SQL
            SqlCommand cmd = cnx.CreateCommand();
            // Definir el tipo de comando
            cmd.CommandType = System.Data.CommandType.Text;
            // Definir el comando
            cmd.CommandText = "SELECT * FROM PrioridadTarea";
            // Ejecutar comando
            SqlDataReader dr = cmd.ExecuteReader();
            // Verificar si hay datos para leer
            while (dr.Read())
            {
                PrioridadTarea prioridadTarea= new PrioridadTarea((int)dr["ID"], dr["Nombre_Prioridad"] as string);
                listaPrioridad.Add(prioridadTarea);
            }
            // Cerramos le lector de datos y la conexion
            dr.Close(); cnx.Close();
            // Retornar la lista de categorias
            return listaPrioridad;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProyectoTareas.Data.InterFaces;
using ProyectoTareas.Models;

namespace ProyectoTareas.Data
{
    public class TareaDAO : ITarea
    {
        public bool Actualizar(Tarea tarea)
        {
            SqlConnection cnx = DataBase.ObtenerConexion();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"
                UPDATE Tarea 
                SET Titulo = @pTitulo, 
                    Descripcion = @pDescripcion, 
                    Fecha_Limite = @pFechaLimite, 
                    Estado_ID = @pIdEstado, 
                    Prioridad_ID = @pIdPrioridad, 
                    Categoria_ID = @pIdCategoria
                WHERE ID = @pIdTarea";
            cmd.Parameters.AddWithValue("@pTitulo", tarea.Titulo);
            cmd.Parameters.AddWithValue("@pDescripcion", tarea.Descripcion);
            cmd.Parameters.AddWithValue("@pFechaLimite", tarea.FechaLimite);
            cmd.Parameters.AddWithValue("@pIdEstado", tarea.EstadoId.Id);
            cmd.Parameters.AddWithValue("@pIdPrioridad", tarea.PrioridadId.Id);
            cmd.Parameters.AddWithValue("@pIdCategoria", tarea.CategoriaId.Id);
            cmd.Parameters.AddWithValue("@pIdTarea", tarea.Id);
            bool confirmacion = cmd.ExecuteNonQuery() > 0;
            cnx.Close();
            return confirmacion;

        }

        public List<Tarea> BuscarTitulo(string titulo)
        {
            List<Tarea> tareas = new List<Tarea>();
            SqlConnection cnx = DataBase.ObtenerConexion();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_ObtenerTareasPorTitulo";
            cmd.Parameters.AddWithValue("@pTitulo", titulo);
            // Ejecutar comando
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tarea tarea = new Tarea
                {
                    Id = Convert.ToInt32(dr["ID"]),
                    Titulo = Convert.ToString(dr["Titulo"]),
                    Descripcion = Convert.ToString(dr["Descripcion"]),
                    FechaLimite = Convert.ToDateTime(dr["Fecha_Limite"]),
                    EstadoId = new EstadoTarea { Nombre = Convert.ToString(dr["Estado"]) },
                    PrioridadId = new PrioridadTarea { Nombre = Convert.ToString(dr["Prioridad"]) },
                    CategoriaId = new Categoria { Nombre = Convert.ToString(dr["Categoria"]) },
                    FechaCreacion = Convert.ToDateTime(dr["Fecha_Creacion"])
                };
                tareas.Add(tarea);

            }
            return tareas;    
        }




        public bool Eliminar(int id)
        {
            SqlConnection cnx = DataBase.ObtenerConexion();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Tarea WHERE ID = @pIdTarea";
            cmd.Parameters.AddWithValue("@pIdTarea", id);
            bool confirmacion = cmd.ExecuteNonQuery() > 0;
            cnx.Close();
            return confirmacion;
        }

        public Tarea ObtenerPorId(int id)
        {
            SqlConnection cnx = DataBase.ObtenerConexion();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM Tarea WHERE ID = @pIdTarea";
            cmd.Parameters.AddWithValue("@pIdTarea", id);

            SqlDataReader dr = cmd.ExecuteReader();
            Tarea tarea = null;

            if (dr.Read())
            {
                tarea = new Tarea
                {
                    Id = Convert.ToInt32(dr["ID"]),
                    Titulo = Convert.ToString(dr["Titulo"]),
                    Descripcion = Convert.ToString(dr["Descripcion"]),
                    FechaLimite = Convert.ToDateTime(dr["Fecha_Limite"]),
                    EstadoId = new EstadoTarea { Id = Convert.ToInt32(dr["Estado_ID"]) },
                    PrioridadId = new PrioridadTarea { Id = Convert.ToInt32(dr["Prioridad_ID"]) },
                    CategoriaId = new Categoria { Id = Convert.ToInt32(dr["Categoria_ID"]) }
                };
            }

            cnx.Close();
            return tarea;
        }

        public List<Tarea> ObtnerTareasComplejo(string titulo, string descripcion, int categoriaId, int estadoId, int prioridadId)
        {
            List<Tarea> tareas = new List<Tarea>();
            SqlConnection cnx = DataBase.ObtenerConexion();
            try
            {
                cnx.Open();
                SqlCommand cmd = cnx.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_ObtenerTareasComplejo";

                // Parámetros del procedimiento almacenado
                cmd.Parameters.AddWithValue("@pTitulo", titulo);
                cmd.Parameters.AddWithValue("@pDescripcion", descripcion);
                cmd.Parameters.AddWithValue("@pCategoria", categoriaId );
                cmd.Parameters.AddWithValue("@pEstado", estadoId );
                cmd.Parameters.AddWithValue("@pPrioridad", prioridadId );

                // Ejecutar comando
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Tarea tarea = new Tarea
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        Titulo = Convert.ToString(dr["Titulo"]),
                        Descripcion = Convert.ToString(dr["Descripcion"]),
                        FechaLimite = Convert.ToDateTime(dr["Fecha_Limite"]),
                        EstadoId = new EstadoTarea { Nombre = Convert.ToString(dr["Estado"]) },
                        PrioridadId = new PrioridadTarea { Nombre = Convert.ToString(dr["Prioridad"]) },
                        CategoriaId = new Categoria { Nombre = Convert.ToString(dr["Categoria"]) },
                        FechaCreacion = Convert.ToDateTime(dr["Fecha_Creacion"])
                    };
                    tareas.Add(tarea);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error al obtener tareas: " + ex.Message);
            }
            finally
            {
                cnx.Close();
            }
            return tareas;
        }

        public int Registrar(Tarea tarea)
        {
            SqlConnection cnx = DataBase.ObtenerConexion();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_RegistrarTarea";

            
            cmd.Parameters.AddWithValue("@pUsuarioID", tarea.UsuarioId.Id);
            cmd.Parameters.AddWithValue("@pTitulo", tarea.Titulo);
            cmd.Parameters.AddWithValue("@pDescripcion", tarea.Descripcion);
            cmd.Parameters.AddWithValue("@pFechaLimite", tarea.FechaLimite);
            cmd.Parameters.AddWithValue("@pEstadoID", tarea.EstadoId.Id);
            cmd.Parameters.AddWithValue("@pPrioridadID", tarea.PrioridadId.Id);
            cmd.Parameters.AddWithValue("@pCategoriaID", tarea.CategoriaId.Id);

            
            int idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
            cnx.Close();
            return idGenerado;
        }

    }
}
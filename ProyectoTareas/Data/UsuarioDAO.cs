using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using ProyectoTareas.Data.InterFaces;
using ProyectoTareas.Models;

namespace ProyectoTareas.Data
{
    public class UsuarioDAO : IUsuario
    {
        public Usuario LoginUsuaruario(string email, string contrasenia)
        {
            Usuario usuario = new Usuario(0,"No se encontro el usuario","No coincide","null");
            SqlConnection cnx = DataBase.ObtenerConexion();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT Id, Nombre, Email, Contrasenia FROM Usuario WHERE Email = @pEmail AND Contrasenia = @pContrasenia";
            cmd.Parameters.AddWithValue("@pEmail", email);
            cmd.Parameters.AddWithValue("@pContrasenia", contrasenia);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()){
                 usuario = new Usuario((int)dr["ID"], (string)dr["Nombre"], (string)dr["Email"], (string)dr["Contrasenia"]                  
                    );
            }
            dr.Close(); cnx.Close();
            return usuario;
        }
    }
}
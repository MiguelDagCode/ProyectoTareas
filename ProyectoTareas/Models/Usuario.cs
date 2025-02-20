using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTareas.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Contrasenia { get; set; }

        public Usuario() { 
        Id = 0;
            Nombre = string.Empty;
            Email = string.Empty;
            Contrasenia = string.Empty;
        
        }

        public Usuario(int id, string nombre, string email, string contrasenia)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Contrasenia = contrasenia;
        }

        public override string ToString()
        {
            return "Usuario [Id=" + Id + "Nombre=" +Nombre +"Email=" + Email + "Contraseña=" + Contrasenia +"]";
        }

    }
}
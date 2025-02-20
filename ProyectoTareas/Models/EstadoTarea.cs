using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTareas.Models
{
    public class EstadoTarea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public EstadoTarea() { 
        Id = 0;
        Nombre = string.Empty;
        }

        public EstadoTarea(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return "EstadoTarea[Id=" + Id + "Nombre" + Nombre + "]";
        }
    
    }
}
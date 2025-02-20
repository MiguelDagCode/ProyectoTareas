using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTareas.Models
{
    public class PrioridadTarea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public PrioridadTarea() { 
        Id = 0;
        Nombre = string.Empty;
        
        }

        public PrioridadTarea(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
        public override string ToString()
        {
            return "PrioridadTarea[Id=" + Id + "Nombre" + Nombre + "]";
        }



    }
}
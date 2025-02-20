using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTareas.Models
{
    public class Notificacion
    {
        public int Id { get; set; }
        public Tarea TareaId { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha_Envio { get; set; }

        public Notificacion() { 
        Id = 0;
        TareaId = new Tarea();
        Mensaje = string.Empty;
            Fecha_Envio = DateTime.Now;
        }

        public Notificacion(int id, Tarea tareaId, string mensaje, DateTime fecha_Envio)
        {
            Id = id;
            TareaId = tareaId;
            Mensaje = mensaje;
            Fecha_Envio = fecha_Envio;
        }

        public override string ToString()
        {
            return "Notificacion[Id=" + Id + "TareaId=" + TareaId + "Mensaje=" + Mensaje + "Fecha_Envio=" + Fecha_Envio;
        }

    }
}
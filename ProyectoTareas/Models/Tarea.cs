using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTareas.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public Usuario UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaLimite { get; set; }
        public EstadoTarea EstadoId { get; set; }
        public PrioridadTarea PrioridadId { get; set; }
        public Categoria CategoriaId { get; set; }
        public DateTime FechaCreacion {  get; set; }

        public Tarea()
        {
            Id = 0;
            UsuarioId = new Usuario();
            Titulo = string.Empty;
            Descripcion = string.Empty;
            FechaLimite = DateTime.MinValue;
            EstadoId = new EstadoTarea();
            PrioridadId = new PrioridadTarea();
            CategoriaId = new Categoria();
            FechaCreacion = DateTime.MinValue;
        }

        public Tarea(int id, Usuario usuarioId, string titulo, string descripcion, DateTime fechaLimite, EstadoTarea estadoId, PrioridadTarea prioridadId, Categoria categoriaId, DateTime fechaCreacion)
        {
            Id = id;
            UsuarioId = usuarioId;
            Titulo = titulo;
            Descripcion = descripcion;
            FechaLimite = fechaLimite;
            EstadoId = estadoId;
            PrioridadId = prioridadId;
            CategoriaId = categoriaId;
            FechaCreacion = fechaCreacion;
        }

        public override string ToString()
        {
            return "Tarea[Id="+ Id +"UsuarioId=" + UsuarioId + "Titulo=" +Titulo+ "Descripcion=" +Descripcion + "FechaLimite=" + FechaLimite+
            "EstadoId=" + EstadoId +"PrioridadId="+PrioridadId+"CategoriaId="+CategoriaId+"FechaCreacion="+FechaCreacion    ;
        }


    }
}
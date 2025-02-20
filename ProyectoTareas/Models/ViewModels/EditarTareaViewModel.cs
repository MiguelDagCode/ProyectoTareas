using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTareas.Models.ViewModels
{
    public class EditarTareaViewModel
    {
        public Tarea Tarea { get; set; }
        public List<EstadoTarea> Estados { get; set; }
        public List<PrioridadTarea> Prioridades { get; set; }
        public List<Categoria> Categorias { get; set; }
        
        public List<Tarea> Tareas { get; set; }
    }
}
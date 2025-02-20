using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTareas.Data;
using ProyectoTareas.Models;
using ProyectoTareas.Models.ViewModels;

namespace ProyectoTareas.Controllers
{
    public class ConsultarController : Controller
    {
        // GET: Consultar
        [HttpGet]
        public ActionResult Consultar()
        {
           
            EstadoDAO estadoDAO = new EstadoDAO();
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            PrioridadDAO prioridadDAO = new PrioridadDAO();
            

            var viewModel = new EditarTareaViewModel
            {
                Estados = estadoDAO.ListarTodo(),
                Prioridades = prioridadDAO.ListarTodo(),
                Categorias = categoriaDAO.ListarTodo()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Consultar(FormCollection formulario)
        {
            // Obtener los valores del formulario
            string titulo = formulario["Titulo"];
            string descripcion = formulario["Descripcion"];
            int estadoId = Convert.ToInt32(formulario["EstadoId"]);
            int prioridadId = Convert.ToInt32(formulario["PrioridadId"]);
            int categoriaId = Convert.ToInt32(formulario["CategoriaId"]);

            // Crear una instancia del DAO
            TareaDAO tareaDAO = new TareaDAO();

            // Realizar la búsqueda
            List<Tarea> tareas = tareaDAO.ObtnerTareasComplejo(titulo, descripcion, categoriaId, estadoId, prioridadId);

            // Verificar si se encontraron resultados
            if (tareas.Count == 0)
            {
                ViewBag.Mensaje = "No se encontraron tareas con los criterios ingresados.";
            }

            // Asignar resultados a ViewBag (puedes quitar esto si usas el modelo)
            // ViewBag.ListaTareasBuscados = tareas;

            // Volver a cargar los combos de estado, prioridad y categoría
            EstadoDAO estadoDAO = new EstadoDAO();
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            PrioridadDAO prioridadDAO = new PrioridadDAO();

            var viewModel = new EditarTareaViewModel
            {
                Estados = estadoDAO.ListarTodo(),
                Prioridades = prioridadDAO.ListarTodo(),
                Categorias = categoriaDAO.ListarTodo(),
                Tareas = tareas // Asignar las tareas al ViewModel
            };

            return View(viewModel);
        }

    }
}


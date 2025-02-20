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
    public class AdministrarController : Controller
    {
        // GET: Administrar
        [HttpGet]
        public ActionResult Administrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Administrar(FormCollection formulario)
        {
            string titulo = formulario["txtTitulo"];
            TareaDAO tareaDAO = new TareaDAO();
            List<Tarea> tareas = tareaDAO.BuscarTitulo(titulo);

            if (tareas.Count == 0)
            {
                ViewBag.Mensaje = "No se encontraron tareas con ese título.";
            }

            ViewBag.ListaTareasBuscados = tareas;
            ViewBag.TituloBuscado = titulo;

            return View();
        }
        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            TareaDAO tareaDAO = new TareaDAO();
            bool eliminado = tareaDAO.Eliminar(id);

            if (eliminado)
            {
                TempData["Mensaje"] = "Tarea eliminada correctamente.";
            }
            else
            {
                TempData["Mensaje"] = "No se pudo eliminar la tarea.";
            }

            return RedirectToAction("Administrar");
        }

        
        
        //Editar
        [HttpGet]
        public ActionResult Editar(int id)
        {
           TareaDAO tareaDAO=new TareaDAO();
            EstadoDAO estadoDAO = new EstadoDAO();  
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            PrioridadDAO prioridadDAO = new PrioridadDAO();
            var tarea = tareaDAO.ObtenerPorId(id);
            if (tarea == null)
            {
                return null;
            }

            var viewModel = new EditarTareaViewModel
            {
                Tarea = tarea,
                Estados = estadoDAO.ListarTodo(),
                Prioridades = prioridadDAO.ListarTodo(),
                Categorias = categoriaDAO.ListarTodo()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Editar(EditarTareaViewModel model, FormCollection formulario)
        {
            TareaDAO tareaDAO = new TareaDAO();
            EstadoDAO estadoDAO = new EstadoDAO();
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            PrioridadDAO prioridadDAO = new PrioridadDAO();
            if (!ModelState.IsValid)
            {
                model.Estados = estadoDAO.ListarTodo();
                model.Prioridades = prioridadDAO.ListarTodo();
                model.Categorias = categoriaDAO.ListarTodo();
                return View(model);
            }

            int id = Convert.ToInt32(formulario["txtIdTarea"]);
            var tarea = tareaDAO.ObtenerPorId(id);
    

            
            // Actualizar datos
            tarea.Titulo = Convert.ToString(formulario["txtTitulo"]);
            tarea.Descripcion = Convert.ToString(formulario["txtDescripcion"]);
            tarea.FechaLimite = Convert.ToDateTime(formulario["dateFechaLimite"]);
            tarea.EstadoId.Id = Convert.ToInt32(formulario["cmbEstadoId"]);
            tarea.PrioridadId.Id = Convert.ToInt32(formulario["cmbPrioridadId"]);
            tarea.CategoriaId.Id = Convert.ToInt32(formulario["cmbCategoriaId"]);
            tareaDAO.Actualizar(tarea);

            TempData["Mensaje"] = "Tarea actualizada correctamente";
            return RedirectToAction("Administrar");
        }





    }
}
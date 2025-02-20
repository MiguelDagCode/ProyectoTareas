using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTareas.Data;
using ProyectoTareas.Data.InterFaces;
using ProyectoTareas.Models;
using ProyectoTareas.Models.ViewModels;

namespace ProyectoTareas.Controllers
{
    public class RegistrarController : Controller
    {
        // GET: Registrar
        [HttpGet]
        public ActionResult Registrar()
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
       
        public ActionResult Registrar(FormCollection formulario)
        {
            var tarea = new Tarea();
            TareaDAO tareaDAO = new TareaDAO();

            try
            {
                // Asignar los valores del formulario
                tarea.Titulo = Convert.ToString(formulario["txtTitulo"]);
                tarea.Descripcion = Convert.ToString(formulario["txtDescripcion"]);
                tarea.FechaLimite = Convert.ToDateTime(formulario["dateFechaLimite"]);
                tarea.EstadoId = new EstadoTarea { Id = Convert.ToInt32(formulario["lsEstado"]) };
                tarea.PrioridadId = new PrioridadTarea { Id = Convert.ToInt32(formulario["lsPriodidad"]) };
                tarea.CategoriaId = new Categoria { Id = Convert.ToInt32(formulario["lsCategoria"]) };
                tarea.UsuarioId.Id = 1;
                // Registrar la tarea
                int idGenerado = tareaDAO.Registrar(tarea);

                // Verificar si se registró correctamente
                if (idGenerado > 0)
                {
                    TempData["Mensaje"] = "Tarea registrada correctamente.";
                    TempData["MensajeTipo"] = "success"; // Para indicar que fue exitoso
                }
                else
                {
                    TempData["Mensaje"] = "No se pudo registrar la tarea.";
                    TempData["MensajeTipo"] = "error"; // Para indicar que hubo un error
                }
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = $"Ocurrió un error inesperado: {ex.Message}";
                TempData["MensajeTipo"] = "error";
                // Puedes agregar más información como la traza de la excepción
                TempData["ErrorDetails"] = ex.StackTrace;
            }
            TempData["PrioridadSeleccionada"] = formulario["lsPrioridad"];
            return RedirectToAction("Registrar");
        }

    }
}
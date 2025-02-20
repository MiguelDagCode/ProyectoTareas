using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTareas.Data;
using ProyectoTareas.Models;

namespace ProyectoTareas.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formulario)
        {
            string email = Convert.ToString(formulario["txtEmail"]);
            string contrasenia = Convert.ToString(formulario["txtContrasena"]);
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            Usuario usuario = usuarioDAO.LoginUsuaruario(email, contrasenia);
            if (usuario.Id >0)
            {
                return RedirectToAction("Index", "Index");

            }
            else
            {
                ViewBag.Mensaje = "Credenciales incorrectas.";
                return View();
            }
        }
    }
}
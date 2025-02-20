using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTareas.Models;

namespace ProyectoTareas.Data.InterFaces
{
    internal interface IUsuario
    {
        Usuario LoginUsuaruario(string email, string contrasenia);
    
    
    }
}

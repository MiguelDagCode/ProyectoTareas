using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTareas.Models;

namespace ProyectoTareas.Data.InterFaces
{
    internal interface ITarea
    {

        List<Tarea> BuscarTitulo(string titulo);
        bool Actualizar(Tarea tarea);
        bool Eliminar(int id);

        Tarea ObtenerPorId(int id);

        List<Tarea> ObtnerTareasComplejo(string titulo, string descripcion, int categoriaId, int estadoId, int prioridadId);

        int Registrar(Tarea tarea);

    }
}

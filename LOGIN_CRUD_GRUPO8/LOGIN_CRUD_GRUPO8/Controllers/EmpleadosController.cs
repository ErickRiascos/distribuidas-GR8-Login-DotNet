using Microsoft.AspNetCore.Mvc;
using LOGIN_CRUD_GRUPO8.Datos;
using LOGIN_CRUD_GRUPO8.Models;

namespace LOGIN_CRUD_GRUPO8.Controllers
{
    public class EmpleadosController : Controller
    {

        DatosEmpleado datosEmpleado = new DatosEmpleado();

        public IActionResult ListarEmpleados()
        {
            var lista = datosEmpleado.listar();

            return View(lista);
        }

        public IActionResult editar(string id)
        {
            var empleado = datosEmpleado.buscar(id);

            return View(empleado);
        }
    }
}

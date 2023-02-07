using Microsoft.AspNetCore.Mvc;
using LOGIN_CRUD_GRUPO8.Datos;
using LOGIN_CRUD_GRUPO8.Models;

namespace LOGIN_CRUD_GRUPO8.Controllers
{
    public class EmpleadosController : Controller
    {

        DatosEmpleado datosEmpleado = new DatosEmpleado();
        Usuario usuario = new Usuario();

        public IActionResult ListarEmpleados()
        {
            var lista = datosEmpleado.listar();

            return View(lista);
        }

        public IActionResult EditarEmpleado(string id)
        {
            var empleado = datosEmpleado.buscar(id);

            return View(empleado);
        }

        [HttpPost]
        public IActionResult EditarEmpleado(Empleado empleado)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = datosEmpleado.editar(empleado);

            if (respuesta)
                return RedirectToAction("ListarEmpleados");
            else
                return View();
        }

        public IActionResult EliminarEmpleado(string id)
        {
            var empleado = datosEmpleado.buscar(id);

            return View(empleado);
        }

        [HttpPost]
        public IActionResult EliminarEmpleado(Empleado empleado)
        {
            var respuestaUsuario = usuario.eliminar(empleado.id);
            var respuestaEmpleado = datosEmpleado.eliminar(empleado.id);

            if (respuestaEmpleado == true && respuestaUsuario == true)
                return RedirectToAction("ListarEmpleados");
            else
                return View();
        }
    }
}

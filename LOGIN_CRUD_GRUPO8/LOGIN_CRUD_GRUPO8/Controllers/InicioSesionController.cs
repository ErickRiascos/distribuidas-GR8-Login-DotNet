using LOGIN_CRUD_GRUPO8.Datos;
using LOGIN_CRUD_GRUPO8.Models;
using Microsoft.AspNetCore.Mvc;

namespace LOGIN_CRUD_GRUPO8.Controllers
{
    public class InicioSesionController : Controller
    {

        DatosEmpleado datosEmpleado = new DatosEmpleado();

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(InicioSesion inicioSesion)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = inicioSesion.comprobarInicioSesion();

            if (respuesta)
            {
                return RedirectToAction("ListarEmpleados", "Empleados");
            } else
            {
                return View();
            }
        }

        public IActionResult RegistrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarUsuario(EmpleadoUsuario empleadoUsuario)
        {

            if (!ModelState.IsValid)
                return View();

            Empleado empleado = new Empleado(empleadoUsuario.id, empleadoUsuario.cedula, empleadoUsuario.nombre, empleadoUsuario.apellidoPaterno,
                empleadoUsuario.apellidoMaterno, Convert.ToDateTime("10-10-2010"), 1);

            Usuario usuario = new Usuario(empleadoUsuario.usuario, empleadoUsuario.correo, "123");

            var respuestaEmpleado = datosEmpleado.guardar(empleado);
            var respuestaUsuario = usuario.guardar(empleado.id);

            if (respuestaUsuario == true && respuestaEmpleado == true)
            {
                return RedirectToAction("IniciarSesion");
            }
            else
            {
                return View();
            }
        }
    }
}

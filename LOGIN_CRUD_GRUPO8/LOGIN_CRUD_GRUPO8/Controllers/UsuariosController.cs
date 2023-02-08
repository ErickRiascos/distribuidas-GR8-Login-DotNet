using LOGIN_CRUD_GRUPO8.Models;
using Microsoft.AspNetCore.Mvc;

namespace LOGIN_CRUD_GRUPO8.Controllers
{
    public class UsuariosController : Controller
    {

        Usuario usuario = new Usuario();

        public IActionResult ListarUsuarios()
        {
            var lista = usuario.listar();

            /***** COMPROBACIÓN SESIÓN ACTIVA *****/
            if (HttpContext.Session.GetString("ID") != null)
            {
                return View(lista);
            }
            else
            {
                return RedirectToAction("IniciarSesion", "InicioSesion");
            }
            /**************************************/
        }

        public IActionResult EditarUsuario(string idUsuario)
        {
            var objetoUsuario = usuario.buscar(idUsuario);

            /***** COMPROBACIÓN SESIÓN ACTIVA *****/
            if (HttpContext.Session.GetString("ID") != null)
            {
                return View(objetoUsuario);
            }
            else
            {
                return RedirectToAction("IniciarSesion", "InicioSesion");
            }
            /**************************************/
        }

        [HttpPost]
        public IActionResult EditarUsuario(Usuario usu)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = usuario.editar(usu);

            if (respuesta)
                return RedirectToAction("ListarUsuarios");
            else
                return View();
        }

        public IActionResult EditarClaveUsuario()
        {
            var objetoUsuario = usuario.buscar(HttpContext.Session.GetString("ID"));

            /***** COMPROBACIÓN SESIÓN ACTIVA *****/
            if (HttpContext.Session.GetString("ID") != null)
            {
                return View(objetoUsuario);
            }
            else
            {
                return RedirectToAction("IniciarSesion", "InicioSesion");
            }
            /**************************************/
        }

        [HttpPost]
        public IActionResult EditarClaveUsuario(Usuario usu)
        {

            if (validarConfirmacionClave())
            {
                var respuesta = usuario.editarClave(usu);

                if (respuesta)
                    return RedirectToAction("MostrarPerfil", "Perfil");
                else
                    return View();
            } else
            {
                return View();
            }

            
        }

        public bool validarConfirmacionClave()
        {
            bool resultado = false;

            var contra = Request.Form["clave"];
            var contraConfirmada = Request.Form["confirmarClave"];
            var hola = "hola";

            if (contra == contraConfirmada)
            {
                resultado = true;
            }

            return resultado;
        }
    }
}

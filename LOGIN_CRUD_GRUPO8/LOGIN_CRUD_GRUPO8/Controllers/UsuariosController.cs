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

            return View(lista);
        }

        public IActionResult EditarUsuario(string idUsuario)
        {
            var objetoUsuario = usuario.buscar(idUsuario);
            return View(objetoUsuario);
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
    }
}

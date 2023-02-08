using LOGIN_CRUD_GRUPO8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace LOGIN_CRUD_GRUPO8.Controllers
{
    public class PerfilController : Controller
    {
        public IActionResult MostrarPerfil()
        {
            List<string> datosSesion = new List<string>();

            /***** COMPROBACIÓN SESIÓN ACTIVA *****/
            if (HttpContext.Session.GetString("ID") != null)
            {
                datosSesion.Add(HttpContext.Session.GetString("ID"));
                datosSesion.Add(HttpContext.Session.GetString("Cedula"));
                datosSesion.Add(HttpContext.Session.GetString("Nombre"));
                datosSesion.Add(HttpContext.Session.GetString("ApellidoPaterno"));
                datosSesion.Add(HttpContext.Session.GetString("ApellidoMaterno"));
                datosSesion.Add(HttpContext.Session.GetString("Usuario"));
                datosSesion.Add(HttpContext.Session.GetString("Clave"));
                datosSesion.Add(HttpContext.Session.GetString("Correo"));

                return View(datosSesion);
            }
            else
            {
                return RedirectToAction("IniciarSesion", "InicioSesion");
            }
            /**************************************/

            
        }
    }
}

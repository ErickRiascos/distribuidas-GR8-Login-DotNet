using LOGIN_CRUD_GRUPO8.Datos;
using LOGIN_CRUD_GRUPO8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Mail;

namespace LOGIN_CRUD_GRUPO8.Controllers
{
    public class InicioSesionController : Controller
    {

        DatosEmpleado datosEmpleado = new DatosEmpleado();

        public IActionResult IniciarSesion()
        {
            /***** COMPROBACIÓN SESIÓN ACTIVA *****/
            if (HttpContext.Session.GetString("ID") != null)
            {
                return RedirectToAction("MostrarPerfil", "Perfil");
            } else
            {
                return View();
            }
            /**************************************/

        }

        [HttpPost]
        public IActionResult IniciarSesion(InicioSesion inicioSesion)
        {
            if (!ModelState.IsValid)
                return View();

            var respuestaInicioSesion = inicioSesion.comprobarInicioSesion();

            if (respuestaInicioSesion)
            {
                Usuario usuario = new Usuario();
                Usuario usu = usuario.buscarPorUsuarioYClave(inicioSesion.usuario, inicioSesion.password);
                Empleado empleado = datosEmpleado.buscar(usu.idUsuario);

                /**** VARIABLES DE SESION ****/

                HttpContext.Session.SetString("ID", usu.idUsuario);
                HttpContext.Session.SetString("Cedula", empleado.cedula);
                HttpContext.Session.SetString("Nombre", empleado.nombre);
                HttpContext.Session.SetString("ApellidoPaterno", empleado.apellidoPaterno);
                HttpContext.Session.SetString("ApellidoMaterno", empleado.apellidoMaterno);
                HttpContext.Session.SetString("Usuario", usu.usuario);
                HttpContext.Session.SetString("Clave", usu.clave);
                HttpContext.Session.SetString("Correo", usu.correo);
                HttpContext.Session.SetInt32("ClaveTemp", usu.claveTemporal);

                /****************************/

                if ((int)HttpContext.Session.GetInt32("ClaveTemp") == 1)
                {
                    return RedirectToAction("EditarClaveUsuario", "Usuarios");
                } else
                {
                    return RedirectToAction("MostrarPerfil", "Perfil");
                }

            } else
            {
                return View();
            }
        }

        public IActionResult RegistrarUsuario()
        {

            /***** COMPROBACIÓN SESIÓN ACTIVA *****/
            if (HttpContext.Session.GetString("ID") != null)
            {
                return RedirectToAction("MostrarPerfil", "Perfil");
            }
            else
            {
                return View();
            }
            /**************************************/
        }

        [HttpPost]
        public IActionResult RegistrarUsuario(EmpleadoUsuario empleadoUsuario)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (validarCaptcha())
            {   
                Empleado empleado = new Empleado(empleadoUsuario.id, empleadoUsuario.cedula, empleadoUsuario.nombre, empleadoUsuario.apellidoPaterno,
                empleadoUsuario.apellidoMaterno, Convert.ToDateTime("10-10-2010"), 1);
                Usuario usuario = new Usuario(empleadoUsuario.usuario, empleadoUsuario.correo, "");
                string clave = usuario.generarClaveRandom();

                /***** ENCRIPTAR CONTRASEÑA *****/

                string claveEncriptada = BCrypt.Net.BCrypt.HashPassword(clave);

                /********************************/

                usuario.clave = claveEncriptada;

                var respuestaEmpleado = datosEmpleado.guardar(empleado);
                var respuestaUsuario = usuario.guardar(empleado.id);

                if (respuestaUsuario == true && respuestaEmpleado == true)
                {
                    enviarCorreo2(usuario, clave);
                    return RedirectToAction("IniciarSesion");
                }
                else
                {
                    return View();
                }

            } else
            {
                return View();
            }

            
        }

        public IActionResult CerrarSesion()
        {
            /***** COMPROBACIÓN SESIÓN ACTIVA *****/
            if (HttpContext.Session.GetString("ID") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IniciarSesion", "InicioSesion");
            }
            /**************************************/
        }

        [HttpPost]
        public IActionResult CerrarSesionActiva()
        {
            /***** ELIMINANDO VARIABLES DE SESIÓN *****/
            HttpContext.Session.Clear();
            /******************************************/

            return RedirectToAction("IniciarSesion");
        }

        public void enviarCorreo(Empleado empleado, Usuario usuario)
        {
            string correoDesde = "empresamonster8338@gmail.com";
            string claveCorreoDesde = "sudkhlghqqlypize";
            string asuntoCorreo = "Clave Temporal para  Aplicación Monster";
            string cuerpoCorreo = "Estimado usuario, su contraseña temporal es: " + usuario.clave + ". Inicie sesión para cambiar la contraseña.";
            string host = "smtp.gmail.com";
            int puerto = 25;

            try
            {
                /****** CONFIGURACION CORREO ******/
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(correoDesde);
                correo.To.Add(usuario.correo);
                correo.Subject = asuntoCorreo;
                correo.Body = cuerpoCorreo;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                /****** CONFIGURACION SERVIDOR SMTP ******/
                SmtpClient smtp = new SmtpClient();
                smtp.Host = host;
                smtp.Port = puerto;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential(correoDesde, claveCorreoDesde);

                /****** ENVIO CORREO ******/
                smtp.Send(correo);


            } catch (Exception e)
            {

            }
        }

        public void enviarCorreo2(Usuario usuario, string clave)
        {
            string correoDesde = "empresamonster8338@gmail.com";
            string claveCorreoDesde = "sudkhlghqqlypize";
            string asuntoCorreo = "Clave Temporal para  Aplicación Monster";
            string cuerpoCorreo =
                "<body>" +
                    "<h1>Bienvenido a la Aplicación Monster</h1>" +
                    "<h4>Señor usuario,</h4>" +
                    "<span>Su clave temporal es la siguiente: " + clave + ". Inicie sesión para cambiarla.</span>" +
                    "<br/><br/><span>Saludos cordiales</span>" +
                    "<span>Grupo 8</span>" +
                "</body>";

            string host = "smtp.gmail.com";
            int puerto = 587;

            /****** CONFIGURACION SERVIDOR SMTP ******/
            SmtpClient smtp = new SmtpClient(host, puerto);
            smtp.Credentials = new NetworkCredential(correoDesde, claveCorreoDesde);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;

            /****** CONFIGURACION CORREO ******/
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress(correoDesde, "Clave Temporal");
            correo.To.Add(new MailAddress(usuario.correo));
            correo.Subject = asuntoCorreo;
            correo.Body = cuerpoCorreo;
            correo.IsBodyHtml = true;

            /****** ENVIO CORREO ******/
            smtp.Send(correo);
        }

        //Metodo para validacion de captcha
        public bool validarCaptcha()
        {
            bool resultado = false;

            var respuestaCaptcha = Request.Form["g-recaptcha-response"];
            var llaveSecreta = "6Lc2MmQkAAAAAPuSgMbYyLmUdMXnw_maWBZ738pL";
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, llaveSecreta, respuestaCaptcha);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse respuesta = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(respuesta.GetResponseStream()))
                {
                    JObject jRespuesta = JObject.Parse(stream.ReadToEnd());
                    var esCorrecto = jRespuesta.Value<bool>("success");
                    resultado = esCorrecto ? true : false;
                }
            }

            return resultado;
        }
    }
}

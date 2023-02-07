using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using login_dotnet_grupo8.ec.edu.espe.monster.modelo;
using Microsoft.AspNetCore.Mvc;

namespace login_dotnet_grupo8.ec.edu.espe.monster.controlador
{
    public class d : Controller
    {
        Empleado empleado = new Empleado();

        public IActionResult listar()
        {
            var lista = empleado.listar();

            return View(lista);
        }
    }
}

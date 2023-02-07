using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace login_dotnet_grupo8.ec.edu.espe.monster.modelo
{
    public class Conexion
    {
        private string cadenaConexion = string.Empty;

        public Conexion()
        {
            /*var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("configuraciones.json").Build();
            
            cadenaConexion = builder.GetSection("ConnectionStrings:CadenaConexion").Value;*/

            cadenaConexion = "Data Source=(local); Initial Catalog=SEGURIDAD;User Id=sa;Password=elkin.vera;MultipleActiveResultSets=True;Connect Timeout=100;Integrated Security=true;Application Name=login_dotnet_grupo8";
        }

        public string getCadenaConexion()
        {
            return cadenaConexion;
        }
    }
}
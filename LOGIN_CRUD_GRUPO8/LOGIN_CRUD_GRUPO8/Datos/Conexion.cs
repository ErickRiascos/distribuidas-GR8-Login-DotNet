namespace LOGIN_CRUD_GRUPO8.Datos
{
    public class Conexion
    {
        private string cadenaConexion = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            
            cadenaConexion = builder.GetSection("ConnectionStrings:CadenaConexion").Value;

        }

        public string getCadenaConexion()
        {
            return cadenaConexion;
        }
    }
}

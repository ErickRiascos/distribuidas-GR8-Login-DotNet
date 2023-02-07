namespace LOGIN_CRUD_GRUPO8.Models
{
    public class Empleado
    {
        /******* ATRIBUTOS con GETTERS y SETTERS *******/

        public string id { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int estaActivo { get; set; }

        /******* ************ *******/

        /******* CONSTRUCTORES *******/

        public Empleado()
        {

        }

        public Empleado(string id, string cedula, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, int estaActivo)
        {
            this.id = id;
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.fechaNacimiento = fechaNacimiento;
            this.estaActivo = estaActivo;
        }

        /******* ************ *******/
    }
}


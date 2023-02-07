using System.ComponentModel.DataAnnotations;

namespace LOGIN_CRUD_GRUPO8.Models
{
    public class Empleado
    {
        /******* ATRIBUTOS con GETTERS y SETTERS *******/

        [Required(ErrorMessage = "El campo ID es obligatorio")]
        public string id { get; set; }
        [Required(ErrorMessage = "El campo Cédula es obligatorio")]
        public string cedula { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo Apellido Paterno es obligatorio")]
        public string apellidoPaterno { get; set; }
        [Required(ErrorMessage = "El campo Apellido Materno es obligatorio")]
        public string apellidoMaterno { get; set; }
        [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio")]
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


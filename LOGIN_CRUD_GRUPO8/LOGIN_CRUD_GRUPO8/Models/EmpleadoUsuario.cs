using System.ComponentModel.DataAnnotations;

namespace LOGIN_CRUD_GRUPO8.Models
{
    public class EmpleadoUsuario
    {
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
        [Required(ErrorMessage = "El campo Usuario es obligatorio")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string correo { get; set; }


        public EmpleadoUsuario()
        {

        }

        public EmpleadoUsuario(string id, string cedula, string nombre, string apellidoPaterno, string apellidoMaterno, string usuario, string correo)
        {
            this.id = id;
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.usuario = usuario;
            this.correo = correo;
        }
    }
}

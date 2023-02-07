using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Data.SqlClient;
using LOGIN_CRUD_GRUPO8.Datos;
using System.ComponentModel.DataAnnotations;

namespace LOGIN_CRUD_GRUPO8.Models
{
    public class InicioSesion
    {

        [Required(ErrorMessage = "El campo Usuario es obligatorio")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        public string password { get; set; }

        public InicioSesion()
        {

        }

        public InicioSesion(string usuario, string password)
        {
            this.usuario = usuario;
            this.password = password;
        }

        public bool comprobarInicioSesion()
        {
            bool aux = false;

            Conexion conn = new Conexion();
            string stringConexion = conn.getCadenaConexion();

            SqlCommand cmd = new SqlCommand();
            SqlConnection conexion = new SqlConnection(stringConexion);
            conexion.Open();

            cmd.Connection = conexion;
            cmd.CommandText = "SELECT * FROM XESUBSE_USUARIO WHERE USUARIO = '" + usuario + "' AND USU_PASWD = '" + password + "'";

            var dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                aux = true;
            }

            return aux; 
        }
    }
}

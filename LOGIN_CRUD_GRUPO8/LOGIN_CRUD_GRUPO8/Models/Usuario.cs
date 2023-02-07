using LOGIN_CRUD_GRUPO8.Datos;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LOGIN_CRUD_GRUPO8.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "El campo ID es obligatorio")]
        public string idUsuario { get; set; }
        [Required(ErrorMessage = "El campo Usuario es obligatorio")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "El campo Correo Electrónico es obligatorio")]
        public string correo { get; set; }
        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        public string clave { get; set; }
        [Required(ErrorMessage = "El campo Fecha de Creación es obligatorio")]
        public DateTime fechaCreacion { get; set; }
        [Required(ErrorMessage = "El campo Fecha de Modificación es obligatorio")]
        public DateTime fechaModificacion { get; set; }
        public int claveTemporal { get; set; }

        private string stringConexion;

        public Usuario()
        {
            clave = "123";
            claveTemporal = 1;

            Conexion conn = new Conexion();
            stringConexion = conn.getCadenaConexion();
        }

        public Usuario(string usuario, string correo, string clave)
        {
            this.usuario = usuario;
            this.correo = correo;
            this.clave = clave;
            claveTemporal = 1;

            Conexion conn = new Conexion();
            stringConexion = conn.getCadenaConexion();
        }

        public Usuario(string idUsuario, string usuario, string correo, DateTime fechaCreacion, DateTime fechaModificacion)
        {
            this.idUsuario = idUsuario;
            this.usuario = usuario;
            this.correo = correo;
            this.fechaCreacion = fechaCreacion;
            this.fechaModificacion = fechaModificacion;

            Conexion conn = new Conexion();
            stringConexion = conn.getCadenaConexion();
        }

        public List<Usuario> listar()
        {
            var listaUsuarios = new List<Usuario>();

            SqlCommand cmd = new SqlCommand();
            SqlConnection conexion = new SqlConnection(stringConexion);
            conexion.Open();

            cmd.Connection = conexion;
            cmd.CommandText = "SELECT * FROM XESUBSE_USUARIO";

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    listaUsuarios.Add(new Usuario()
                    {
                        idUsuario = dr["EMP_ID"].ToString(),
                        usuario = dr["USUARIO"].ToString(),
                        correo = dr["CORREO"].ToString(),
                        fechaCreacion = Convert.ToDateTime(dr["USU_FECCRE"]),
                        fechaModificacion = Convert.ToDateTime(dr["USU_FECMOD"])
                    });
                }
            }

            return listaUsuarios;
        }

        public bool guardar(string id)
        {
            bool respuesta;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection conexion = new SqlConnection(stringConexion);
                conexion.Open();

                cmd.Connection = conexion;
                cmd.CommandText = "INSERT INTO XESUBSE_USUARIO (EMP_ID, USUARIO, EST_CODIGO, CORREO, USU_PASWD, USU_FECCRE, USU_FECMOD, CLAVE_TEMPORAL) VALUES ('" + id + "', '" + usuario + "', '1', '" + correo + "', '" + clave + "', '10-10-2010', '29-7-2013', " + claveTemporal + ")";
                cmd.ExecuteReader();

                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }

            return respuesta;
        }

        public Usuario buscar(string idUsuario)
        {
            Usuario usu = new Usuario();

            SqlCommand cmd = new SqlCommand();
            SqlConnection conexion = new SqlConnection(stringConexion);
            conexion.Open();

            cmd.Connection = conexion;
            cmd.CommandText = "SELECT * FROM XESUBSE_USUARIO WHERE EMP_ID = '" + idUsuario + "'";

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    usu.idUsuario = dr["EMP_ID"].ToString();
                    usu.usuario = dr["USUARIO"].ToString();
                    usu.correo = dr["CORREO"].ToString();
                    usu.clave = dr["USU_PASWD"].ToString();
                    usu.fechaCreacion = Convert.ToDateTime(dr["USU_FECCRE"]);
                    usu.fechaModificacion = Convert.ToDateTime(dr["USU_FECMOD"]);
                }
            }

            return usu;
        }

        public bool editar(Usuario usuario)
        {
            bool respuesta;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection conexion = new SqlConnection(stringConexion);
                conexion.Open();

                cmd.Connection = conexion;

                cmd.CommandText = "UPDATE XESUBSE_USUARIO SET USUARIO = '" + usuario.usuario + "', CORREO = '" + usuario.correo + "', USU_PASWD = '" + usuario.clave + "' WHERE EMP_ID = '" + usuario.idUsuario + "'";
                cmd.ExecuteReader();

                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }

            return respuesta;
        }

        public bool eliminar(string id)
        {
            bool respuesta;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection conexion = new SqlConnection(stringConexion);
                conexion.Open();

                cmd.Connection = conexion;

                cmd.CommandText = "DELETE FROM XESUBSE_USUARIO WHERE EMP_ID = '" + id + "'";
                cmd.ExecuteReader();

                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }

            return respuesta;
        }
    }
}

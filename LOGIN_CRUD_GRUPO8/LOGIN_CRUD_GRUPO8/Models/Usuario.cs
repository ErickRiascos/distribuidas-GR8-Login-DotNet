using LOGIN_CRUD_GRUPO8.Datos;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LOGIN_CRUD_GRUPO8.Models
{
    public class Usuario
    {
        public string id { get; set; }
        public string usuario { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public DateTime fechaCreacion { get; set; }
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

        public Usuario(string id, string usuario, string correo, DateTime fechaCreacion, DateTime fechaModificacion)
        {
            this.id = id;
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
                        id = dr["EMP_ID"].ToString(),
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
                    id = dr["EMP_ID"].ToString();
                    usuario = dr["USUARIO"].ToString();
                    correo = dr["CORREO"].ToString();
                    fechaCreacion = Convert.ToDateTime(dr["USU_FECCRE"]);
                    fechaModificacion = Convert.ToDateTime(dr["USU_FECMOD"]);
                }
            }

            return usu;
        }

        public bool editar()
        {
            bool respuesta;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection conexion = new SqlConnection(stringConexion);
                conexion.Open();

                cmd.Connection = conexion;
                cmd.CommandText = "UPDATE XESUBSE_USUARIO SET USUARIO = '" + usuario + "', CORREO = '" + correo + "', USU_PASWD = '" + clave + "' WHERE EMP_ID = '" + id +"'";
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

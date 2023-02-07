using LOGIN_CRUD_GRUPO8.Models;
using System.Data.SqlClient;
using System.Data;

namespace LOGIN_CRUD_GRUPO8.Datos
{
    public class DatosEmpleado
    {
        private string stringConexion;

        public DatosEmpleado()
        {
            Conexion conexion = new Conexion();
            stringConexion = conexion.getCadenaConexion();
        }

        public List<Empleado> listar()
        {
            var listaEmpleados = new List<Empleado>();

            SqlCommand cmd = new SqlCommand();
            SqlConnection conexion = new SqlConnection(stringConexion);
            conexion.Open();

            cmd.Connection = conexion;
            cmd.CommandText = "SELECT * FROM SUBSE";

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    listaEmpleados.Add(new Empleado()
                    {
                        id = dr["EMP_ID"].ToString(),
                        cedula = dr["EMP_CEDULA"].ToString(),
                        nombre = dr["EMP_NOMBRE"].ToString(),
                        apellidoPaterno = dr["EMP_APELLIDO_PATERNO"].ToString(),
                        apellidoMaterno = dr["EMP_APELLIDO_MATERNO"].ToString(),
                        fechaNacimiento = Convert.ToDateTime(dr["EMP_FECHA_NACIMIENTO"]),
                        estaActivo = Convert.ToInt32(dr["EMP_ESTAACTIVO"])
                    });
                }
            }

            return listaEmpleados;
        }

        public Empleado buscar(string id)
        {
            Empleado empleado = new Empleado();

            SqlCommand cmd = new SqlCommand();
            SqlConnection conexion = new SqlConnection(stringConexion);
            conexion.Open();

            cmd.Connection = conexion;
            cmd.CommandText = "SELECT * FROM SUBSE WHERE EMP_ID = '" + id + "'";

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    empleado.id = dr["EMP_ID"].ToString();
                    empleado.cedula = dr["EMP_CEDULA"].ToString();
                    empleado.nombre = dr["EMP_NOMBRE"].ToString();
                    empleado.apellidoPaterno = dr["EMP_APELLIDO_PATERNO"].ToString();
                    empleado.apellidoMaterno = dr["EMP_APELLIDO_MATERNO"].ToString();
                    empleado.fechaNacimiento = Convert.ToDateTime(dr["EMP_FECHA_NACIMIENTO"]);
                }
            }

            return empleado;
        }

        public bool guardar(Empleado empleado)
        {
            bool respuesta;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection conexion = new SqlConnection(stringConexion);
                conexion.Open();

                cmd.Connection = conexion;
                cmd.CommandText = "INSERT INTO SUBSE (EMP_ID, EMP_CEDULA, EMP_NOMBRE, EMP_APELLIDO_PATERNO, EMP_APELLIDO_MATERNO, EMP_FECHA_NACIMIENTO, EMP_ESTAACTIVO) values ('" + empleado.id + "', '" + empleado.cedula + "', '" + empleado.nombre + "', '" + empleado.apellidoPaterno + "', '" + empleado.apellidoMaterno + "', '10-10-2010', 1)";
                cmd.ExecuteReader();

                respuesta = true;

            } catch (Exception ex)
            {
                respuesta = false;
            }

            return respuesta;
        }

        public bool editar(Empleado empleado)
        {
            bool respuesta;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection conexion = new SqlConnection(stringConexion);
                conexion.Open();

                cmd.Connection = conexion;

                cmd.CommandText = "UPDATE SUBSE SET EMP_CEDULA = '" + empleado.cedula + "', EMP_NOMBRE = '" + empleado.nombre + "', EMP_APELLIDO_PATERNO = '" + empleado.apellidoPaterno + "', EMP_APELLIDO_MATERNO = '" + empleado.apellidoMaterno + "' WHERE EMP_ID = '" + empleado.id + "'";
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

                cmd.CommandText = "DELETE FROM SUBSE WHERE EMP_ID = '" + id + "'";
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

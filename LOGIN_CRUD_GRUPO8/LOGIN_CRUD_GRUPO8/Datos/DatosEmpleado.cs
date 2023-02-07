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
            SqlCommand cmd = new SqlCommand();
            SqlConnection conexion = new SqlConnection(stringConexion);
            conexion.Open();

            cmd.Connection = conexion;
            cmd.CommandText = "SELECT * FROM SUBSE WHERE EMP_ID = '" + id + "'";

            var dr = cmd.ExecuteReader();

            Empleado empleado = new Empleado(
                dr["EMP_ID"].ToString(),
                dr["EMP_CEDULA"].ToString(),
                dr["EMP_NOMBRE"].ToString(),
                dr["EMP_APELLIDO_PATERNO"].ToString(),
                dr["EMP_APELLIDO_MATERNO"].ToString(),
                Convert.ToDateTime(dr["EMP_FECHA_NACIMIENTO"]),
                Convert.ToInt32(dr["EMP_ESTAACTIVO"])
            );

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
    }
}

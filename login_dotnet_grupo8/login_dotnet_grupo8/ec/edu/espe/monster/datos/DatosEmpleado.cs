using login_dotnet_grupo8.ec.edu.espe.monster.modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace login_dotnet_grupo8.ec.edu.espe.monster.datos
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
    }
}
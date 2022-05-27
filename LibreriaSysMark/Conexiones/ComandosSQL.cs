using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaSysMark.Modelos;
using Dapper;
using System.Data;

namespace LibreriaSysMark.Conexiones
{
    //Clase que controla todas las llamadas a la base de datos creadas por David Eduardo
    //Modelos utilizados son referencias de la carpeta Modelos y DataConexion

    internal class ComandosSQL : DataConexion
    {
        //Almacena la "llave" de la AppConfig para la ruta de la base de datos a utilizar
        private const string conexionDB = "SysMark";

        //Conexion a SQL para "registrar empleados" a la base de datos utilizando el ORM Dapper
        public ModeloEmpleado CrearEmpleado(ModeloEmpleado modelo)
        {
                                                                                    //ConfigGlobalConexion tiene la cadena string de la conexion de la bd
            using (IDbConnection conexion = new System.Data.SqlClient.SqlConnection(ConfigGlobalConexion.StringConexion(conexionDB)))
            {
                //Parametros de Dapper 
                var m = new DynamicParameters();
                m.Add("@nombreCompleto", modelo.NombreCompleto);
                m.Add("@apellidoPaterno", modelo.ApellidoPaterno);
                m.Add("@apellidoMaterno", modelo.ApellidoMaterno);
                m.Add("@correoElectronico", modelo.CorreoElectronico);
                m.Add("@IdEmpleado", dbType: DbType.Int32, direction: ParameterDirection.Output);

                conexion.Execute("dbo.registrarEmpleado", m, commandType: CommandType.StoredProcedure);

                modelo.IdEmpleado = m.Get<int>("IdEmpleado");

                return modelo;

            }

        }

        //Funcion que se encarga de traer todos los empleados a una lista como objetos "Modelo empleado"
        //para ser utilizados en la carga de datos de combobox
        public List<ModeloEmpleado> CargaEmpleados()
        {

            List<ModeloEmpleado> salidaComboBox = new List<ModeloEmpleado>();

            using (IDbConnection conexion = new System.Data.SqlClient.SqlConnection(ConfigGlobalConexion.StringConexion(conexionDB)))
            {

                salidaComboBox = conexion.Query<ModeloEmpleado>("dbo.traeEmpleadosActivos").ToList();

            }

            return salidaComboBox;

        }


        //Funcion que carga a una lista de objetos "ModeloEstatus" para ser utilizado en la carga de un combobox
        public List<ModeloEstatus> CargaEstatus()
        {

            List<ModeloEstatus> salidaComboEstatus = new List<ModeloEstatus>();

            using (IDbConnection conexion = new System.Data.SqlClient.SqlConnection(ConfigGlobalConexion.StringConexion(conexionDB)))
            {

                salidaComboEstatus = conexion.Query<ModeloEstatus>("dbo.traeTodosLosEstatus").ToList();

            }

            return salidaComboEstatus;

        }

        //Funcion que carga a una lista de objetos "string" para ser utilizados en la carga de un combobox
        public List<string> CargaCorreos() {
        
            List<string> salidaCorreos = new List<string>();

            using (IDbConnection conexion = new System.Data.SqlClient.SqlConnection(ConfigGlobalConexion.StringConexion(conexionDB))) {

                salidaCorreos = conexion.Query<string>("dbo.traeTodosLosCorreosEmpleadoActivo").ToList();

            }

            return salidaCorreos;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaSysMark.Conexiones;
using System.Configuration;

namespace LibreriaSysMark
{
    public static class ConfigGlobalConexion
    {

        public static DataConexion Conexion { get; private set; }

        //Clase utilizada para crear la conexion al iniciar el porgrama y
        //ser referenciado sin tener que llmarlo cada vez
        public static void IniciarConexion() {

            ComandosSQL sql = new ComandosSQL();
            Conexion = sql;

        }

        //Cadena de conexion que tiene la referencia de la base en AppConfig
        public static string StringConexion(string name) {

            return ConfigurationManager.ConnectionStrings[name].ConnectionString;

        }


    }
}

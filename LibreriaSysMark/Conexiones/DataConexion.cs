using LibreriaSysMark.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaSysMark.Conexiones
{
    //Clase de interfaz que determina la sintaxis a usar cuando referencias una de estas clases
    public interface DataConexion
    {

     ModeloEmpleado CrearEmpleado(ModeloEmpleado modelo);

     List<ModeloEmpleado> CargaEmpleados();

     List<ModeloEstatus> CargaEstatus();

     List<string> CargaCorreos();

    }
}

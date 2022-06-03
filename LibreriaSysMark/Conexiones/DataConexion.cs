using LibreriaSysMark.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaSysMark.Conexiones
{
    //Clase de interfaces que determina la manera de usar y la sintaxis cuando referencias una de estas clases
    //Necesarias para poder utilizar los getters y setters para asignar o devolver valores de los modelos
    public interface DataConexion
    {

     ModeloEmpleado CrearEmpleado(ModeloEmpleado modelo);

     List<ModeloEmpleado> CargaEmpleados();

     List<ModeloEstatus> CargaEstatus();

     List<string> CargaCorreos();

     List<ModeloProyecto> CargaProyectos();

    }
}

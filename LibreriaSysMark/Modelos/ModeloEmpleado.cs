using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaSysMark.Modelos
{
    //Modelo para la clase empleado, utiliza los getters y setters para dar los valores y devolverlos
    public class ModeloEmpleado
    {

        public int IdEmpleado { get; set; }
        public string NombreCompleto { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string CorreoElectronico { get; set; }
        public string TodoElNombre { get { return $"{NombreCompleto} {ApellidoPaterno} {ApellidoMaterno}"; } }

        //Constructor vacio utilizado para la carga de valores en los combobox
        public ModeloEmpleado() {

     

        }

        public ModeloEmpleado(string nombreCompleto, string apellidoPaterno, string apellidoMaterno, string correo)
        {

            NombreCompleto = nombreCompleto;

            ApellidoPaterno = apellidoPaterno;

            ApellidoMaterno = apellidoMaterno;

            CorreoElectronico = correo;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaSysMark.Modelos
{
    public class ModeloProyecto
    {

        public int IdProyecto { get; set; }

        public string Descripcion { get; set; }

        //Constructor vacio requerido para cargar la informacion al comboBox
        public ModeloProyecto() {

        }

    }
}

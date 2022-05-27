using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaSysMark.Modelos
{
    //Clase que contiene las propiedades de "Estatus"
    public class ModeloEstatus
    {
    
        public int IdEstatus { get; set; } 
        public string Descripcion { get; set; }

        //Constructor vacio para cargar la lista de "Estatus" al combobox
        public ModeloEstatus() { 
        
        }

    }
}

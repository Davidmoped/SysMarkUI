using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LibreriaSysMark.Modelos;
using LibreriaSysMark;
using System.Text.RegularExpressions;

namespace SysMark
{
    public partial class AgregarEmpleados : Form
    {
            public AgregarEmpleados()
        {
            InitializeComponent();
        }

        private void Limpiar() {

            txtNombreCompleto.Clear();
            txtApellidoMaterno.Clear();
            txtApellidoPaterno.Clear();
            txtCorreo.Clear();

        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {

            DialogResult mensaje = MessageBox.Show("Agregar nuevo empleado a la base de datos?",
              "Aviso de confirmacion", MessageBoxButtons.YesNoCancel);

            if (mensaje == DialogResult.Yes)
            {

                //Devuelve valor bool true si toda la validacion fue exitosa
                if (ValidacionForma() == true)
                {

                    ModeloEmpleado modelo = new ModeloEmpleado(

                            txtNombreCompleto.Text,
                            txtApellidoPaterno.Text,
                            txtApellidoMaterno.Text,
                            txtCorreo.Text);

                    ConfigGlobalConexion.Conexion.CrearEmpleado(modelo);

                    txtNombreCompleto.Text = "";
                    txtApellidoPaterno.Text = "";
                    txtApellidoMaterno.Text = "";
                    txtCorreo.Text = "";

                    MessageBox.Show("Empleado registrado exitosamente.");
                }

                else
                {

                    MessageBox.Show("Datos invalidos, revise que todos los campos tengan datos, y" +
                      " la dirección de correo sea valida.");

                }

            }

        }

        private bool ValidacionForma() {

            //Valida los 3 campos que contengan algun valor
            bool validacionExitosa = true;

            if (txtNombreCompleto.Text.Length == 0) {
            
                 validacionExitosa = false;

            }

            if (txtApellidoPaterno.Text.Length == 0) {

                validacionExitosa = false;

            }

            if (txtApellidoMaterno.Text.Length == 0) {

                validacionExitosa = false;

            }

            if (txtCorreo.Text.Length == 0) {

                validacionExitosa = false;

            }

            string correo = txtCorreo.Text;

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            Match match = regex.Match(correo);

            if (!match.Success) {

                validacionExitosa = false;

            } 
            
            return validacionExitosa;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            DialogResult mensaje = MessageBox.Show("¿Limpiar todos los campos de la pantalla?",
               "Aviso de confirmacion", MessageBoxButtons.YesNoCancel);

            if (mensaje == DialogResult.Yes)
            {

                Limpiar();

            }
        }
    }
}

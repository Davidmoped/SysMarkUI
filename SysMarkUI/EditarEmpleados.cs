using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using LibreriaSysMark;
using LibreriaSysMark.Modelos;
using System.Text.RegularExpressions;

namespace SysMarkUI
{
    public partial class EditarEmpleados : Form
    {
        public EditarEmpleados()
        {
            InitializeComponent();
            CargarDatos();
            cargaCombo();
            txtNombreCompleto.Select();
        }

        private List<ModeloEstatus> comboEstatus = ConfigGlobalConexion.Conexion.CargaEstatus();

        private bool ValidacionForma()
        {

            //Valida los 3 campos que contengan algun valor
            bool validacionExitosa = true;

            if (txtNombreCompleto.Text.Length == 0)
            {

                validacionExitosa = false;

            }

            if (txtApellidoPaterno.Text.Length == 0)
            {

                validacionExitosa = false;

            }

            if (txtApellidoMaterno.Text.Length == 0)
            {

                validacionExitosa = false;

            }

            if (txtCorreo.Text.Length == 0)
            {

                validacionExitosa = false;

            }

            string correo = txtCorreo.Text;

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            Match match = regex.Match(correo);

            if (!match.Success)
            {

                validacionExitosa = false;

            }

            return validacionExitosa;
        }

        private void cargaCombo() { 
        
            cmbEstatus.DataSource = comboEstatus;
            cmbEstatus.DisplayMember = "Descripcion";
            cmbEstatus.ValueMember = "IdEstatus";

        }

        private void bloquearCampos() {

            groupBox1.Enabled = false;
            btnBorrar.Enabled = false;
        
        }

        private void limpiarCampos() {

            txtIdEmpleado.Clear();
            txtNombreCompleto.Clear();
            txtApellidoPaterno.Clear();
            txtApellidoMaterno.Clear();
            txtCorreo.Clear();
            cmbEstatus.SelectedIndex = 0;

        }

        private void CargarDatos() {

            BusquedaEmpleado nuevaForm = new BusquedaEmpleado();

            if (nuevaForm.ShowDialog(this) == DialogResult.OK)
            {

                groupBox1.Enabled = true;

                btnEditar.Enabled = true;

                btnBorrar.Enabled = true;

                txtIdEmpleado.Text = nuevaForm.IdEmpleado.ToString();

                txtNombreCompleto.Text = nuevaForm.Nombre;

                txtApellidoPaterno.Text = nuevaForm.ApellidoPaterno;

                txtApellidoMaterno.Text = nuevaForm.ApellidoMaterno;

                txtCorreo.Text = nuevaForm.CorreoElectronico;

            }

        }


        private void btnEditar_Click(object sender, EventArgs e)
        {

            DialogResult mensaje = MessageBox.Show("Esta seguro de que quiere modificar la informacion?",
                "Aviso de confirmacion", MessageBoxButtons.YesNoCancel);

            if (mensaje == DialogResult.Yes)
            {

                if (ValidacionForma() == true)
                {

                    string conexion = ConfigurationManager.AppSettings["Conexion"];

                    using (SqlConnection conexionDB = new SqlConnection(conexion))
                    {

                        using (SqlCommand comando = new SqlCommand("dbo.editarEmpleado", conexionDB))
                        {

                            int IdEmpleado = int.Parse(txtIdEmpleado.Text);

                            comando.CommandType = CommandType.StoredProcedure;

                            comando.Parameters.Add("@NombreCompleto", sqlDbType: SqlDbType.NVarChar).Value = txtNombreCompleto.Text;

                            comando.Parameters.Add("@ApellidoPaterno", sqlDbType: SqlDbType.NVarChar).Value = txtApellidoPaterno.Text;

                            comando.Parameters.Add("@ApellidoMaterno", sqlDbType: SqlDbType.NVarChar).Value = txtApellidoMaterno.Text;

                            comando.Parameters.Add("@CorreoElectronico", sqlDbType: SqlDbType.NVarChar).Value = txtCorreo.Text;

                            comando.Parameters.Add("@EstatusEmpleado", sqlDbType: SqlDbType.Int).Value = cmbEstatus.SelectedValue;

                            comando.Parameters.Add("@IdEmpleado", sqlDbType: SqlDbType.Int).Value = IdEmpleado;

                            conexionDB.Open();
                            comando.ExecuteNonQuery();
                            conexionDB.Close();

                            MessageBox.Show("Registro editado exitosamente.");

                        }

                    }

                }

                else {

                    MessageBox.Show("Datos invalidos, revise que todos los campos tengan datos, y" +
                        " la dirección de correo sea valida.");

                }

            }

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            CargarDatos();
       
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

            string conexionDB = ConfigurationManager.AppSettings["Conexion"];

            DialogResult mensaje = MessageBox.Show("Esta seguro de querer borrar el registro?",
                "Aviso de confirmacion", MessageBoxButtons.YesNoCancel);

            if (mensaje == DialogResult.Yes)
            {

                using (SqlConnection conexion = new SqlConnection(conexionDB))
                {

                    using (SqlCommand comando = new SqlCommand("dbo.borrarEmpleado", conexion))
                    {
                        conexion.Open();

                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.Add("@IdEmpleado", sqlDbType: SqlDbType.Int).Value = txtIdEmpleado.Text;

                        comando.ExecuteNonQuery();

                        conexion.Close();

                        MessageBox.Show("Registro eliminado exitosamente.");

                        limpiarCampos();

                        bloquearCampos();

                    }

                }

            }

        }

    }

}
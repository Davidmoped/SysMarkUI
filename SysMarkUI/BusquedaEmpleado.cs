using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using LibreriaSysMark.Conexiones;
using LibreriaSysMark;
using System.Data.SqlClient;

namespace SysMarkUI
{
    public partial class BusquedaEmpleado : Form
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string CorreoElectronico { get; set; }

        public BusquedaEmpleado()
        {
            InitializeComponent();
            CargarDatos();
            txtBusqueda.Select();
            rdbNombre.Checked = true;
        }

        DataTable resultados = new DataTable();

        public void CargarDatos() {

            string conexionDB = ConfigurationManager.AppSettings["Conexion"];

            using (SqlConnection conexion = new SqlConnection(conexionDB)) {

                using (SqlCommand comando = new SqlCommand("dbo.traeTodosLosEmpleados", conexion)) {

                    comando.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adaptadorResultados = new SqlDataAdapter(comando)) {
                     
                            adaptadorResultados.Fill(resultados);

                            dataGridView1.DataSource = resultados;
      
                        }

                }

                }

            }


        private void btnAceptar_Click(object sender, EventArgs e)
        {

            btnAceptar.DialogResult = DialogResult.OK;

            IdEmpleado = (int)dataGridView1.CurrentRow.Cells["IdEmpleado"].Value;

            Nombre = dataGridView1.CurrentRow.Cells["NombreCompleto"].Value.ToString();

            ApellidoPaterno = dataGridView1.CurrentRow.Cells["ApellidoPaterno"].Value.ToString();

            ApellidoMaterno = dataGridView1.CurrentRow.Cells["ApellidoMaterno"].Value.ToString();

            CorreoElectronico = dataGridView1.CurrentRow.Cells["CorreoElectronico"].Value.ToString();

            Close();

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

            Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            btnAceptar.Enabled = true;

        }

        private void BusquedaEmpleado_Load(object sender, EventArgs e)
        {

            dataGridView1.ClearSelection();
        
        }   

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            //TODO FILTRAR POR MEDIOS

                if (rdbNombre.Checked == true)
                {

                    DataView dv = resultados.DefaultView;
                    dv.RowFilter = string.Format("NombreCompleto like '%{0}%'", txtBusqueda.Text);
                    dataGridView1.DataSource = dv.ToTable();
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
                    dataGridView1.ClearSelection();
                    btnAceptar.Enabled = false;

                }

                if (rdbApellido.Checked == true) {

                    DataView dv = resultados.DefaultView;
                    dv.RowFilter = string.Format("ApellidoPaterno like '%{0}%'", txtBusqueda.Text);
                    dataGridView1.DataSource = dv.ToTable();
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
                    dataGridView1.ClearSelection();
                    btnAceptar.Enabled = false;
                }

                if (rdbCorreo.Checked == true) {

                    DataView dv = resultados.DefaultView;
                    dv.RowFilter = string.Format("ApellidoPaterno like '%{0}%'", txtBusqueda.Text);
                    dataGridView1.DataSource = dv.ToTable();
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
                    dataGridView1.ClearSelection();
                    btnAceptar.Enabled = false;

                }

            }

        }
    }

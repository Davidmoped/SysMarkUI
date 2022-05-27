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
using System.Configuration;

namespace SysMark
{
    public partial class Busqueda : Form
    {
        public Busqueda()
        {
            InitializeComponent();
            txtBusqueda.Select();

        }

        DataSet resultados = new DataSet();

        public string[] Empresa = new string[30];  
        //string quese ocupa para pasar los parametros al otro formulario
        //(depende de la cantidad de los registros en el grid es el tamaño)
        
        DataTable dtResultados = new DataTable();

        public void leer_datos(string query, ref DataSet dstprincipal, string tabla)
        {

            try

            {

               string cadena = ConfigurationManager.AppSettings["Conexion"];
              
                SqlConnection cn = new SqlConnection(cadena);

                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtResultados);
                da.Dispose();
                cn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            leer_datos("dbo.traeTodoMarketing", ref resultados, "Marketing");

            //this.mifiltro = ((DataTable)resultados.Tables["Marketing"]).DefaultView;

            dataGridView1.DataSource = dtResultados;
            radioButton1.Checked = true;
            dataGridView1.ClearSelection();
           
        }

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {

                if (radioButton1.Checked == true)
                {

                    string fieldName = string.Concat("[", dtResultados.Columns[1].ColumnName, "]");
                    dtResultados.DefaultView.Sort = fieldName;
                    DataView view = dtResultados.DefaultView;
                    view.RowFilter = string.Empty;
                    if (txtBusqueda.Text != string.Empty)
                        view.RowFilter = fieldName + " LIKE '%" + txtBusqueda.Text + "%'";
                    dataGridView1.DataSource = view;
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
                    dataGridView1.ClearSelection();
                    btnAceptar.Enabled = false;

                }

                if (radioButton2.Checked == true)
                {

                    string fieldName = string.Concat("[", dtResultados.Columns[10].ColumnName, "]");
                    dtResultados.DefaultView.Sort = fieldName;
                    DataView view = dtResultados.DefaultView;
                    view.RowFilter = string.Empty;
                    if (txtBusqueda.Text != string.Empty)
                        view.RowFilter = fieldName + " LIKE '%" + txtBusqueda.Text + "%'";
                    dataGridView1.DataSource = view;
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
                    dataGridView1.ClearSelection();
                    btnAceptar.Enabled = false;

                }

                if (radioButton3.Checked == true)
                {

                    string fieldName = string.Concat("[", dtResultados.Columns[3].ColumnName, "]");
                    dtResultados.DefaultView.Sort = fieldName;
                    DataView view = dtResultados.DefaultView;
                    view.RowFilter = string.Empty;
                    if (txtBusqueda.Text != string.Empty)
                        view.RowFilter = fieldName + " LIKE '%" + txtBusqueda.Text + "%'";
                    dataGridView1.DataSource = view;
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
                    dataGridView1.ClearSelection();
                    btnAceptar.Enabled = false;

                }

                if (radioButton4.Checked == true)
                {

                    string fieldName = string.Concat("[", dtResultados.Columns[26].ColumnName, "]");
                    dtResultados.DefaultView.Sort = fieldName;
                    DataView view = dtResultados.DefaultView;
                    view.RowFilter = string.Empty;
                    if (txtBusqueda.Text != string.Empty)
                        view.RowFilter = fieldName + " LIKE '%" + txtBusqueda.Text + "%'";
                    dataGridView1.DataSource = view;
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
                    dataGridView1.ClearSelection();
                    btnAceptar.Enabled = false;

                }

            }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            btnAceptar.Enabled = true;
            
            int Fila = dataGridView1.CurrentRow.Index;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (i == Fila)
                {
                    //  DataRow dr = grdCustomers.Rows[Fila];

                    Empresa[0] = (dataGridView1.CurrentRow.Cells[0].Value).ToString();//IDEmpresa

                    Empresa[1] = (dataGridView1.CurrentRow.Cells[1].Value).ToString();

                    Empresa[2] = (dataGridView1.CurrentRow.Cells[2].Value).ToString();   
                    
                    Empresa[3] = (dataGridView1.CurrentRow.Cells[3].Value).ToString();

                    Empresa[4] = (dataGridView1.CurrentRow.Cells[4].Value).ToString();

                    Empresa[5] = (dataGridView1.CurrentRow.Cells[5].Value).ToString();

                    Empresa[6] = (dataGridView1.CurrentRow.Cells[6].Value).ToString();

                    Empresa[7] = (dataGridView1.CurrentRow.Cells[7].Value).ToString();

                    Empresa[8] = (dataGridView1.CurrentRow.Cells[8].Value).ToString();

                    Empresa[9] = (dataGridView1.CurrentRow.Cells[9].Value).ToString();

                    Empresa[10] = (dataGridView1.CurrentRow.Cells[10].Value).ToString();

                    Empresa[11] = (dataGridView1.CurrentRow.Cells[11].Value).ToString();

                    Empresa[12] = (dataGridView1.CurrentRow.Cells[12].Value).ToString();

                    Empresa[13] = (dataGridView1.CurrentRow.Cells[13].Value).ToString();

                    Empresa[14] = (dataGridView1.CurrentRow.Cells[14].Value).ToString();

                    Empresa[15] = (dataGridView1.CurrentRow.Cells[15].Value).ToString();

                    Empresa[16] = (dataGridView1.CurrentRow.Cells[16].Value).ToString();

                    Empresa[17] = (dataGridView1.CurrentRow.Cells[17].Value).ToString();

                    Empresa[18] = (dataGridView1.CurrentRow.Cells[18].Value).ToString();

                    Empresa[19] = (dataGridView1.CurrentRow.Cells[19].Value).ToString();

                    Empresa[20] = (dataGridView1.CurrentRow.Cells[20].Value).ToString();

                    Empresa[21] = (dataGridView1.CurrentRow.Cells[21].Value).ToString();

                    Empresa[22] = (dataGridView1.CurrentRow.Cells[22].Value).ToString();

                    Empresa[23] = (dataGridView1.CurrentRow.Cells[23].Value).ToString();

                    Empresa[24] = (dataGridView1.CurrentRow.Cells[24].Value).ToString();

                    Empresa[25] = (dataGridView1.CurrentRow.Cells[25].Value).ToString();

                    Empresa[26] = (dataGridView1.CurrentRow.Cells[26].Value).ToString();

                    Empresa[27] = (dataGridView1.CurrentRow.Cells[27].Value.ToString());

                    Empresa[28] = (dataGridView1.CurrentRow.Cells[28].Value.ToString());

                    Empresa[29] = (dataGridView1.CurrentRow.Cells[29].Value.ToString());

                }
            }
        }

    }
}
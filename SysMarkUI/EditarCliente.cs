using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;
using Outlook = Microsoft.Office.Interop.Outlook;
using LibreriaSysMark.Modelos;
using LibreriaSysMark;
using System.Data;

namespace SysMark
{
    public partial class EditarCliente : Form
    {
        //Carga de variable que contiene todos los valores para los combobox
        private List<ModeloEmpleado> comboEmpleados = ConfigGlobalConexion.Conexion.CargaEmpleados();

        private List<ModeloProyecto> comboProyecto = ConfigGlobalConexion.Conexion.CargaProyectos();

        //Lista que contiene todos los correos de empleados registrados a marketing
        private List<string> mandarCorreo = ConfigGlobalConexion.Conexion.CargaCorreos();

        int IDEmpresa = 0;

        private void habilitarAgendaLlamada()
        {

            if (chbAgendarLlamada.Checked == true)
            {

                dtProximaLlamada.Enabled = true;

            }
            else if (chbAgendarLlamada.Checked == false)
            {

                dtProximaLlamada.Enabled = false;

            }

        }

        private void activarCampos() {

            //Metodo que activa los campos al seleccionar un registro para modificar

            txtempresa.Enabled = true;

            txtpweb.Enabled = true;

            btnIR.Enabled = true;

            txterp.Enabled = true;

            txtcont.Enabled = true;

            txtpuesto.Enabled = true;

            txttelefono.Enabled = true;

            txtext.Enabled = true;

            txtCelular.Enabled = true;

            txtmail.Enabled = true;

            txtgiro.Enabled = true;

            txtestado.Enabled = true;

            txtciudad.Enabled = true;

            txtdirec.Enabled = true;

            txtcodigop.Enabled = true;

            txtcontsecundario.Enabled = true;

            txtpuesto2.Enabled = true;

            txttel2.Enabled = true;

            txtmail2.Enabled = true;

            txtCelularContacto2.Enabled = true;

            fechacontacto.Enabled = true;

            cmbestatus.Enabled = true;

            ChkEpicor.Enabled = true;

            ChkOpera.Enabled = true;

            chbAgendarLlamada.Enabled = true;

            txtcomentarios.Enabled = true;

            cmbingresado.Enabled = true;

            cmbclientede.Enabled = true;

            BtnGuardar.Enabled = true;

            button1.Enabled = true;

          

        }

        private void desactivarCampos() {

            //Metodo que desactiva los campos al borrar un registro por razones de validacion

            txtempresa.Enabled = false;

            txtpweb.Enabled = false;

            btnIR.Enabled = false;

            txterp.Enabled = false;

            txtcont.Enabled = false;

            txtpuesto.Enabled = false;

            txttelefono.Enabled = false;

            txtext.Enabled = false;

            txtCelular.Enabled = false;

            txtmail.Enabled = false;

            txtgiro.Enabled = false;

            txtestado.Enabled = false;

            txtciudad.Enabled = false;

            txtdirec.Enabled = false;

            txtcodigop.Enabled = false;

            txtcontsecundario.Enabled = false;

            txtpuesto2.Enabled = false;

            txttel2.Enabled = false;

            txtmail2.Enabled = false;

            txtCelularContacto2.Enabled = false;

            fechacontacto.Enabled = false;

            cmbestatus.Enabled = false;

            chbAgendarLlamada.Enabled = false;

            dtProximaLlamada.Enabled = false;

            ChkEpicor.Enabled = false;

            ChkOpera.Enabled = false;

            txtcomentarios.Enabled = false;

            cmbingresado.Enabled = false;

            cmbclientede.Enabled = false;

            BtnGuardar.Enabled = false;

            button1.Enabled = false;

         

        }

        public void crearJunta(string Asunto, string Ubicacion, DateTime FechaDeInicio, string Mensaje,
          DateTime FechaFinDeCita, int Recordatorio)
        {
            //Creacion de un objeto cita en Outlook, mas inforacion en la seccion de AgregarCliente.cs
            Outlook.Application outlookApp = new Outlook.Application();

            Outlook.AppointmentItem junta = null;

            Outlook.Recipients recipients = null;

            Outlook.Recipient recipient = null;

            junta = outlookApp.CreateItem(Outlook.OlItemType.olAppointmentItem);

            junta.Subject = Asunto;

            junta.Location = Ubicacion;

            junta.Body = Mensaje;

            junta.Start = FechaDeInicio;

            junta.MeetingStatus = Outlook.OlMeetingStatus.olMeeting;

            recipients = junta.Recipients;

            foreach (string correo in mandarCorreo)
            {

                recipient = recipients.Add(correo);

                recipient.Type = (int)Outlook.OlMeetingRecipientType.olRequired;

            }

            junta.BusyStatus = Outlook.OlBusyStatus.olBusy;
            //Para que en el calendario salga el estado de ocupado

            junta.ReminderSet = true;

            junta.ReminderMinutesBeforeStart = Recordatorio;

            junta.Save();
            //Para guardar la cita

            if (recipient.Resolve())
            {

                junta.Send();

            }
        }

        private void llenarCampos()
        {
            //Ventana emergente con los registros de clientes de marketing
            Busqueda frm = new Busqueda();
            
            DialogResult res = frm.ShowDialog();

            //Si se selecciono un registro, se activan los campos dle formulario y se pasan los campos
            //de cada celda en el datagridview de la forma Busqueda.cs por medio de un arreglo
            if (res == DialogResult.OK)
            {

                activarCampos();

                //Almacena el valor del ID del record de la base de datos en valorIDEMPRESA
                int valorIDEMPRESA = int.Parse(frm.Empresa[0]);

                //Se asigna el valor para ser utilizado en la clausla WHERE en la UPDATE query 
                IDEmpresa = valorIDEMPRESA;

                if (frm.Empresa[1].ToString() == "") { }
                else { txtempresa.Text = frm.Empresa[1].ToString(); } //EMPRESA

                if (frm.Empresa[2].ToString() == "") { }
                else { txtgiro.Text = frm.Empresa[2].ToString(); } //GIRO

                if (frm.Empresa[3].ToString() == "") { }
                else { txtestado.Text = frm.Empresa[3].ToString(); } //ESTADO

                if (frm.Empresa[4].ToString() == "") { }
                else { txtciudad.Text = frm.Empresa[4].ToString(); } //CIUDAD

                if (frm.Empresa[5].ToString() == "") { }
                else { txtdirec.Text = frm.Empresa[5].ToString(); } //DIRECCION

                if (frm.Empresa[6].ToString() == "") { }
                else { txtcodigop.Text = frm.Empresa[6].ToString(); } //CP

                if (frm.Empresa[7].ToString() == "") { }
                else { txttelefono.Text = frm.Empresa[7].ToString(); } //TELEFONO

                if (frm.Empresa[8].ToString() == "") { }
                else { txtext.Text = frm.Empresa[8].ToString(); } //EXTENCION

                if (frm.Empresa[9].ToString() == "") { }
                else { txtmail.Text = frm.Empresa[9].ToString(); } //EMAIL

                if (frm.Empresa[10].ToString() == "") { }
                else { txtcont.Text = frm.Empresa[10].ToString(); } //CONTACTO
                    
                if (frm.Empresa[11].ToString() == "") { }
                else { txtpuesto.Text = frm.Empresa[11].ToString(); } //PUESTO

                if (frm.Empresa[12].ToString() == "") { }
                else { txttel2.Text = frm.Empresa[12].ToString(); } //TELEFONO2

                //El indice 13 pertenece al campo EXTENSION 2 que no se utiliza en el formulario

                if (frm.Empresa[14].ToString() == "") { }
                else { txtmail2.Text = frm.Empresa[14].ToString(); } //EMAIL

                if (frm.Empresa[15].ToString() == "") { }
                else { txtcontsecundario.Text = frm.Empresa[15].ToString(); } //CONTACTO2

                if (frm.Empresa[16].ToString() == "") { }
                else { txtpuesto2.Text = frm.Empresa[16].ToString(); } //PUESTO 2

                if (frm.Empresa[17].ToString() == "") { }
                else { dtProximaLlamada.Value = DateTime.Parse(frm.Empresa[17].ToString()); } //PROXIMA LLAMADA

                if (frm.Empresa[18].ToString() == "") { }
                else { txtpweb.Text = frm.Empresa[18].ToString(); } //PAGINA WEB

                if (frm.Empresa[19].ToString() == "") { }
                else { txterp.Text = frm.Empresa[19].ToString(); } //ERP QUE MANEJAN

                if (frm.Empresa[20].ToString() == "") { }
                else { cmbestatus.Text = frm.Empresa[20].ToString(); } //ESTATUS

                if (frm.Empresa[21].ToString() == "") { }
                else { txtcomentarios.Text = frm.Empresa[21].ToString(); } //COMENTARIOS

                if (frm.Empresa[22].ToString() == "") { }
                else { fechacontacto.Value = DateTime.Parse(frm.Empresa[22].ToString()); } //FECHACONTACTO

                if (frm.Empresa[23].ToString() == "") { }
                else { ChkEpicor.Checked = bool.Parse(frm.Empresa[23].ToString()); } //PROYECTO EPICOR

                if (frm.Empresa[24].ToString() == "") { }
                else { ChkOpera.Checked = bool.Parse(frm.Empresa[24].ToString()); } //PROYECTO OPERA

                if (frm.Empresa[25].ToString() == "") { }
                else { cmbingresado.Text = frm.Empresa[25].ToString(); } //INGRESADO POR

                if (frm.Empresa[26].ToString() == "") { }
                else { cmbclientede.Text = frm.Empresa[26].ToString(); } //CLIENTE DE

                if (frm.Empresa[27].ToString() == "") { }
                else { txtCelular.Text = frm.Empresa[27].ToString(); } //CELULAR

                if (frm.Empresa[28].ToString() == "") { }
                else { txtCelularContacto2.Text = frm.Empresa[28].ToString(); } //CELULAR CONTACTO 2

                if (frm.Empresa[29].ToString() == "") { }
                else { chbAgendarLlamada.Checked = bool.Parse(frm.Empresa[29].ToString()); }

            }
        }

        public void soloNumerosTextBox(KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar)) { e.Handled = false; } //permite numeros
            if (char.IsLetter(e.KeyChar)) { e.Handled = true; } //NO permite letras
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = true; }

        }

       
        private void cargaCombo()
        {
            //Metodo que carga los valores de la base de datos al comboBox
            cmbingresado.DataSource = comboEmpleados;
            cmbingresado.DisplayMember = "TodoElNombre";

            cmbclientede.DataSource = comboProyecto;
            cmbclientede.DisplayMember = "Descripcion";

        }


        public EditarCliente()
        {

            InitializeComponent();
            llenarCampos();
            cargaCombo();
            habilitarAgendaLlamada();
            txtempresa.Select();
            fechacontacto.Value = DateTime.Now;
            dtProximaLlamada.Value = DateTime.Now;
        }


        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //Trae la conexion del archivo config
            string ConexionBD = ConfigurationManager.AppSettings["Conexion"];

            DialogResult mensaje = MessageBox.Show("Esta seguro de que quiere modificar la informacion?",
                "Aviso de confirmacion", MessageBoxButtons.YesNoCancel);

            if (mensaje == DialogResult.Yes)
            {

                DateTime date = fechacontacto.Value.Date;
                string fechaDeContacto = date.ToString("MM/dd/yyyy");
                DateTime date2 = dtProximaLlamada.Value;
                string fechaNuevoContacto = date2.ToString("MM/dd/yyyy HH:mm");

                using (SqlConnection conexion = new SqlConnection(ConexionBD))
                {

                    using (SqlCommand cmd = new SqlCommand("dbo.modificarMarketing", conexion))
                    {


                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Empresa", txtempresa.Text);

                        cmd.Parameters.AddWithValue("@PaginaWeb", txtpweb.Text);

                        cmd.Parameters.AddWithValue("@ERPManejado", txterp.Text);

                        cmd.Parameters.AddWithValue("@Contacto", txtcont.Text);

                        cmd.Parameters.AddWithValue("@Puesto", txtpuesto.Text);

                        cmd.Parameters.AddWithValue("@Telefono", txttelefono.Text);

                        cmd.Parameters.AddWithValue("@Extension", txtext.Text);

                        cmd.Parameters.AddWithValue("@Email", txtmail.Text);

                        cmd.Parameters.AddWithValue("@Giro", txtgiro.Text);

                        cmd.Parameters.AddWithValue("@Estado", txtestado.Text);

                        cmd.Parameters.AddWithValue("@Ciudad", txtciudad.Text);

                        cmd.Parameters.AddWithValue("@Direccion", txtdirec.Text);

                        cmd.Parameters.AddWithValue("@CP", txtcodigop.Text);

                        cmd.Parameters.AddWithValue("@Contacto2", txtcontsecundario.Text);

                        cmd.Parameters.AddWithValue("@Puesto2", txtpuesto2.Text);

                        cmd.Parameters.AddWithValue("@Telefono2", txttel2.Text);

                        cmd.Parameters.AddWithValue("@Email2", txtmail2.Text);

                        cmd.Parameters.AddWithValue("@ProximaLLamada", fechaNuevoContacto);

                        cmd.Parameters.AddWithValue("@FechaContacto", fechaDeContacto);

                        cmd.Parameters.AddWithValue("@Estatus", cmbestatus.Text);

                        cmd.Parameters.AddWithValue("@ProyectoEpicor", ChkEpicor.Checked);

                        cmd.Parameters.AddWithValue("@ProyectoOpera", ChkOpera.Checked);

                        cmd.Parameters.AddWithValue("@Comentarios", txtcomentarios.Text);

                        cmd.Parameters.AddWithValue("@IngresadoPor", cmbingresado.Text);

                        cmd.Parameters.AddWithValue("@ClienteDe", cmbclientede.Text);

                        cmd.Parameters.AddWithValue("@Celular", txtCelular.Text);

                        cmd.Parameters.AddWithValue("CelularContacto2", txtCelularContacto2.Text);

                        cmd.Parameters.AddWithValue("@TieneLlamada", chbAgendarLlamada.Checked);

                        cmd.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = IDEmpresa;

                        conexion.Open();

                        cmd.ExecuteNonQuery();

                        conexion.Close();

                    }

                }


                if (chbAgendarLlamada.Checked == true)
                {

                    DateTime llamarDeNuevo = dtProximaLlamada.Value;

                    crearJunta("Llamada con: " + txtcont.Text + " ,de la empresa: " + txtempresa.Text,
                                "Contacto: Telefono fijo: " + txttelefono.Text + "   Celular: " +
                                txtCelular.Text,
                                llamarDeNuevo,
                                txtcomentarios.Text,
                                DateTime.Today.AddDays(1),
                                5);

                    Limpiar();

                }

                    MessageBox.Show("Registro Editado Exitosamente");

            }

        }

        
        private void BtnHome_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
         
            llenarCampos();
            
        }

        //Boton eliminar Registro
        private void button1_Click(object sender, EventArgs e)
        {

            //Metodo para borrar los registros

            //Inicio de conexion a BD con el archivo App Config
            string ConexionDB = ConfigurationManager.AppSettings["Conexion"];

            DialogResult mensaje = MessageBox.Show("Esta seguro de que quiere eliminar la informacion?",
                "Aviso de confirmacion", MessageBoxButtons.YesNoCancel);

            if (mensaje == DialogResult.Yes)
            {

                using (SqlConnection conexion = new SqlConnection(ConexionDB)) {

                    using (SqlCommand cmd = new SqlCommand("dbo.borrarMarketing", conexion))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = IDEmpresa;

                        conexion.Open();

                        cmd.ExecuteNonQuery();

                        conexion.Close();

                        MessageBox.Show("Registro borrado exitosamente.");

                        Limpiar();

                        desactivarCampos();

                    }

                }

            }

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {

            Limpiar();

        }
        public void Limpiar()
        {
            //Funcion para limpiar todos los campos
            txtempresa.Clear();

            txtpweb.Clear();

            txterp.Clear();

            txtcont.Clear();

            txtpuesto.Clear();

            txttelefono.Clear();

            txtext.Clear();

            txtmail.Clear();

            txtgiro.Clear();

            txtestado.Clear();

            txtciudad.Clear();

            txtdirec.Clear();

            txtcodigop.Clear();

            txtcontsecundario.Clear();

            txtpuesto2.Clear();

            txttel2.Clear();

            txtmail2.Clear();

            txtcomentarios.Clear();

            txtcomentarios.Clear();

            txtCelular.Clear();

            txtCelularContacto2.Clear();

            ChkEpicor.Checked = false;

            ChkOpera.Checked = false;

            chbAgendarLlamada.Checked = false;

            fechacontacto.Value = DateTime.Today;

            dtProximaLlamada.Value = DateTime.Today;

            cmbestatus.SelectedIndex = 0;

            cmbingresado.SelectedIndex = 0;

            cmbclientede.SelectedIndex = 0;
           
        }

        private void btnIR_Click(object sender, EventArgs e)
        {

            if (txtpweb.Text != "")
            {

                string Pagina = txtpweb.Text;
                string[] validador = Pagina.Split('.');

                if (validador.Length >= 3)
                {

                    System.Diagnostics.Process.Start(Pagina);

                }

                else { MessageBox.Show("El texto ingresado no es una pagina web"); }

            }

        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {

            soloNumerosTextBox(e);

        }

        private void txtext_KeyPress(object sender, KeyPressEventArgs e)
        {

            soloNumerosTextBox(e);

        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {

            soloNumerosTextBox(e);

        }

        private void txtcodigop_KeyPress(object sender, KeyPressEventArgs e)
        {

            soloNumerosTextBox(e);

        }

        private void txttel2_KeyPress(object sender, KeyPressEventArgs e)
        {

            soloNumerosTextBox(e);

        }

        private void txtCelularContacto2_KeyPress(object sender, KeyPressEventArgs e)
        {

            soloNumerosTextBox(e);

        }

        private void txtmin_KeyPress(object sender, KeyPressEventArgs e)
        {

            soloNumerosTextBox(e);

        }

        private void chbAgendarLlamada_CheckedChanged(object sender, EventArgs e)
        {

            habilitarAgendaLlamada();

        }

        private void BtnNuevo_Click_1(object sender, EventArgs e)
        {
            DialogResult mensaje = MessageBox.Show("¿Limpiar los campos?",
                "Aviso de confirmación", MessageBoxButtons.YesNoCancel);

            if (mensaje == DialogResult.Yes) {

                Limpiar();

            }
          
        }
    }

}

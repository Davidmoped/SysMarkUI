using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using LibreriaSysMark.Modelos;
using LibreriaSysMark;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Collections.Generic;
using System.Data;

namespace SysMark
{

    public partial class AgregarCliente : Form
    {

        //Carga de informacion a la base de datos para ser implementado al combobox correspondiente

        private List<ModeloEmpleado> comboEmpleados = ConfigGlobalConexion.Conexion.CargaEmpleados();

        private List<ModeloProyecto> comboProyecto = ConfigGlobalConexion.Conexion.CargaProyectos();

        //Lista que contiene todos los correos delos empleados registrados en Marketing
        private List<string> mandarCorreo = ConfigGlobalConexion.Conexion.CargaCorreos();

        public AgregarCliente()
        {
            InitializeComponent();
            cargaCombo();
            habilitarAgendaLlamada();
            txtempresa.Select();
            dtProximaLlamada.Value = DateTime.Now;
            FechaContacto.Value = DateTime.Now;
        }

        private void habilitarAgendaLlamada()
        {
            //Funcion que deshabilita el control de fecha para agendar una llamada
            if (chbAgendarLlamada.Checked == true)
            {

                dtProximaLlamada.Enabled = true;

            }
            else if (chbAgendarLlamada.Checked == false)
            {

                dtProximaLlamada.Enabled = false;

            }

        }

        private void cargaCombo() {

            //Llenado de los combobox desde la base de datos
            cmbingresado.DataSource = comboEmpleados;
            cmbingresado.DisplayMember = "TodoElNombre";

            cmbclientede.DataSource = comboProyecto;
            cmbclientede.DisplayMember = "Descripcion";
         

        }

        public void soloNumerosTextBox(KeyPressEventArgs e)
        {
            //Funcion que deshabilita en los campos de celular y telefono ingresar letras
            if (char.IsDigit(e.KeyChar)) { e.Handled = false; } //permite numeros

            if (char.IsLetter(e.KeyChar)) { e.Handled = true; } //NO permite letras
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = true; }
        }

        public void crearJunta(string Asunto, string Ubicacion, DateTime FechaDeInicio, string Mensaje,
            DateTime FechaFinDeCita, int Recordatorio) {


            //Creacion de una instancia de la libreria Microsoft Outlook Interlop
            Outlook.Application outlookApp = new Outlook.Application();

            //Declaracion de los objetos Outlook para mandar un recordatorio de junta
            Outlook.AppointmentItem junta = null;

            Outlook.Recipients recipients = null;

            Outlook.Recipient recipient = null;

            //Creacion de un objeto Cita de Outlook
            junta = outlookApp.CreateItem(Outlook.OlItemType.olAppointmentItem);

            //Declaracion de los parametros de la funcion que serviran como la estructura y cuerpo de la Cita
            junta.Subject = Asunto;

            junta.Location = Ubicacion;

            junta.Body = Mensaje;

            junta.Start = FechaDeInicio;

            junta.MeetingStatus = Outlook.OlMeetingStatus.olMeeting;

            recipients = junta.Recipients;

            //Bucle de la lista de correos de empleados para ser agregados como miembros al citatorio de 
            //la llamada 
            foreach (string correo in mandarCorreo) {

                recipient = recipients.Add(correo);

                recipient.Type = (int)Outlook.OlMeetingRecipientType.olRequired;

            }

            junta.BusyStatus = Outlook.OlBusyStatus.olBusy;
            //Parametro para que en el calendario salga el estado de ocupado la cita

            junta.ReminderSet = true;
            //Parametro necesario para mostrar una notificacion de recordatorio en outlook

            junta.ReminderMinutesBeforeStart = Recordatorio;

            junta.Save();
            //Para guardar la cita

            //Condicional que verifica que todo este en orden y manda el citatorio a todos los miembros
            if (recipient.Resolve())
            {

                junta.Send();

            }
        }

        public static void borrarCita(DateTime FechaInicio)
        {

            Outlook.Application outlookApp = new Outlook.Application(); //Crea un objeto de OutLook Outlook.AppointmentItem Cita; //Instanciamos Un objeto de tipo Cita(AppointmentItem)

            Outlook.AppointmentItem item;

            item = (Outlook.AppointmentItem)outlookApp.CreateItem(Outlook.OlItemType.olAppointmentItem);

            Outlook.RecurrencePattern pattern =
                item.GetRecurrencePattern();

            Outlook.AppointmentItem itemDelete = pattern.
                GetOccurrence(FechaInicio);


            if (itemDelete != null)
            {

                itemDelete.Delete();

            }

        }



        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult mensaje = MessageBox.Show("Agregar la informacion?",
                "Aviso de confirmacion", MessageBoxButtons.YesNoCancel);

            if (mensaje == DialogResult.Yes)
            {
                //Variables para almacenar la fecha de contacto y llamar de nuevo, formateadas a una cadena valida
                //para SQL
                DateTime date = FechaContacto.Value.Date;
                string fechaContacto = date.ToString("MM/dd/yyyy");
                DateTime date2 = dtProximaLlamada.Value;
                string fechaNuevoContacto = date2.ToString("MM/dd/yyyy HH:mm");

                // TODO IMPLEMENTAR CONEXION MAS OPTIMA

                //Inicio de la conexion a la base de datos
                string ConexionBD = ConfigurationManager.AppSettings["Conexion"];
                
                //Declaracion de variables desechables para la conexion de base de datos no se necesita un conexion.Close()
                using (SqlConnection conexion = new SqlConnection(ConexionBD))
                {
                    using (SqlCommand command = new SqlCommand("dbo.registrarMarketing", conexion))
                    {
                        //Uso de stored procedure mas informacion en el diccionario de datos y
                        //la base de datos de produccion o de prueba
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Empresa", txtempresa.Text);

                        command.Parameters.AddWithValue("@PaginaWeb", txtpweb.Text);

                        command.Parameters.AddWithValue("@ERPManejado", txterp.Text);

                        command.Parameters.AddWithValue("@Contacto", txtcont.Text);

                        command.Parameters.AddWithValue("@Puesto", txtpuesto.Text);

                        command.Parameters.AddWithValue("@Telefono", txttelefono.Text);

                        command.Parameters.AddWithValue("@Extension", txtext.Text);

                        command.Parameters.AddWithValue("@Email", txtmail.Text);

                        command.Parameters.AddWithValue("@Giro", txtgiro.Text);

                        command.Parameters.AddWithValue("@Estado", txtestado.Text);

                        command.Parameters.AddWithValue("@Ciudad", txtciudad.Text);

                        command.Parameters.AddWithValue("@Direccion", txtdirec.Text);

                        command.Parameters.AddWithValue("@CP", txtcp.Text);

                        command.Parameters.AddWithValue("@Contacto2", txtcontacto2.Text);

                        command.Parameters.AddWithValue("@Puesto2", txtpuesto2.Text);

                        command.Parameters.AddWithValue("@Telefono2", txttel2.Text);

                        command.Parameters.AddWithValue("@Email2", txtmail2.Text);

                        if (chbAgendarLlamada.Checked == true)
                        {

                            command.Parameters.AddWithValue("@ProximaLLamada", fechaNuevoContacto);

                        }
                        else {

                            command.Parameters.AddWithValue("@ProximaLLamada", DBNull.Value);

                        }

                        command.Parameters.AddWithValue("@FechaContacto", fechaContacto);

                        command.Parameters.AddWithValue("@Estatus", cmbestatus.Text);

                        command.Parameters.AddWithValue("@ProyectoEpicor", ChkEpicor.Checked);

                        command.Parameters.AddWithValue("@ProyectoOpera", ChkOpera.Checked);

                        command.Parameters.AddWithValue("@Comentarios", txtcomentarios.Text);

                        command.Parameters.AddWithValue("@IngresadoPor", cmbingresado.Text);

                        command.Parameters.AddWithValue("@ClienteDe", cmbclientede.Text);

                        command.Parameters.AddWithValue("@Celular", txtCelular.Text);

                        command.Parameters.AddWithValue("@CelularContacto2", txtCelularContacto2.Text);

                        command.Parameters.AddWithValue("@TieneLlamada", chbAgendarLlamada.Checked);

                        conexion.Open();

                        command.ExecuteNonQuery();

                        MessageBox.Show("Registro Guardado Exitosamente");

                        conexion.Close();

                    }

                }


                //Condicion para realizar la funcion de agendar un citatorio en outlook
                //si la checkbox agendar llamada esta activa
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

                }

                Limpiar();

            }

        }

        //Limpieza de todos los campos del formulario y reseteo a valores default
        public void Limpiar()
        {
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

            txtcp.Clear();

            txtcontacto2.Clear();

            txtpuesto2.Clear();

            txttel2.Clear();

            txtmail2.Clear();

            txtcomentarios.Clear();

            txtcomentarios.Clear();

            txtCelular.Clear();

            txtCelularContacto2.Clear();

            ChkEpicor.Checked = false;

            ChkOpera.Checked = false;

            FechaContacto.Value = DateTime.Today;

            dtProximaLlamada.Value = DateTime.Today;

            cmbestatus.SelectedIndex = 0;

            cmbingresado.SelectedIndex = 0;

            cmbclientede.SelectionLength = 0;
         

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

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumerosTextBox(e);
        }

        private void txtext_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumerosTextBox(e);
        }

        private void txtmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumerosTextBox(e);
        }

        private void txtcp_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumerosTextBox(e);
        }

        private void txttel2_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumerosTextBox(e);
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

        private void chbAgendarLlamada_CheckedChanged(object sender, EventArgs e)
        {

            habilitarAgendaLlamada();
            
        }

    }
}

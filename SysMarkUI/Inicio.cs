using SysMarkUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysMark
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            CustomizeDesing();
        }

        private void CustomizeDesing()
        {
            PanelMarketingSubmenu.Visible = false;
            panelpaginawebsubmenu.Visible = false;
            panelAdministrarSubMenu.Visible = false;
            
            //...
        }

     /*   private void CambioColorBoton() {

            Control button = ((Control)sender);
            switch (ctr)
            {
                default:
                    break;
            }

        } */

        private void openprincipalform(Form principalform)
        {

            if (activeform != null)
                activeform.Close();
            activeform = principalform;
            principalform.TopLevel = false;
            principalform.FormBorderStyle = FormBorderStyle.None;
            principalform.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(principalform);
            panelPrincipal.Tag = principalform;
            principalform.BringToFront();
            principalform.Show();

        }

        private void HideSubMenu()
        {

            if (PanelMarketingSubmenu.Visible == true)
            {

                PanelMarketingSubmenu.Visible = false;

            }

            if (panelpaginawebsubmenu.Visible == true)
            {

                panelpaginawebsubmenu.Visible = false;

            }
                
        }
        private void Showsubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {

                HideSubMenu();
                subMenu.Visible = true;

            }
            else
            {

                subMenu.Visible = false;

            }
        }   

        private void btnEditaremp_Click(object sender, EventArgs e)
        {
            openprincipalform(new EditarCliente());
            
            //...
            HideSubMenu();
        }

        private void btnConsultaremp_Click(object sender, EventArgs e)
        {
            openprincipalform(new Busqueda());
            //...
            HideSubMenu();
        }

        private void btnEliminaremp_Click(object sender, EventArgs e)
        {
            //...
            HideSubMenu();
        }

        private void btnMarketing_Click_1(object sender, EventArgs e)
        
        {
            this.btnMarketing.BackColor = Color.FromArgb(10, 105, 105);
            Showsubmenu(PanelMarketingSubmenu);
           
        }

        private void btnAgregaremp_Click(object sender, EventArgs e)
        {
            openprincipalform(new AgregarCliente());
            //...
            HideSubMenu();
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            Showsubmenu(panelpaginawebsubmenu);

        }

        private void btnAgregarpw_Click(object sender, EventArgs e)
        {
            //...
            HideSubMenu();
        }

        private void btnEditarpw_Click(object sender, EventArgs e)
        {
            //...
            HideSubMenu();
        }

        private void btnConsultapw_Click(object sender, EventArgs e)
        {
            //...
            HideSubMenu();
        }

        private void btnConsultarpw_Click(object sender, EventArgs e)
        {
            //...
            HideSubMenu();
        }

       

        private void btnEditarcte_Click(object sender, EventArgs e)
        {
            //...
            HideSubMenu();
        }

        private void btnConsultarcte_Click(object sender, EventArgs e)
        {
            //...
            HideSubMenu();
        }

        private void btnEliminarcte_Click(object sender, EventArgs e)
        {
            //...
            HideSubMenu();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private Form activeform = null;
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdministrar_Click(object sender, EventArgs e)
        {
            this.btnAdministrar.BackColor = Color.FromArgb(10, 105, 105);
            Showsubmenu(panelAdministrarSubMenu);
        }

        private void btnEditarEmpleado_Click_1(object sender, EventArgs e)
        {
            openprincipalform(new AgregarEmpleados());
            //...
            HideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openprincipalform(new EditarEmpleados());
            //...
            HideSubMenu();
        }

        private void btnConsultaEmpleado_Click(object sender, EventArgs e)
        {

            openprincipalform(new BusquedaEmpleado());
            //...
            HideSubMenu();

        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            
        }
    }
}

namespace SysMarkUI
{
    partial class VistaEmpleado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaEmpleado));
            this.rdbCorreo = new System.Windows.Forms.RadioButton();
            this.rdbApellido = new System.Windows.Forms.RadioButton();
            this.rdbNombre = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnInicio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // rdbCorreo
            // 
            this.rdbCorreo.AutoSize = true;
            this.rdbCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCorreo.Location = new System.Drawing.Point(631, 16);
            this.rdbCorreo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdbCorreo.Name = "rdbCorreo";
            this.rdbCorreo.Size = new System.Drawing.Size(243, 29);
            this.rdbCorreo.TabIndex = 59;
            this.rdbCorreo.TabStop = true;
            this.rdbCorreo.Text = "Busqueda por Correo";
            this.rdbCorreo.UseVisualStyleBackColor = true;
            // 
            // rdbApellido
            // 
            this.rdbApellido.AutoSize = true;
            this.rdbApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbApellido.Location = new System.Drawing.Point(355, 16);
            this.rdbApellido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdbApellido.Name = "rdbApellido";
            this.rdbApellido.Size = new System.Drawing.Size(255, 29);
            this.rdbApellido.TabIndex = 58;
            this.rdbApellido.TabStop = true;
            this.rdbApellido.Text = "Busqueda por Apellido";
            this.rdbApellido.UseVisualStyleBackColor = true;
            // 
            // rdbNombre
            // 
            this.rdbNombre.AutoSize = true;
            this.rdbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNombre.Location = new System.Drawing.Point(76, 16);
            this.rdbNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdbNombre.Name = "rdbNombre";
            this.rdbNombre.Size = new System.Drawing.Size(252, 29);
            this.rdbNombre.TabIndex = 57;
            this.rdbNombre.TabStop = true;
            this.rdbNombre.Text = "Busqueda por Nombre";
            this.rdbNombre.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 29);
            this.label1.TabIndex = 56;
            this.label1.Text = "Ingrese su Busqueda";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(40, 115);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(875, 366);
            this.dataGridView1.TabIndex = 55;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(458, 70);
            this.txtBusqueda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(272, 26);
            this.txtBusqueda.TabIndex = 60;
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInicio.Image = ((System.Drawing.Image)(resources.GetObject("btnInicio.Image")));
            this.btnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.Location = new System.Drawing.Point(761, 60);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(138, 46);
            this.btnInicio.TabIndex = 61;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInicio.UseVisualStyleBackColor = false;
            // 
            // VistaEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 496);
            this.Controls.Add(this.btnInicio);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.rdbCorreo);
            this.Controls.Add(this.rdbApellido);
            this.Controls.Add(this.rdbNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "VistaEmpleado";
            this.Text = "VistaEmpleado";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbCorreo;
        private System.Windows.Forms.RadioButton rdbApellido;
        private System.Windows.Forms.RadioButton rdbNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnInicio;
    }
}
namespace _MYS1_Proyecto_G1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tablaUbicaciones = new System.Windows.Forms.Button();
            this.cargarDestinos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.calcularRutas = new System.Windows.Forms.Button();
            this.UbicacionesTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataUbicaciones = new System.Windows.Forms.DataGridView();
            this.idColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cordenadaz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoFallo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadEventos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avpista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataVuelos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.te = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UbicacionesTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataUbicaciones)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataVuelos)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaUbicaciones
            // 
            this.tablaUbicaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablaUbicaciones.Location = new System.Drawing.Point(370, 6);
            this.tablaUbicaciones.Name = "tablaUbicaciones";
            this.tablaUbicaciones.Size = new System.Drawing.Size(96, 42);
            this.tablaUbicaciones.TabIndex = 0;
            this.tablaUbicaciones.Text = "Cargar";
            this.tablaUbicaciones.UseVisualStyleBackColor = true;
            this.tablaUbicaciones.Click += new System.EventHandler(this.button1_Click);
            // 
            // cargarDestinos
            // 
            this.cargarDestinos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cargarDestinos.Location = new System.Drawing.Point(330, 6);
            this.cargarDestinos.Name = "cargarDestinos";
            this.cargarDestinos.Size = new System.Drawing.Size(101, 44);
            this.cargarDestinos.TabIndex = 1;
            this.cargarDestinos.Text = "Cargar";
            this.cargarDestinos.UseVisualStyleBackColor = true;
            this.cargarDestinos.Click += new System.EventHandler(this.cargarDestinos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Administrador- Aeropuerto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(352, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seleccionar archivo de ubicaciones";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(318, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Seleccionar archivo de destinos";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // calcularRutas
            // 
            this.calcularRutas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calcularRutas.Location = new System.Drawing.Point(326, 478);
            this.calcularRutas.Name = "calcularRutas";
            this.calcularRutas.Size = new System.Drawing.Size(117, 39);
            this.calcularRutas.TabIndex = 5;
            this.calcularRutas.Text = "Calcular Rutas";
            this.calcularRutas.UseVisualStyleBackColor = true;
            this.calcularRutas.Click += new System.EventHandler(this.calcularRutas_Click);
            // 
            // UbicacionesTab
            // 
            this.UbicacionesTab.Controls.Add(this.tabPage1);
            this.UbicacionesTab.Controls.Add(this.tabPage2);
            this.UbicacionesTab.Location = new System.Drawing.Point(26, 67);
            this.UbicacionesTab.Name = "UbicacionesTab";
            this.UbicacionesTab.SelectedIndex = 0;
            this.UbicacionesTab.Size = new System.Drawing.Size(820, 405);
            this.UbicacionesTab.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataUbicaciones);
            this.tabPage1.Controls.Add(this.tablaUbicaciones);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(812, 379);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ubicaciones";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataUbicaciones
            // 
            this.dataUbicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUbicaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumna,
            this.nombre,
            this.latitud,
            this.longitud,
            this.cordenadaz,
            this.tipoFallo,
            this.cantidadEventos,
            this.tiempo,
            this.avpista,
            this.tp,
            this.ta});
            this.dataUbicaciones.Location = new System.Drawing.Point(6, 54);
            this.dataUbicaciones.Name = "dataUbicaciones";
            this.dataUbicaciones.Size = new System.Drawing.Size(800, 319);
            this.dataUbicaciones.TabIndex = 4;
            this.dataUbicaciones.Visible = false;
            this.dataUbicaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // idColumna
            // 
            this.idColumna.HeaderText = "ID";
            this.idColumna.Name = "idColumna";
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            // 
            // latitud
            // 
            this.latitud.HeaderText = "Cordena X";
            this.latitud.Name = "latitud";
            // 
            // longitud
            // 
            this.longitud.HeaderText = "Cordena Y";
            this.longitud.Name = "longitud";
            // 
            // cordenadaz
            // 
            this.cordenadaz.HeaderText = "Cordena Z";
            this.cordenadaz.Name = "cordenadaz";
            // 
            // tipoFallo
            // 
            this.tipoFallo.HeaderText = "Tipo Falla";
            this.tipoFallo.Name = "tipoFallo";
            // 
            // cantidadEventos
            // 
            this.cantidadEventos.HeaderText = "Cantidad Eventos";
            this.cantidadEventos.Name = "cantidadEventos";
            // 
            // tiempo
            // 
            this.tiempo.HeaderText = "Tiempo Reparacion";
            this.tiempo.Name = "tiempo";
            // 
            // avpista
            // 
            this.avpista.HeaderText = "Capacidad Av.";
            this.avpista.Name = "avpista";
            // 
            // tp
            // 
            this.tp.HeaderText = "Tiempo Persona";
            this.tp.Name = "tp";
            // 
            // ta
            // 
            this.ta.HeaderText = "Tiempo Abordaje";
            this.ta.Name = "ta";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataVuelos);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.cargarDestinos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(812, 379);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Destinos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataVuelos
            // 
            this.dataVuelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataVuelos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.ad,
            this.costo,
            this.vm,
            this.te});
            this.dataVuelos.Location = new System.Drawing.Point(9, 64);
            this.dataVuelos.Name = "dataVuelos";
            this.dataVuelos.Size = new System.Drawing.Size(800, 319);
            this.dataVuelos.TabIndex = 5;
            this.dataVuelos.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Aeropuerto O.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // ad
            // 
            this.ad.HeaderText = "Aeropuerto D.";
            this.ad.Name = "ad";
            // 
            // costo
            // 
            this.costo.HeaderText = "Costo";
            this.costo.Name = "costo";
            // 
            // vm
            // 
            this.vm.HeaderText = "Virajes máximo";
            this.vm.Name = "vm";
            // 
            // te
            // 
            this.te.HeaderText = "Tiempo Esperado";
            this.te.Name = "te";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 529);
            this.Controls.Add(this.UbicacionesTab);
            this.Controls.Add(this.calcularRutas);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Simulación de vuelos comerciales 0.0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.UbicacionesTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataUbicaciones)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataVuelos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button tablaUbicaciones;
        private System.Windows.Forms.Button cargarDestinos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button calcularRutas;
        private System.Windows.Forms.TabControl UbicacionesTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataUbicaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumna;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn latitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn cordenadaz;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoFallo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadEventos;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn avpista;
        private System.Windows.Forms.DataGridViewTextBoxColumn tp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ta;
        private System.Windows.Forms.DataGridView dataVuelos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ad;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn vm;
        private System.Windows.Forms.DataGridViewTextBoxColumn te;
    }
}


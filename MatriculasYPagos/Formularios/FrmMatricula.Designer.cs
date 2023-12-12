namespace MatriculasYPagos.Formularios
{
    partial class FrmMatricula
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
            this.cmbIDAlumno = new System.Windows.Forms.ComboBox();
            this.cmbIDClase = new System.Windows.Forms.ComboBox();
            this.dgMatriculas = new System.Windows.Forms.DataGridView();
            this.ID_Matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Alumno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Clase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgMatriculas)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbIDAlumno
            // 
            this.cmbIDAlumno.FormattingEnabled = true;
            this.cmbIDAlumno.Location = new System.Drawing.Point(12, 310);
            this.cmbIDAlumno.Name = "cmbIDAlumno";
            this.cmbIDAlumno.Size = new System.Drawing.Size(212, 21);
            this.cmbIDAlumno.TabIndex = 1;
            // 
            // cmbIDClase
            // 
            this.cmbIDClase.FormattingEnabled = true;
            this.cmbIDClase.Location = new System.Drawing.Point(12, 363);
            this.cmbIDClase.Name = "cmbIDClase";
            this.cmbIDClase.Size = new System.Drawing.Size(212, 21);
            this.cmbIDClase.TabIndex = 2;
            // 
            // dgMatriculas
            // 
            this.dgMatriculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMatriculas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Matricula,
            this.ID_Alumno,
            this.ID_Clase,
            this.Fecha_Matricula});
            this.dgMatriculas.Location = new System.Drawing.Point(2, 0);
            this.dgMatriculas.Name = "dgMatriculas";
            this.dgMatriculas.ReadOnly = true;
            this.dgMatriculas.Size = new System.Drawing.Size(743, 168);
            this.dgMatriculas.TabIndex = 4;
            this.dgMatriculas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMatriculas_CellContentClick);
            // 
            // ID_Matricula
            // 
            this.ID_Matricula.HeaderText = "ID";
            this.ID_Matricula.Name = "ID_Matricula";
            this.ID_Matricula.ReadOnly = true;
            this.ID_Matricula.Width = 133;
            // 
            // ID_Alumno
            // 
            this.ID_Alumno.HeaderText = "ID_Alumno";
            this.ID_Alumno.Name = "ID_Alumno";
            this.ID_Alumno.ReadOnly = true;
            this.ID_Alumno.Width = 133;
            // 
            // ID_Clase
            // 
            this.ID_Clase.HeaderText = "ID Clase";
            this.ID_Clase.Name = "ID_Clase";
            this.ID_Clase.ReadOnly = true;
            this.ID_Clase.Width = 133;
            // 
            // Fecha_Matricula
            // 
            this.Fecha_Matricula.HeaderText = "Fecha de la Matricula";
            this.Fecha_Matricula.Name = "Fecha_Matricula";
            this.Fecha_Matricula.ReadOnly = true;
            this.Fecha_Matricula.Width = 300;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Green;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(12, 206);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(103, 40);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(121, 206);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(103, 40);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Alumnos ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Clase";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // FrmMatricula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgMatriculas);
            this.Controls.Add(this.cmbIDClase);
            this.Controls.Add(this.cmbIDAlumno);
            this.Name = "FrmMatricula";
            this.Text = "FrmMatricula";
            this.Load += new System.EventHandler(this.FrmMatricula_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMatriculas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbIDAlumno;
        private System.Windows.Forms.ComboBox cmbIDClase;
        private System.Windows.Forms.DataGridView dgMatriculas;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Alumno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Clase;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Matricula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
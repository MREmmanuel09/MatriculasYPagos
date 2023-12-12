namespace MatriculasYPagos.Formularios
{
    partial class FrmPago
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
            this.SuspendLayout();
            // 
            // FrmPago
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FrmPago";
            this.Load += new System.EventHandler(this.FrmPago_Load_2);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgPagos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Alumno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Clase;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Matricula;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.ComboBox cmbIDClase;
        private System.Windows.Forms.ComboBox cmbIDAlumno;
        private System.Windows.Forms.TextBox TxtMonto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtAsunto;
        private System.Windows.Forms.Label label4;
    }
}
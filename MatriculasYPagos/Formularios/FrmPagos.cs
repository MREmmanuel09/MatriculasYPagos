using System;
using System.Data;
using System.Windows.Forms;
using Logica.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MatriculasYPagos.Formularios
{
    public partial class FrmPago : Form
    {
        // Crear una instancia de la clase Pago
        private Pago pagoSeleccionado = new Pago();

        public FrmPago()
        {
            InitializeComponent();
        }

        private void dgPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evento CellContentClick
        }

        private void FrmPago_Load(object sender, EventArgs e)
        {
            // Cargar datos en los ComboBox al cargar el formulario
            CargarComboAlumnos();
            CargarComboClases();

            // Configurar el DataGridView
            ConfigurarDataGridView();

            // Llenar el DataGridView al cargar el formulario
            RefrescarDataGridView();
        }

        private void CargarComboAlumnos()
        {
            // Crear una instancia de la clase Alumno para obtener los datos
            Alumno alumno = new Alumno();

            // Obtener los datos directamente desde la base de datos
            DataTable dtAlumnos = alumno.ObtenerAlumnos();

            // Asignar la lista como origen de datos para el ComboBox
            cmbIDAlumno.DataSource = dtAlumnos;
            cmbIDAlumno.DisplayMember = "Nombre"; // Ajusta el campo a mostrar según tu esquema
            cmbIDAlumno.ValueMember = "id"; // Valor asociado a la selección
        }

        private void CargarComboClases()
        {
            // Crear una instancia de la clase Clase para obtener los datos
            Clase clase = new Clase();

            // Obtener los datos directamente desde la base de datos
            DataTable dtClases = clase.ObtenerClases();

            // Asignar la lista como origen de datos para el ComboBox
            cmbIDClase.DataSource = dtClases;
            cmbIDClase.DisplayMember = "Nombre_Clase"; // Ajusta el campo a mostrar según tu esquema
            cmbIDClase.ValueMember = "ID_Clase"; // Valor asociado a la selección
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener valores de los controles
            int idAlumno = Convert.ToInt32(cmbIDAlumno.SelectedValue);
            int idClase = Convert.ToInt32(cmbIDClase.SelectedValue);
            decimal monto = Convert.ToDecimal(TxtMonto.Text);
            DateTime fechaPago = dtpFechaPago.Value;
            string asunto = TxtAsunto.Text;

            // Asignar valores a la instancia de Pago
            pagoSeleccionado.ID_Alumno = idAlumno;
            pagoSeleccionado.ID_Clase = idClase;
            pagoSeleccionado.Monto = monto;
            pagoSeleccionado.Fecha_de_Pago = fechaPago;
            pagoSeleccionado.Asunto = asunto;

            // Llamar al método Agregar de la clase Pago
            bool resultado = pagoSeleccionado.Agregar();

            // Manejar el resultado
            if (resultado)
            {
                MessageBox.Show("Pago agregado correctamente.");
                RefrescarDataGridView();
            }
            else
            {
                MessageBox.Show("Error al agregar el pago.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dgPagos.SelectedRows.Count > 0)
            {
                // Obtener el ID del pago seleccionado en el DataGridView
                int idPago = Convert.ToInt32(dgPagos.SelectedRows[0].Cells["ID_Pago"].Value);

                // Crear una nueva instancia de Pago
                Pago pagoAEliminar = new Pago { ID_Pago = idPago };

                // Llamar al método Eliminar de la clase Pago
                bool resultado = pagoAEliminar.Eliminar();

                // Manejar el resultado
                if (resultado)
                {
                    MessageBox.Show("Pago eliminado correctamente.");
                    RefrescarDataGridView();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el pago.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un pago para eliminar.");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dgPagos.SelectedRows.Count > 0)
            {
                // Obtener valores de los controles y la fila seleccionada en el DataGridView
                int idPago = Convert.ToInt32(dgPagos.SelectedRows[0].Cells["ID_Pago"].Value);
                int idAlumno = Convert.ToInt32(cmbIDAlumno.SelectedValue);
                int idClase = Convert.ToInt32(cmbIDClase.SelectedValue);
                decimal monto = Convert.ToDecimal(TxtMonto.Text);
                DateTime fechaPago = dtpFechaPago.Value;
                string asunto = TxtAsunto.Text;

                // Asignar valores a la instancia de Pago
                pagoSeleccionado.ID_Pago = idPago;
                pagoSeleccionado.ID_Alumno = idAlumno;
                pagoSeleccionado.ID_Clase = idClase;
                pagoSeleccionado.Monto = monto;
                pagoSeleccionado.Fecha_de_Pago = fechaPago;
                pagoSeleccionado.Asunto = asunto;

                // Llamar al método Actualizar de la clase Pago
                bool resultado = pagoSeleccionado.Actualizar();

                // Manejar el resultado
                if (resultado)
                {
                    MessageBox.Show("Pago actualizado correctamente.");
                    RefrescarDataGridView();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el pago.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un pago para actualizar.");
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            // Refrescar el DataGridView llamando al método ListarPagos
            RefrescarDataGridView();
        }

        private void RefrescarDataGridView()
        {
            // Crear una instancia de la clase Pago para obtener los datos
            Pago pago = new Pago();

            // Asignar el origen de datos del DataGridView al DataTable devuelto por ListarPagos
            dgPagos.DataSource = pago.ListarPagos();
        }

        private void ConfigurarDataGridView()
        {
            // Configurar el DataGridView para que sea de solo lectura
            dgPagos.ReadOnly = true;

            // Configurar el modo de selección a celdas
            dgPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Agregar columnas al DataGridView según tus necesidades
            dgPagos.Columns["ID_Pago"].DataPropertyName = "ID_Pago";
            dgPagos.Columns["ID_Alumno"].DataPropertyName = "ID_Alumno";
            dgPagos.Columns["ID_Clase"].DataPropertyName = "ID_Clase";
            dgPagos.Columns["Monto"].DataPropertyName = "Monto";
            dgPagos.Columns["Fecha_de_Pago"].DataPropertyName = "Fecha_de_Pago";
            dgPagos.Columns["Asunto"].DataPropertyName = "Asunto";

            // Configurar otras propiedades según tus necesidades
            // dgPagos.AutoGenerateColumns = true;

            // ... Otros ajustes si son necesarios
        }

        // ... Otros métodos del formulario ...

        private void FrmPago_Load_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmPago_Load_2(object sender, EventArgs e)
        {

        }
    }
}

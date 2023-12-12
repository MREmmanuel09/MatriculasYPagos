using System;
using System.Data;
using System.Windows.Forms;
using Logica.Models;

namespace MatriculasYPagos.Formularios
{
    public partial class FrmMatricula : Form
    {
        // Crear una instancia de la clase Matricula
        private Matricula matriculaSeleccionada = new Matricula();

        public FrmMatricula()
        {
            InitializeComponent();
        }

        private void dgMatriculas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evento CellContentClick
        }

        private void FrmMatricula_Load(object sender, EventArgs e)
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
            cmbIDClase.DisplayMember = "Nombre"; // Ajusta el campo a mostrar según tu esquema
            cmbIDClase.ValueMember = "ID_Clase"; // Valor asociado a la selección
        }

        // ... Otros métodos del formulario ...

        

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener valores de los controles
            int idAlumno = Convert.ToInt32(cmbIDAlumno.SelectedValue);
            int idClase = Convert.ToInt32(cmbIDClase.SelectedValue);
            DateTime fechaMatricula = dtpFechaMatricula.Value;

            // Asignar valores a la instancia de Matricula
            matriculaSeleccionada.ID_Alumno = idAlumno;
            matriculaSeleccionada.ID_Clase = idClase;
            matriculaSeleccionada.Fecha_Matricula = fechaMatricula;

            // Llamar al método Agregar de la clase Matricula
            bool resultado = matriculaSeleccionada.Agregar();

            // Manejar el resultado
            if (resultado)
            {
                MessageBox.Show("Matrícula agregada correctamente.");
                RefrescarDataGridView();
            }
            else
            {
                MessageBox.Show("Error al agregar la matrícula.");
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dgMatriculas.SelectedRows.Count > 0)
            {
                // Obtener el ID de la matrícula seleccionada en el DataGridView
                int idMatricula = Convert.ToInt32(dgMatriculas.SelectedRows[0].Cells["ID_Matricula"].Value);

                // Crear una nueva instancia de Matricula
                Matricula matriculaAEliminar = new Matricula { ID_Matricula = idMatricula };

                // Llamar al método Eliminar de la clase Matricula
                bool resultado = matriculaAEliminar.Eliminar();

                // Manejar el resultado
                if (resultado)
                {
                    MessageBox.Show("Matrícula eliminada correctamente.");
                    RefrescarDataGridView();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la matrícula.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una matrícula para eliminar.");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dgMatriculas.SelectedRows.Count > 0)
            {
                // Obtener valores de los controles y la fila seleccionada en el DataGridView
                int idMatricula = Convert.ToInt32(dgMatriculas.SelectedRows[0].Cells["ID_Matricula"].Value);
                int idAlumno = Convert.ToInt32(cmbIDAlumno.SelectedValue);
                int idClase = Convert.ToInt32(cmbIDClase.SelectedValue);
                DateTime fechaMatricula = dtpFechaMatricula.Value;

                // Asignar valores a la instancia de Matricula
                matriculaSeleccionada.ID_Matricula = idMatricula;
                matriculaSeleccionada.ID_Alumno = idAlumno;
                matriculaSeleccionada.ID_Clase = idClase;
                matriculaSeleccionada.Fecha_Matricula = fechaMatricula;

                // Llamar al método Actualizar de la clase Matricula
                bool resultado = matriculaSeleccionada.Actualizar();

                // Manejar el resultado
                if (resultado)
                {
                    MessageBox.Show("Matrícula actualizada correctamente.");
                    RefrescarDataGridView();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la matrícula.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una matrícula para actualizar.");
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            // Refrescar el DataGridView llamando al método ListarMatriculas
            RefrescarDataGridView();
        }

        private void RefrescarDataGridView()
        {
            // Crear una instancia de la clase Matricula para obtener los datos
            Matricula matricula = new Matricula();

            // Asignar el origen de datos del DataGridView al DataTable devuelto por ListarMatriculas
            dgMatriculas.DataSource = matricula.ListarMatriculas();
        }


        private void ConfigurarDataGridView()
        {
            // Configurar el DataGridView para que sea de solo lectura
            dgMatriculas.ReadOnly = true;

            // Configurar el modo de selección a celdas
            dgMatriculas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    
            // Agregar columnas al DataGridView según tus necesidades
            dgMatriculas.Columns["ID_Matricula"].DataPropertyName = "ID_Matricula";
            dgMatriculas.Columns["ID_Alumno"].DataPropertyName = "ID_Alumno";
            dgMatriculas.Columns["ID_Clase"].DataPropertyName = "ID_Clase";
            dgMatriculas.Columns["Fecha_Matricula"].DataPropertyName = "Fecha_Matricula";
            

            // Configurar otras propiedades según tus necesidades
            // dgMatriculas.AutoGenerateColumns = true;

            // ... Otros ajustes si son necesarios
        }


        private void FrmMatricula_Load_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
    }
}


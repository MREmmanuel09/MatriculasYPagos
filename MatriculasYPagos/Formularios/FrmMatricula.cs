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
            try
            {
                Alumno alumno = new Alumno();
                DataTable dtAlumnos = alumno.ObtenerAlumnos();

                cmbIDAlumno.DataSource = dtAlumnos;
                cmbIDAlumno.DisplayMember = "Nombre";
                cmbIDAlumno.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los alumnos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboClases()
        {
            try
            {
                Clase clase = new Clase();
                DataTable dtClases = clase.ObtenerClases();

                cmbIDClase.DataSource = dtClases;
                cmbIDClase.DisplayMember = "Nombre";
                cmbIDClase.ValueMember = "ID_Clase";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las clases: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dgMatriculas.SelectedRows.Count > 0)
            {
                // Obtener los valores de la fila seleccionada
                int idMatricula = Convert.ToInt32(dgMatriculas.SelectedRows[0].Cells["ID_Matricula"].Value);
                int idAlumno = Convert.ToInt32(dgMatriculas.SelectedRows[0].Cells["ID_Alumno"].Value);
                int idClase = Convert.ToInt32(dgMatriculas.SelectedRows[0].Cells["ID_Clase"].Value);

                // Imprimir los valores para verificar en la consola de salida
                Console.WriteLine($"ID_Matricula: {idMatricula}, ID_Alumno: {idAlumno}, ID_Clase: {idClase}");

                // Verificar si cmbIDAlumno tiene elementos seleccionables
                if (cmbIDAlumno.Items.Count > 0)
                {
                    // Verificar si el valor de idAlumno está en la lista
                    if (cmbIDAlumno.Items.Contains(idAlumno))
                    {
                        cmbIDAlumno.SelectedValue = idAlumno;
                    }
                    else
                    {
                        Console.WriteLine($"El valor {idAlumno} no está en la lista de cmbIDAlumno.");
                    }
                }
                else
                {
                    Console.WriteLine("El ComboBox cmbIDAlumno no tiene elementos seleccionables.");
                }

                // Haz lo mismo para cmbIDClase
                if (cmbIDClase.Items.Count > 0)
                {
                    // Verificar si el valor de idClase está en la lista
                    if (cmbIDClase.Items.Contains(idClase))
                    {
                        cmbIDClase.SelectedValue = idClase;
                    }
                    else
                    {
                        Console.WriteLine($"El valor {idClase} no está en la lista de cmbIDClase.");
                    }
                }
                else
                {
                    Console.WriteLine("El ComboBox cmbIDClase no tiene elementos seleccionables.");
                }

                // Asegurarte de almacenar el ID de matrícula seleccionado para su posterior actualización
                matriculaSeleccionada.ID_Matricula = idMatricula;
            }
            else
            {
                MessageBox.Show("Selecciona una fila antes de intentar actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener valores de los controles del formulario
            int idAlumno = Convert.ToInt32(cmbIDAlumno.SelectedValue);
            int idClase = Convert.ToInt32(cmbIDClase.SelectedValue);
            DateTime fechaMatricula = DateTime.Now;  // Puedes ajustar esto según tu lógica

            // Crear una nueva instancia de MatriculaInfo y establecer los valores
            Matricula.MatriculaInfo nuevaMatricula = new Matricula.MatriculaInfo()
            {
                ID_Alumno = idAlumno,
                ID_Clase = idClase,
                Fecha_Matricula = fechaMatricula
            };

            // Llamar al método Agregar de MatriculaInfo
            if (nuevaMatricula.Agregar())
            {
                // Refrescar el DataGridView
                RefrescarDataGridView();

                // Limpiar controles después de agregar
                LimpiarControles();

                MessageBox.Show("Matrícula agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al agregar la matrícula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dgMatriculas.SelectedRows.Count > 0)
            {
                // Obtener el ID de matrícula de la fila seleccionada
                int idMatricula = Convert.ToInt32(dgMatriculas.SelectedRows[0].Cells["ID_Matricula"].Value);

                // Crear una nueva instancia de MatriculaInfo y establecer el ID de matrícula
                Matricula.MatriculaInfo matriculaEliminar = new Matricula.MatriculaInfo()
                {
                    ID_Matricula = idMatricula
                };

                // Llamar al método Eliminar de MatriculaInfo
                if (matriculaEliminar.Eliminar())
                {
                    // Refrescar el DataGridView
                    RefrescarDataGridView();

                    // Limpiar controles después de eliminar
                    LimpiarControles();

                    MessageBox.Show("Matrícula eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al eliminar la matrícula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila antes de intentar eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LimpiarControles()
        {
            // Limpiar los controles del formulario después de agregar o eliminar
            cmbIDAlumno.SelectedIndex = -1;
            cmbIDClase.SelectedIndex = -1;
            // Limpiar otros controles si es necesario
            matriculaSeleccionada.ID_Matricula = 0;  // Reiniciar el ID seleccionado
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

        private void FrmMatricula_Load_2(object sender, EventArgs e)
        {

        }

    }
}


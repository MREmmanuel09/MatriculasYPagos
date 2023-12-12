using Logica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

// Declaraciones de nivel superior

public class Conexion
{
    private SqlConnection connection;
    public List<SqlParameter> ListaDeParametros { get; set; }

    public Conexion(string cadenaDeConexion)
    {
        connection = new SqlConnection(cadenaDeConexion);
        ListaDeParametros = new List<SqlParameter>();
    }

    public SqlConnection ObtenerConexion()
    {
        try
        {
            SqlConnection conexion = new SqlConnection(connection.ConnectionString);
            // No es necesario abrir la conexión aquí, se abrirá cuando se ejecute el comando
            return conexion;
        }
        catch (Exception ex)
        {
            // Manejar errores de conexión
            Console.WriteLine("Error de conexión: " + ex.Message);
            return null;
        }
    }

    public void CerrarConexion(SqlConnection conexion)
    {
        try
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
        catch (Exception ex)
        {
            // Manejar errores al cerrar la conexión
            Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
        }
    }

    public DataTable EjecutarSELECT(string storedProcedure)
    {
        DataTable dataTable = new DataTable();

        using (SqlCommand command = new SqlCommand(storedProcedure, connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(ListaDeParametros.ToArray());

            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(dataTable);
            }
        }

        return dataTable;
    }

    public int EjecutarDML(string storedProcedure)
    {
        int rowsAffected = 0;

        using (SqlCommand command = new SqlCommand(storedProcedure, connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(ListaDeParametros.ToArray());

            connection.Open();
            rowsAffected = command.ExecuteNonQuery();
            connection.Close();
        }

        return rowsAffected;
    }
}

public class Alumno
{
    // ... (propiedades y otros métodos)

    // Método para obtener datos de alumnos desde la base de datos
    public DataTable ObtenerAlumnos()
    {
        DataTable dataTable = new DataTable();

        Conexion conexion = new Conexion("Server=PCEMMANUEL\\SQLEXPRESS01;Database=PR;Integrated Security=True;");

        using (SqlConnection connection = conexion.ObtenerConexion())
        {
            using (SqlCommand command = new SqlCommand("SELECT id, nombre FROM alumnos", connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
        }

        return dataTable;
    }
}

public class Clase
{
    // ... (propiedades y otros métodos)

    // Método para obtener datos de clases desde la base de datos
    public DataTable ObtenerClases()
    {
        DataTable dataTable = new DataTable();

        Conexion conexion = new Conexion("Server=PCEMMANUEL\\SQLEXPRESS01;Database=PR;Integrated Security=True;");

        using (SqlConnection connection = conexion.ObtenerConexion())
        {
            using (SqlCommand command = new SqlCommand("SELECT ID_Clase, Nombre_Clase FROM Clases", connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
        }

        return dataTable;
    }
}

public class Matricula
{
    public int ID_Matricula { get; set; }
    public int ID_Alumno { get; set; }
    public int ID_Clase { get; set; }
    public DateTime Fecha_Matricula { get; set; }

    public class MatriculaInfo
    {
        // Propiedades de la matrícula
        public int ID_Matricula { get; set; }
        public int ID_Alumno { get; set; }
        public int ID_Clase { get; set; }
        public DateTime Fecha_Matricula { get; set; }

        public bool Agregar()
        {
            bool resultado = false;

            Conexion MiCcn = new Conexion("Server=PCEMMANUEL\\SQLEXPRESS01;Database=PR;Integrated Security=True;");

            MiCcn.ListaDeParametros.Add(new SqlParameter("@ID_Alumno", this.ID_Alumno));
            MiCcn.ListaDeParametros.Add(new SqlParameter("@ID_Clase", this.ID_Clase));
            MiCcn.ListaDeParametros.Add(new SqlParameter("@Fecha_Matricula", this.Fecha_Matricula));

            int ejecutarDMLResultado = MiCcn.EjecutarDML("SPMatriculaAgregar");

            if (ejecutarDMLResultado > 0)
            {
                resultado = true;
            }

            return resultado;
        }

        public bool Eliminar()
        {
            bool resultado = false;

            Conexion MiCnn = new Conexion("Server=PCEMMANUEL\\SQLEXPRESS01;Database=PR;Integrated Security=True;");

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID_Matricula", this.ID_Matricula));

            int ejecutarDMLResultado = MiCnn.EjecutarDML("SPMatriculaEliminar");

            if (ejecutarDMLResultado > 0)
            {
                resultado = true;
            }

            return resultado;
        }

        public bool Actualizar()
        {
            bool resultado = false;

            Conexion MiCnn = new Conexion("Server=PCEMMANUEL\\SQLEXPRESS01;Database=PR;Integrated Security=True;");

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID_Matricula", this.ID_Matricula));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID_Alumno", this.ID_Alumno));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID_Clase", this.ID_Clase));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Fecha_Matricula", this.Fecha_Matricula));

            int ejecutarDMLResultado = MiCnn.EjecutarDML("SPMatriculaActualizar");

            if (ejecutarDMLResultado > 0)
            {
                resultado = true;
            }

            return resultado;
        }
    }

    public DataTable ListarMatriculas()
    {
        DataTable R = new DataTable();

        Conexion MiCnn = new Conexion("Server=PCEMMANUEL\\SQLEXPRESS01;Database=PR;Integrated Security=True;");

        // Limpiar cualquier parámetro anterior
        MiCnn.ListaDeParametros.Clear();

        // Imprimir la consulta SQL directamente
        Console.WriteLine("Consulta SQL: SELECT * FROM matriculas");

        R = MiCnn.EjecutarSELECT("SPMatriculaListar");
        return R;
    }

    public MatriculaInfo ConsultarPorID(int IDMatricula)
    {
        MatriculaInfo R = new MatriculaInfo();

        Conexion MyCnn = new Conexion("Server=PCEMMANUEL\\SQLEXPRESS01;Database=PR;Integrated Security=True;");

        MyCnn.ListaDeParametros.Add(new SqlParameter("@ID_Matricula", IDMatricula));

        DataTable DatosMatricula = MyCnn.EjecutarSELECT("SPMatriculaConsultarPorID");

        if (DatosMatricula != null && DatosMatricula.Rows.Count > 0)
        {
            DataRow MiFila = DatosMatricula.Rows[0];

            R.ID_Matricula = Convert.ToInt32(MiFila["ID_Matricula"]);
            R.ID_Alumno = Convert.ToInt32(MiFila["ID_Alumno"]);
            R.ID_Clase = Convert.ToInt32(MiFila["ID_Clase"]);
            R.Fecha_Matricula = Convert.ToDateTime(MiFila["Fecha_Matricula"]);
        }

        return R;
    }

    // Evento Load del formulario
}

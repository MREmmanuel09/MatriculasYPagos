using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Conexion
    {
        private readonly string cadenaConexion;

        // Lista de parámetros para usar en consultas
        public List<SqlParameter> ListaDeParametros { get; set; }

        public Conexion(string connectionString)
        {
            cadenaConexion = connectionString;
            ListaDeParametros = new List<SqlParameter>();
        }
        
        public SqlConnection ObtenerConexion()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
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

        public int EjecutarDML(string storedProcedure)
        {
            int resultado = 0;

            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                using (SqlCommand comando = new SqlCommand(storedProcedure, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros a la consulta, si es necesario
                    foreach (SqlParameter parametro in ListaDeParametros)
                    {
                        comando.Parameters.Add(parametro);
                    }

                    resultado = comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejar errores al ejecutar DML
                Console.WriteLine("Error al ejecutar DML: " + ex.Message);
            }

            return resultado;
        }

        public DataTable EjecutarSELECT(string storedProcedure)
        {
            DataTable resultado = new DataTable();

            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                using (SqlCommand comando = new SqlCommand(storedProcedure, conexion))
                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros a la consulta, si es necesario
                    foreach (SqlParameter parametro in ListaDeParametros)
                    {
                        comando.Parameters.Add(parametro);
                    }

                    adaptador.Fill(resultado);
                }
            }
            catch (Exception ex)
            {
                // Manejar errores al ejecutar SELECT
                Console.WriteLine("Error al ejecutar SELECT: " + ex.Message);
            }

            return resultado;
        }
    }
}

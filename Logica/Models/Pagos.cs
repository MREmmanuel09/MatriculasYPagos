using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Logica.Models
{
    public class Pagos
    {
        public int ID_Pago { get; set; }
        public int ID_Alumno { get; set; }
        public int ID_Clase { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha_de_Pago { get; set; }
        public string Asunto { get; set; }


        public bool AgregarPago(Pagos pago)
        {
            bool resultado = false;

            Conexion MiCnn = new Conexion("Server=PCEMMANUEL\\SQLEXPRESS01;Database=PR;Integrated Security=True;");

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID_Alumno", pago.ID_Alumno));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID_Clase", pago.ID_Clase));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Monto", pago.Monto));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Fecha_de_Pago", pago.Fecha_de_Pago));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Asunto", pago.Asunto));

            int resultadoDML = MiCnn.EjecutarDML("SPPagoAgregar");

            if (resultadoDML > 0)
                resultado = true;

            return resultado;
        }

        // Método para eliminar un pago
        public bool EliminarPago(int idPago)
        {
            bool resultado = false;

            Conexion MiCnn = new Conexion("Server=PCEMMANUEL\\SQLEXPRESS01;Database=PR;Integrated Security=True;");

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID_Pago", idPago));

            int resultadoDML = MiCnn.EjecutarDML("SPPagoEliminar");

            if (resultadoDML > 0)
                resultado = true;

            return resultado;
        }

        // Método para actualizar un pago
        public bool ActualizarPago(Pagos pago)
        {
            bool resultado = false;

            Conexion MiCnn = new Conexion("Server=PCEMMANUEL\\SQLEXPRESS01;Database=PR;Integrated Security=True;");

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID_Pago", pago.ID_Pago));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID_Alumno", pago.ID_Alumno));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID_Clase", pago.ID_Clase));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Monto", pago.Monto));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Fecha_de_Pago", pago.Fecha_de_Pago));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Asunto", pago.Asunto));

            int resultadoDML = MiCnn.EjecutarDML("SPPagoActualizar");

            if (resultadoDML > 0)
                resultado = true;

            return resultado;
        }

        // Método para listar todos los pagos
        public DataTable ListarPagos()
        {
            DataTable resultado = new DataTable();

            Conexion MiCnn = new Conexion("Server=PCEMMANUEL\\SQLEXPRESS01;Database=PR;Integrated Security=True;");

            // Limpiar cualquier parámetro anterior
            MiCnn.ListaDeParametros.Clear();

            resultado = MiCnn.EjecutarSELECT("SPPagoListar");

            return resultado;
        }

        // Método para consultar un pago por ID
        public Pagos ConsultarPagoPorID(int idPago)
        {
            Pagos resultado = new Pagos();

            Conexion MiCnn = new Conexion("Server=PCEMMANUEL\\SQLEXPRESS01;Database=PR;Integrated Security=True;");

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID_Pago", idPago));

            DataTable DatosPago = MiCnn.EjecutarSELECT("SPPagoConsultarPorID");

            if (DatosPago != null && DatosPago.Rows.Count > 0)
            {
                DataRow MiFila = DatosPago.Rows[0];

                resultado.ID_Pago = Convert.ToInt32(MiFila["ID_Pago"]);
                resultado.ID_Alumno = Convert.ToInt32(MiFila["ID_Alumno"]);
                resultado.ID_Clase = Convert.ToInt32(MiFila["ID_Clase"]);
                resultado.Monto = Convert.ToDecimal(MiFila["Monto"]);
                resultado.Fecha_de_Pago = Convert.ToDateTime(MiFila["Fecha_de_Pago"]);
                resultado.Asunto = MiFila["Asunto"].ToString();
            }

            return resultado;
        }
    }
}

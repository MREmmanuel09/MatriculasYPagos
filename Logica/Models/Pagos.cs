using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Logica.Models
{
    public class Pagos
    {
        public int ID_Pago { get; set; }
        public int ID_Alumno { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha_Pago { get; set; }

        public bool Agregar()
        {
            bool R = false;

            Conexion MiCcn = new Conexion("Server=PCEMMANUEL\\SQLEXPRESS01; Database=PR; Integrated Security=true;");

            MiCcn.ListaDeParametros.Add(new SqlParameter("@ID_Alumno", this.ID_Alumno));
            MiCcn.ListaDeParametros.Add(new SqlParameter("@Monto", this.Monto));
            MiCcn.ListaDeParametros.Add(new SqlParameter("@Fecha_Pago", this.Fecha_Pago));

            int resultado = MiCcn.EjecutarDML("SPPagosAgregar");

            if (resultado > 0)
                R = true;

            return R;
        }

        public bool Eliminar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion("Server=PCEMMANUEL\\SQLEXPRESS01; Database=PR; Integrated Security=true;");

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID_Pago", this.ID_Pago));

            int resultado = MiCnn.EjecutarDML("SPPagosEliminar");

            if (resultado > 0)
                R = true;

            return R;
        }

        public bool Actualizar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion("Server=PCEMMANUEL\\SQLEXPRESS01; Database=PR; Integrated Security=true;");

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID_Pago", this.ID_Pago));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID_Alumno", this.ID_Alumno));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Monto", this.Monto));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Fecha_Pago", this.Fecha_Pago));

            int resultado = MiCnn.EjecutarDML("SPPagosActualizar");

            if (resultado > 0)
                R = true;

            return R;
        }

        public DataTable ListarPagos()
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion("Server=PCEMMANUEL\\SQLEXPRESS01; Database=PR; Integrated Security=true;");

            MiCnn.ListaDeParametros.Add(new SqlParameter("@VerPagos", true));

            R = MiCnn.EjecutarSELECT("SPPagosListar");
            return R;
        }

        public Pagos ConsultarPorID(int IDPago)
        {
            Pagos R = new Pagos();

            Conexion MyCnn = new Conexion("Server=PCEMMANUEL\\SQLEXPRESS01; Database=PR; Integrated Security=true;");

            MyCnn.ListaDeParametros.Add(new SqlParameter("@ID_Pago", IDPago));

            DataTable DatosPago = MyCnn.EjecutarSELECT("SPPagosConsultarPorID");

            if (DatosPago != null && DatosPago.Rows.Count > 0)
            {
                DataRow MiFila = DatosPago.Rows[0];

                R.ID_Pago = Convert.ToInt32(MiFila["ID_Pago"]);
                R.ID_Alumno = Convert.ToInt32(MiFila["ID_Alumno"]);
                R.Monto = Convert.ToDecimal(MiFila["Monto"]);
                R.Fecha_Pago = Convert.ToDateTime(MiFila["Fecha_Pago"]);
            }

            return R;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Constructo estatico, inicilaiza el string de conexion.
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;");
            comando = new SqlCommand();
        }

        /// <summary>
        /// Inserta en la base de datos los atributos de un objeto Paquete y el nombre del alumno
        /// </summary>
        /// <param name="p">Objeto Paquete</param>
        /// <returns>True si se insertan los datos</returns>
        public static bool insertar(Paquete p)
        {
            bool rta = true;

            try
            {
                string sql = "INSERT INTO [correo-sp-2017].[dbo].[Paquetes] (direccionEntrega, trackingID, alumno) VALUES(";
                sql = sql + "'" + p.DireccionEntrega.ToString() + "','" + p.TrackingID.ToString() + "','" + "Sergio Dominguez" + "')";

                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                comando.Connection = conexion;

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }


            } catch (Exception e) 
            {
                rta = false;
                throw e;

            } finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return rta;
        }

    }
}

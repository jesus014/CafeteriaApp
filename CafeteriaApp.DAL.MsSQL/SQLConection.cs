using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace CafeteriaApp.DAL.MsSQL
{
    public class SQLConection
    {
        private readonly SqlConnection conexion;
        public string Error { get; private set; }
        public SQLConection()
        {
            conexion = new SqlConnection(@"Data Source=localhost;Initial Catalog=CafeteriaApp;Integrated Security=True");
            Conectar();
        }

        private bool Conectar()
        {
            try
            {
                conexion.Open();
                Error = "";
               return true;
            }
            catch (SqlException ex)
            {

                Error=ex.Message;
                return false;
            }      
        }
        /// <summary>
        /// ejecuta un comando sql sobre la base de datos (insert update delete)
        /// </summary>
        /// <param name="command"> comando sql a ejecutar</param>
        /// <returns>regresa el numero de filas afectadas, -1 cuando a ocurrido un error</returns>

        public int Comando(string command)
        {
            try
            {
                Debug.Print($"===>{command}");
                SqlCommand cmd = new SqlCommand(command, conexion);
                int r=cmd.ExecuteNonQuery();
                Error = "";
                return r;
            }
            catch (Exception ex)
            {

                Error = ex.Message;
                return -1 ;
            }
        }

        /// <summary>
        /// ejecuta una conuslta sql sobre la base de datos en este caso un select
        /// </summary>
        /// <param name="consulta">consulta sql</param>
        /// <returns>registros resultantes de la consulta</returns>

        public SqlDataReader Consulta(string consulta)
        {
            try
            {
                Debug.Print($"{consulta}");
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                SqlDataReader dataReader = cmd.ExecuteReader();
                Error = "";
                return dataReader;
            }
            catch (Exception ex)
            {

                Error = ex.Message;
                return null;
            }
        }

        ~SQLConection()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    conexion.Close();

                }
                catch (Exception ex)
                {

                    Error=ex.Message;
                }
            }
        }
    }
}

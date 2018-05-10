using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Data
{
    public class DataBase
    {
        // Variable de conexión a base de datos
        private SqlConnection cnn { get; set; }
        // Variable de la cadena de conexión a base de datos
        private static string strCnn = ConfigurationManager.ConnectionStrings["dbConnect"].ConnectionString;

        /// <summary>
        /// Conectar a la Base de Datos
        /// </summary>
        /// <returns></returns>
        private bool Conectar() {
            try
            {
                cnn = new SqlConnection(strCnn);
                cnn.Open();

                if (cnn.State == ConnectionState.Open)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Desconectar de la base de datos
        /// </summary>
        private void Desconectar() {
            try
            {
                if (cnn != null) {
                    if (cnn.State == ConnectionState.Open) {
                        cnn.Close();
                    }
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Agregar parámetros al command
        /// </summary>
        /// <param name="parameter">Parametros a agregar</param>
        /// <param name="cmd">Command pasado por referencia</param>
        private void addParameter(SqlParameter[] parameter, ref SqlCommand cmd) {
            try
            {
                cmd.Parameters.AddRange(parameter);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Ejecutar una consulta y retornar el valor de una celda
        /// </summary>
        /// <param name="query">Consulta a ejecutar</param>
        /// <param name="parameter">Parámetros de la consulta, por defecto null</param>
        /// <param name="cmdType">Tipo de comando, SP, Texto, por defecto SP</param>
        /// <param name="timeOut">TimeOut para la ejecución, por defecto 60 seg</param>
        /// <returns></returns>
        public object executeScalar(string query, SqlParameter[] parameter = null, CommandType cmdType = CommandType.StoredProcedure, int timeOut = 60) {
            try
            {
                object response = new object();

                /* Primero establecer conexión a la Base de Datos */
                if (this.Conectar())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandText = query;
                    cmd.CommandType = cmdType;
                    cmd.CommandTimeout = timeOut;

                    /* Agregar parámetros al command */
                    if (parameter != null)
                    {
                        this.addParameter(parameter, ref cmd);
                    }

                    response = cmd.ExecuteScalar();
                }
                else {
                    response = "No fue posible establecer conexión con la base de datos";
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                this.Desconectar();
            }
        }

        /// <summary>
        /// Ejecutar una consulta y retornar el número de filas afectadas
        /// </summary>
        /// <param name="query">Consulta a ejecutar</param>
        /// <param name="parameter">Parámetros de la consulta, por defecto null</param>
        /// <param name="cmdType">Tipo de comando, SP, Texto, por defecto SP</param>
        /// <param name="timeOut">TimeOut para la ejecución, por defecto 60 seg</param>
        /// <returns></returns>
        public int executeNonQuery(string query, SqlParameter[] parameter = null, CommandType cmdType = CommandType.StoredProcedure, int timeOut = 60)
        {
            try
            {
                int response = -1;

                /* Primero establecer conexión a la Base de Datos */
                if (this.Conectar())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandText = query;
                    cmd.CommandType = cmdType;
                    cmd.CommandTimeout = timeOut;

                    /* Agregar parámetros al command */
                    if (parameter != null)
                    {
                        this.addParameter(parameter, ref cmd);
                    }

                    response = cmd.ExecuteNonQuery();
                }
                
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Desconectar();
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Modelo
{
    public class ClaseDatos
    {

        #region Declaración de atributos
        private SqlConnection sqlConnection = null; //Permite realizar una conexión a una BD.
        private SqlCommand sqlCommand = null;   //Permite referenciar los procedimientos almacenados.
        private SqlDataAdapter sqlDataAdapter = null; //Permite listar información
        private DataTable dataTable = null; //Parecido al dataAdapter - usado para la gestión de datos en memoria
        private string cadenaConexion = string.Empty; //Se almacena la conexión a la base de datos de origen de los datos.
        #endregion

        #region Constructor la clase ClaseDatos
        //Se usa el atributo cadenaConexion para indicar hacia
        //donde se realizará la comunicación con la base de datos
        public ClaseDatos() {
            this.cadenaConexion = @"Data Source=DESKTOP-H0N5B2Q\SQLEXPRESS;Initial Catalog=bdejemplomvc1;Integrated Security=True";
        }
        #endregion

        #region Método de acción (Insert, Update y Delete)
        public void ejecutarSP(SqlParameter[] sqlParameter, string procedimientoAlmacenado) {
            try
            {
                sqlConnection = new SqlConnection(this.cadenaConexion);
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = procedimientoAlmacenado;
                sqlCommand.Parameters.AddRange(sqlParameter);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally {
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }
        }
        #endregion

    }
}

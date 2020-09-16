using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using System.Data;
using System.Data.SqlClient;

namespace Controlador
{
    public class PersonasDAO
    {
        ClaseDatos claseDatos = null;
        PersonasDTO personasDTO = null;
        DataTable dataTable = null;

        public PersonasDAO(PersonasDTO personasDTO) {
            this.personasDTO = personasDTO;
        }

        public DataTable ListarPersonas() {

            dataTable = new DataTable();

            try
            {
                claseDatos = new ClaseDatos();
                SqlParameter[] parametros = null;

                if (this.personasDTO == null)
                {

                    parametros = new SqlParameter[3];

                    parametros[0] = new SqlParameter();
                    parametros[0].ParameterName = "@cedula";
                    parametros[0].SqlDbType = SqlDbType.Int;
                    parametros[0].SqlValue = personasDTO.getCedula();

                    parametros[1] = new SqlParameter();
                    parametros[1].ParameterName = "@nombre";
                    parametros[1].SqlDbType = SqlDbType.VarChar;
                    parametros[1].Size = 50;
                    parametros[1].SqlValue = personasDTO.getNombre();

                    parametros[2] = new SqlParameter();
                    parametros[2].ParameterName = "@edad";
                    parametros[2].SqlDbType = SqlDbType.TinyInt;
                    parametros[2].SqlValue = personasDTO.getEdad();

                }
                else {
                    parametros = null;
                }

                dataTable = claseDatos.retornaTabla(parametros, "sppersonas_listar");

            }
            catch (Exception exception) {
                throw new Exception(exception.Message);
            }

            return dataTable;

        }

    }
}

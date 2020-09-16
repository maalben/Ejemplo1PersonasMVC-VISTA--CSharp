using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controlador;

namespace Ejemplo1PersonasMVC_VISTA_
{
    public partial class Form1 : Form
    {

        PersonasDAO personasDAO = null;
        PersonasDTO personasDTO = null;
        DataTable dataTable = null;

        public Form1()
        {
            InitializeComponent();
            listarPersonas();
        }

        public void listarPersonas() {

            personasDTO = new PersonasDTO();
            personasDAO = new PersonasDAO(personasDTO);

            dataTable = new DataTable();
            dataTable = personasDAO.ListarPersonas();

            if (dataTable.Rows.Count > 0) {
                dtpersonas.DataSource = dataTable;
            } else {
                MessageBox.Show("No hay registros de Personas.");
            }

        }

    }
}

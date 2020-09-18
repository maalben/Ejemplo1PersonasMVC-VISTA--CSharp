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
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
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

        public void guardarPersona() {

            personasDTO = new PersonasDTO();
            personasDTO.setCedula(int.Parse(txtcedula.Text));
            personasDTO.setNombre(txtnombre.Text);
            personasDTO.setEdad(Byte.Parse(txtedad.Text));

            personasDAO = new PersonasDAO(personasDTO);

            personasDAO.guardarPersona();

            MessageBox.Show("Se ha guardado el registro");

        }

        private void limpiarCampos() {
            txtcedula.Text = String.Empty;
            txtnombre.Text = String.Empty;
            txtedad.Text = String.Empty;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            guardarPersona();
            listarPersonas();
            limpiarCampos();
        }

        private void eliminarPersona() {

            personasDTO = new PersonasDTO();
            personasDTO.setCedula(int.Parse(txtcedula.Text));
            personasDAO = new PersonasDAO(personasDTO);

            personasDAO.eliminarPersona();

            MessageBox.Show("Registro eliminado");
            limpiarCampos();

        }

        private void guardarCambiosPersonas() {

            personasDTO = new PersonasDTO();
            personasDTO.setCedula(int.Parse(txtcedula.Text));
            personasDTO.setNombre(txtnombre.Text);
            personasDTO.setEdad(Byte.Parse(txtedad.Text));

            personasDAO = new PersonasDAO(personasDTO);

            personasDAO.guardarCambiosPersonas();

            MessageBox.Show("Registro actualizado");

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            eliminarPersona();
            listarPersonas();

            txtcedula.Enabled = true;
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
        }

        private void dtpersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcedula.Text = dtpersonas.Rows[dtpersonas.CurrentRow.Index].Cells[0].Value.ToString();
            txtnombre.Text = dtpersonas.Rows[dtpersonas.CurrentRow.Index].Cells[1].Value.ToString();
            txtedad.Text = dtpersonas.Rows[dtpersonas.CurrentRow.Index].Cells[2].Value.ToString();

            txtcedula.Enabled = false;
            btnguardar.Enabled = false;
            btnguardarcambios.Enabled = true;
            btneliminar.Enabled = true;

        }

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {
            guardarCambiosPersonas();
            listarPersonas();
            limpiarCampos();

            txtcedula.Enabled = true;
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
        }
    }
}

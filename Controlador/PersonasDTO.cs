using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controlador
{
    public class PersonasDTO
    {

        private int cedula;
        private string nombre;
        private byte edad;

        public void setCedula(int valor) {
            this.cedula = valor;
        }

        public int getCedula() {
            return this.cedula;
        }

        public void setNombre(string valor)
        {
            this.nombre = valor;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public void setEdad(byte valor)
        {
            this.edad = valor;
        }

        public byte getEdad()
        {
            return this.edad;
        }

    }
}

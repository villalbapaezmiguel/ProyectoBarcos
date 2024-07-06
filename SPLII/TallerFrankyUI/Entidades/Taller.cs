using Parcial.WindowsForm.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial.WindowsForm.Entidades
{
    public class Taller
    {
        private List<Barco> barcos;

        public Taller() 
        {
            this.Barcos = new List<Barco>();
        }

        public List<Barco> Barcos { get => barcos; set => barcos = value; }

        public bool EncontrarBarco(Barco auxBarco)
        {
            if(auxBarco is Marina)
            {
                foreach (Marina barco in this.Barcos)
                {
                    if (barco == auxBarco)
                    {
                        return true;
                    }
                }
            }
            if(auxBarco is Pirata)
            {
                foreach (Pirata barco in this.Barcos)
                {
                    if(barco == auxBarco)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IngresarBarco(Barco barco)
        {
            if(EncontrarBarco(barco) == false)
            {
                this.barcos.Add(barco);
                return true;
            }
            return false;
        }

        public bool Reparar(object auxTaller)
        {
            if(auxTaller is Taller)
            {
                foreach(Barco aux in  this.Barcos)
                {
                    if(aux.EstadoReparado == false)
                    {
                        aux.CalcularCosto();
                        DataBarcos.AgregarDB(aux);
                        aux.EstadoReparado = true;
                        return true;
                    }
                }
            }
            return false;
        }

    }
}

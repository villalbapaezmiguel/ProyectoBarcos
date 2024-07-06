using Parcial.WindowsForm.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.WindowsForm
{
    public abstract class Barco 
    {
        private int id;
        private float costo;
        private bool estadoReparado;
        private string nombre;
        private EOperacion operacion;
        private int tripulacion;

        public Barco()
        {
            
        }

        public Barco(int id, float costo, bool estadoReparado, string nombre, EOperacion operacion, int tripulacion)
        {
            this.id = id;
            this.costo = costo;
            this.estadoReparado = estadoReparado;
            this.nombre = nombre;
            this.operacion = operacion;
            this.tripulacion = tripulacion;
        }

        public float Costo { get => costo; set => costo = value; }
        public bool EstadoReparado { get => estadoReparado; set => estadoReparado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public EOperacion Operacion { get => operacion; set => operacion = value; }
        //public int Tripulacion { get => tripulacion; set => tripulacion = value; }
        public abstract int Tripulacion { get; set; }
        public int Id { get => id; set => id = value; }

        public static bool operator == (Barco a, Barco b)
        {
            return a.Nombre == b.Nombre;
        }
        public static bool operator != (Barco a, Barco b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("costo:" + this.costo);
            sb.AppendLine(" Estado reparacion: " + this.estadoReparado);
            sb.AppendLine("Nombre" + this.nombre);
            sb.AppendLine("Operacion" + this.operacion);
            sb.AppendLine("Tripulacion" + this.tripulacion);

            return sb.ToString();
        }

        public abstract void CalcularCosto();


    }
}

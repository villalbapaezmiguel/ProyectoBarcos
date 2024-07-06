using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace Parcial.WindowsForm
{
    public class Marina : Barco 
    {
        public override int Tripulacion
        {
            //Hola
            get
            {
                if (Tripulacion < 0)
                {
                    Random numero = new Random();
                    return numero.Next(30, 60);
                }

                return 0;
            }
            set
            {
                //Revisar por las dudas
                int numero = value;
                Tripulacion = numero;
            }
        }

        public override void CalcularCosto()
        {
            Random numero = new Random();
            Costo = numero.Next(5000, 25000);
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder(base.ToString());
            text.AppendLine($"Tripulacion Marina: {Tripulacion.ToString()}.");
            return text.ToString();
        }
    }
}

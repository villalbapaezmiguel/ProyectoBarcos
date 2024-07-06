using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.WindowsForm
{
    public class Pirata : Barco
    {


        public override int Tripulacion {
            
            get
            {
                if(Tripulacion < 0 )
                {
                    Random numero = new Random();
                    return numero.Next(10, 30);
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
            Costo =  numero.Next(2000, 12000);
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder(base.ToString());
            text.AppendLine($"Tripulacion Pirata: {Tripulacion.ToString()}.");
            return text.ToString();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoBatalla
{
    public enum ePalo
    {
        Corazones = 1,
        Diamantes = 2,
        Treboles = 3,
        Picas = 4
    }
    internal class Carta
    {
        private ePalo palo;
        private int numero;

        public ePalo Palo
        { 
            get { return palo;}
        }
        public int Numero
        { 
            get { return numero;}
        }

        public Carta()
        {
            
        }
        
        public Carta(ePalo palo, int numero)
        {
            this.palo = palo;
            this.numero = numero;
        }
        public override string ToString()
        {
            return $"{numero} de {palo}";
        }
    }
}
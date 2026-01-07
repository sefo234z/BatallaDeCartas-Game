using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoBatalla
{
    internal class Jugador
    {
        private List<Carta> _cartasJugador;
        private string _nombre;


        public String Nombre
        {
            get { return _nombre; }
        }

        public List<Carta> CartasJugador
        {
            get { return _cartasJugador; }
        }
        public Jugador()
        {
            
        }
        public Jugador(string nombre)
        {
            this._nombre = nombre;
            _cartasJugador = new List<Carta>();
        }

        
    }

}

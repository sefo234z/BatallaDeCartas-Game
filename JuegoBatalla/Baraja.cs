using JuegoBatalla;
using System;
using System.Collections.Generic;

namespace JuegoBatalla
{
    internal class Baraja
    {
        private List<Carta> cartas;
        private static Random random = new Random();

        public List<Carta> Cartas
        {
            get { return cartas; }
        }

        public Baraja()
        {
            cartas = new List<Carta>();

            foreach (ePalo palo in Enum.GetValues(typeof(ePalo)))
            {
                for (int numero = 1; numero <= 13; numero++)
                {
                    cartas.Add(new Carta(palo, numero));
                }                
            }
        }

        public List<Carta> Repartir(int cartasPorJugador)
        {
            List<Carta> mano = new List<Carta>();

            for (int i = 0; i < cartasPorJugador && cartas.Count > 0; i++)
            {
                mano.Add(cartas[0]);
                cartas.RemoveAt(0);
            }
            return mano;
        }
        public void Barajar()
        {
            for (int i = cartas.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Carta temp = cartas[i];
                cartas[i] = cartas[j];
                cartas[j] = temp;
            }
        }

        public override string ToString()
        {
            string resultado = "=== BARAJA ===\n";

            foreach (var carta in Cartas)
            {
                resultado += carta + "\n";
            }

            resultado += "Total cartas: " + Cartas.Count;
            return resultado;
        }

        /* public void MostrarBaraja()
         {
             foreach (var carta in cartas)
             {
                 Console.WriteLine(carta);
             }
         }*/
    }
}
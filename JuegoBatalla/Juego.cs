using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoBatalla
{
    internal class Juego
    {
        Dictionary<Jugador, Carta> cartasTablero = new Dictionary<Jugador, Carta>();
        Baraja baraja = new Baraja();
        List<Jugador> lJugadores = new List<Jugador>();
        public Juego()
        { 
        }
        
        public void CrearJugador(string nombre)
        {
            Jugador nuevoJugador = new Jugador(nombre);
            lJugadores.Add(nuevoJugador);
        }
        public void RepartirCartas()
        {
            baraja.Barajar();
            int cartasPorJugador = baraja.Cartas.Count / lJugadores.Count;

            foreach (var jugador in lJugadores)
            {
                List<Carta> cartasJugador = baraja.Repartir(cartasPorJugador);
                jugador.CartasJugador.AddRange(cartasJugador);
            }
            
        }
        public void MostrarCartasJugadores()
        {
            Console.WriteLine("=== CARTAS DE LOS JUGADORES ===");

            for (int i = 0; i < lJugadores.Count; i++)
            {
                Console.WriteLine($"\n--- {lJugadores[i].Nombre} ---");
                Console.WriteLine($"Total de cartas: {lJugadores[i].CartasJugador.Count}");

                for (int j = 0; j < lJugadores[i].CartasJugador.Count; j++)
                {
                    Carta carta = lJugadores[i].CartasJugador[j];
                    Console.WriteLine($"Carta {j + 1}: {carta}");
                }
            }
        }
        public void MostrarTotalCartas()
        {
            Console.WriteLine("=== CARTAS DE LOS JUGADORES ===");

            for (int i = 0; i < lJugadores.Count; i++)
            {
                Console.WriteLine($"\n--- {lJugadores[i].Nombre} ---");
                Console.WriteLine($"Total de cartas: {lJugadores[i].CartasJugador.Count}");
            }
        }
        public void TirarCartas()
        {
            cartasTablero = new Dictionary<Jugador,Carta>();
            for (int i = 0; i < lJugadores.Count; i++)
            {
                Carta carta = lJugadores[i].CartasJugador[0];
                Console.WriteLine(lJugadores[i].Nombre+": " + carta);
                lJugadores[i].CartasJugador.RemoveAt(0);
                cartasTablero[lJugadores[i]] = carta;
            }
            string ganador = CompararCartasTiradas(cartasTablero);
            Console.WriteLine("HA GANADO:" + ganador);
            AñadirCartasAlGanador(ganador);
            MostrarTotalCartas();
        }
        public string CompararCartasTiradas(Dictionary<Jugador, Carta> cartas)
        {
            if (cartas == null || cartas.Count == 0)
            {
                Console.WriteLine("No hay cartas para comparar");
                return null;
            }

            KeyValuePair<Jugador, Carta> cartaGanadora = cartas.First();

            foreach (var entrada in cartas)
            {
                if (EsCartaMayor(entrada.Value, cartaGanadora.Value))
                {
                    cartaGanadora = entrada;
                }
            }

            return cartaGanadora.Key.Nombre;
        }
        private bool EsCartaMayor(Carta carta1, Carta carta2)
        {
            if (carta1.Numero != carta2.Numero)
            {
                return carta1.Numero > carta2.Numero;
            }
            return (int)carta1.Palo > (int)carta2.Palo;
        }
        public void AñadirCartasAlGanador(string ganador)
        {
            Jugador jugadorGanador = cartasTablero.Keys
                .FirstOrDefault(j => j.Nombre == ganador);

            if (jugadorGanador != null)
            {
              jugadorGanador.CartasJugador.AddRange(cartasTablero.Values);  
               cartasTablero.Clear();
            }
            
        }
        public bool HayGanador()
        {
            foreach (var jugador in cartasTablero.Keys)
            {
                if (jugador == null || jugador.CartasJugador == null)
                {
                    Console.WriteLine("Jugador o lista de cartas inválida.");
                    continue;
                }

                if (jugador.CartasJugador.Count == 52)
                {
                    Console.WriteLine($"¡{jugador.Nombre} ha ganado el juego con las 52 cartas!");
                    return true;
                }
            }
            return false;
        }
    }





}

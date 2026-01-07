using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoBatalla
{
    internal class Program
    {
        static Juego juego = new Juego();

        //metodo to string para mostrar cartas de los jugadores dentro de baraja
        static void Main(string[] args)
        {
            CrearJugadores();
        }

        public static void CrearJugadores()
        {
            int totalJugadores = 0;

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Bienvenido al juego de la batalla!");
            Console.WriteLine("----------------------------------");
            do
            {
                Console.Write("Cuantos jugadores quereis jugar la partida: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out totalJugadores))
                {
                    if (totalJugadores > 1 && totalJugadores < 6)
                    {
                    }
                    else
                    {
                        Console.WriteLine("Dime un numero entre 2 y 5.");
                    }
                }
                else
                {
                    Console.WriteLine("Valor no valido, vuelve a introducirlo.");
                }

            } while (totalJugadores < 2 || totalJugadores > 5);
            for (int i = 0; i < totalJugadores; i++)
            {
                Console.Write($"Nombre del jugador {i + 1}:");
                string nombre = Console.ReadLine();
                juego.CrearJugador(nombre);
                
            }
            juego.RepartirCartas();
            int totalRondas = 0;
            Console.WriteLine("=== EMPIEZA LA PARTIDA ===");
            do
            {
               totalRondas++;
               Console.WriteLine("=== RONDA " + totalRondas + " ===");
               juego.TirarCartas();
               Console.ReadKey();
            } while (!juego.HayGanador());
            Console.ReadKey();




        }


    }
}

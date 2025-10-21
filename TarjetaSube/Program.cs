using System;
using TarjetaSube;

namespace TarjetaSube
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Tarjeta SUBE - Rosario ===\n");

            // Crear una tarjeta
            Tarjeta miTarjeta = new Tarjeta();
            Console.WriteLine($"Saldo inicial: ${miTarjeta.Saldo}");

            // Cargar saldo
            Console.WriteLine("\n--- Cargando saldo ---");
            if (miTarjeta.Cargar(5000))
            {
                Console.WriteLine($"✓ Carga exitosa de $5000");
                Console.WriteLine($"Saldo actual: ${miTarjeta.Saldo}");
            }

            // Intentar carga inválida
            Console.WriteLine("\n--- Intentando carga inválida ---");
            if (!miTarjeta.Cargar(1500))
            {
                Console.WriteLine("✗ Carga de $1500 rechazada (monto no permitido)");
            }

            // Crear un colectivo
            Colectivo colectivo = new Colectivo("K");
            Console.WriteLine($"\n--- Viajando en colectivo línea {colectivo.Linea} ---");

            // Realizar viajes
            for (int i = 1; i <= 3; i++)
            {
                Boleto? boleto = colectivo.PagarCon(miTarjeta);
                if (boleto != null)
                {
                    Console.WriteLine($"\nViaje {i}:");
                    Console.WriteLine($"  Línea: {boleto.LineaColectivo}");
                    Console.WriteLine($"  Monto pagado: ${boleto.Monto}");
                    Console.WriteLine($"  Saldo restante: ${boleto.SaldoRestante}");
                    Console.WriteLine($"  Fecha: {boleto.Fecha:dd/MM/yyyy HH:mm:ss}");
                }
            }

            // Verificar saldo final
            Console.WriteLine($"\n--- Resumen ---");
            Console.WriteLine($"Saldo final en tarjeta: ${miTarjeta.Saldo}");
            Console.WriteLine($"Total gastado: ${5000 - miTarjeta.Saldo}");

            // Intentar viajar sin saldo suficiente
            Console.WriteLine("\n--- Intentando viajar sin saldo suficiente ---");
            Tarjeta tarjetaVacia = new Tarjeta();
            Boleto? boletoRechazado = colectivo.PagarCon(tarjetaVacia);
            if (boletoRechazado == null)
            {
                Console.WriteLine("✗ Viaje rechazado: saldo insuficiente");
            }

            Console.WriteLine("\n=== Presiona cualquier tecla para salir ===");
            Console.ReadKey();
        }
    }
}
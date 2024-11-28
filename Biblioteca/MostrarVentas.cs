using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class MostrarVentass
    {
        public void Mostrar()
        {
            Console.Clear();
            Console.WriteLine(" -------------------------------------------------------------------------");
            Console.Write("|                      ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("LISTA DE VENTAS REGISTRADAS");
            Console.ResetColor();
            Console.Write("                        |\n");
            Console.Write(" -------------------------------------------------------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(2, 3);
            Console.Write("NRO. VENTA");
            Console.SetCursorPosition(17, 3);
            Console.Write("CÓDIGO");
            Console.SetCursorPosition(49, 3);
            Console.Write("CANTIDAD");
            Console.SetCursorPosition(62, 3);
            Console.Write("PRECIO");
            Console.ResetColor();
            Console.WriteLine();


            for (int i = 0; i < Variables.ventas.GetLongLength(0); i++) //GetLongLength(0) recupera el tamaño de filas y si pongo 1 seria tamaño de las columnas.
            {
                if (Variables.ventas[i, 0] != null) // Verifica si la fila contiene datos, para asi evitar que se muestren los datos vacios
                {

                    Console.SetCursorPosition(2, 4 + i);
                    Console.Write(Variables.ventas[i, 0]);
                    Console.SetCursorPosition(17, 4 + i);
                    Console.Write(Variables.ventas[i, 1]);
                    Console.SetCursorPosition(49, 4 + i);
                    Console.Write(Variables.ventas[i, 2]);
                    Console.SetCursorPosition(62, 4 + i);
                    Console.Write(Variables.ventas[i, 3]);
                }
            }
            Console.Write("\n -------------------------------------------------------------------------\n");
        }
    }
}

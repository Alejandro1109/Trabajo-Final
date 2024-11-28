using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class MostrarVentass
    {
        public void Mostrar()
        {
            productos metodos = new productos();
            bool listaProductosVacia = false;

            //Verificamos si la lista de items tiene al menos un item
            for (int i = 0; i < Variables.items.GetLongLength(0); i++)
            {
                if (!string.IsNullOrEmpty(Variables.items[i, 0]))
                {
                    listaProductosVacia = false;
                    break;
                }

                listaProductosVacia = true;
            }

            if (listaProductosVacia == true)
            {
                Console.WriteLine("No se pueden listar las ventas si no se ha registrado los productos.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine(" -------------------------------------------------------------------------");
                Console.Write("|                      ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("LISTA DE PRODUCTOS VENDIDOS");
                Console.ResetColor();
                Console.Write("                     |\n");
                Console.Write(" -------------------------------------------------------------------------");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(2, 3); 
                Console.Write("NRO.VENTA");
                Console.SetCursorPosition(12, 3); 
                Console.Write("CODIGO");
                Console.SetCursorPosition(22, 3); 
                Console.Write("STOCK");
                Console.SetCursorPosition(30, 3); 
                Console.Write("PRECIO\n");
                Console.ResetColor();

                Console.WriteLine();

                for (int i = 0; i < Variables.ventas.GetLongLength(0); i++) //GetLongLength(0) recuper0a el tamaño de filas y si pongo 1 seria tamaño de las columnas.
                {
                    if (Variables.ventas[i, 0] != null) // Verifica si la fila contiene datos, para asi evitar que se muestren los datos vacios
                    {
                            Console.SetCursorPosition(2, 4 + i); Console.Write(Variables.ventas[i, 0]);
                            Console.SetCursorPosition(12, 4 + i); Console.Write(Variables.ventas[i, 1]);
                            Console.SetCursorPosition(22, 4 + i); Console.Write(Variables.ventas[i, 2]);
                            Console.SetCursorPosition(30, 4 + i); Console.Write(Variables.ventas[i, 3]);
                    }
                }
            }
        }
    }
}

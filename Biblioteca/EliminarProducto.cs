using System;
using System.Collections.Generic;
using System.Text;


namespace Biblioteca
{
    public class EliminarProducto
    {

        public void Eliminar()
        {
            if (MetodosAuxiliares.verificarExisteProductosRegistrados())
            {
                Console.Write("Ingrese código del producto a eliminar: ");
                string cod = Console.ReadLine().Trim().ToUpper();
                int indice = MetodosAuxiliares.buscar(cod); // Guardamos el índice del producto

                if (indice != -1)
                {
                    for (int i = indice; i < Variables.items.GetLength(0) - 1; i++)
                    {
                        for (int j = 0; j < Variables.items.GetLength(1); j++)
                        {
                            Variables.items[i, j] = Variables.items[i + 1, j];
                        }
                    }

                    for (int j = 0; j < Variables.items.GetLength(1); j++)
                    {
                        Variables.items[Variables.items.GetLength(0) - 1, j] = null;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nEl producto ha sido eliminado correctamente!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nEl producto no se puede eliminar porque no existe!");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo hay productos para eliminar.");
                Console.ResetColor();
            }
        }
    }




}

using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class RegistrodeVentas
    {

        public void RegistrarVentas()
        {

            productos metodos = new productos();
            string codigo = "";
            string cantidad = "";
            string stock = "";
            char repetir = 's';
            int filaVentas = 0, filaItems;
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

            if (listaProductosVacia == false)
            {
                do
                {
                    metodos.MostrarProductos();
                    Console.WriteLine("           --------------------------------------------");
                    Console.WriteLine("          |             REGISTRAR VENTA                |");
                    Console.WriteLine("           --------------------------------------------\n");

                    //Buscamos la primera fila vacia en la columna de codigo;
                    if (filaVentas == 0)
                    {
                        for (int i = 0; i < Variables.ventas.GetLongLength(0); i++)
                        {
                            if (string.IsNullOrEmpty(Variables.ventas[i, 1]))
                            {
                                filaVentas = i;
                                break;
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(Variables.ventas[filaVentas, 1]))
                    {
                        if (string.IsNullOrEmpty(codigo))
                        {
                            Console.Write("Ingrese el código del producto del cuál va registrar venta : ");
                            codigo = Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("Código Invalido. Ingrese el código del producto del cuál va registrar una venta: ");
                            codigo = Console.ReadLine();
                        }


                        //Verificamos si lo ingresado en la consola es un código válido y si existe
                        if (MetodosAuxiliares.VerificarCodigoValido(codigo) == 0 || MetodosAuxiliares.VerificarCodigo(codigo.ToString()) == 0)
                        {
                            Console.Clear();
                            continue;
                        }

                        //Si todas las verificaciones pasan correctamente, se registra el código en el arreglo
                        Variables.ventas[filaVentas, 1] = codigo;

                    }

                    filaItems = metodos.buscar(codigo);


                    //Se registra la cantidad si es que pasa todas las verificaciones
                    if (string.IsNullOrEmpty(Variables.ventas[filaVentas, 2]))
                    {
                        Console.Write("Ingrese la cantidad que se va vender: ");
                        cantidad = numeroValido(Console.ReadLine()).ToString();
                        stock = devolverStock(codigo);


                        if (int.Parse(cantidad) > int.Parse(Variables.items[1, 2]))
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            limpiarLineaActual();
                            Console.Write($"Cantidad no disponible en stock. \nStock Disponible: {stock} \nIngrese la cantidad que se va vender: ");
                            cantidad = Console.ReadLine();

                        }


                        //Se registra la venta
                        Variables.ventas[filaVentas, 2] = cantidad;
                        //Registramos el precio de la venta
                        Variables.ventas[filaVentas, 3] = Variables.items[filaItems, 3];
                        //Registramos el n de venta
                        Variables.ventas[filaVentas, 0] = filaVentas.ToString();

                        //Se modifica el stock
                        Variables.items[filaItems, 2] = (int.Parse(stock) - int.Parse(cantidad)).ToString();


                        if (!string.IsNullOrEmpty(Variables.ventas[filaVentas, 1]))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nLa venta se ha registrado correctamente!\n");
                            Console.ResetColor();

                            //Reseteamos las variables para volverlas a usar
                            filaItems = 0;
                            filaVentas = 0;
                            codigo = "";

                            //Preguntamos si se quiere registrar otra venta
                            Console.Write("Ingrese [s] si quiere registrar otra venta, o [n] si desea volver al menú: ");
                            repetir = Console.ReadKey().KeyChar;

                            if (repetir == 'n')
                            { break; }
                            if (repetir == 's')
                            {
                                Console.Clear();
                            }
                        }

                    }

                }
                while (repetir == 's');

            }

            else
            {
                metodos.MostrarProductos();
                Console.WriteLine("\nNo puede registrar una venta sin tener ningún producto registrado.");
            }

        }


        public string devolverStock(string codigo)
        {
            string stock = "";

            for (int i = 0; i < Variables.items.GetLongLength(0); i++)
            {
                if (Variables.items[i, 0] == codigo)
                {
                    stock = Variables.items[i, 2];
                }
            }

            return stock;
        }

        public int numeroValido(string n)
        {
            int numero;

            while (!int.TryParse(n, out numero) || numero < 0)
            {
                Console.Write("Ingrese un número válido: ");
                n = Console.ReadLine();
            }

            return numero;

        }
        public static void limpiarLineaActual()
        {
            int lineaActual = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, lineaActual);
        }

        public static bool verificarStockDisponible(int cantidad, int stock)
        {
            if (cantidad > stock)
            {
                return true;
            }

            return false;
        }

    }
}

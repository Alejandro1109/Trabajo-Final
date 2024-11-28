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
            string cantidadVenta = "";
            string stock = "";
            char repetir = 's';
            int filaVentas=0, filaItems;


            //Verificamos que exista algún producto registrado
            if (MetodosAuxiliares.verificarExisteProductosRegistrados())
            {
                do
                {
                    metodos.MostrarProductos();
                    Console.WriteLine(" ---------------------------------------------------------");
                    Console.Write("|                    ");
                    Console.Write("REGISTRAR VENTA");
                    Console.Write("                      |\n");
                    Console.WriteLine(" ---------------------------------------------------------\n");

                    //Buscamos la primera fila vacia en la lista de ventas;
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
                            Console.Write("Ingrese el código del producto del cuál va registrar una venta: ");
                            codigo = Console.ReadLine().ToUpper();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Código Invalido.");
                            Console.ResetColor();
                            Console.Write(" Ingrese el código del producto del cuál va registrar una venta: ");
                            codigo = Console.ReadLine().ToUpper();
                        }


                        //Verificamos si lo ingresado en la consola es un código válido y si existe
                        if (MetodosAuxiliares.VerificarCodigoValido(codigo) == 0 || MetodosAuxiliares.VerificarCodigoExiste(codigo.ToString()) == 0)
                        {
                            Console.Clear();
                            continue;
                        }

                        //Si todas las verificaciones pasan correctamente, se registra el código en el arreglo de ventas
                        Variables.ventas[filaVentas, 1] = codigo;

                    }

                    filaItems = MetodosAuxiliares.buscar(codigo);

                    //Se registra la cantidad si es que pasa todas las verificaciones
                    if (string.IsNullOrEmpty(Variables.ventas[filaVentas, 2]))
                    {
                        stock = devolverStock(codigo);

                        if (int.Parse(stock) == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("No hay stock disponible para vender.");
                            Console.ResetColor();
                            Console.Write(" [Presione cualquier tecla para registrar otra venta]");
                            Console.ReadKey();

                            //Reseteamos las variables para volverlas a usar
                            filaItems = 0;
                            filaVentas = 0;
                            codigo = "";
                            cantidadVenta = "";
                            continue;
                        }

                        Console.Write($"Ingrese la cantidad que se va vender: ");
                        cantidadVenta = numeroValido(Console.ReadLine());

                        while (int.Parse(cantidadVenta) > int.Parse(Variables.items[filaItems, 2]))
                        {

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"Cantidad no disponible en stock.");
                            Console.ResetColor();
                            Console.Write($"\nIngrese la cantidad que se va vender: ");
                            cantidadVenta = numeroValido(Console.ReadLine());

                        }


                        //Se registra la venta
                        Variables.ventas[filaVentas, 2] = cantidadVenta;
                        //Registramos el precio de la venta
                        Variables.ventas[filaVentas, 3] = Variables.items[filaItems, 3];
                        //Registramos el n de venta
                        Variables.ventas[filaVentas, 0] = filaVentas.ToString();
                        //Se modifica el stock
                        Variables.items[filaItems, 2] = (int.Parse(stock) - int.Parse(cantidadVenta)).ToString();


                        if (!string.IsNullOrEmpty(Variables.ventas[filaVentas, 1]))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nLa venta se ha registrado correctamente!\n");
                            Console.ResetColor();

                            //Reseteamos las variables para volverlas a usar
                            filaItems = 0;
                            filaVentas = 0;
                            codigo = "";
                            stock = "";
                            cantidadVenta = "";

                            //Preguntamos si se quiere registrar otra venta
                            Console.Write("Ingrese [s] si quiere registrar otra venta, o [n] si desea volver al menú: ");
                            repetir = char.ToLower(Console.ReadKey().KeyChar);
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo puede registrar una venta sin tener ningún producto registrado.");
                Console.ResetColor();

            }

        }
        public int devolverFilaItems(string codigo)
        {
            for (int i = 0; i < Variables.items.GetLongLength(0); i++)
            {
                if (Variables.items[i, 0] == codigo)
                {
                    return i;
                }
            }

            return 0;

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

        public string numeroValido(string n)
        {
            int numero;

            while (!int.TryParse(n, out numero) || numero < 0 || numero == 0)
            {
                Console.Write("Ingrese una cantidad válida: ");
                n = Console.ReadLine();
            }

            return numero.ToString();

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

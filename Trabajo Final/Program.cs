using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca;

namespace Trabajo_Final
{
    public class Program
    {
        public int cantidad = 0;
        static void Main(string[] args)
        {
            //Declaramos los metodos que se van a usar
            EliminarProducto eliminar = new EliminarProducto();
            MostrarVentass mostrarventas = new MostrarVentass();
            EliminarProducto eliminarProducto = new EliminarProducto();
            RegistrodeVentas registrarVentas = new RegistrodeVentas();
            productos registarProductos = new productos();
            char regresar;

            do
            {
                int opcion = registarProductos.menu();
                switch (opcion)
                {
                    case 1:
                        registarProductos.Registrar(opcion);
                        break;
                    case 2:
                        registarProductos.MostrarProductos();
                        registarProductos.Modificar();
                        break;
                    case 3:
                        registarProductos.MostrarProductos();
                        eliminar.Eliminar();
                        break;
                    case 4:
                        registrarVentas.RegistrarVentas();
                        break;
                    case 5:
                        registarProductos.MostrarProductos();
                        break;
                    case 6:
                        mostrarventas.Mostrar();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                }
                Console.Write("\t\n¿Desea regresar al menú? [s/n] -> "); 
                regresar = char.ToUpper(Console.ReadKey().KeyChar);
                Console.Clear();
            } while (regresar == 'S');
        }
    }
}

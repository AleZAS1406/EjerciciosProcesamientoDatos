using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3___Procesamiento_de_un_archivo
{
    [Serializable]
    public struct Producto
    {
        public int Idprod;
        public string Nombre;
        public decimal Precio;

        public Producto(int idprod, string nombre, decimal precio)
        {
            Idprod = idprod;
            Nombre = nombre;
            Precio = precio;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Producto> productos = new List<Producto>();

            while (true)
            {
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Mostrar productos");
                Console.WriteLine("3. Salir");

                Console.Write("Ingrese su opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarProducto(productos);
                        break;
                    case 2:
                        MostrarProductos(productos);
                        break;
                    case 3:
                        GuardarProductosEnArchivoBinario(productos, "productos.bin");
                        Console.WriteLine("Productos guardados con éxito.");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, inténtelo de nuevo.");
                        break;
                }
            }
        }

        static void AgregarProducto(List<Producto> productos)
        {
            Console.Write("Ingrese el ID del producto: ");
            int idprod = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el precio del producto: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            productos.Add(new Producto(idprod, nombre, precio));
        }

        static void MostrarProductos(List<Producto> productos)
        {
            foreach (Producto producto in productos)
            {
                Console.WriteLine($"ID: {producto.Idprod}, Nombre: {producto.Nombre}, Precio: {producto.Precio}");
            }
        }

        static void GuardarProductosEnArchivoBinario(List<Producto> productos, string archivo)
        {
            FileStream archivoEscritor = new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter escritor = new BinaryWriter(archivoEscritor);

            foreach (Producto producto in productos)
            {
                escritor.Write(producto.Idprod);
                escritor.Write(producto.Nombre);
                escritor.Write(producto.Precio);
            }

            escritor.Close();
            archivoEscritor.Close();
        }
    }
}

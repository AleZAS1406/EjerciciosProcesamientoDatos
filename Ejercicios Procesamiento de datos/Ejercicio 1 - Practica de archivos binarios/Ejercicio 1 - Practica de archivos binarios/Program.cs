using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ejercicio_1___Practica_de_archivos_binarios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Pedir al usuario que ingrese varias cadenas
            Console.WriteLine("Ingrese varias cadenas (nombres, por ejemplo):");
            string[] cadenas = Console.ReadLine().Split(',');

            // Guardar las cadenas en un archivo binario
            GuardarCadenasEnArchivoBinario(cadenas, "cadenas.bin");

            // Leer las cadenas del archivo binario y mostrarlas en la consola
            LeerCadenasDelArchivoBinario("cadenas.bin");
        }

        static void GuardarCadenasEnArchivoBinario(string[] cadenas, string archivo)
        {
            FileStream archivoEscritor = new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter escritor = new BinaryWriter(archivoEscritor);

            foreach (string cadena in cadenas)
            {
                escritor.Write(cadena);
            }

            escritor.Close();
            archivoEscritor.Close();
        }

        static void LeerCadenasDelArchivoBinario(string archivo)
        {
            FileStream archivoLector = new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Read);
            BinaryReader lector = new BinaryReader(archivoLector);

            while (archivoLector.Position != archivoLector.Length)
            {
                Console.WriteLine("Cadena leida: " + lector.ReadString());
            }

            lector.Close();
            archivoLector.Close();

        }

    }
}

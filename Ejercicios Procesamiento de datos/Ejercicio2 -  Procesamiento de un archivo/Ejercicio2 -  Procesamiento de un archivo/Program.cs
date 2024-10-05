using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2____Procesamiento_de_un_archivo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Escribir números pares en un archivo binario
            EscribirNumerosParesEnArchivoBinario("numeros_pares.bin");

            // Leer números pares del archivo binario y mostrarlos en la consola
            LeerNumerosParesDelArchivoBinario("numeros_pares.bin");

            Console.ReadKey();
        }

        static void EscribirNumerosParesEnArchivoBinario(string archivo)
        {
            FileStream archivoEscritor = new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter escritor = new BinaryWriter(archivoEscritor);

            for (int i = 2; i <= 20; i += 2)
            {
                escritor.Write(i);
            }

            escritor.Close();
            archivoEscritor.Close();
        }

        static void LeerNumerosParesDelArchivoBinario(string archivo)
        {
            FileStream archivoLector = new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Read);
            BinaryReader lector = new BinaryReader(archivoLector);

            while (archivoLector.Position != archivoLector.Length)
            {
                Console.WriteLine("Número par leido: " + lector.ReadInt32());
            }

            lector.Close();
            archivoLector.Close();
            
        }
    }

}



using System.Collections.Generic;

namespace Cartuchada_Console
{
    public static class CartdrigeCatalogueCsvToSqlQuery
    {
        // Script para la recuperación del catálogo completo de GB de la antigua Cartuchada.
        // Convierte el csv del catálogo de Game Boy en un query SQL para la tabla GameCatalogue.
        // Necesita el antiguo csv para funcionar.
        public static void Execute() 
        { 
            string projectRootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string filePath = Path.Combine(projectRootPath, "Lista Completa de Game Boy.csv");

            if (!File.Exists(filePath))
            {
                Console.WriteLine("El archivo no se encuentra en la carpeta.");
                return;
            }
            
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length < 2)
            {
                Console.WriteLine("El archivo CSV no tiene suficientes datos.");
                return;
            }

            // Divide el resultado en queries de 1000 valores.
            int querySize = 1000;
            int totalLines = lines.Length;
            int numberOfQueries = (totalLines / querySize) + (totalLines % querySize == 0 ? 0 : 1);

            // Por cada query:
            for (int queryNumber = 0; queryNumber < numberOfQueries; queryNumber++)
            {
                int startLine = queryNumber * querySize + 1;
                int endLine = Math.Min((queryNumber + 1) * querySize + 1, totalLines);

                string queryHeader = $"INSERT INTO GameCatalogue (IdProductType, Name, JAP, NA, PAL)\nVALUES";
                Console.WriteLine(queryHeader);

                // Imprime los valores del query.
                for (int i = startLine; i < endLine; i++)
                {
                    string line = lines[i];
                    string[] columns = line.Split(',');

                    if (columns.Length < 6)
                    {
                        Console.WriteLine($"La fila {i + 1} tiene un número incorrecto de columnas.");
                        continue;
                    }

                    string numeracion = columns[0].Trim(); // Columna 'NUMERACION'
                    string consola = columns[1].Trim(); // Columna 'CONSOLA'
                    string tituloDelJuego = columns[2].Trim(); // Columna 'TITULO DEL JUEGO'
                    string japon = columns[3].Trim(); // Columna 'JAPON'
                    string americaDelNorte = columns[4].Trim(); // Columna 'AMERICA DEL NORTE'
                    string pal = columns[5].Trim(); // Columna 'PAL'

                    // Determina si el juego está 'RELEASED' o 'UNRELEASED' para cada región
                    int jap = 0;
                    int na = 0;
                    int palRegion = 0;

                    if (japon.ToUpper() == "RELEASED") { jap = 1; }
                    if (americaDelNorte.ToUpper() == "RELEASED") { na = 1; }
                    if (pal.ToUpper() == "RELEASED") { palRegion = 1; }

                    string queryLine = string.Empty;
                    if (i != endLine - 1) 
                    { 
                        queryLine = $"    (1, '{tituloDelJuego.Replace("'", "''")}', {jap}, {na}, {palRegion}),"; 
                    }
                    else 
                    { 
                        queryLine = $"    (1, '{tituloDelJuego.Replace("'", "''")}', {jap}, {na}, {palRegion});\n"; 
                    }

                    Console.WriteLine(queryLine);
                }
            }
        }
    }
}

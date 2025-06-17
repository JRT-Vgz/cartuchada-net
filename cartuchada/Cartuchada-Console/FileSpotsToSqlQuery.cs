
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace Cartuchada_Console
{
    public static class FileSpotsToSqlQuery
    {

        public static void Execute()
        {
            // printear el encabezado del query
            string header = "INSERT INTO Spot (IdProductType, IdGame, IdRegion, IdCondition, SpotDate, SpotPrice)\nVALUES";
            Console.WriteLine(header);

            // iterar por los archivos de la carpeta
            string projectRootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string folder = "Fichas de Juegos";
            string folderFullPath = Path.Combine(projectRootPath, folder);

            var fileNames = Directory.EnumerateFiles(folderFullPath);




            //Solo cuenta los primeros 1962
            int intStopReading = 1962;
            int currentFileCount = 0;

            foreach (var filePath in fileNames)
            {
                if (currentFileCount == intStopReading) { return; }
                currentFileCount++;

                // por cada archivo, si hay mas de una linea, crear una linea del query. Printear
                if (!File.Exists(filePath)) { return; }

                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length <= 2) { continue; }

                string[] processedLines = lines.Skip(1).ToArray();

                foreach (var line in processedLines)
                {
                    string[] columns = line.Split(',');

                    string idProductType = "1";
                    string idGame = FormattingManager.FormatIdGame(filePath);
                    string idRegion = FormattingManager.FormatRegion(columns[5]);
                    string idCondition = FormattingManager.FormatCondition(columns[6]);
                    string spotDate = "'2024-01-15'";
                    string spotPrice = FormattingManager.FormatPrice(columns[8]);

                    var result = $"({idProductType}, {idGame}, {idRegion}, {idCondition}, {spotDate}, {spotPrice}),";
                    Console.WriteLine(result);
                }




            }

        }
    }

    public static class FormattingManager
    {
        public static string FormatRegion(string region)
        {
            if (region == "JAP") { return "1"; }
            else if (region == "NA") { return "2"; }
            else if (region == "PAL ESP") { return "3"; }
            else if (region == "PAL EUR") { return "4"; }
            else if (region == "PAL FAH") { return "5"; }
            else if (region == "PAL FRA") { return "6"; }
            else if (region == "PAL UKV") { return "7"; }
            else if (region == "PAL NOE") { return "8"; }
            else if (region == "PAL ITA") { return "9"; }
            else { return "NO PROCESADO"; }
        }

        public static string FormatCondition(string condition)
        {
            if (condition == "NEAR-MINT") { return "6"; }
            else if (condition == "EXCELLENT") { return "5"; }
            else if (condition == "PLAYED") { return "2"; }
            else if (condition == "MINT") { return "7"; }
            else if (condition == "LIGHT-PLAYED") { return "3"; }
            else if (condition == "POOR") { return "1"; }
            else if (condition == "GOOD") { return "4"; }
            else { return "NO PROCESADO"; }
        }

        public static string FormatPrice(string price)
        {
            return price.Substring(0, price.Length - 1);
        }

        public static string FormatIdGame(string filePath)
        {
            string idGame = string.Empty;

            string regex = @"(?<=\D)(\d{4})(?=\D)";

            var match = Regex.Match(filePath, regex);
            if (match.Success)  { idGame = match.Value; }

            if (idGame.StartsWith("0"))
            {
                idGame = idGame.Substring(1, idGame.Length - 1);
            }

            if (idGame.StartsWith("0"))
            {
                idGame = idGame.Substring(1, idGame.Length - 1);
            }

            if (idGame.StartsWith("0"))
            {
                idGame = idGame.Substring(1, idGame.Length - 1);
            }

            return idGame;
        }
    }
}

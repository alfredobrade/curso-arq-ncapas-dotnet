using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_pedidos.Services
{
    public static class TextFileService
    {
        public static void TxtFileCreateOrWrite(string fileName = "default", string message = "")// , IEnumerable<string> lines)
        {
            string relativePath = $@"Tools\Storage\TextFilesStorage\{fileName}.txt";
            string filePath = Path.Combine(BaseDirectory(), relativePath);

            File.WriteAllText(filePath, message);

            Console.WriteLine("Text file saved to " + filePath);
        }
        public static void TxtFileCreateByStrList(string fileName, List<string> lines)
        {
            // Create a list of strings
            string relativePath = $@"Tools\Storage\TextFilesStorage\{fileName}.txt";
            string filePath = Path.Combine(BaseDirectory(), relativePath);
            // Define the desktop path


            File.WriteAllLines(filePath, lines);

            Console.WriteLine("Text file saved to " + filePath);
        }

        public static void TxtFileAddLine(string fileName = "default", string message = "")
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string relativePath = $@"Tools\Storage\TextFilesStorage\{fileName}.txt";
            string filePath = Path.Combine(BaseDirectory(), relativePath);

            // Append a new line with a new word
            string newLine = $"this is a new line";
            File.AppendAllText(filePath, Environment.NewLine + newLine);

            Console.WriteLine("New SQL statement appended to " + filePath);
        }

        public static string TxtFileReadText(string fileName = "default")
        {

            // - with File.ReadAllLines ->  string[]
            string relativePath = $@"Tools\Storage\TextFilesStorage\{fileName}.txt";
            string filePath = Path.Combine(BaseDirectory(), relativePath);

            // Leer todas las líneas del archivo
            return File.ReadAllText(filePath);


        }
        public static void TxtFileReadAllLines(string fileName = "default")
        {

            // - with File.ReadAllLines ->  string[]
            string relativePath = $@"Tools\Storage\TextFilesStorage\{fileName}.txt";
            string filePath = Path.Combine(BaseDirectory(), relativePath);

            // Leer todas las líneas del archivo
            string[] lines = File.ReadAllLines(filePath);

            // Imprimir cada línea
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }

        public static void SqlTextFileCreate(string fileName, IEnumerable<string> lines)
        {
            // Create a list of strings
            List<string> strings = new List<string> { "Apple", "Banana", "Cherry" };

            // Define the desktop path
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, $"{fileName}.sql");

            // Create a list to hold the SQL statements
            List<string> sqlStatements = new List<string>();

            // Format each string into an SQL INSERT statement
            foreach (var str in strings)
            {
                string sql = $"INSERT INTO TableName (Name) VALUES ('{str}');";
                sqlStatements.Add(sql);
                Console.WriteLine(sql); // Print to console
            }

            // Write the SQL statements to the file
            File.WriteAllLines(filePath, sqlStatements);

            Console.WriteLine("SQL statements saved to " + filePath);
        }


        public static void SqlTextFileAddLine(string fileName, string line)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string filePath = Path.Combine(desktopPath, $"{fileName}.sql");

            // Append a new line with a new word
            string newWord = "Date";
            string newSql = $"INSERT INTO TableName (Name) VALUES ('{newWord}');";
            File.AppendAllText(filePath, Environment.NewLine + newSql);

            Console.WriteLine("New SQL statement appended to " + filePath);
        }

        public static string BaseDirectory()
        {

            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}


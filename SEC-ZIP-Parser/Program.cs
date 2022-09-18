using System;
using SEC_ZIP_Parser.Classes.Json;
using SEC_ZIP_Parser.Classes.Json.Files;

namespace SEC_ZIP_Parser
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            const string dir = "C:\\Users\\Landon\\Downloads\\submissions";
            var files = new SubmissionFiles(dir);
            for (var i = 0; i < files.Length; i++)
            {
                var parser = new CompanyJsonParser(files[i]);
                var company = parser.Parse();
                Console.WriteLine(company.AsString());
            }
        }
    }
}
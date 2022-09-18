using System;
using SEC_ZIP_Parser.Classes.Json;
using SEC_ZIP_Parser.Classes.Json.Files;

namespace SEC_ZIP_Parser
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var dir = "C:\\Users\\Landon\\Downloads\\submissions";
            var files = new SubmissionFiles(dir);
            for (var i = 0; i < files.Length; i++)
            {
                var company = CompanyJsonParser.ParseGeneralSubmissionCompany(files[i]);
                Console.WriteLine(company.AsString());
            }
        }
    }
}
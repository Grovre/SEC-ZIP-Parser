using System;
using System.Linq;
using SEC_ZIP_Parser.Classes.CompanyClasses;
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
            var enumerator = files.FilePaths;

            enumerator.AsParallel()
                .AsUnordered()
                .Select(ParseCompany)
                .Select(co => co.AsString())
                .ForAll(Console.WriteLine);
        }

        private static Company ParseCompany(string path)
        {
            var parser = new CompanyJsonParser(path);
            var co = parser.Parse();
            return co;
        }
    }
}
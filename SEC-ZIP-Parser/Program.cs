using System;
using SEC_ZIP_Parser.Classes.Json;

namespace SEC_ZIP_Parser
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var company =
                CompanyJsonParser.ParseGeneralSubmissionCompany(
                    "C:\\Users\\Landon\\Downloads\\submissions\\CIK0000019617.json");

            Console.WriteLine(company.Addresses);
            Console.WriteLine(company.Category);
            Console.WriteLine(company.Description);
            Console.WriteLine(company.Exchanges);
            Console.WriteLine(company.EntityType);
            Console.WriteLine(company.CentralIndexKey);
            Console.WriteLine(company.EmployerIdNumber);
        }
    }
}
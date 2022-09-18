using System.IO;
using System.Linq;
using System.Text.Json;

namespace SEC_ZIP_Parser.Classes.Json
{
    public class CompanyJsonParser
    {
        public static Company ParseGeneralSubmissionCompany(string jsonFilePath)
        {
            var json = File.ReadAllLines(jsonFilePath)[0];
            var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            var parser = new CompanyJsonParser();
            
            var addresses = parser.GetAddresses(root);
            var category = root.GetProperty(JsonPropertyNames.CompanyCategory).GetString();
            var cik = root.GetProperty(JsonPropertyNames.CentralIndexKey).GetString();
            var desc = root.GetProperty(JsonPropertyNames.CompanyDescription).GetString();
            var ein = root.GetProperty(JsonPropertyNames.EmployerIdNumber).GetString();
            var entityType = root.GetProperty(JsonPropertyNames.CompanyEntityType).GetString();
            var exchanges = root.GetProperty(JsonPropertyNames.Exchanges)
                .EnumerateArray()
                .Select(el => el.ToString())
                .Select(ExchangesHelper.Parse)
                .ToHashSet();

            var company = new Company
            {
                Addresses = addresses,
                Category = category,
                CentralIndexKey = cik,
                Description = desc,
                EmployerIdNumber = ein,
                EntityType = entityType,
                Exchanges = exchanges
            };
            
            return company;
        }

        public CompanyAddress[] GetAddresses(JsonElement root)
        {
            var addresses = root.GetProperty(JsonPropertyNames.Addresses);
            return addresses.EnumerateObject().Select(CompanyAddressHelper.ReadJsonElement).ToArray();
        }
    }
}
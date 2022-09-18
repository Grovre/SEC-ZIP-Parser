using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SEC_ZIP_Parser.Classes.Enums;
using SEC_ZIP_Parser.Classes.Helpers;

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
            var category = parser.SafeStringRetrievalFromProperty(root, JsonPropertyNames.CompanyCategory);
            var cik = parser.SafeStringRetrievalFromProperty(root, JsonPropertyNames.CentralIndexKey);
            var desc = parser.SafeStringRetrievalFromProperty(root, JsonPropertyNames.CompanyDescription);
            var ein = parser.SafeStringRetrievalFromProperty(root, JsonPropertyNames.EmployerIdNumber);
            var entityType = parser.SafeStringRetrievalFromProperty(root, JsonPropertyNames.CompanyEntityType);
            HashSet<Exchanges> exchanges;
            try
            {
                exchanges = root.GetProperty(JsonPropertyNames.Exchanges)
                    .EnumerateArray()
                    .Select(el => el.ToString())
                    .Select(ExchangesHelper.Parse)
                    .ToHashSet();
            }
            catch (KeyNotFoundException)
            {
                exchanges = null;
            }

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
        
        #nullable enable
        public string? SafeStringRetrievalFromProperty(JsonElement el, string propertyName)
        {
            try
            {
                return el.GetProperty(propertyName).GetString();
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public CompanyAddress[]? GetAddresses(JsonElement root)
        {
            var rootStr = root.ToString();
            JsonElement addresses;
            try
            {
                addresses = root.GetProperty(JsonPropertyNames.Addresses);
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
            return addresses.EnumerateObject().Select(CompanyAddressHelper.ReadJsonElement).ToArray();
        }
    }
}
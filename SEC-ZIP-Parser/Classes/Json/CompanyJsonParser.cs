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
        public string JsonFilePath { get; }

        public CompanyJsonParser(string jsonPath)
        {
            JsonFilePath = jsonPath;
        }

        public Company Parse()
        {
            var co = new Company();
            ParseTo(ref co);
            return co;
        }

        public void ParseTo(ref Company dst)
        {
            var json = File.ReadAllLines(JsonFilePath)[0];
            var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            
            var addresses = GetAddresses(root);
            var category = SafeStringRetrievalFromProperty(root, JsonPropertyNames.CompanyCategory);
            var cik = SafeStringRetrievalFromProperty(root, JsonPropertyNames.CentralIndexKey);
            var desc = SafeStringRetrievalFromProperty(root, JsonPropertyNames.CompanyDescription);
            var ein = SafeStringRetrievalFromProperty(root, JsonPropertyNames.EmployerIdNumber);
            var entityType = SafeStringRetrievalFromProperty(root, JsonPropertyNames.CompanyEntityType);
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

            dst.Addresses = addresses;
            dst.Category = category;
            dst.CentralIndexKey = cik;
            dst.Description = desc;
            dst.EmployerIdNumber = ein;
            dst.EntityType = entityType;
            dst.Exchanges = exchanges;
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

        private static CompanyAddress[]? GetAddresses(JsonElement root)
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
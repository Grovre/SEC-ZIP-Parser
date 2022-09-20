using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SEC_ZIP_Parser.Classes.CompanyClasses;
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
            var json = File.ReadAllText(JsonFilePath);
            var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            
            var addresses = GetAddresses(root);
            var category = SafeStringRetrievalFromProperty(root, CompanyPropertyNames.CompanyCategory);
            var cik = SafeStringRetrievalFromProperty(root, CompanyPropertyNames.CentralIndexKey);
            var desc = SafeStringRetrievalFromProperty(root, CompanyPropertyNames.CompanyDescription);
            var ein = SafeStringRetrievalFromProperty(root, CompanyPropertyNames.EmployerIdNumber);
            var entityType = SafeStringRetrievalFromProperty(root, CompanyPropertyNames.CompanyEntityType);
            var name = SafeStringRetrievalFromProperty(root, CompanyPropertyNames.CompanyName);
            var sic = SafeStringRetrievalFromProperty(root, CompanyPropertyNames.StandardIndustrialClassification);
            var sicDesc =
                SafeStringRetrievalFromProperty(root, CompanyPropertyNames.StandardIndustrialClassificationDescription);
            var phone = SafeStringRetrievalFromProperty(root, CompanyPropertyNames.CompanyPhone);
            HashSet<Exchanges> exchanges;
            try
            {
                exchanges = root.GetProperty(CompanyPropertyNames.Exchanges)
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
            dst.Name = name;
            dst.StandardIndustrialClassification = sic;
            dst.StandardIndustrialClassificationDesc = sicDesc;
            dst.CompanyPhone = phone;
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
            JsonElement addresses;
            try
            {
                addresses = root.GetProperty(CompanyPropertyNames.Addresses);
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
            return addresses.EnumerateObject().Select(CompanyAddressHelper.ReadJsonElement).ToArray();
        }
    }
}
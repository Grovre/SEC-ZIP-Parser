using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SEC_ZIP_Parser.Classes.CompanyClasses;
using SEC_ZIP_Parser.Classes.Enums;
using SEC_ZIP_Parser.Classes.Helpers;

namespace SEC_ZIP_Parser.Classes.Json
{
    public class CompanyJsonParser : JsonParser<Company>
    {
        public CompanyJsonParser(string jsonPath) : base(jsonPath)
        {
            // Copy and paste master
        }

        public override Company Parse()
        {
            var co = new Company();
            ParseTo(ref co);
            return co;
        }

        public override void ParseTo(ref Company dst)
        {
            var root = GetJsonRootElement();
            
            var addresses = GetAddresses(root);
            var category = SafeStringRetrievalFromProperty(root, CompanyPropertyNames.CompanyCategory).RetrievedValue;
            var cik = SafeStringRetrievalFromProperty(root, CompanyPropertyNames.CentralIndexKey).RetrievedValue;
            var desc = SafeStringRetrievalFromProperty(root, CompanyPropertyNames.CompanyDescription).RetrievedValue;
            var ein = SafeStringRetrievalFromProperty(root, CompanyPropertyNames.EmployerIdNumber).RetrievedValue;
            var entityType = SafeStringRetrievalFromProperty(root, CompanyPropertyNames.CompanyEntityType).RetrievedValue;
            var name = SafeStringRetrievalFromProperty(root, CompanyPropertyNames.CompanyName).RetrievedValue;
            var sic = SafeStringRetrievalFromProperty(root, CompanyPropertyNames.StandardIndustrialClassification).RetrievedValue;
            var sicDesc =
                SafeStringRetrievalFromProperty(root, CompanyPropertyNames.StandardIndustrialClassificationDescription).RetrievedValue;
            var phone = SafeStringRetrievalFromProperty(root, CompanyPropertyNames.CompanyPhone).RetrievedValue;
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
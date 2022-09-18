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
            var 
        }

        public CompanyAddress[] GetAddresses(JsonElement root)
        {
            var addresses = root.GetProperty(JsonPropertyNames.Addresses);
            return addresses.EnumerateObject().Select(CompanyAddressHelper.ReadJsonElement).ToArray();
        }
    }
}
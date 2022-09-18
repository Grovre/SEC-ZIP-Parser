using System.IO;
using Newtonsoft.Json;

namespace SEC_ZIP_Parser.Classes.Json
{
    public class CompanyJsonParser
    {
        public static Company ParseGeneralSubmissionCompany(string jsonFilePath)
        {
            var fileStreamReader = File.OpenText(jsonFilePath);
            // To complete
        }
    }
}
using System.Text.Json;
using SEC_ZIP_Parser.Classes.Enums;
using SEC_ZIP_Parser.Classes.Json;

namespace SEC_ZIP_Parser.Classes.Helpers;

public static class CompanyAddressHelper
{
    public static CompanyAddress ReadJsonElement(JsonProperty businessOrMailingElement)
    {
        var addressPropertyName = businessOrMailingElement.ToString();
        var addressType = addressPropertyName switch
        {
            JsonPropertyNames.BusinessAddress => AddressType.Business,
            JsonPropertyNames.MailingAddress => AddressType.Mailing,
            _ => AddressType.Other
        };
        if (addressType == AddressType.Other)
            return null;
        var addressElement = businessOrMailingElement.Value;
    
        CompanyAddress businessAddress = new()
        {
            Type = addressType,
            City = addressElement.GetProperty(JsonPropertyNames.City).GetString(),
            StateOrCountry = addressElement.GetProperty(JsonPropertyNames.StateOrCountry).GetString(),
            Street1 = addressElement.GetProperty(JsonPropertyNames.Street1).GetString(),
            Street2 = addressElement.GetProperty(JsonPropertyNames.Street2).GetString(),
            ZipCode = addressElement.GetProperty(JsonPropertyNames.Zip).GetString()
        };
    
        return businessAddress;
    }
}
using System.Text.Json;
using SEC_ZIP_Parser.Classes.CompanyClasses;
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
            CompanyPropertyNames.BusinessAddress => AddressType.Business,
            CompanyPropertyNames.MailingAddress => AddressType.Mailing,
            _ => AddressType.Other
        };
        if (addressType == AddressType.Other)
            return null;
        var addressElement = businessOrMailingElement.Value;
    
        CompanyAddress businessAddress = new()
        {
            Type = addressType,
            City = addressElement.GetProperty(CompanyPropertyNames.City).GetString(),
            StateOrCountry = addressElement.GetProperty(CompanyPropertyNames.StateOrCountry).GetString(),
            Street1 = addressElement.GetProperty(CompanyPropertyNames.Street1).GetString(),
            Street2 = addressElement.GetProperty(CompanyPropertyNames.Street2).GetString(),
            ZipCode = addressElement.GetProperty(CompanyPropertyNames.Zip).GetString()
        };
    
        return businessAddress;
    }
}
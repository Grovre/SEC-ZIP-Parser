using System.Collections.Generic;

namespace SEC_ZIP_Parser.Classes
{
    public class Company
    {
        private CompanyAddress? businessAddress;
        private CompanyAddress? mailingAddress;
        private string category;
        private string cik;
        private string description;
        private string ein;
        private string entityType;
        private HashSet<Exchanges> exchanges;
    }
    
    
}
using System.Collections.Generic;
using SEC_ZIP_Parser.Classes.Enums;

namespace SEC_ZIP_Parser.Classes
{
    public class Company
    {
        private CompanyAddress[] addresses;
        private string category;
        private string cik;
        private string description;
        private string ein;
        private string entityType;
        private HashSet<Exchanges> exchanges;
    }
    
    
}
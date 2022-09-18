using System.Collections.Generic;
using SEC_ZIP_Parser.Classes.Enums;

namespace SEC_ZIP_Parser.Classes
{
    public class Company
    {
        public CompanyAddress[] Addresses { get; set; }

        public string Category { get; set; }

        public string CentralIndexKey { get; set; }

        public string Description { get; set; }

        public string EmployerIdNumber { get; set; }

        public string EntityType { get; set; }

        public HashSet<Exchanges> Exchanges { get; set; }
    }
}
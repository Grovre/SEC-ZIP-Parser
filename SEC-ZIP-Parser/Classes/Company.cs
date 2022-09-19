#nullable enable
using System.Collections.Generic;
using System.Text;
using SEC_ZIP_Parser.Classes.Enums;

namespace SEC_ZIP_Parser.Classes
{
    public class Company
    {
        public CompanyAddress[]? Addresses { get; set; }

        public string? Name { get; set; }

        public string? StandardIndustrialClassification { get; set; }
        
        public string? StandardIndustrialClassificationDesc { get; set; }

        public string? CompanyPhone { get; set; }

        public string? Category { get; set; }

        public string? CentralIndexKey { get; set; }

        public string? Description { get; set; }

        public string? EmployerIdNumber { get; set; }

        public string? EntityType { get; set; }

        public HashSet<Exchanges>? Exchanges { get; set; }

        public string AsString()
        {
            StringBuilder sb = new();
            sb.Append("Name: ").Append(Name).AppendLine()
                .Append("Phone: ").Append(CompanyPhone).AppendLine()
                .Append("Addresses: ").Append(Addresses).AppendLine()
                .Append("Category: ").Append(Category).AppendLine()
                .Append("CIK: ").Append(CentralIndexKey).AppendLine()
                .Append("Desc: ").Append(Description).AppendLine()
                .Append("EIN: ").Append(EmployerIdNumber).AppendLine()
                .Append("Entity Type: ").Append(EntityType).AppendLine()
                .Append("Exchanges: ").Append(Exchanges).AppendLine()
                .Append("SIC: ").Append(StandardIndustrialClassification).AppendLine()
                .Append("SIC Desc: ").Append(StandardIndustrialClassificationDesc).AppendLine();
            return sb.ToString();
        }
    }
}
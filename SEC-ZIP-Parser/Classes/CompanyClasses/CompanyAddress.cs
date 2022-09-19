using SEC_ZIP_Parser.Classes.Enums;

namespace SEC_ZIP_Parser.Classes.CompanyClasses
{
    public class CompanyAddress
    {
        private AddressType type;
        private string city;
        private string stateOrCountry;
        private string street1;
        private string street2;
        private string zipCode;

        public AddressType Type
        {
            get => type;
            set => type = value;
        }

        public string City
        {
            get => city;
            set => city = value;
        }

        public string StateOrCountry
        {
            get => stateOrCountry;
            set => stateOrCountry = value;
        }

        public string Street1
        {
            get => street1;
            set => street1 = value;
        }

        public string Street2
        {
            get => street2;
            set => street2 = value;
        }

        public string ZipCode
        {
            get => zipCode;
            set => zipCode = value;
        }
    }
}
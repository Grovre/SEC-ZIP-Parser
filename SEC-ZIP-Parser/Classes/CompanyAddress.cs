namespace SEC_ZIP_Parser.Classes
{
    public struct CompanyAddress
    {
        private AddressType type;
        private string city;
        private string stateOrCountry;
        private string street1;
        private string street2;
        private string zipCode;

        public AddressType Type => type;

        public string City => city;

        public string StateOrCountry => stateOrCountry;

        public string Street1 => street1;

        public string Street2 => street2;

        public string ZipCode => zipCode;
    }

    public enum AddressType
    {
        Business, Mailing, Other
    }
}
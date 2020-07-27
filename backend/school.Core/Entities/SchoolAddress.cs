namespace school.Core.Entities
{
    public class SchoolAddress
    {
        public string Id { get; set; }
        public string Type { get; set; }   //casa, oficina, etc
        public string Address { get; set; }
        public string PhoneLocal { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneOther { get; set; }
    }
}

using System;
namespace backend.Core.Entities
{
    public class SchoolContact
    {
        public string Id { get; set; }
        public string Type { get; set; }  //Gerente, interlocutor, secretaria, contcto
        public string Name { get; set; }
        public string Position { get; set; }
        public object Email { get; set; }
        public string PhoneLocal { get; set; }
        public string PhoneMobile { get; set; }
        public string Other { get; set; }
    }
}

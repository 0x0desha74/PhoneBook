using PhoneBook.Core.Entities;


namespace PhoneBook.Core.Specifications
{
   public class ContactWithAddressSpecifications : BaseSpecifications<Contact>
    {
        public ContactWithAddressSpecifications()
        {
            Includes.Add(c => c.Adresses);
        }
        public ContactWithAddressSpecifications(int id) : base(c => c.Id == id)
        {
            Includes.Add(c => c.Adresses);

        }
    }
}
    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressBooksystem
{
    internal class contactClass
    {
    }

    class ContactPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public void UpdateContact(ContactPerson updatedContact)
        {
            FirstName = updatedContact.FirstName;
            LastName = updatedContact.LastName;
            Address = updatedContact.Address;
            City = updatedContact.City;
            State = updatedContact.State;
            Zip = updatedContact.Zip;
            PhoneNumber = updatedContact.PhoneNumber;
            Email = updatedContact.Email;
        }
    }
}

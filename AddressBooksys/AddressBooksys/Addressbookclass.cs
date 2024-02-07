using addressBooksystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressBooksystem
{
   

    class AddressBook
    {
        private List<ContactPerson> contacts;

        public AddressBook()
        {
            contacts = new List<ContactPerson>();
        }

        public void AddContact(ContactPerson contact)
        {
            contacts.Add(contact);
        }

        public void DisplayContact(ContactPerson contact)
        {
            Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
            Console.WriteLine($"Address: {contact.Address}, {contact.City}, {contact.State} {contact.Zip}");
            Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine();
        }

        public ContactPerson FindContact(string firstName, string lastName)
        {
            return contacts.Find(c =>
                string.Equals(c.FirstName, firstName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(c.LastName, lastName, StringComparison.OrdinalIgnoreCase));
        }

        public void DisplayAllContacts()
        {
            foreach (var contact in contacts)
            {
                DisplayContact(contact);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressBooksystem
{
    internal class Program
    {

         static void welcome()
        {
            Console.WriteLine("Welcome to Address Book");
        }
        static void Main(string[] args)

        {
            welcome();  // welcome note

            AddressBook addressBook = new AddressBook();

            // Use Console to get details for a new contact
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter City: ");
            string city = Console.ReadLine();

            Console.Write("Enter State: ");
            string state = Console.ReadLine();

            Console.Write("Enter Zip Code: ");
            string zip = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            // Create a new contact using the entered details
            ContactPerson newContact = new ContactPerson
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                City = city,
                State = state,
                Zip = zip,
                PhoneNumber = phoneNumber,
                Email = email
            };

            // Add the new contact to the address book
            addressBook.AddContact(newContact);

            // Display the added contact
            Console.WriteLine("Contact Added:");
            addressBook.DisplayContact(newContact);

            // For simplicity, let's just pause the console application
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
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
    }

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
        }
    }

    //Console.WriteLine();
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace addressBooksystem
{
    internal class Program
    {
        private static void Welcome()
        {
            Console.WriteLine("Welcome to Address Book");
        }

        static void Main(string[] args)
        {
            Welcome();  // welcome note

            AddressBook addressBook = new AddressBook();

            // menu
            bool exit = false;
            while (!exit)
            {
                DisplayMenu();
                Console.Write("Enter your choice (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        
                        ContactPerson newContact = GetContactDetailsFromUser();
                        addressBook.AddContact(newContact);
                        Console.WriteLine("Contact Added:");
                        addressBook.DisplayContact(newContact);
                        break;

                    case "2":
                       
                        EditExistingContact(addressBook);
                        break;

                    case "3":
                        
                        DeletePerson(addressBook);
                        break;

                    case "4":
                        
                        Console.WriteLine("\nAll Contacts in Address Book:");
                        addressBook.DisplayAllContacts();
                        break;

                    case "5":
                        
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option (1-5).");
                        break;
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create a new contact");
            Console.WriteLine("2. Edit an existing contact");
            Console.WriteLine("3. Delete a contact");
            Console.WriteLine("4. Display all contacts");
            Console.WriteLine("5. Exit");
        }

        private static ContactPerson GetContactDetailsFromUser()
        {
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

            return new ContactPerson
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
        }

        private static void EditExistingContact(AddressBook addressBook)
        {
            Console.Write("Enter the First Name of the contact to edit: ");
            string editFirstName = Console.ReadLine();

            Console.Write("Enter the Last Name of the contact to edit: ");
            string editLastName = Console.ReadLine();

            
            ContactPerson existingContact = addressBook.FindContact(editFirstName, editLastName);

            if (existingContact != null)
            {
                
                Console.WriteLine("\nExisting Contact Details:");
                addressBook.DisplayContact(existingContact);

                
                ContactPerson updatedContact = GetContactDetailsFromUser();

                
                existingContact.UpdateContact(updatedContact);

                Console.WriteLine("Contact Updated:");
                addressBook.DisplayContact(existingContact);
            }
            else
            {
                Console.WriteLine("Contact not found. Unable to edit.");
            }
        }

        private static void DeletePerson(AddressBook addressBook)
        {
            Console.Write("Enter the First Name of the contact to delete: ");
            string deleteFirstName = Console.ReadLine();

            Console.Write("Enter the Last Name of the contact to delete: ");
            string deleteLastName = Console.ReadLine();

            
            ContactPerson contactToDelete = addressBook.FindContact(deleteFirstName, deleteLastName);

            if (contactToDelete != null)
            {
                
                Console.WriteLine("\nContact Details before Deletion:");
                addressBook.DisplayContact(contactToDelete);

                
                addressBook.DeleteContact(contactToDelete);

                Console.WriteLine("Contact Deleted.");
            }
            else
            {
                Console.WriteLine("Contact not found. Unable to delete.");
            }
        }
    }

    class ContactPerson
    {
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _city;
        private string _state;
        private string _zip;
        private string _phoneNumber;
        private string _email;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

       
        public void UpdateContact(ContactPerson updatedContact)
        {
            Address = updatedContact.Address;
            City = updatedContact.City;
            State = updatedContact.State;
            Zip = updatedContact.Zip;
            PhoneNumber = updatedContact.PhoneNumber;
            Email = updatedContact.Email;
        }
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
            Console.WriteLine();
        }

        
        public ContactPerson FindContact(string firstName, string lastName)
        {
            return contacts.Find(c =>
                string.Equals(c.FirstName, firstName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(c.LastName, lastName, StringComparison.OrdinalIgnoreCase));
        }

        
        public void DeleteContact(ContactPerson contact)
        {
            contacts.Remove(contact);
        }

        
        public void DisplayAllContacts()
        {
            foreach (var contact in contacts)
            {
                DisplayContact(contact);
            }
        }
    }

    //Console.WriteLine();
}







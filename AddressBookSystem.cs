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

            // Getting contact details from the user
            ContactPerson newContact = GetContactDetailsFromUser();

            // Adding the new contact to the address book
            addressBook.AddContact(newContact);

            Console.WriteLine("Contact Added:");
            addressBook.DisplayContact(newContact);

            // Editing an existing contact
            EditExistingContact(addressBook);

            // Deleting a person from the address book
            DeletePerson(addressBook);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
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

            // Find the contact in the address book
            ContactPerson existingContact = addressBook.FindContact(editFirstName, editLastName);

            if (existingContact != null)
            {
                // Display existing contact details
                Console.WriteLine("\nExisting Contact Details:");
                addressBook.DisplayContact(existingContact);

                // Get updated details from the user
                ContactPerson updatedContact = GetContactDetailsFromUser();

                // Update the existing contact
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

            // Find the contact in the address book
            ContactPerson contactToDelete = addressBook.FindContact(deleteFirstName, deleteLastName);

            if (contactToDelete != null)
            {
                // Display contact details before deletion
                Console.WriteLine("\nContact Details before Deletion:");
                addressBook.DisplayContact(contactToDelete);

                // Delete the contact
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // Method to update contact details
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

        // Method to find a contact by name
        public ContactPerson FindContact(string firstName, string lastName)
        {
            return contacts.Find(c =>
                string.Equals(c.FirstName, firstName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(c.LastName, lastName, StringComparison.OrdinalIgnoreCase));
        }

        // Method to delete a contact
        public void DeleteContact(ContactPerson contact)
        {
            contacts.Remove(contact);
        }
    }
}

//Console.WriteLine();





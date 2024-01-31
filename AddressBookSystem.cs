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
            Console.WriteLine("Welcome to Address Book System");
        }

        static void Main(string[] args)
        {
            Welcome();  // welcome note

            Dictionary<string, AddressBook> addressBooks = new Dictionary<string, AddressBook>();

            // Loop to show menu options
            bool exit = false;
            while (!exit)
            {
                DisplayMainMenu();
                Console.Write("Enter your choice (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Add a new address book
                        AddNewAddressBook(addressBooks);
                        break;

                    case "2":
                        // Operate on an existing address book
                        OperateOnAddressBook(addressBooks);
                        break;

                    case "3":
                        // Display all address books
                        DisplayAllAddressBooks(addressBooks);
                        break;

                    case "4":
                        // Exit the program
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option (1-4).");
                        break;
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void DisplayMainMenu()
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Add a new address book");
            Console.WriteLine("2. Operate on an existing address book");
            Console.WriteLine("3. Display all address books");
            Console.WriteLine("4. Exit");
        }

        private static void AddNewAddressBook(Dictionary<string, AddressBook> addressBooks)
        {
            Console.Write("Enter the name of the new address book: ");
            string newBookName = Console.ReadLine();

            if (!addressBooks.ContainsKey(newBookName))
            {
                AddressBook newAddressBook = new AddressBook();
                addressBooks.Add(newBookName, newAddressBook);
                Console.WriteLine($"Address Book '{newBookName}' added successfully.");
            }
            else
            {
                Console.WriteLine($"Address Book with the name '{newBookName}' already exists.");
            }
        }

        private static void OperateOnAddressBook(Dictionary<string, AddressBook> addressBooks)
        {
            Console.Write("Enter the name of the address book: ");
            string bookName = Console.ReadLine();

            if (addressBooks.TryGetValue(bookName, out AddressBook selectedAddressBook))
            {
                // Operate on the selected address book
                bool exitAddressBook = false;
                while (!exitAddressBook)
                {
                    DisplayAddressBookMenu(bookName);
                    Console.Write($"Enter your choice for '{bookName}' Address Book (1-4): ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            // Create a new contact in the selected address book
                            CreateNewContact(selectedAddressBook);
                            break;

                        case "2":
                            // Edit an existing contact
                            EditExistingContact(selectedAddressBook);
                            break;

                        case "3":
                            // Display all contacts in the address book
                            Console.WriteLine($"\nAll Contacts in '{bookName}' Address Book:");
                            selectedAddressBook.DisplayAllContacts();
                            break;

                        case "4":
                            // Exit the address book menu
                            exitAddressBook = true;
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option (1-4).");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine($"Address Book with the name '{bookName}' not found.");
            }
        }

        private static void DisplayAddressBookMenu(string bookName)
        {
            Console.WriteLine($"\nAddress Book Menu for '{bookName}':");
            Console.WriteLine("1. Create a new contact");
            Console.WriteLine("2. Edit an existing contact");
            Console.WriteLine("3. Display all contacts");
            Console.WriteLine("4. Exit");
        }

        private static void DisplayAllAddressBooks(Dictionary<string, AddressBook> addressBooks)
        {
            Console.WriteLine("\nAll Address Books:");
            foreach (var bookName in addressBooks.Keys)
            {
                Console.WriteLine($"- {bookName}");
            }
        }

        private static void CreateNewContact(AddressBook addressBook)
        {
            // Getting contact details from the user
            ContactPerson newContact = GetContactDetailsFromUser();

            // Adding the new contact to the address book
            addressBook.AddContact(newContact);

            Console.WriteLine("Contact Added:");
            addressBook.DisplayContact(newContact);
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

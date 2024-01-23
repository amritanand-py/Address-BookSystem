using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressBooksystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBookMain obj1 = new AddressBookMain();
            obj1.welcome();

            // first entry
            obj1.firstName = "Alex";
            obj1.lastName = "hales";
            obj1.phone = "9876543210";
            obj1.zip = "130013";
            obj1.state =  "Ohio";
            obj1.city = "LA";
            obj1.email = "abc@aplha.edu.in";

            

            

            Console.WriteLine(obj1.firstName);
            Console.WriteLine(obj1.lastName);
            Console.WriteLine(obj1.phone);
            Console.WriteLine(obj1.zip);
            Console.WriteLine(obj1.state);
            Console.WriteLine(obj1.city);
            Console.WriteLine(obj1.email);

        }
    }

    class AddressBookMain
    {
        public string firstName;
        public string lastName;
        public string city;
        public string state;
        public string zip;
        public string email;
        public String phone;

        public void welcome()
        {
            Console.WriteLine("Welcome to Address Book");
        }

        public void AddressBookmain(string fName, string lName, String City,String State,String Zip,String Email,String Phone)
        {
            firstName = fName;
            lastName = lName;
            city = City;
            state = State;
            zip = Zip;
            email = Email;
            phone = Phone;
        }

    }


}

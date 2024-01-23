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
        }
    }

    class AddressBookMain
    {
        public void welcome()
        {
            Console.WriteLine("Welcome to Address Book");
        }

    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookSystem
{
    internal class Menu
    {
        private PhoneBook phoneBook = new PhoneBook();

        public void Display()
        {
            while (true)
            {
                Console.WriteLine("Phone Book Menu:");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Remove Contact");
                Console.WriteLine("3. Search Contact");
                Console.WriteLine("4. Edit Contact");
                Console.WriteLine("5. Display All Contacts");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        RemoveContact();
                        break;
                    case "3":
                        SearchContact();
                        break;
                    case "4":
                        EditContact();
                        break;
                    case "5":
                        DisplayAllContacts();
                        break;
                    case "6":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please select again.");
                        break;
                }
            }
        }

        private void AddContact()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter phone number: ");
            string phoneNumber = Console.ReadLine();
            phoneBook.add(name, phoneNumber);
        }

        private void RemoveContact()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            phoneBook.remove(name);
        }

        private void SearchContact()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            phoneBook.search(name);
        }

        private void EditContact()
        {
            Console.Write("Enter old name: ");
            string oldName = Console.ReadLine();
            Console.Write("Enter new name: ");
            string newName = Console.ReadLine();
            Console.Write("Enter new phone number: ");
            string newPhoneNumber = Console.ReadLine();
            phoneBook.edit(oldName, newName, newPhoneNumber);
        }

        private void DisplayAllContacts()
        {
            phoneBook.displayAllContacts();
        }
    }

}


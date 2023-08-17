using PhoneBookSystem;

internal class Program
{
    private static void Main(string[] args)
    {
       
            Menu menu = new Menu();
            PhoneBook phoneBook = new PhoneBook();


            // Load contacts from JSON
            phoneBook.loadContactsFromJson();

            // Display the menu
            menu.Display();
        
    }
}
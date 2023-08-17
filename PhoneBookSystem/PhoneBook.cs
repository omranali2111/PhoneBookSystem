using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

internal class PhoneBook
{
    private const string FileName = "contacts.json"; 

    Dictionary<string, string> contactInfo = new Dictionary<string, string>();

    public void add(string name, string phoneNumber)
    {
        try
        {
            bool contactExists = contactInfo.Any(contact => contact.Key == name);

            if (!contactExists)
            {
                contactInfo[name] = phoneNumber;
                Console.WriteLine($"Contact '{name}' has been added with phone number '{phoneNumber}'.");
                saveContactsToJson();
            }
            else
            {
                Console.WriteLine($"A contact with name '{name}' already exists. Please choose a different name.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding contact: {ex.Message}");
        }
    }


    public void remove(string name)
    {
        if (contactInfo.ContainsKey(name))
        {
            contactInfo.Remove(name);
            Console.WriteLine($"Contact '{name}' has been deleted.");
            saveContactsToJson();
        }
        else
        {
            Console.WriteLine($"Contact '{name}' not found.");
        }
    }

    public void search(string name)
    {
        if (contactInfo.ContainsKey(name))
        {
            string phoneNumber = contactInfo[name];
            Console.WriteLine($"Contact found: '{name}' with phone number '{phoneNumber}'.");
        }
        else
        {
            Console.WriteLine($"Contact '{name}' not found.");
        }
    }

    public void edit(string oldName, string newName, string newPhoneNumber)
    {
        if (contactInfo.ContainsKey(oldName))
        {
            string phoneNumber = contactInfo[oldName];
            contactInfo.Remove(oldName);
            contactInfo[newName] = newPhoneNumber;
            Console.WriteLine($"Contact '{oldName}' has been edited to '{newName}' with new phone number '{newPhoneNumber}'.");
            saveContactsToJson();
        }
        else
        {
            Console.WriteLine($"Contact '{oldName}' not found.");
        }
    }
    public void displayAllContacts()
    {
        Dictionary<string, string> loadedContacts = loadContactsFromJson();
        DisplayContacts(loadedContacts);
    }
    private void DisplayContacts(Dictionary<string, string> contacts)
    {
        foreach (var contact in contacts)
        {
            Console.WriteLine($"Name: {contact.Key}, Phone Number: {contact.Value}");
        }
    }

    public void saveContactsToJson()
    {
        try
        {
            string json = JsonSerializer.Serialize(contactInfo, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FileName, json);
            Console.WriteLine("Contact information has been saved to JSON file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving contacts: {ex.Message}");
        }
    }

    public Dictionary<string, string> loadContactsFromJson()
    {
        try
        {
            //Dictionary<string, string> loadedContacts = new Dictionary<string, string>();

            if (File.Exists(FileName))
            {
                string json = File.ReadAllText(FileName);
                contactInfo = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                Console.WriteLine("Contact information has been loaded from JSON file.");
            }
            else
            {
                Console.WriteLine("No JSON file found. No contacts loaded.");
            }

            return contactInfo;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading contacts: {ex.Message}");
            return new Dictionary<string, string>();
        }
    }
}

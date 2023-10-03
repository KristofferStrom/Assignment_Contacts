using Assignment_Contacts.Interfaces;
using Assignment_Contacts.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace Assignment_Contacts.Services;

public class ContactService : IContactService
{
    private IFileService _fileService = new FileService();
    List<Contact> _contacts = new List<Contact>();
    private readonly string _filePath = "Contacts.json";
    public ContactService()
    {
        GetAllContactsFromFile();
    }

    private void GetAllContactsFromFile()
    {
        try
        {
            var allContactsJSON = _fileService.ReadFromFile(_filePath);

            if(allContactsJSON != null)
            {
                 _contacts = JsonConvert.DeserializeObject<List<Contact>>(allContactsJSON)!;
            }

        }
        catch { }

    }

    //List<IContact> _contacts = new List<IContact>
    //{
    //    new Contact
    //    {
    //        FirstName = "Kristoffer",
    //        LastName = "Ström",
    //        Email = "kristoffer.strom@hotmail.se",
    //        PhoneNumber = "1234567890",
    //        Address = new Address
    //        {
    //            StreetAddress = "Gubbängsvägen 90",
    //            PostalCode = "12345",
    //            City = "Enskede",
    //        }
    //    },
    //    new Contact
    //    {
    //        FirstName = "Kalle",
    //        LastName = "Ström",
    //        Email = "kalle.strom@hotmail.com",
    //        PhoneNumber = "1234522855",
    //        Address = new Address
    //        {
    //            StreetAddress = "Ringvägen 30",
    //            PostalCode = "12445",
    //            City = "Stockholm",
    //        }
    //    }

    //};
    public IContact CreateNewContact(Contact contact)
    {
        try
        {
            if(contact != null)
            {
                _contacts.Add(contact);

                Task.Run(() => _fileService.SaveToFileAsync(_filePath, JsonConvert.SerializeObject(_contacts)));

                return contact;
            }
        }
        catch { }

        return null!;
    }

    public List<Contact> GetAllContacts()
    {
        if (_contacts.Count == 0)
            return null!;

        return _contacts;
    }

    public IContact GetContact(string email)
    {
        var contact = _contacts.FirstOrDefault(contact => contact.Email == email);
        if (contact == null)
            return null!;

        return contact;
    }

    public bool RemoveContact(string email)
    {
        var contactToRemove = _contacts.FirstOrDefault(contact => contact.Email == email);

        if(contactToRemove == null)
            return false;
        
        _contacts.Remove(contactToRemove);
        return true;
    }
}

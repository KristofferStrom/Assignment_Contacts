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
        GetInitialContactsFromFile();
    }

    private void GetInitialContactsFromFile()
    {
        try
        {
            var allContactsJSON = _fileService.ReadFromFile(_filePath);

            if(allContactsJSON != null)
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(allContactsJSON)!;
        }
        catch { }
    }

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
        try
        {
            _contacts.Remove(contactToRemove);
            Task.Run(() => _fileService.SaveToFileAsync(_filePath, JsonConvert.SerializeObject(_contacts)));
            return true;
        }
        catch { }
        
        return false;
    }
}

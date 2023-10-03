
namespace Assignment_Contacts.Interfaces;

public interface IFileService
{
    Task SaveToFileAsync(string filePath, string content);
    string ReadFromFile(string filePath);
}

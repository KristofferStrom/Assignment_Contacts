
using Assignment_Contacts.Interfaces;

namespace Assignment_Contacts.Services;

public class FileService : IFileService
{
    //Hämtar all text från en fil
    public string ReadFromFile(string filePath)
    {
        try
        {
            if(File.Exists(filePath))
            {
                using StreamReader sr = new StreamReader(filePath);
                return sr.ReadToEnd();
            }
        }
        catch { }

        return null!;
    }

    //Skriver över all text i en fil. Skapar upp en fil om den inte redan existerar.
    public async Task SaveToFileAsync(string filePath, string content)
    {
        try
        {
            using StreamWriter sw = new StreamWriter(filePath);
            await sw.WriteLineAsync(content);
        }
        catch { }
    }
}

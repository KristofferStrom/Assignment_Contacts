namespace Assignment_Contacts.Interfaces;

public interface IUserInterfaceService
{
    void AddField(string message);
    void AddHeader(string title);
    void AddTableHeader(int columnLength, params string[] titles);
    void AddTableRow(int columnLength, params string[] row);
    string GetFieldInput(string title);
    string GetSelectedOption(params string[] options);
    void ReadKey();
}

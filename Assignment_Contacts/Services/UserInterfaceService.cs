using Assignment_Contacts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Contacts.Services
{
    public class UserInterfaceService : IUserInterfaceService
    {
        private readonly string _divider = CreateDivider(200);

        public void AddHeader(string title)
        {
            Console.Clear();
            Console.WriteLine(title);
            Console.WriteLine(_divider[..title.Length]);
        }

        public void AddTableHeader(int columnLength, params string[] titles)
        {
            var sb = new StringBuilder();
            foreach (var title in titles)
            {
                sb.Append(CreateColumn(columnLength, title));
            }

            Console.WriteLine(sb);
            Console.WriteLine(_divider[..(sb.Length - 1)]);

        }

        private string CreateColumn(int columnLength, string tableItem)
        {
            var whiteSpace = "                                    ";
            if (tableItem.Length >= columnLength)
            {
                return tableItem[..(columnLength - 4)] + "... ";
            }

            if (tableItem.Length < columnLength)
            {
                return tableItem + whiteSpace[..(columnLength - tableItem.Length)];
            }

            return tableItem;
        }

        public string GetFieldInput(string title)
        {
            Console.Write($"{title}: ");
            return Console.ReadLine()!;
        }

        public string GetSelectedOption(params string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1} {options[i]}");
            }
            Console.WriteLine(_divider[..27]);
            Console.Write("Välj något av alternativen: ");

            return Console.ReadLine()!;
        }

        public void AddTableRow(int columnLength, params string[] row)
        {
            var sb = new StringBuilder();

            foreach (var item in row)
            {
                sb.Append(CreateColumn(columnLength, item));
            }

            Console.WriteLine(sb);
        }

        public void ReadKey()
        {
            Console.ReadKey();
        }

        private static string CreateDivider(int length)
        {
            string divider = "";
            for (int i = 0; i < length; i++)
            {
                divider += "-";
            }

            return divider;
        }

        public void AddField(string message)
        {
            Console.WriteLine(message);
        }
    }
}

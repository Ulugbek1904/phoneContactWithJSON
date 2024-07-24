using phoneContactWithJSON.Models;
using System.Text.Json;

namespace phoneContactWithJSON.Services
{
    internal class JSONServices : IJSONServices
    {
        private const string filePath =
            "../../../phoneContacts.json";

        private ILoggingServices loggingServices;
        public JSONServices()
        {
            this.loggingServices =
                new LoggingServices();

            EnsureFileExist();
        }

        public List<PhoneContact> ReadContacts()
        {
            try
            {
                var fileContent = File.ReadAllText(filePath);
                var contacts = JsonSerializer.Deserialize<List<PhoneContact>>(fileContent);
                return contacts ?? new List<PhoneContact>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON deserialization error: {ex.Message}");
                return new List<PhoneContact>();
            }
        }

        public void AddContact(PhoneContact contact)
        {
            var contacts = ReadContacts();
            contacts.Add(contact);

            var jsonString = JsonSerializer.Serialize
                (contacts, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filePath, jsonString);
        }

        public void SaveAllContacts(List<PhoneContact> contacts)
        {
            var lines = contacts.Select(contact =>
            $"Name: {contact.Name} Number: " +
            $"{contact.PhoneNumber}");

            File.WriteAllLines(filePath, lines);
        }

        private static void EnsureFileExist()
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }
    }
}

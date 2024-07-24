using phoneContactWithJSON.Models;

namespace phoneContactWithJSON.Services
{
    public interface IJSONServices
    {
        void AddContact(PhoneContact contacts);
        List<PhoneContact> ReadContacts();
        void SaveAllContacts(List<PhoneContact> contacts);
    }
}
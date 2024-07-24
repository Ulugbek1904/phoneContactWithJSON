namespace phoneContactWithJSON.Services
{
    public interface IContactServices
    {
        void ShowAllContacts();
        void SearchContact();
        void AddContact();
        void DeleteContact();
        void EditContact();
    }
}
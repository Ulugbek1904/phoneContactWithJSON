namespace phoneContactWithJSON.Services
{
    internal class HomeServices : IHomeServices
    {
        IContactServices contactServices;
        IJSONServices jsonServices;
        ILoggingServices loggingServices;
        public HomeServices()
        {
            this.contactServices = new ContactServices();
            this.jsonServices = new JSONServices();
            this.loggingServices = new LoggingServices();
        }

        public void LoadMenu()
        {
            while (true)
            {
                string menu = "" +
                    "1. My Contacts\n" +
                    "2. Search contact\n" +
                    "3. Add contact\n" +
                    "4. update contact\n" +
                    "5. delete contact\n" +
                    "6. Exit\n";

                this.loggingServices.LogInfo(
                    "====== Menu ======\n");

                this.loggingServices.
                    LogInfo(menu);

                this.loggingServices.
                    LogInfo("Choose one : ");
                try
                {
                    string userInput = Console.ReadLine();
                    int intInput = int.Parse(userInput);
                    switch (intInput)
                    {
                        case 1:
                            contactServices.ShowAllContacts();
                            break;
                        case 2:
                            contactServices.SearchContact();
                            break;
                        case 3:
                            contactServices.AddContact();
                            break;
                        case 4:
                            contactServices.EditContact();
                            break;
                        case 5:
                            contactServices.DeleteContact();
                            break;
                        case 6:
                            Exit();
                            break;
                        default:
                            throw new
                                ArgumentOutOfRangeException();
                    }
                }
                catch (ArgumentOutOfRangeException exc)
                {
                    loggingServices.LogError(
                        $"{exc.Message}. Try again");
                }
                catch (Exception exc)
                {
                    loggingServices.LogError(
                        $"{exc.Message}. Try again");
                }
            }
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}


using DataVerseManager.Services;
using DataVerseManager.UI;

namespace DataVerseManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to JSON file
            string filePath = "Data/userprofile.json";

            // Create the service using the correct class
            UserProfileService profileService = new UserProfileService(filePath);

            // Create UI menus
            ProfileMenu profileMenu = new ProfileMenu(profileService);
            MainMenu mainMenu = new MainMenu(profileMenu);

            // Start the program
            mainMenu.Show();
        }
    }
}


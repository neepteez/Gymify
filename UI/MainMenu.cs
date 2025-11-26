using Spectre.Console;
using DataVerseManager.UI;
using DataVerseManager.Services;

namespace DataVerseManager.UI
{
    public class MainMenu
    {
        private readonly ProfileMenu _profileMenu;

        public MainMenu(ProfileMenu profileMenu)
        {
            _profileMenu = profileMenu;
        }

        public void Show()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();

                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]Welcome to GymiFy[/]")
                        .PageSize(10)
                        .AddChoices(new[]
                        {
                            "Manage User Profile",
                            "Settings",
                            "Exit Program"
                        }));

                switch (choice)
                {
                    case "Manage User Profile":
                        _profileMenu.Show();
                        break;

                    case "Settings":
                        ShowSettings();
                        break;

                    case "Exit Program":
                        running = false;
                        break;
                }
            }
        }

        private void ShowSettings()
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[blue]Settings are not implemented yet.[/]");
            AnsiConsole.MarkupLine("Press any key to return...");
            Console.ReadKey();
        }
    }
}

using System;
using DataVerseManager.Models;
using DataVerseManager.Services;
using Spectre.Console;

namespace DataVerseManager.UI
{
    public class ProfileMenu
    {
        private readonly UserProfileService _profileService;

        public ProfileMenu(UserProfileService profileService)
        {
            _profileService = profileService;
        }

        public void Show()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();

                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[bold yellow]👤 User Profile Menu[/]")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to select)[/]")
                        .AddChoices("View Profile", "Update Profile", "Exit"));

                switch (choice)
                {
                    case "View Profile":
                        ViewProfile();
                        break;

                    case "Update Profile":
                        UpdateProfile();
                        break;

                    case "Exit":
                        running = false;
                        break;
                }
            }
        }

        private void ViewProfile()
        {
            var profile = _profileService.LoadProfile();
            Console.Clear();

            var table = new Table()
                .Border(TableBorder.Rounded)
                .BorderColor(Color.Green)
                .AddColumn("[yellow]Field[/]")
                .AddColumn("[cyan]Value[/]")
                .AddRow("Age", profile.Age.ToString())
                .AddRow("Length (cm)", profile.Length.ToString())
                .AddRow("Weight (kg)", profile.Weight.ToString())
                .AddRow("Measurements", profile.Measurements ?? "None")
                .AddRow("Description", profile.Description ?? "None");

            var panel = new Panel(table)
                .Header("[bold green]Your Profile[/]")
                .BorderColor(Color.Aqua)
                .Padding(1, 1, 1, 1);

            AnsiConsole.Write(panel);

            AnsiConsole.MarkupLine("\n[grey]Press any key to return...[/]");
            Console.ReadKey();
        }

        private void UpdateProfile()
        {
            Console.Clear();

            int age = AnsiConsole.Ask<int>("Enter your [green]Age[/]:");
            int length = AnsiConsole.Ask<int>("Enter your [green]Length (cm)[/]:");
            int weight = AnsiConsole.Ask<int>("Enter your [green]Weight (kg)[/]:");
            string measurements = AnsiConsole.Ask<string>("Enter your [green]Measurements[/]:");
            string description = AnsiConsole.Ask<string>("Enter your [green]Description[/]:");

            UserProfile profile = new UserProfile
            {
                Age = age,
                Length = length,
                Weight = weight,
                Measurements = measurements,
                Description = description
            };

            _profileService.SaveProfile(profile);

            AnsiConsole.MarkupLine("\n[green]Profile updated and saved![/]");
            Console.ReadKey();
        }
    }
}





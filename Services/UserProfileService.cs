using System.IO;
using System.Text.Json;
using DataVerseManager.Models;

namespace DataVerseManager.Services
{
    public class UserProfileService
    {
        private readonly string filePath;

        // ADD THIS — constructor with filePath
        public UserProfileService(string filePath)
        {
            this.filePath = filePath;
        }

        public UserProfile LoadProfile()
        {
            if (!File.Exists(filePath))
                return new UserProfile();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<UserProfile>(json)!;
        }

        public void SaveProfile(UserProfile profile)
        {
            string json = JsonSerializer.Serialize(profile, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
            File.WriteAllText(filePath, json);
        }
    }
}









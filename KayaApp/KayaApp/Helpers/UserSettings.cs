using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace KayaApp.Helpers
{
    public class UserSettings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string UserCompanyName
        {
            get => AppSettings.GetValueOrDefault(nameof(UserCompanyName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserCompanyName), value);
        }
        public static string UserName
        {
            get => AppSettings.GetValueOrDefault(nameof(UserName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserName), value);
        }
        public static string UserPass
        {
            get => AppSettings.GetValueOrDefault(nameof(UserPass), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserPass), value);
        }


    }
}

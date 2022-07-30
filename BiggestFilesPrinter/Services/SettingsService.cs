using Microsoft.Extensions.Configuration;

namespace BiggestFilesPrinter;

public class SettingsService
{
    public static Settings Get()
    {
        var appSettings = new Settings();
        var configPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
        if (File.Exists(configPath))
        {
            var config = new ConfigurationBuilder().AddJsonFile(configPath).Build();
            config.GetSection(Settings.AppSettings).Bind(appSettings);
        }

        return appSettings;
    }
}


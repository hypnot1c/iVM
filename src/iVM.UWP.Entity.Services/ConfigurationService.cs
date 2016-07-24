using iVM.Core.Entity.Services;
using System;
using Windows.Data.Json;
using Windows.Storage;


namespace iVM.UWP.Entity.Services
{
  public class ConfigurationService : IConfigurationService
  {
    private JsonObject config;

    public ConfigurationService() : this("settings.json")
    {
    }
    public ConfigurationService(string configFile)
    {
      this.LoadConfig(configFile);
    }

    private async void LoadConfig(string configFile)
    {
      var packageFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
      var file = await packageFolder.GetFileAsync(configFile);
      var configContent = await FileIO.ReadTextAsync(file);
      this.config = JsonObject.Parse(configContent);
    }
    public double GetNumber(string key)
    {
      return this.config[key].GetNumber();
    }
  }
}

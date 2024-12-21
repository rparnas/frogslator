namespace Frogslator;

internal class StringSetting
{
  readonly Settings Settings;
  readonly string PropertyName;

  public StringSetting(Settings settings, string propertyName)
  {
    Settings = settings;
    PropertyName = propertyName;
  }

  public string? Get()
  {
    return (string?)Settings[PropertyName];
  }

  public void Set(string value)
  {
    Settings[PropertyName] = value;
    Settings.Save();
  }
}

namespace Frogslator;

public class Translation
{
  public readonly int Address;
  public string Notes;
  public bool Skip;
  public string Text;

  public Translation(int address)
  {
    Address = address;
    Notes = string.Empty;
    Skip = Parser.UnusedLines.Contains(address);
    Text = string.Empty;
  }
}

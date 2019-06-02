using System.Collections.Generic;

namespace Frog
{
  public class Translation
  {
    public readonly int Address;
    public string Notes;
    public bool Skip;
    public string Text;

    public Translation(int address)
    {
      Address = address;
      Notes = "";
      Skip = false;
      Text = "";
    }
  }
}

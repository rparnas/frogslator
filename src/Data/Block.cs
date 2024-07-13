namespace Frogslator;

internal class Block
{
  public readonly int Start;
  public readonly int Stop;

  public int Length => Stop - Start;

  public Block(int start, int stop)
  {
    Start = start;
    Stop = stop;
  }
}

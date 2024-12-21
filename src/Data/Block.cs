namespace Frogslator;

internal record Block(
  int Start,
  int Stop)
{
  public int Length => Stop - Start;
}

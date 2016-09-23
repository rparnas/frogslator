using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Frog
{
  class State
  {
    // States to transition to.
    State[] states;

    // Dictionary which makes up the state table.
    Dictionary<string, Pair> stateTable;

    // Create a new state based on the given filename.
    public State(string fileName, State[] s)
    {
      states = s;
      stateTable = new Dictionary<string, Pair>();

      // Load in the state file.
      StreamReader reader = File.OpenText(fileName);

      // Ignore the first line.
      string line = reader.ReadLine();
      while ((line = reader.ReadLine()) != null)
      {
        var items = line.Split(new char[] { '\t' });

        // If it is a hex number
        var input = items[0].StartsWith("0x") ? int.Parse(items[0].Substring(2, items[0].Length - 2), System.Globalization.NumberStyles.HexNumber).ToString() : items[0];
        var output = items[1];
        var nextState = int.Parse(items[2]);

        stateTable.Add(input, new Pair(output, nextState));
      }
      reader.Close();
    }

    // Given the byte input, return the output string and the next state.
    public void Transition(byte input, out string output, out State nextState)
    {
      var p = stateTable[input.ToString()];
      output = p.output;
      nextState = states[p.nextState];
    }

    public void Transition(string input, out string output, out State nextState)
    {
      if (stateTable.ContainsKey(input))
      {
        var p = stateTable[input];
        output = p.output;
        nextState = states[p.nextState];
      }
      else
      {
        output = "0x00";
        nextState = states[0];
      }
    }

    public bool ContainsKey(string input)
    {
      return stateTable.ContainsKey(input);
    }

    struct Pair
    {
      public Pair(string o, int n)
      {
        output = o;
        nextState = n;
      }

      public string output;
      public int nextState;
    }
  }
}
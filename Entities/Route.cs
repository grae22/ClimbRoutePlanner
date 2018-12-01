using System.Collections.Generic;
using System.Linq;

namespace CRP.Entities
{
  internal class Route
  {
    public string Name { get; }
    public List<Pitch> Pitches { get; }

    public Route(in string name, in IEnumerable<Pitch> pitches)
    {
      Name = name;
      Pitches = pitches.ToList();
    }
  }
}

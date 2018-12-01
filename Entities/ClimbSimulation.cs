using System.Collections.Generic;
using System.Linq;

using CRP.Interfaces;
using CRP.Logic;

using Newtonsoft.Json;

namespace CRP.Entities
{
  internal class ClimbSimulation
  {
    [JsonProperty]
    private readonly List<GearCarrier> _climbers;

    [JsonProperty]
    private readonly Route _route;

    [JsonProperty]
    private readonly IGearAssignmentRegistry _gearAssignmentRegistry;

    public ClimbSimulation(
      in IEnumerable<GearCarrier> climbers,
      in Route route,
      in IGearAssignmentRegistry gearAssignmentRegistry)
    {
      _climbers = climbers.ToList();
      _route = route;
      _gearAssignmentRegistry = gearAssignmentRegistry;
    }

    public void AddClimber(in GearCarrier climber)
    {
      _climbers.Add(climber);
    }
  }
}

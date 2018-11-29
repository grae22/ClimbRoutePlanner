using System.Collections.Generic;

namespace CRP.Entities
{
  internal class ClimbSimulation
  {
    private readonly List<GearCarrier> _climbers = new List<GearCarrier>();

    public void AddClimber(in GearCarrier climber)
    {
      _climbers.Add(climber);
    }
  }
}

using System.Collections.Generic;
using CRP.Entities;
using CRP.Interfaces;

namespace CRP.Logic
{
  internal class GearAssignmentRegistry : IGearAssignmentRegistry
  {
    public IReadOnlyDictionary<GearItem, GearCarrier> AssigneesByItem => _assignmentRegistry.AssigneesByItem;

    private readonly AssignmentRegistry<GearItem, GearCarrier> _assignmentRegistry = new AssignmentRegistry<GearItem, GearCarrier>();

    public void Assign(in GearItem item, in GearCarrier carrier)
    {
      _assignmentRegistry.Assign(item, carrier);
    }

    public void Transfer(
      in GearItem item,
      in GearCarrier sourceCarrier,
      in GearCarrier destinationCarrier)
    {
      _assignmentRegistry.Transfer(
        item,
        sourceCarrier,
        destinationCarrier);
    }
  }
}

using CRP.Entities;

namespace CRP.Interfaces
{
  internal interface IGearAssignmentRegistry
  {
    void Assign(in GearItem item, in GearCarrier assignee);

    void Transfer(
      in GearItem item,
      in GearCarrier sourceCarrier,
      in GearCarrier destinationCarrier);
  }
}

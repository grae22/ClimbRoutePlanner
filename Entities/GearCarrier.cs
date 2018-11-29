using CRP.Interfaces;

namespace CRP.Entities
{
  internal class GearCarrier
  {
    public int Id { get; }
    public string Name { get; }
    public Location Location { get; private set; }

    private readonly IGearAssignmentRegistry _gearAssignmentRegistry;

    public GearCarrier(
      in int id,
      in string name,
      in IGearAssignmentRegistry gearAssignmentRegistry)
    {
      Id = id;
      Name = name;
      
      _gearAssignmentRegistry = gearAssignmentRegistry;
    }

    public void AssignItem(GearItem item)
    {
      _gearAssignmentRegistry.Assign(item, this);
    }

    public void TransferItem(GearItem item, GearCarrier newCarrier)
    {
      if (Location != newCarrier.Location)
      {
        return;
      }

      _gearAssignmentRegistry.Transfer(
        item,
        this,
        newCarrier);
    }

    public void ChangeLocation(in Location location)
    {
      Location = location;
    }
  }
}

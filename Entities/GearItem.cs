namespace CRP.Entities
{
  internal class GearItem
  {
    public int Id { get; }
    public string Name { get; }

    public GearItem(
      in int id,
      in string name)
    {
      Id = id;
      Name = name;
    }
  }
}

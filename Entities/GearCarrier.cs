namespace CRP.Entities
{
  internal class GearCarrier
  {
    public int Id { get; }
    public string Name { get; }

    public GearCarrier(
      in int id,
      in string name)
    {
      Id = id;
      Name = name;
    }
  }
}

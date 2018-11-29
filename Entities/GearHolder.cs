namespace CRP.Entities
{
  internal class GearHolder
  {
    public int Id { get; }
    public string Name { get; }

    public GearHolder(
      in int id,
      in string name)
    {
      Id = id;
      Name = name;
    }
  }
}

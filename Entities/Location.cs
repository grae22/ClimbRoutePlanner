namespace CRP.Entities
{
  internal class Location
  {
    public int Id { get; }
    public string Name { get; }

    public Location(
      in int id,
      in string name)
    {
      Id = id;
      Name = name;
    }

    public override string ToString()
    {
      return $"Id=\"{Id}\",Name=\"{Name}\"";
    }
  }
}

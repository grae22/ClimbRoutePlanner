namespace CRP.Entities
{
  internal class Pitch
  {
    public string Name { get; }
    public Location Location { get; }
    public GearCarrier Protection { get; }

    public Pitch(in string name, in Location location)
    {
      Name = name;
      Location = location;
    }
  }
}

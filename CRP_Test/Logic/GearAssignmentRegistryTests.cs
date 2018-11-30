using CRP.Entities;
using CRP.Exceptions;
using CRP.Logic;

using NUnit.Framework;

namespace CRP_Test.Logic
{
  [TestFixture]
  public class GearAssignmentRegistryTests
  {
    [Test]
    public void Transfer_GivenCarriersAtDifferentLocations_ShouldRaiseException()
    {
      // Arrange.
      var testObject = new GearAssignmentRegistry();
      var carrier1 = new GearCarrier(0, "C1", testObject);
      var carrier2 = new GearCarrier(1, "C2", testObject);
      var item = new GearItem(0, "I1");
      var location1 = new Location(0, "L1");
      var location2 = new Location(1, "L2");

      carrier1.AssignItem(item);

      carrier1.ChangeLocation(location1);
      carrier2.ChangeLocation(location2);

      // Act.
      // Assert.
      try
      {
        carrier1.TransferItem(item, carrier2);
      }
      catch (AssignmentRegistryException)
      {
        Assert.Pass();
      }

      Assert.Fail();
    }
  }
}

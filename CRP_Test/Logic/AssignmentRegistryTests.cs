using CRP.Entities;
using CRP.Logic;

using NUnit.Framework;

namespace CRP_Test.Logic
{
  [TestFixture]
  public class AssignmentRegistryTests
  {
    [Test]
    public void Assign_GivenNoCurrentCarrier_ShouldAssignToSpecifiedCarrier()
    {
      // Arrange.
      var testObject = new AssignmentRegistry<GearItem, GearCarrier>();
      var gearItem = new GearItem(0, "Item1");
      var newCarrier = new GearCarrier(0, "Carrier1");

      // Act.
      testObject.Assign(gearItem, newCarrier);

      // Assert.
      Assert.AreSame(newCarrier, testObject.AssigneesByItem[gearItem]);
    }

    [Test]
    public void Assign_GivenCurrentCarrier_ShouldAssignToNewCarrier()
    {
      // Arrange.
      var testObject = new AssignmentRegistry<GearItem, GearCarrier>();
      var gearItem = new GearItem(0, "Item1");
      var oldCarrier = new GearCarrier(0, "Carrier1");
      var newCarrier = new GearCarrier(0, "Carrier2");

      testObject.Assign(gearItem, oldCarrier);

      // Act.
      testObject.Assign(gearItem, newCarrier);

      // Assert.
      Assert.AreSame(newCarrier, testObject.AssigneesByItem[gearItem]);
    }
  }
}

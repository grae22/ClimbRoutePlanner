using CRP.Entities;
using CRP.Logic;

using NUnit.Framework;

namespace CRP_Test.Logic
{
  [TestFixture]
  public class AssignmentRegistryTests
  {
    [Test]
    public void Assign_GivenNoCurrentHolder_ShouldAssignToSpecifiedHolder()
    {
      // Arrange.
      var testObject = new AssignmentRegistry<GearItem, GearHolder>();
      var gearItem = new GearItem(0, "Item1");
      var newHolder = new GearHolder(0, "Holder1");

      // Act.
      testObject.Assign(gearItem, newHolder);

      // Assert.
      Assert.AreSame(newHolder, testObject.HoldersByItem[gearItem]);
    }

    [Test]
    public void Assign_GivenCurrentHolder_ShouldAssignToNewHolder()
    {
      // Arrange.
      var testObject = new AssignmentRegistry<GearItem, GearHolder>();
      var gearItem = new GearItem(0, "Item1");
      var oldHolder = new GearHolder(0, "Holder1");
      var newHolder = new GearHolder(0, "Holder2");

      testObject.Assign(gearItem, oldHolder);

      // Act.
      testObject.Assign(gearItem, newHolder);

      // Assert.
      Assert.AreSame(newHolder, testObject.HoldersByItem[gearItem]);
    }
  }
}

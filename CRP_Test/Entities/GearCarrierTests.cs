using CRP.Entities;
using CRP.Interfaces;

using NSubstitute;

using NUnit.Framework;

namespace CRP_Test.Entities
{
  [TestFixture]
  public class GearCarrierTests
  {
    [Test]
    public void AssignItem_GivenItem_ShouldAssignToSelf()
    {
      // Arrange.
      var gearItem = new GearItem(0, "I1");
      var gearRegistry = Substitute.For<IGearAssignmentRegistry>();
      var testObject = new GearCarrier(0, "C1", gearRegistry);

      // Act.
      testObject.AssignItem(gearItem);

      // Assert.
      gearRegistry.Received().Assign(gearItem, testObject);
    }

    [Test]
    public void TransferItem_GivenItemToTransferToAnotherCarrier_ShouldTransferTheItem()
    {
      // Arrange.
      var gearRegistry = Substitute.For<IGearAssignmentRegistry>();
      var gearItem = new GearItem(0, "I1");
      var originalCarrier = new GearCarrier(0, "C1", gearRegistry);
      var newCarrier = new GearCarrier(0, "C2", gearRegistry);

      originalCarrier.AssignItem(gearItem);

      // Act.
      originalCarrier.TransferItem(gearItem, newCarrier);

      // Assert.
      gearRegistry.Received().Transfer(gearItem, originalCarrier, newCarrier);
    }
  }
}

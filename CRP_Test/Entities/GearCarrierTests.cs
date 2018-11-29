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
    public void Constructor_GivenNothing_ShouldHaveNullLocation()
    {
      // Arrange.
      var gearRegistry = Substitute.For<IGearAssignmentRegistry>();

      // Act.
      var testObject = new GearCarrier(0, "C1", gearRegistry);

      // Assert.
      Assert.IsNull(testObject.Location);
    }

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

    [Test]
    public void TransferItem_GivenDifferentLocations_ShouldNotTransferTheItem()
    {
      // Arrange.
      var gearRegistry = Substitute.For<IGearAssignmentRegistry>();
      var gearItem = new GearItem(0, "I1");
      var originalCarrier = new GearCarrier(0, "C1", gearRegistry);
      var newCarrier = new GearCarrier(0, "C2", gearRegistry);
      var location1 = new Location(0, "L1");
      var location2 = new Location(1, "L2");

      originalCarrier.AssignItem(gearItem);
      originalCarrier.ChangeLocation(location1);

      newCarrier.ChangeLocation(location2);

      // Act.
      originalCarrier.TransferItem(gearItem, newCarrier);

      // Assert.
      gearRegistry.Received(0).Transfer(gearItem, originalCarrier, newCarrier);
    }

    [Test]
    public void ChangeLocation_GivenNewLocation_ShouldUpdateLocation()
    {
      // Arrange.
      var gearRegistry = Substitute.For<IGearAssignmentRegistry>();
      var testObject = new GearCarrier(0, "C1", gearRegistry);
      var newLocation = new Location(0, "L1");

      // Act.
      testObject.ChangeLocation(newLocation);

      // Assert.
      Assert.AreSame(newLocation, testObject.Location);
    }
  }
}

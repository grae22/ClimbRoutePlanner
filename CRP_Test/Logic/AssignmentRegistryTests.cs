using System;
using CRP.Exceptions;
using CRP.Logic;
using NSubstitute.ExceptionExtensions;
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
      var testObject = new AssignmentRegistry<object, object>();
      var item = new object();
      var assignee = new object();

      // Act.
      testObject.Assign(item, assignee);

      // Assert.
      Assert.AreSame(assignee, testObject.AssigneesByItem[item]);
    }

    [Test]
    public void Assign_GivenCurrentCarrier_ShouldAssignToNewCarrier()
    {
      // Arrange.
      var testObject = new AssignmentRegistry<object, object>();
      var item = new object();
      var assignee = new object();
      var newAssignee = new object();

      testObject.Assign(item, assignee);

      // Act.
      testObject.Assign(item, newAssignee);

      // Assert.
      Assert.AreSame(newAssignee, testObject.AssigneesByItem[item]);
    }

    [Test]
    public void Transfer_GivenCurrentCarrier_ShouldAssignToNewCarrier()
    {
      // Arrange.
      var testObject = new AssignmentRegistry<object, object>();
      var item = new object();
      var originalAssignee = new object();
      var newAssignee = new object();

      testObject.Assign(item, originalAssignee);

      // Act.
      testObject.Transfer(item, originalAssignee, newAssignee);

      // Assert.
      Assert.AreSame(newAssignee, testObject.AssigneesByItem[item]);
    }

    [Test]
    public void Transfer_GivenItemNotAssignedToCurrentCarrier_ShouldRaiseException()
    {
      // Arrange.
      var testObject = new AssignmentRegistry<object, object>();
      var item = new object();
      var originalAssignee = new object();
      var newAssignee = new object();

      // Act.
      // Assert.
      try
      {
        testObject.Transfer(item, originalAssignee, newAssignee);
      }
      catch (AssignmentRegistryException)
      {
        Assert.Pass();
      }

      Assert.Fail();
    }
  }
}

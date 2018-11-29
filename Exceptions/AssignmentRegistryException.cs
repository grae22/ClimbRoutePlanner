using System;

namespace CRP.Exceptions
{
  internal class AssignmentRegistryException : Exception
  {
    public static AssignmentRegistryException Create<TAssignedItem, TAssignee>(
      string message,
      TAssignedItem item,
      TAssignee assignee)
    {
      return new AssignmentRegistryException(
        $"{message} | Assigned item: {item} | Assignee: {assignee} |");
    }

    public AssignmentRegistryException(string message)
    :
      base(message)
    {
    }
  }
}

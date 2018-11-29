using System;
using System.Collections.Generic;

using CRP.Exceptions;

namespace CRP.Logic
{
  internal class AssignmentRegistry<TAssignedItem, TAssignee>
  {
    public IReadOnlyDictionary<TAssignedItem, TAssignee> AssigneesByItem => _assigneesByItem;

    private readonly Dictionary<TAssignedItem, TAssignee> _assigneesByItem = new Dictionary<TAssignedItem, TAssignee>();

    public void Assign(in TAssignedItem item, in TAssignee assignee)
    {
      if (item == null)
      {
        throw new ArgumentNullException(nameof(item));
      }

      if (assignee == null)
      {
        throw new ArgumentNullException(nameof(assignee));
      }

      if (!_assigneesByItem.ContainsKey(item))
      {
        _assigneesByItem.Add(item, assignee);
        return;
      }

      _assigneesByItem[item] = assignee;
    }

    public void Transfer(
      in TAssignedItem item,
      in TAssignee originalAssignee,
      in TAssignee newAssignee)
    {
      if (item == null)
      {
        throw new ArgumentNullException(nameof(item));
      }

      if (originalAssignee == null)
      {
        throw new ArgumentNullException(nameof(originalAssignee));
      }

      if (newAssignee == null)
      {
        throw new ArgumentNullException(nameof(newAssignee));
      }

      if (!_assigneesByItem.ContainsKey(item))
      {
        throw AssignmentRegistryException.Create(
          "Item is not assigned.",
          item,
          newAssignee);
      }

      if (!Equals(_assigneesByItem[item], originalAssignee))
      {
        throw AssignmentRegistryException.Create(
          "Attempting to transfer an item that is not assigned to the specified original assignee.",
          item,
          newAssignee);
      }

      _assigneesByItem[item] = newAssignee;
    }
  }
}

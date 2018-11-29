using System;
using System.Collections.Generic;

namespace CRP.Logic
{
  internal class AssignmentRegistry<TAssignedItem, TAssignee>
  {
    public IReadOnlyDictionary<TAssignedItem, TAssignee> AssigneesByItem => _assigneesByItem;

    private readonly Dictionary<TAssignedItem, TAssignee> _assigneesByItem = new Dictionary<TAssignedItem, TAssignee>();

    public void Assign(TAssignedItem gearItem, TAssignee newAssignee)
    {
      if (gearItem == null)
      {
        throw new ArgumentNullException(nameof(gearItem));
      }

      if (newAssignee == null)
      {
        throw new ArgumentNullException(nameof(newAssignee));
      }

      if (!_assigneesByItem.ContainsKey(gearItem))
      {
        _assigneesByItem.Add(gearItem, newAssignee);
        return;
      }

      _assigneesByItem[gearItem] = newAssignee;
    }
  }
}

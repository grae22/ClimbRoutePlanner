using System;
using System.Collections.Generic;

namespace CRP.Logic
{
  internal class AssignmentRegistry<TAssignedItem, TAssignee>
  {
    public IReadOnlyDictionary<TAssignedItem, TAssignee> HoldersByItem => _holdersByItem;

    private readonly Dictionary<TAssignedItem, TAssignee> _holdersByItem = new Dictionary<TAssignedItem, TAssignee>();

    public void Assign(TAssignedItem gearItem, TAssignee newHolder)
    {
      if (gearItem == null)
      {
        throw new ArgumentNullException(nameof(gearItem));
      }

      if (newHolder == null)
      {
        throw new ArgumentNullException(nameof(newHolder));
      }

      if (!_holdersByItem.ContainsKey(gearItem))
      {
        _holdersByItem.Add(gearItem, newHolder);
        return;
      }

      _holdersByItem[gearItem] = newHolder;
    }
  }
}

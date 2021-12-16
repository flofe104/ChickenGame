using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItem<ItemBehaviour, ItemStats> : MonoBehaviour
    where ItemStats : InstantiatableBehaviourItem<ItemBehaviour, ItemStats>
    where ItemBehaviour : EquippedItem<ItemBehaviour, ItemStats>
{

    protected ItemStats item;

    public ItemStats Item
    {
        get
        {
            return item;
        }
        set
        {
            item = value;
            OnItemStatsAssigned(item);
        }
    }

    protected virtual void OnItemStatsAssigned(ItemStats stats) { }


}
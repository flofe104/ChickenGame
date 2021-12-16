using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItemBehaviour<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour> : MonoBehaviour
    where ItemStats : InstantiatableBehaviourItem<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where ItemBehaviour : EquippedItemBehaviour<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where PlayerBehaviour : PlayerItemUser<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where NpcBehaviour : NpcItemUser<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
{


    protected ItemStats item;

    public virtual void DestroyItem()
    {
        Destroy(gameObject);
    }

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
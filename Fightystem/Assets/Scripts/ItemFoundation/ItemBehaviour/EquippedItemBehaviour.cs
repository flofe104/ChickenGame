using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Animations;
using UnityEngine;

public class EquippedItemBehaviour<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour> : MonoBehaviour
    where ItemStats : InstantiatableBehaviourItem<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where ItemBehaviour : EquippedItemBehaviour<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where PlayerBehaviour : PlayerItemUser<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where NpcBehaviour : NpcItemUser<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
{


    private ItemStats item;

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

    protected Animator userAnimator;

    public void SetUserAnimator(Animator animator)
    {
        userAnimator = animator;
    }

    public virtual void DestroyItem()
    {
        Destroy(gameObject);
    }

    protected virtual void OnItemStatsAssigned(ItemStats stats) { }

}
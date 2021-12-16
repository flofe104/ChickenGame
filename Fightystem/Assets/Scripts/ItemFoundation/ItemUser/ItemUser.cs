using System;
using UnityEditor.Animations;
using UnityEngine;

public abstract class ItemUser<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour> : MonoBehaviour
    where ItemStats : InstantiatableBehaviourItem<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where ItemBehaviour : EquippedItemBehaviour<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where PlayerBehaviour : PlayerItemUser<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where NpcBehaviour : NpcItemUser<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
{ 

    /// <summary>
    /// the behaviour to controll the weapon
    /// </summary>
    protected ItemBehaviour item;

    public void SetItemBehaviour(ItemBehaviour behaviour)
    {
        item = behaviour;
        OnItemBehaviourAssigned();
    }

    private Animator anim;

    public Animator Anim
    {
        get
        {
            if(anim == null)
            {
                anim = gameObject.AddComponent<Animator>();
            }
            return anim;
        }
    }

    protected AnimatorController animator;

    public AnimatorController Animator
    {
        get
        {
            return animator;
        }
        set
        {
            animator = value;
            anim.runtimeAnimatorController = animator;
            OnItemAnimationAssigned(animator);
        }
    }

    protected virtual void OnItemAnimationAssigned(AnimatorController animator) { }

    protected virtual void OnItemBehaviourAssigned() { }


    //protected void EquipWeapon(InstantiatableBehaviourItem<ItemBehaviour, ItemStats> item)
    //{
    //    DestroyEquipedWeapon();
    //    this.item = item.CreateInstanceAndGetBehaviour(transform);
    //}

    //protected void DestroyEquipedWeapon()
    //{
    //    if (item != null)
    //    {
    //        item.DestroyItem();
    //        item = null;
    //    }
    //}

}

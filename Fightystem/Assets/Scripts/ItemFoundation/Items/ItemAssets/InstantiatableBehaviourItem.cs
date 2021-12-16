using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class InstantiatableBehaviourItem<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour> : InstantiableInventoryItem, IInstantiatableItemBehaviour<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where ItemStats : InstantiatableBehaviourItem<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where ItemBehaviour : EquippedItemBehaviour<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where PlayerBehaviour : PlayerItemUser<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where NpcBehaviour : NpcItemUser<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
{


    public AnimatorController animationController;
    public Animator animator;

    public ItemBehaviour CreateUserBehaviourAndInstantiateItem(IItemEquipper equipper)
    {
        GameObject instance = CreateInstance(equipper.GetItemParent);
        ItemBehaviour result = instance.GetComponent<ItemBehaviour>();
        var user = equipper.SelectUserBehaviour<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>();
        user.SetItemBehaviour(result);
        user.Animator = animationController;
        result.SetUserAnimator(user.Anim);
        return result;
    }

    protected override void OnInstantiate(GameObject instance)
    {
        AddItemBehaviour(instance);
    }

    protected ItemBehaviour AddItemBehaviour(GameObject instance)
    {
        ItemBehaviour itemBehaviour = instance.AddComponent<ItemBehaviour>();
        itemBehaviour.Item = (ItemStats)this;
        WorkOnItemBehaviour(itemBehaviour);
        return itemBehaviour;
    }

    protected virtual void WorkOnItemBehaviour(ItemBehaviour itemBehaviour) { }

}

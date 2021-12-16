using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatableBehaviourItem<ItemBehaviour, ItemStats> : InstantiableInventoryItem
    where ItemStats : InstantiatableBehaviourItem<ItemBehaviour, ItemStats>
    where ItemBehaviour : EquippedItem<ItemBehaviour, ItemStats>
{


    public ItemBehaviour CreateInstanceAndGetBehaviour(Transform parent)
    {
        GameObject instance = CreateInstance(parent);
        return instance.GetComponent<ItemBehaviour>();
    }

    protected override void OnInstantiate(GameObject instance)
    {
        AddItemBehaviour(instance);
    }

    protected ItemBehaviour AddItemBehaviour(GameObject instance)
    {
        ItemBehaviour item = instance.AddComponent<ItemBehaviour>();
        item.Item = (ItemStats)this;
        return item;
    }

}

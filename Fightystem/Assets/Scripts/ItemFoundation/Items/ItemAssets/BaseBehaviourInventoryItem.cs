using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BaseBehaviourInventoryItem : InstantiableInventoryItem
{

    protected PlayerInputActions actions;

    protected abstract BaseItemBehaviour GetOrAddItemBehaviour(GameObject instance);


    protected override void OnInstantiate(GameObject instance)
    {
        BaseItemBehaviour behaviour = GetOrAddItemBehaviour(instance);
        behaviour.SetItemStats(this);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BehaviourInventoryItem<T> : BaseBehaviourInventoryItem where T : BaseItemBehaviour
{

    protected sealed override BaseItemBehaviour GetOrAddItemBehaviour(GameObject instance)
    {
        return instance.GetOrAddComponent<T>();
    }

}

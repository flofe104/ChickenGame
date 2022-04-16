using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericItemBehaviour<T> : BaseItemBehaviour where T : BaseBehaviourInventoryItem
{

    protected T itemStats;

    public sealed override void SetItemStats(BaseBehaviourInventoryItem stats)
    {
        if(stats.GetType() != typeof(T))
        {
            throw new System.Exception($"Added item stats type {stats.GetType().Name} does not fit expected type {typeof(T).Name}");
        }
        itemStats = (T)stats;
    }

}

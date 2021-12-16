using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUser<ItemBehaviour, ItemStats> : MonoBehaviour
    where ItemStats : InstantiatableBehaviourItem<ItemBehaviour, ItemStats>
    where ItemBehaviour : EquippedItem<ItemBehaviour, ItemStats>
{

}

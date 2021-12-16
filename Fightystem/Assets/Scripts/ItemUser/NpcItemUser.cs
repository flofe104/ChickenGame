using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcItemUser<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour> : ItemUser<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where ItemStats : InstantiatableBehaviourItem<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where ItemBehaviour : EquippedItemBehaviour<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where PlayerBehaviour : PlayerItemUser<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where NpcBehaviour : NpcItemUser<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
{

}

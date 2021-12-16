using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for all equipable weapons
/// </summary>
/// <typeparam name="WeaponBehaviour">The behaviour to controll the weapon with</typeparam>
/// <typeparam name="WeaponStats">the weapontype to control</typeparam>
public interface IInstantiatableItemBehaviour<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour> : IInstantiatableItem
    where ItemStats : InstantiatableBehaviourItem<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where ItemBehaviour : EquippedItemBehaviour<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where PlayerBehaviour : PlayerItemUser<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
    where NpcBehaviour : NpcItemUser<ItemBehaviour, ItemStats, PlayerBehaviour, NpcBehaviour>
{

    ItemBehaviour CreateUserBehaviourAndInstantiateItem(IItemEquipper equipper);

}

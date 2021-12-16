using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for all equipable weapons
/// </summary>
/// <typeparam name="WeaponBehaviour">The behaviour to controll the weapon with</typeparam>
/// <typeparam name="WeaponStats">the weapontype to control</typeparam>
public interface IInstantiatableWeapon<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour> : IInstantiatableItemBehaviour<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where WeaponStats : InstantiatableBehaviourItem<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where WeaponBehaviour : EquippedItemBehaviour<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where PlayerWeaponBehaviour : PlayerItemUser<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where NPCWeaponBehaviour : NpcItemUser<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
{


}

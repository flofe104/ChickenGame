using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behaviour class to controll any inventory weapon
/// </summary>
/// <typeparam name="WeaponBehaviour">The type that controlls the inventory weapon. Choose always the type that inherits from this class</typeparam>
/// <typeparam name="WeaponStats"></typeparam>
public abstract class EquippedWeaponBehaviour<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour> : EquippedItemBehaviour<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where WeaponStats : InstantiatableBehaviourItem<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where WeaponBehaviour : EquippedItemBehaviour<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where PlayerWeaponBehaviour : PlayerItemUser<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where NPCWeaponBehaviour : NpcItemUser<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
{

    protected WeaponStats Weapon => item;

    public bool IsInAttack { get; protected set; }

    public virtual bool CanStartAttack => !IsInAttack;

}

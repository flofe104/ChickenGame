using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behaviour class to controll any inventory weapon
/// </summary>
/// <typeparam name="WeaponBehaviour">The type that controlls the inventory weapon. Choose always the type that inherits from this class</typeparam>
/// <typeparam name="WeaponStats"></typeparam>
public abstract class EquippedWeapon<WeaponBehaviour, WeaponStats> : EquippedItem<WeaponBehaviour, WeaponStats>
    where WeaponStats : InventoryWeapon<WeaponBehaviour, WeaponStats> 
    where WeaponBehaviour : EquippedWeapon<WeaponBehaviour, WeaponStats>
{

    protected WeaponStats Weapon => item;

    public bool IsInAttack { get; protected set; }

    public virtual bool CanStartAttack => !IsInAttack;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMeleeWeapon<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour> : InventoryWeapon<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where WeaponStats : InstantiatableBehaviourItem<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where WeaponBehaviour : EquippedItemBehaviour<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where PlayerWeaponBehaviour : PlayerItemUser<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where NPCWeaponBehaviour : NpcItemUser<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
{
    [Range(0, 2)]
    public float range;

    [Range(45, 180)]
    public float rotationAngle;

}

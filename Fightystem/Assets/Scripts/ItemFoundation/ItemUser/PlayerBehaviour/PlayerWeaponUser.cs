using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponUser<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour> : PlayerItemUser<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where WeaponStats : InstantiatableBehaviourItem<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where WeaponBehaviour : EquippedItemBehaviour<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where PlayerWeaponBehaviour : PlayerItemUser<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where NPCWeaponBehaviour : NpcItemUser<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
{

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Behaviour controller of a melee Weapon
/// </summary>
public abstract class EquippedMeleeWeaponBehaviour<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour> : EquippedWeaponBehaviour<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where WeaponStats : InventoryMeleeWeapon<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where WeaponBehaviour : EquippedItemBehaviour<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where PlayerWeaponBehaviour : PlayerItemUser<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
    where NPCWeaponBehaviour : NpcItemUser<WeaponBehaviour, WeaponStats, PlayerWeaponBehaviour, NPCWeaponBehaviour>
{

    public void Attack(Func<IHealth, bool> healthDamageFilter)
    {
        this.healthDamageFilter = healthDamageFilter;
        StartAttack();
    }

    protected IEnumerator attackAnimation;

    /// <summary>
    /// when the Weapon encounters a collision with an entitiy which has IHealth attached to any of its scripts
    /// this function will determine if the entity will get damage on contact
    /// </summary>
    protected Func<IHealth, bool> healthDamageFilter;

    protected BoxCollider weaponCollider;

    protected Rigidbody body;

    protected BoxCollider WeaponCollider
    {
        get
        {
            if(weaponCollider == null)
            {
                weaponCollider = gameObject.AddComponent<BoxCollider>();
                weaponCollider.isTrigger = true;
                weaponCollider.enabled = false;
                CreateRigidBodyIfNotExising();
            }
            return weaponCollider;
        }
    }

    protected void CreateRigidBodyIfNotExising()
    {
        if (body == null)
        {
            body = gameObject.AddComponent<Rigidbody>();
            body.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            body.useGravity = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EvaluateHitCollider(other);
    }

    protected void EvaluateHitCollider(Collider collider)
    {
        IHealth health = collider.GetComponent<IHealth>();
        if (health != null && healthDamageFilter(health))
        {
            health.Damage(Weapon.Damage);
        }
    }

    protected void StartAttack()
    {
        if (!CanStartAttack)
            return;

    }

    protected override void OnItemStatsAssigned(WeaponStats stats)
    {
        ApplyWeaponStatsToCollider();
    }

    public void ApplyWeaponStatsToCollider()
    {
        WeaponCollider.size = new Vector3(0.5f,Weapon.colliderLength, 0.5f);
        WeaponCollider.center = new Vector3(0, Weapon.colliderLength / 2, 0);
    }

    protected void OnAttackEnded()
    {
        IsInAttack = false;
        weaponCollider.enabled = false;
    }

    protected void EndAttack()
    {
        attackAnimation = null;
        OnAttackEnded();
    }

}

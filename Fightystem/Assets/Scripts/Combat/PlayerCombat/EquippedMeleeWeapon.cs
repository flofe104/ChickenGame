using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Behaviour controller of a melee Weapon
/// </summary>
public class EquippedMeleeWeapon : EquippedWeapon<EquippedMeleeWeapon, InventoryMeleeWeapon>
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


    protected void AnimateMeleeWeaponAttack()
    {
        attackAnimation = RotateWeapon();
        StartCoroutine(attackAnimation);
    }

    protected IEnumerator RotateWeapon()
    {
        float timeInAttack = 0;
        weaponCollider.enabled = true;
        do
        {
            //wait a frame
            yield return null;
            timeInAttack += Time.deltaTime;
            float attackProgress = timeInAttack / Weapon.AttackAnimationDuration;
            float rotateProgress = Mathf.Lerp(0, Weapon.rotationAngle, attackProgress);
            ResetWeaponRotation();
            transform.Rotate(0, 0, rotateProgress, Space.Self);
        } while (timeInAttack < Weapon.AttackAnimationDuration);


        ///Check if the angle of the rotation of the Weapon after the rotation time matches the expected rotation 
        ///with an allowed error (due to floating point precision) of 0.001 degree
        Assert.AreApproximatelyEqual(Quaternion.Angle(Quaternion.Euler(Weapon.EquipEulerAngle), transform.localRotation), Weapon.rotationAngle, 0.001f);

        weaponCollider.enabled = false;
        yield return new WaitForSeconds(Weapon.AttackCooldownAfterAnimation);
        EndAttack();
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

        IsInAttack = true;
        AnimateMeleeWeaponAttack();
    }

    protected void ResetWeaponRotation()
    {
        transform.localEulerAngles = Weapon.EquipEulerAngle;
    }

    protected override void OnItemStatsAssigned(InventoryMeleeWeapon stats)
    {
        base.OnItemStatsAssigned(stats);
    }

    public void ApplyWeaponStatsToCollider()
    {
        WeaponCollider.size = new Vector3(0.5f,Weapon.range, 0.5f);
        WeaponCollider.center = new Vector3(0, Weapon.range / 2, 0);
    }

    protected void OnAttackEnded()
    {
        IsInAttack = false;
        weaponCollider.enabled = false;

        ResetWeaponRotation();

        ///Check if the Weapon rotation matches its start rotation after the attack ended
        Assert.AreEqual(transform.localEulerAngles, Weapon.EquipEulerAngle);
    }

    protected void EndAttack()
    {
        attackAnimation = null;
        OnAttackEnded();
    }

}

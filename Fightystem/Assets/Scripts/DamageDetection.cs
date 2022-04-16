using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetection : MonoBehaviour
{

    public DamageCollider damageColliders;

    private void OnTriggerEnter(Collider other)
    {
        IDamageable health = other.GetComponent<IDamageable>();
        if (health != null)
        {
            health.TakeDamage(damageColliders.damage);
        }
        else
        {

        }
        damageColliders.DisableDamageCollider();
        damageColliders.anim.ReturnToDefaultPosition();
    }

}

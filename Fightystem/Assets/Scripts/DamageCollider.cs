using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{

    public Collider damageCollider;
    public AnimatorHandler anim;

    public int damage = 10;

    private void Awake()
    {
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger = true;
        DisableDamageCollider();
    }

    public void EnableDamageCollider()
    {
        damageCollider.enabled = true;
    }

    public void DisableDamageCollider()
    {
        damageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable health = other.GetComponent<IDamageable>();
        if(health != null)
        {
            health.TakeDamage(damage);
        }
        else
        {

        }
        DisableDamageCollider();
        anim.ReturnToDefaultPosition();

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

}

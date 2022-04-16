using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public AnimatorHandler animHandler;

    public InputHandler inputHandler;


    private void Update()
    {
        HandleAttack();
    }

    public void HandleAttack()
    {
        if (animHandler.IsInteracting)
            return;

        if(inputHandler.isAttacking)
        {
            animHandler.PlayTargetAnimation("ChickenPick", true,0.01f);
        }
    }

}

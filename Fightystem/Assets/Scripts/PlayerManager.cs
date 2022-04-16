using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public InputHandler inputHandler;

    public AnimatorHandler animatorHandler;

    private void Update()
    {
        inputHandler.isInteracting = animatorHandler.IsInteracting;
    }

}

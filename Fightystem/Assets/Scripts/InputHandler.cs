using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    protected PlayerInputActions input;

    [SerializeField]
    protected CameraController cameraHandler;


    protected Vector2 movementInput;
    protected Vector2 cameraInput;

    public Vector3 MoveInputDirection => new Vector3(movementInput.x,0,movementInput.y);

    public float HorizontalCameraInput => cameraInput.x;

    public float HorizontalMoveInput => movementInput.x;

    public float VerticalMoveInput => movementInput.y;

    public float VerticalCameraInput => cameraInput.y;

    public float moveAmount;

    public bool isAttacking;
    public bool isInteracting;

    private void OnEnable()
    {
        if(input == null)
        {
            input = new PlayerInputActions();
            input.PlayerMovement.Movement.performed += 
                input => movementInput = input.ReadValue<Vector2>();
            input.PlayerMovement.Movement.canceled += _ => movementInput = Vector2.zero;
            input.PlayerMovement.Camera.performed += input => cameraInput = input.ReadValue<Vector2>();
            input.PlayerMovement.Camera.canceled += _ => cameraInput = Vector2.zero;
            input.PlayerActions.DefaultAttack.performed += _ => isAttacking = true;
            input.PlayerActions.DefaultAttack.canceled += _ => isAttacking = false;
        }
        input.Enable();
    }



    private void OnDisable()
    {
        input?.Disable();
    }

    private void LateUpdate()
    {
        cameraHandler.UpdateCamera(HorizontalCameraInput, VerticalCameraInput);
    }

    public void UpdateInput()
    {
        MoveInput();
    }

    protected void MoveInput()
    {
        moveAmount = Mathf.Clamp01(movementInput.magnitude);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerLocomotion : MonoBehaviour
{

    protected InputHandler input;

    public Rigidbody body;

    public Transform playerModel;

    public float moveSpeed = 5;

    public float rotationSpeed = 10;

    protected Transform mainCamera;

    public AnimatorHandler animHandler;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        input = GetComponent<InputHandler>();
        //animHandler = GetComponentInChildren<AnimatorHandler>();
        mainCamera = Camera.main.transform;
        animHandler.Initialize();
    }

    private void Update()
    {
        input.UpdateInput();
        MoveTransform();

        if(animHandler.CanRotate)
        {
            RotateTransform();
        }

    }

    protected void RotateTransform()
    {
        float delta = Time.deltaTime;
        Vector3 targetDir = mainCamera.forward * input.VerticalMoveInput + mainCamera.right * input.HorizontalMoveInput;
        targetDir.Normalize();
        targetDir.y = 0;

        if (targetDir == Vector3.zero)
            targetDir = playerModel.forward;

        Quaternion totalTarget = Quaternion.LookRotation(targetDir);
        Quaternion frameTarget = Quaternion.Slerp(playerModel.rotation, totalTarget, rotationSpeed * delta);

        playerModel.rotation = frameTarget;
    }

    protected void MoveTransform()
    {
        Vector3 moveDirection = mainCamera.TransformDirection(input.MoveInputDirection);
        moveDirection.Normalize();
        Vector3 projectedVel = Vector3.ProjectOnPlane(moveDirection, Vector3.up);
        body.velocity = projectedVel  * moveSpeed;

        animHandler.UpdateAnimatorValues(input.moveAmount, 0);
    }


}

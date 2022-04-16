using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    public Transform targetTransform;
    public Transform cameraPivotTransform;
    public Transform cameraTransform;

    private LayerMask ignoreLayers;

    public float lookSpeed = 0.1f;
    public float followSpeed = 0.1f;
    public float pivotSpeed = 0.03f;

    private float defaultPosition;
    private float lookAngle;
    private float pivotAngle;

    private float minPivAngle = -35;
    private float maxPivAngle = 35;

    private void Awake()
    {
        defaultPosition = cameraTransform.localPosition.z;
        ignoreLayers = ~(1 << 8 | 1 << 9 | 1 << 10);

    }

    public void FollowTarget()
    {
        Vector3 targetPos = Vector3.Lerp(transform.position, targetTransform.position, Time.deltaTime * followSpeed);
        transform.position = targetPos;
    }

    public void HandleCameraRotation(float delta, float mouseInputX, float mouseInputY)
    {
        lookAngle += (mouseInputX * lookSpeed) * delta;
        pivotAngle -= (mouseInputY * pivotSpeed) * delta;
        pivotAngle = Mathf.Clamp(pivotAngle, minPivAngle, maxPivAngle);

        Vector3 rotation = Vector3.zero;
        rotation.y = lookAngle;
        Quaternion targetRot = Quaternion.Euler(rotation);
        transform.rotation = targetRot;

        rotation.y = 0;
        rotation.x = pivotAngle;

        targetRot = Quaternion.Euler(rotation);
        cameraPivotTransform.localRotation = targetRot;


    }

}

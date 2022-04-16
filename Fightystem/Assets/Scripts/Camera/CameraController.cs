using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float sensitivity = 20.0f;
    public float smoothing = 5.0f;

    public Transform followTarget;

    public Transform horizontalRotate;

    public Transform verticalRotateTarget;

    public float mouseMaxSpeedPerFrame = 10;

    private Vector2 mouseLook;
    private Vector2 smoothedMouseLook;

    public float maxDownRotation = -30;

    public float maxUpRotation = 30;

    public Transform maxCameraScrollAnchor;

    public Transform minCameraScrollAnchor;

    public float scrollSpeed = 10;

    public float scrollZoomValue = 0;

    void Start()
    {
        float startZEuler = horizontalRotate.localEulerAngles.z;
        if (startZEuler > 180)
        {

            startZEuler -= 360;
        }
        startZEuler *= -1;

        mouseLook = new Vector2(horizontalRotate.localEulerAngles.y, startZEuler);
        smoothedMouseLook = mouseLook;
    }

 

    //void LateUpdate()
    //{
    //    //if (GameManager.CanCameraMove)
    //    {
    //        RotateCamera();
    //        ScrollCamera();
    //    }
    //}
    
    private void ScrollCamera()
    {
        scrollZoomValue = Mathf.Clamp01(scrollZoomValue + Input.mouseScrollDelta.y * Time.deltaTime * scrollSpeed);
        transform.position = Vector3.Lerp(maxCameraScrollAnchor.position, minCameraScrollAnchor.position, scrollZoomValue);
    }
    public void UpdateCamera(float mouseX, float mouseY)
    {
        RotateCamera(mouseX, mouseY);
        transform.position = followTarget.position;
    }

    public void RotateCamera(float mouseX, float mouseY)
    {
        //float sensitivity = PersistentGameDataController.Settings.cameraSensitivity;

        Vector2 mouseMovement = new Vector2(mouseX, mouseY);
        mouseMovement *= sensitivity * smoothing * Time.deltaTime;


        mouseMovement = new Vector2(
            Mathf.Clamp(mouseMovement.x, -mouseMaxSpeedPerFrame, mouseMaxSpeedPerFrame),
            Mathf.Clamp(mouseMovement.y, -mouseMaxSpeedPerFrame, mouseMaxSpeedPerFrame)
            );

        mouseLook += mouseMovement;

        mouseLook.y = Mathf.Clamp(mouseLook.y, maxDownRotation, maxUpRotation);
        
        smoothedMouseLook.y = Mathf.Lerp(smoothedMouseLook.y, mouseLook.y, 1 / smoothing);
        smoothedMouseLook.x = Mathf.Lerp(smoothedMouseLook.x, mouseLook.x, 1 / smoothing);

        horizontalRotate.transform.localEulerAngles = new Vector3(0, smoothedMouseLook.x, horizontalRotate.transform.localEulerAngles.z);
        verticalRotateTarget.transform.localEulerAngles = new Vector3(-smoothedMouseLook.y, 0, 0);
    }


}

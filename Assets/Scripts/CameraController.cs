using System.Collections;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour {

    [Header("Panning")]
    public float panSpeed = 5f;
    public float panBorderThickness = 15f;
    public float panLimit = 25f;

    [Header("Rotating")]
    public float rotateSpeed = 2f;
    public Vector2 verticalRotationLimit = new Vector2(10f, 100f);
    private float yaw;
    private float pitch;

    [Header("Zooming")]
    public float zoomSpeed = 50f;
    public Vector2 zoomLimit = new Vector2(10f, 75f);

    const int mouseLftClick = 0;
    const int mouseRightClick = 1;

    void Start()
    {
        pitch = transform.eulerAngles.x;
    }

    void Update()
    {
        transform.position = StartPanning();
        Camera.main.fieldOfView = StartZooming();
        transform.eulerAngles = StartRotating();
    }

    /*
     * Move the camera on its XZ-plane
     */
    Vector3 StartPanning()
    {
        Vector3 panPosition = transform.position;
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        forward.y = 0f;
        right.y = 0f;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            /*
             *  Move right if (Input.mousePosition.x >= Screen.width - panBorderThickness) / if (Input.GetKey(KeyCode.D))
             *  or left if (Input.mousePosition.x <= panBorderThickness) / if (Input.GetKey(KeyCode.A))
             */
            if (Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                panPosition += right * panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.x <= panBorderThickness)
            {
                panPosition -= right * panSpeed * Time.deltaTime;
            }
            /*
             * Move forward if (Input.mousePosition.y >= Screen.height - panBorderThickness) / if (Input.GetKey(KeyCode.W))
             * or backward if (Input.mousePosition.y <= panBorderThickness) / if (Input.GetKey(KeyCode.S))
             */
            if (Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                panPosition += forward * panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.y <= panBorderThickness)
            {
                panPosition -= forward * panSpeed * Time.deltaTime;
            }
            panPosition.x = Mathf.Clamp(panPosition.x, -panLimit, panLimit);
            panPosition.z = Mathf.Clamp(panPosition.z, -panLimit, panLimit);
        }
       
        return panPosition;
    }

    /*
     * Move camera along X and Y axis
     */
    Vector3 StartRotating()
    {
        if (Input.GetMouseButton(mouseRightClick))
        {
            yaw += Input.GetAxis("Mouse X") * rotateSpeed;
            pitch -= Input.GetAxis("Mouse Y") * rotateSpeed;
        }
        return new Vector3
                (
                    Mathf.Clamp(pitch, verticalRotationLimit.x, verticalRotationLimit.y),
                    yaw,
                    0f
                );
    }

    /*
     * Move camera linearly along Z axis
     */
    float StartZooming()
    {
        float scrollValue = Input.mouseScrollDelta.y;
        float FOV = Camera.main.fieldOfView;

        if (scrollValue != 0)
        {
            FOV -= scrollValue;
        }

        return Mathf.Clamp(FOV, zoomLimit.x, zoomLimit.y);
    }
}
using System.Collections;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour {

    [Header("Panning")]
    public float panSpeed = 5f;
    public float panBorderThickness = 15f;
    public float panLimit = 20f;

    [Header("Rotating")]
    public float rotateSpeed;
    public Vector2 rotateLimit;

    [Header("Zooming")]
    public float zoomSpeed = 50f;
    public Vector2 zoomLimit = new Vector2(10f, 75f);

    void Start()
    {
        Debug.Log("Width = " + Screen.width);
        Debug.Log("Height = " + Screen.height);
    }

    void Update()
    {
        //Vector3 panUpdatedPosition = StartPanning();
        //transform.position = panUpdatedPosition;

        //float zoomUpdatedPosition = StartZooming();
        //Camera.main.fieldOfView = zoomUpdatedPosition;
    }

    /*
     * Move the camera on its XZ-plane
     */
    Vector3 StartPanning()
    {
        Vector3 panPosition = transform.position;

        /*
         * Move left if (Input.mousePosition.x <= panBorderThickness)
         * or right if (Input.mousePosition.x >= Screen.width - panBorderThickness)
         */
        //if (Input.GetKey(KeyCode.D))
        if (Input.GetKey(KeyCode.LeftControl) && Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            panPosition.x += panSpeed * Time.deltaTime;
        }
        //if (Input.GetKey(KeyCode.A))
        if (Input.GetKey(KeyCode.LeftControl) && Input.mousePosition.x <= panBorderThickness)
        {
            panPosition.x -= panSpeed * Time.deltaTime;
        }
        /*
         * Move forward if (Input.mousePosition.y >= Screen.height - panBorderThickness)
         * or backward if (Input.mousePosition.y <= panBorderThickness)
         */
        //if (Input.GetKey(KeyCode.W))
        if (Input.GetKey(KeyCode.LeftControl) && Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            panPosition.z += panSpeed * Time.deltaTime;
        }
        //if (Input.GetKey(KeyCode.S))
        if (Input.GetKey(KeyCode.LeftControl) && Input.mousePosition.y <= panBorderThickness)
        {
            panPosition.z -= panSpeed * Time.deltaTime;
        }

        panPosition.x = Mathf.Clamp(panPosition.x, -panLimit, panLimit);
        panPosition.z = Mathf.Clamp(panPosition.z, -panLimit, panLimit);

        //transform.position = panPosition;
        return panPosition;
    }

    /*
     * Move camera along X and Y axis
     */
    void StartRotating()
    {

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
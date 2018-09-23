using System.Collections;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour {

    public float panSpeed = 5f;
    public float panBorderThickness = 15f;
    public Vector2 panLimit;

    public float rotateSpeed;

    public float zoomSpeed;

    private bool isPanning;
    private bool isRotating;
    private bool isZooming;

    void Start()
    {
        isPanning = false;
        isRotating = false;
        isZooming = false;
    }
    void Update()
    {
        Vector3 position = transform.position;
        
        Debug.Log("Width = " + Screen.width);
        Debug.Log("Height = " + Screen.height);
        Debug.Log("Mouse at " + Input.mousePosition);

        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            position.x += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x <= panBorderThickness)
        {
            position.x -= panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            position.z += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y <= panBorderThickness)
        {
            position.z -= panSpeed * Time.deltaTime;
        }

        position.x = Mathf.Clamp(position.x, -panLimit.x, panLimit.x);
        position.z = Mathf.Clamp(position.z, -panLimit.y, panLimit.y);

        transform.position = position;       
    }
}
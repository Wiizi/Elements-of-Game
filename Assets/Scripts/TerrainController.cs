using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    const int mouseRightButton = 1;

    float buttonDownThreshold = 0.5f;
    double lastButtonDown;
    bool isListeningForDoubleClicks = false;

    Vector3 pointInPlane = Vector3.zero;

    public bool DetectDoubleRightClicks()
    {
        double timeSinceLastClick = Time.time - lastButtonDown;
        bool doubleRightClicksDetected = false;

        if (Input.GetMouseButtonDown(mouseRightButton))
        {
            if (timeSinceLastClick < buttonDownThreshold && isListeningForDoubleClicks)
            {
                Debug.Log("Double Click");
                isListeningForDoubleClicks = false;
                doubleRightClicksDetected = true;
            }
            else
            {
                lastButtonDown = Time.time;
                isListeningForDoubleClicks = true;
                doubleRightClicksDetected = false;
            }
        }
        else
        {
            if (timeSinceLastClick >= buttonDownThreshold && isListeningForDoubleClicks)
            {
                Debug.Log("Single Click");
                isListeningForDoubleClicks = false;
                doubleRightClicksDetected = false;
            }
        }

        return doubleRightClicksDetected;
    }

    public Vector3 PositionInGamePlane(bool active)
    {
        if (active)
        {
            // create a ray from the mousePosition
            Ray pointClicked = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Raycast returns the distance from the ray start to the hit point
            RaycastHit hitPointInfo;
            if (Physics.Raycast(pointClicked, out hitPointInfo))
            {
                // some point on the plane was hit - get its coordinates
                pointInPlane = pointClicked.GetPoint(hitPointInfo.distance);
                //Instantiate(agentPrefab, pointInPlane, agentPrefab.transform.rotation);
            }
        }

        return pointInPlane;
    }
}

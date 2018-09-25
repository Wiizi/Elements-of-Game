using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    List<Selectable> currentlySelected;
    List<int> selectedIds;

    Vector2 leftMouseDownXYAtClick;

    int SparseRay = 5;

	// Use this for initialization
	void Start () {
        currentlySelected = new List<Selectable>();
        selectedIds = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        // update selection tile
        if (Input.GetMouseButtonDown(0))
        {
            leftMouseDownXYAtClick = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            //Debug.Log("LIST HAS " + currentlySelected.Count);
            for (int i = 0; i < currentlySelected.Count; i++) {
                currentlySelected[i].Deselect();
            }
 
            currentlySelected = new List<Selectable>();
            selectedIds = new List<int>();

            Vector2 currentLeftMouseDownXYAtClick = Input.mousePosition;

            int imin = (int)Mathf.Min(leftMouseDownXYAtClick.x, currentLeftMouseDownXYAtClick.x);
            int imax = (int)Mathf.Max(leftMouseDownXYAtClick.x, currentLeftMouseDownXYAtClick.x) + SparseRay + 1;

            int jmin = (int)Mathf.Min(leftMouseDownXYAtClick.y, currentLeftMouseDownXYAtClick.y);
            int jmax = (int)Mathf.Max(leftMouseDownXYAtClick.y, currentLeftMouseDownXYAtClick.y) + SparseRay + 1;

            //Debug.Log("Current ij " + imin + "," + imax + "," + jmin + "," + jmax);
            for (int i = imin; i < imax; i += SparseRay)
            {
                for (int j = jmin; j < jmax; j += SparseRay)
                {
                    Ray ray = Camera.main.ScreenPointToRay(new Vector2(i, j));
                    RaycastHit hitInfo;
                    if (Physics.Raycast(ray, out hitInfo))
                    {
                        GameObject hitObject = hitInfo.collider.transform.gameObject;
                        Vector3 hitPos = hitInfo.point;
                        if (hitObject == null)
                        {

                        }
                        else
                        {
                            Selectable selectable = hitObject.GetComponentInParent<Selectable>();
                            if (selectable != null && !selectedIds.Contains(selectable.ID))
                            {
                                selectable.Select();
                                currentlySelected.Add(selectable);
                                selectedIds.Add(selectable.ID);
                            }
                        }
                    }
                    else
                    {

                    }
                }
            }
        }
    }
}

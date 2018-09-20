using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {

    public GameObject SelectionIndicatorPrefab;

    GameObject SelectionIndicator;

    public int ID;

	// Use this for initialization
	void Start () {
        SelectionIndicator = Instantiate(SelectionIndicatorPrefab, this.transform);
        Deselect();
        ID = this.GetHashCode();
	}

    public void Select()
    {
        SelectionIndicator.SetActive(true);
    }

    public void Deselect()
    {
        SelectionIndicator.SetActive(false);
    }
}

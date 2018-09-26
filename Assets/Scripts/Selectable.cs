using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {

    public GameObject SelectionIndicatorPrefab;

    public bool isSelected;

    GameObject SelectionIndicator;

    public int ID;

    void Awake()
    {
        isSelected = false;
    }

    // Use this for initialization
    void Start () {
        SelectionIndicator = Instantiate(SelectionIndicatorPrefab, this.transform);
        Deselect();
        ID = this.GetHashCode();
	}

    public void Select()
    {
        isSelected = true;
        SelectionIndicator.SetActive(true);
    }

    public void Deselect()
    {
        isSelected = false;
        SelectionIndicator.SetActive(false);
    }

    public bool IsSelected()
    {
        return isSelected;
    }
}

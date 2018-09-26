using UnityEngine;

public class Selectable : MonoBehaviour {

    public GameObject SelectionIndicatorPrefab;

    public int ID;

    GameObject SelectionIndicator;
    bool isSelected;
    
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

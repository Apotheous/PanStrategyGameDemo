using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitsSelected= new List<GameObject>();

    private static UnitSelections _instance;
    public static UnitSelections Instance { get { return _instance; } }

    private GameObject _selectedUnit;
    private void Awake()
    {
        //if an instance of this already exits and it isn't this one
        if (_instance != null && _instance != this)
        {
            //we destroy this instance
            Destroy(this.gameObject);
        }
        else
        {
            //make this the instance
            _instance = this;
        }
    }

    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        unitsSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log("unitToAdd" + unitToAdd.name);
    }
    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            unitToAdd.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = false;
            unitsSelected.Remove(unitToAdd);
        }
    } 
    public void DragSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    public void DeselectAll()
    {
        foreach (GameObject unitToRemove in unitsSelected) 
        {
            unitToRemove.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = false;
        }
        unitsSelected.Clear();
    }
    public void Deselect(GameObject unitToDeselect)
    {

    }
    public List<GameObject> GetUnitsSelected()
    {
        return unitsSelected;
    }

}

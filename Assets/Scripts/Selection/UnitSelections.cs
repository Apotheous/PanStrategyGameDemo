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
        for (int i = unitsSelected.Count - 1; i >= 0; i--)
        {
            GameObject unitToRemove = unitsSelected[i];
            if (unitToRemove != null && unitToRemove.activeSelf)
            {
                unitToRemove.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                unitsSelected.RemoveAt(i); // Null veya silinmi� nesneleri listeden kald�r
            }
        }
        unitsSelected.Clear();
    }
    public void Deselect(GameObject unitToDeselect)
    {

    }
    public List<GameObject> GetUnitsSelected()
    {
        unitsSelected.RemoveAll(item => item == null); // Null olanlar� listeden kald�r
        return unitsSelected;
    }

}

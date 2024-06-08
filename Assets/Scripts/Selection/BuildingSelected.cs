using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelected : MonoBehaviour
{
    public GameObject _selectedBuilding;
    private static BuildingSelected _instance;
    public static BuildingSelected Instance { get { return _instance; } }


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
        _selectedBuilding = unitToAdd;
        unitToAdd.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log("unitToAdd" + unitToAdd.name);
    }

    public void DeselectAll()
    {
        _selectedBuilding = null;
    }
    public GameObject GetUnitsSelected()
    {
        return _selectedBuilding;
    }
}

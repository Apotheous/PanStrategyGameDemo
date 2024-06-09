using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour
{

    //public List<Country> CountryList;
    public string country;
    public int countryNumber;

    public List<GameObject> countryList= new List<GameObject>();

    private static Country _instance;
    public static Country Instance { get { return _instance; } }
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

    public void ClickSelect(GameObject c_Building)
    {
        //DeselectAll();
        countryList.Add(c_Building);
        c_Building.name = "Country " +countryNumber;
        countryNumber++;
       //CircleCollider2D c_BuildingRangeColl = c_Building.AddComponent<CircleCollider2D>();
       // c_BuildingRangeColl.radius =1f;
       // c_BuildingRangeColl.isTrigger=true;
        
        //unitToAdd.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void DeselectAll()
    {
        countryList = null;
    }
    public List<GameObject> GetUnitsSelected()
    {
        return countryList;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryManager : MonoBehaviour
{
    public List<GameObject> CountryList = new List<GameObject>();
    
    private static CountryManager _instance;
    public static CountryManager Instance { get { return _instance; } }

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

    public void AddCountry(GameObject countryObj)
    {
        CountryList.Add(countryObj);
        countryObj.name = countryObj.name + CountryList.Count;

    }

    public List<GameObject> GetUnitsSelected()
    {
        return CountryList;
    }
}

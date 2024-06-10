using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CountryBuilds : MonoBehaviour
{
    public string countryCode;
    private void Start()
    {
        Debug.Log(countryCode);
        foreach (Transform item in transform)
        {
            Debug.Log("CountryBuilds =" + item.name);
            if (item.name == "Spawner")
            {
                item.AddComponent<CountryCodeSpawner>()._countryCodeUnit=countryCode;
            }
        }
    }
}

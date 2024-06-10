using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CountryCollControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Country Range Control "+collision.name);
        collision.AddComponent<CountryBuilds>().countryCode= gameObject.name;
    }
}

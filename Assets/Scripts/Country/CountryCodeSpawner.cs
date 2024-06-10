using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CountryCodeSpawner : MonoBehaviour
{
    public string _countryCodeUnit;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.gameObject.layer==7)
        {
            if (collision.GetComponent<Unit>()._CountryCode == ""|| collision.GetComponent<Unit>()._CountryCode ==_countryCodeUnit)
            {
                collision.GetComponent<Unit>()._CountryCode = _countryCodeUnit;
            }
            else
            {
                Debug.Log("Enemy Soldier");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryCollControl : Country
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("CountryCollControl" + collision.name);
        
    }
}

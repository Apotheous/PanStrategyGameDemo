using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CountryManager.Instance.AddCountry(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

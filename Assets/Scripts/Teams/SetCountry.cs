using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCountry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Country.Instance.ClickSelect(this.gameObject);

        //countryList.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

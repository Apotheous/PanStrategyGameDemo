using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{

    public string _CountryCode;
    void Start()
    {
        UnitSelections.Instance.unitList.Add(this.gameObject);
        Debug.Log("Unit Country Code Start=" + _CountryCode);
    }
    private void Update()
    {
        Debug.Log("Unit Country Code Update="+ _CountryCode);
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletDamageHolder : MonoBehaviour
{
    public int damage_Value;
    private void Start()
    {

    }
    private void Update()
    {
        Debug.Log(" Bullet Damage Value = " + damage_Value + " Bullet Name = " + gameObject.name);
    }
}

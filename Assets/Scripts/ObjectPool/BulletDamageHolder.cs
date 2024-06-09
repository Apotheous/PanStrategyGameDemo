using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class BulletDamageHolder : MonoBehaviour
{
    /*
     * -Keeps the amnesty damage value of soldiers
     * 
     * -The bulletDamage variable is assigned to the damage_Value 
     * variable in this component from the bullet thrown in the BulletPool.
     * 
     * -The damage value is transferred from the units that the bullets come 
     * into contact with with this damage value variable.
    */
    public int damage_Value;
    //private void Update()
    //{
    //    Debug.Log(" Bullet Damage Value = " + damage_Value + " Bullet Name = " + gameObject.name);
    //}
}

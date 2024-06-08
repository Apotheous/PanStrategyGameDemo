using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullets : MonoBehaviour
{
    public string obj_Name;
    public int Damage;


    protected virtual void Start()
    {
        obj_Name = gameObject.name;
        SetDamageValue();
    }

    public abstract void SetDamageValue();
}

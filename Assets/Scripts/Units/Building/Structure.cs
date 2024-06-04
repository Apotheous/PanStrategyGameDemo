using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Structure : MonoBehaviour
{
    public string obj_Name;
    public int health;


    protected virtual void Start()
    {
        obj_Name = gameObject.name;
        SetHealthValue();
    }

    public abstract void SetHealthValue();
}

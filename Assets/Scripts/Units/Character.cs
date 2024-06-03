using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public string obj_Name;
    public int health;

    public int damage;



    protected virtual void Start()
    {
        obj_Name= gameObject.name;
        health = 10;
        Try();
    }
    //protected virtual void SetDamge(int damageValue)
    //{
    //    this.damage = damageValue;
    //}

    public abstract void Try();
}

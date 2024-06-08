using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Magician : Character , IHittable
{
    public override void SetDamageValue()
    {
        damage = 2;
    }
    public void GetHit(int damageValue, GameObject sender)
    {
        health -= damageValue;
        Debug.Log(sender.name);
        sender.SetActive(false);
        Death(health, this.gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BulletDamageHolder>() != null)
        {
            int dValue = collision.GetComponent<BulletDamageHolder>().damage_Value;
            Debug.Log("Soldier on Damage");
            GetHit(dValue, collision.gameObject);
        }
    }

    public void Death(int health, GameObject sender)
    {
        if (health == 0) { sender.SetActive(false); }
    }
}

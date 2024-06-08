using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlant : Structure, IHittable
{

    public override void SetHealthValue()
    {
        health = 50;
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
        int dValue = collision.GetComponent<BulletDamageHolder>().damage_Value;
        Debug.Log("Building Damage");
        GetHit(dValue, collision.gameObject);
    }

    public void Death(int health, GameObject sender)
    {
        if (health == 0) { sender.SetActive(false); }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trooper : Character, IHittable
{
    public override void SetDamageValue()
    {
        damage = 5;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != transform.tag)
        {
            if (collision.GetComponent<BulletDamageHolder>() != null)
            {
                int dValue = collision.GetComponent<BulletDamageHolder>().damage_Value;
                GetHit(dValue, collision.gameObject);
            }
        }
    }
    public void GetHit(int damageValue, GameObject sender)
    {
        health -= damageValue;
        sender.SetActive(false);
        Death(health, this.gameObject);
    }
    public void Death(int health, GameObject sender)
    {
        if (health <= 0) { Destroy(sender); UnitSelections.Instance.unitsSelected.Remove(sender); }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trooper : Unit, IHittable
{
    Animator unitAnimator;
    HealthBar healthBar;
    private void Start()
    {
        unitAnimator = GetComponent<Animator>();
        healthBar = gameObject.GetComponent<HealthBar>();
        obj_Name = gameObject.GetComponent<Unit>().obj_Name;
        healthCharecter = gameObject.GetComponent<Unit>().healthCharecter;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != transform.tag)
        {
            if (collision.GetComponent<BulletDamageHolder>() != null)
            {
                int dValue = collision.GetComponent<BulletDamageHolder>().damage_Value;
                healthBar.UpdateHealth(-dValue);
                GetHit(dValue, collision.gameObject);

                unitAnimator.SetTrigger("onHit");
            }
        }
    }
    public void GetHit(int damageValue, GameObject sender)
    {
        if (healthCharecter > 0)
        {
            healthCharecter -= damageValue;
            sender.SetActive(false);
        }

        Death(healthCharecter, this.gameObject);
    }
    public void Death(int health, GameObject sender)
    {
        if (health <= 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            unitAnimator.ResetTrigger("onHit");
            unitAnimator.SetTrigger("onDie");

            Destroy(sender, 2.5f);
            UnitSelections.Instance.unitsSelected.Remove(sender);
        }
    }
}

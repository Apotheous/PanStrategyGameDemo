using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSamurai : Character,IHittable
{
    Animator unitAnimator;
    HealthBar healthBar;
    private void Start()
    {
        unitAnimator = GetComponent<Animator>();
        healthBar = gameObject.GetComponent<HealthBar>();
    }
    public override void SetDamageValue()
    {
        damage = 10;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != transform.tag)
        {
            if (collision.GetComponent<BulletDamageHolder>() != null)
            {
                int dValue = collision.GetComponent<BulletDamageHolder>().damage_Value;
                GetHit(dValue, collision.gameObject);
                healthBar.UpdateHealth(-dValue);
                unitAnimator.SetTrigger("onHit");
            }
        }
    }
    public void GetHit(int damageValue, GameObject sender)
    {
        if (health>0)
        {
            health -= damageValue;
            sender.SetActive(false);
        }

        Death(health, this.gameObject);
    }
    public void Death(int health, GameObject sender)
    {
        if (health <= 0) {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            unitAnimator.ResetTrigger("onHit"); 
            unitAnimator.SetTrigger("onDie");

            Destroy(sender, 2.5f);
            UnitSelections.Instance.unitsSelected.Remove(sender); }
    }
}

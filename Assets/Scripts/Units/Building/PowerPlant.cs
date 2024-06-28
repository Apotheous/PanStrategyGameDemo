using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlant : Structure, IHittable
{
    private SpriteRenderer spriteRenderer;
    HealthBar healthBar;

    void Start()
    {
        // SpriteRenderer bileþenine eriþiyoruz
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar = gameObject.GetComponent<HealthBar>();
    }






    public void SetTransparency(float alpha)
    {
        // Mevcut rengi alýyoruz
        Color color = spriteRenderer.color;

        // Alpha deðerini deðiþtiriyoruz (0: tamamen transparan, 1: tamamen opak)
        color.a = alpha;

        // Yeni rengi SpriteRenderer bileþenine uyguluyoruz
        spriteRenderer.color = color;
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {

        yield return new WaitForSeconds(0.1f);
        // Mevcut rengi alýyoruz
        Color color = spriteRenderer.color;

        // Alpha deðerini deðiþtiriyoruz (0: tamamen transparan, 1: tamamen opak)
        color.a = 1;

        // Yeni rengi SpriteRenderer bileþenine uyguluyoruz
        spriteRenderer.color = color;
    }
    public override void SetHealthValue()
    {
        health = 5000;
    }

    public void GetHit(int damageValue, GameObject sender)
    {
        health -= damageValue;
        sender.SetActive(false);
        SetTransparency(0.5f);
        //BulletContact(sender);
        Death(health, this.gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BulletDamageHolder>() != null)
        {
            int dValue = collision.GetComponent<BulletDamageHolder>().damage_Value;
            GetHit(dValue, collision.gameObject);
            healthBar.UpdateHealth(-dValue);
        }
    }

    public void Death(int health, GameObject sender)
    {
        if (health <= 0) { sender.SetActive(false); BuildingSelected.Instance.DeselectAll(); }
    }


    void BulletContact(GameObject bllt)
    {
        GameObject blltExp = bllt.transform.GetChild(0).gameObject;
        blltExp.transform.SetParent(null);
        blltExp.SetActive(true);
        

    }

}

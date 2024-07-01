using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
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
    Transform bulletExplsv;
    public int damage_Value;
    private void Start()
    {
        bulletExplsv = gameObject.transform.GetChild(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletExplosixe(collision.gameObject,transform.position);
    }
    void BulletExplosixe(GameObject other,Vector2 hitPos)
    {
        if (other.GetComponent<BoxCollider2D>() != null && other.tag != gameObject.tag)
        {
            bulletExplsv.SetParent(null);
            // Set the position of bulletExplsv to the position of the current game object
            bulletExplsv.position = hitPos;

            bulletExplsv.gameObject.SetActive(true);
            Invoke("ReturnParent", 0.5f);
        }
    }
    void ReturnParent()
    {
        bulletExplsv.SetParent(this.gameObject.transform);
        bulletExplsv.gameObject.SetActive(false);
    }


}

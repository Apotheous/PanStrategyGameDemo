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
    public float raycastDistance = 10f;
    public LayerMask layerMask; // Layer mask to filter the objects the ray can hit
    public Text DebugText;
    private void Start()
    {
        DebugText=FindAnyObjectByType<Text>();
    }
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, raycastDistance, layerMask);

        if (hit.collider != null)
        {
            Debug.Log("Raycast hit: " + hit.collider.name);
            // Implement additional logic here based on the hit
            float distance = Vector2.Distance(transform.position, hit.point);
            Debug.Log("Raycast hit: " + distance.ToString());
            //if (distance < 0.5f&&distance>0.4f) { BulletExplosixe(hit.transform.gameObject,hit.point); }
        }
        Debug.DrawRay(transform.position, transform.right * raycastDistance, Color.red);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletExplosixe(collision.gameObject,transform.position);
    }
    void BulletExplosixe(GameObject other,Vector2 hitPos)
    {
        if (other.GetComponent<BoxCollider2D>() != null && other.tag == "Enemy")
        {
            bulletExplsv = gameObject.transform.GetChild(0);
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

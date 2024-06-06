using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public List<GameObject> bullets = new List<GameObject>();
    public Transform desPos;
    public int shootingTime;
    public int bulletDamage;
    private GameObject notListedObject;

    private void Start()
    {
        Shoot();
    }

    private void Shoot()
    {
        bullets[0].gameObject.SetActive(true);
        bullets[0].GetComponent<Rigidbody2D>().velocity = Vector2.right*1;
        bullets[0].transform.SetParent(null);
        notListedObject = bullets[0];
        notListedObject.GetComponent<BulletDamageHolder>().damage_Value = bulletDamage;

        bullets.RemoveAt(0);
        Invoke("GetThePool", shootingTime);
    }
    public void GetThePool()
    {
        bullets.Add(notListedObject);
        notListedObject.transform.SetParent(desPos);
        notListedObject.transform.position= desPos.position;
        notListedObject.SetActive(false);
        Shoot();
    }
    
}

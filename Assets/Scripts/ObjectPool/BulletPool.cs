using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public List<GameObject> bullets = new List<GameObject>();
    Transform myTransform;
    public Transform desPos;
    public int shootingTime;
    public int bulletDamage;
    private GameObject notListedObject;
    public bool isCalledShoot;

    private void Start()
    {
        myTransform =gameObject.transform;
        //Shoot();
    }

    public void Shoot()
    {
        if (gameObject.activeSelf) {
            if (!isCalledShoot) { isCalledShoot = true; }
            bullets[0].gameObject.SetActive(true);
            bullets[0].GetComponent<Rigidbody2D>().AddForce(transform.right * 15, ForceMode2D.Impulse);
            bullets[0].transform.SetParent(null);
            notListedObject = bullets[0];
            notListedObject.GetComponent<BulletDamageHolder>().damage_Value = bulletDamage;
            bullets.RemoveAt(0);
            Invoke("GetThePool", shootingTime);
        }
       
    }
    public void GetThePool()
    {
        if (gameObject.activeSelf) {
            bullets.Add(notListedObject);
            notListedObject.transform.SetParent(desPos);
            notListedObject.transform.position = desPos.position;
            notListedObject.SetActive(false);
            Shoot();
        }

    }
    
}

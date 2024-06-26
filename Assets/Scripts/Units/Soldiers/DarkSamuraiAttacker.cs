using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSamuraiAttacker : MonoBehaviour
{
    public GameObject swordColl;
    public GameObject sword;

    private GameObject targetObject; // Temas etti�imiz objeyi tutacak de�i�ken
    private bool isCalledShoot;
    public Animator unitAnimator;
    private void Start()
    {
        isCalledShoot = false;
        unitAnimator.GetComponent<Animator>();
    }

    private void Update()
    {
        if (targetObject != null)
        {
            Shoot(); // targetObject dolu ise Shoot metodunu �a��r
        }
    }

    public void Shoot()
    {
        if (sword !=null && !isCalledShoot)
        {
            isCalledShoot = true;

            //sword.GetComponent<BulletDamageHolder>().damage_Value = bulletDamage;
            unitAnimator.SetTrigger("attack");

            Invoke("GetThePool", 2);
        }
    }

    public void GetThePool()
    {
        unitAnimator.SetTrigger("attack");
        isCalledShoot = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.tag != gameObject.tag)
        {
            if (targetObject == null) // targetObject bo� ise
            {
                targetObject = other.gameObject; // Temas eden objeyi targetObject de�i�kenine ata

            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != null && other.tag != gameObject.tag)
        {
            if (targetObject == other.gameObject) // Temas eden obje tetikleyiciden ��karsa
            {
                targetObject = null; // targetObject de�i�kenini bo�alt
            }

        }
    }
    public void SwordOn()
    {
        swordColl.SetActive(true);
        
    }    
    public void SwordOff()
    {
        swordColl.SetActive(false);
    }

}

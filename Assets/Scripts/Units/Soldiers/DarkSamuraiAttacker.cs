using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSamuraiAttacker : MonoBehaviour
{
    public GameObject swordColl;
    public GameObject sword;

    private GameObject targetObject; // Temas ettiðimiz objeyi tutacak deðiþken
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
            Shoot(); // targetObject dolu ise Shoot metodunu çaðýr
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
            if (targetObject == null) // targetObject boþ ise
            {
                targetObject = other.gameObject; // Temas eden objeyi targetObject deðiþkenine ata

            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != null && other.tag != gameObject.tag)
        {
            if (targetObject == other.gameObject) // Temas eden obje tetikleyiciden çýkarsa
            {
                targetObject = null; // targetObject deðiþkenini boþalt
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

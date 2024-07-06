using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

            if (sword != null && !isCalledShoot)
            {
                isCalledShoot = true;
                // Turn MomObject to face the targetObject without flipping upside down
                Vector3 direction = targetObject.transform.position - gameObject.transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                // Clamp the angle to prevent flipping
                if (angle > 90 || angle < -90)
                {

                    //angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
                    gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                }
                else { gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); }
                //sword.GetComponent<BulletDamageHolder>().damage_Value = bulletDamage;
                unitAnimator.SetTrigger("attack");

                Invoke("GetThePool", 2);
            }
            Shoot(); // targetObject dolu ise Shoot metodunu çaðýr
        }
                if (targetObject == null)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    public void Shoot()
    {
        if (sword != null && !isCalledShoot)
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
            //gameObject.transform.DOKill();
            if (targetObject == null) // targetObject boþ ise
            {

                targetObject = other.gameObject; // Temas eden objeyi targetObject deðiþkenine ata

            }if (targetObject!=null)
            {
                Shoot();
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

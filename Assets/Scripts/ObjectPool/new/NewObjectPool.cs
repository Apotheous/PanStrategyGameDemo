using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class NewObjectPool : MonoBehaviour
{

    public List<GameObject> bullets = new List<GameObject>();
    public Transform desPos;
    public int shootingTime;
    public int bulletDamage;
    private GameObject notListedObject;
    private GameObject targetObject; // Temas ettiðimiz objeyi tutacak deðiþken
    private bool isCalledShoot;
    public GameObject MomObject;



    private void Start()
    {
        isCalledShoot = false;
    }

    public void Shoot()
    {
        if (bullets.Count > 0 && targetObject != null && !isCalledShoot)
        {
            isCalledShoot = true;

            GameObject bullet = bullets[0];
            bullet.SetActive(true);
            bullet.transform.SetParent(null);


            // Calculate the direction to the target object
            Vector2 direction = (targetObject.transform.position - bullet.transform.position).normalized;
            bullet.GetComponent<Rigidbody2D>().AddForce(direction * 5, ForceMode2D.Impulse);

            bullet.GetComponent<BulletDamageHolder>().damage_Value = bulletDamage;

            notListedObject = bullet;
            bullets.RemoveAt(0);

            Invoke("GetThePool", shootingTime);
        }
    }

    public void GetThePool()
    {
        if (notListedObject != null)
        {
            bullets.Add(notListedObject);
            notListedObject.transform.SetParent(desPos);
            notListedObject.transform.position = desPos.position;
            notListedObject.transform.rotation = MomObject.transform.rotation;
            notListedObject.SetActive(false);
            notListedObject = null;
        }

        isCalledShoot = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.tag == "Enemy")
        {
            if (targetObject == null) // targetObject boþ ise
            {
                targetObject = other.gameObject; // Temas eden objeyi targetObject deðiþkenine ata
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != null && other.tag == "Enemy")
        {

            if (targetObject == other.gameObject) // Temas eden obje tetikleyiciden çýkarsa
            {
                targetObject = null; // targetObject deðiþkenini boþalt
            }
        }
    }

    private void Update()
    {
        if (targetObject != null)
        {
            // Turn MomObject to face the targetObject without flipping upside down
            Vector3 direction = targetObject.transform.position - MomObject.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Clamp the angle to prevent flipping
            if (angle > 90 || angle < -90)
            {

                 //angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
                MomObject.transform.rotation = Quaternion.Euler(new Vector3(-180, 0, -angle));
            }
            else { MomObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); }


            Shoot(); // targetObject dolu ise Shoot metodunu çaðýr
        }if (targetObject == null)
        {
            MomObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
    //private void Start()
    //{
    //    isCalledShoot = false;
    //}

    //private void Update()
    //{
    //    if (targetObject != null)
    //    {
    //        // Turn MomObject to face the targetObject
    //        Vector3 direction = targetObject.transform.position - MomObject.transform.position;
    //        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //        MomObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    //        Shoot(); // targetObject dolu ise Shoot metodunu çaðýr
    //    }
    //}

    //public void Shoot()
    //{
    //    if (bullets.Count > 0 && !isCalledShoot)
    //    {
    //        isCalledShoot = true;

    //        GameObject bullet = bullets[0];
    //        bullet.SetActive(true);
    //        // Calculate the direction to the target object
    //        Vector2 direction = (targetObject.transform.position - bullet.transform.position).normalized;
    //        bullet.GetComponent<Rigidbody2D>().AddForce(direction * 15, ForceMode2D.Impulse);

    //        bullet.transform.SetParent(null);
    //        bullet.GetComponent<BulletDamageHolder>().damage_Value = bulletDamage;

    //        notListedObject = bullet;
    //        bullets.RemoveAt(0);

    //        Invoke("GetThePool", shootingTime);
    //    }
    //}

    //public void GetThePool()
    //{
    //    if (notListedObject != null)
    //    {
    //        bullets.Add(notListedObject);
    //        notListedObject.transform.SetParent(desPos);
    //        notListedObject.transform.position = desPos.position;
    //        notListedObject.SetActive(false);
    //        notListedObject = null;
    //    }
    //    isCalledShoot = false;
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other != null && other.tag !=gameObject.tag)
    //    {
    //        if (targetObject == null) // targetObject boþ ise
    //        {
    //            targetObject = other.gameObject; // Temas eden objeyi targetObject deðiþkenine ata
    //        }

    //    }
    //}

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other != null && other.tag != gameObject.tag)
    //    {
    //        if (targetObject == other.gameObject) // Temas eden obje tetikleyiciden çýkarsa
    //        {
    //            targetObject = null; // targetObject deðiþkenini boþalt
    //        }

    //    }
    //}
}

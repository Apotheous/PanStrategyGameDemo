using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOPCaller : MonoBehaviour
{
    public List<GameObject> bullets = new List<GameObject>();
    public Transform desPos;
    public int shootingTime;
    public int bulletDamage;
    private GameObject notListedObject;
    private GameObject targetObject; // Temas ettiðimiz objeyi tutacak deðiþken
    private bool isCalledShoot;

    [SerializeField]
    private List<string> targetTags; // Inspector'da düzenlenebilir tag listesi

    private void Start()
    {
        isCalledShoot = false;
    }

    public void Shoot()
    {
        if (bullets.Count > 0 && !isCalledShoot)
        {
            isCalledShoot = true;

            GameObject bullet = bullets[0];
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 15, ForceMode2D.Impulse);
            bullet.transform.SetParent(null);
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
            notListedObject.SetActive(false);
            notListedObject = null;
        }

        isCalledShoot = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && targetTags.Contains(other.tag))
        {
            if (targetObject == null) // targetObject boþ ise
            {
                targetObject = other.gameObject; // Temas eden objeyi targetObject deðiþkenine ata
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != null && targetTags.Contains(other.tag))
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
            Shoot(); // targetObject dolu ise Shoot metodunu çaðýr
        }
    }
}

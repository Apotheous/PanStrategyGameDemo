using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBarracColl : MonoBehaviour
{
    // Collider içine giren objeleri tutacak liste
    public List<GameObject> collidingObjects = new List<GameObject>();
    private static EnemyBarracColl _instance;
    public static EnemyBarracColl Instance { get { return _instance; } }

    public GameObject spawner;  
    private void Awake()
    {
        
        //if an instance of this already exits and it isn't this one
        if (_instance != null && _instance != this)
        {
            //we destroy this instance
            Destroy(this.gameObject);
        }
        else
        {
            //make this the instance
            _instance = this;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            spawner.GetComponent<EnemySpawner>().Shoot(); 
            // Eðer çarpýþan obje henüz listede yoksa, listeye ekle
            if (!collidingObjects.Contains(collision.gameObject))
            {
                collidingObjects.Add(collision.gameObject);
            }
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Eðer çarpýþan obje listede varsa, listeden çýkar
        if (collidingObjects.Contains(collision.gameObject))
        {
            collidingObjects.Remove(collision.gameObject);
        }
    }
}

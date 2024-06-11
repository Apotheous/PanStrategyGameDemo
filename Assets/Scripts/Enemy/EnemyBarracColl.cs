using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBarracColl : MonoBehaviour
{
    // Collider i�ine giren objeleri tutacak liste
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
            // E�er �arp��an obje hen�z listede yoksa, listeye ekle
            if (!collidingObjects.Contains(collision.gameObject))
            {
                collidingObjects.Add(collision.gameObject);
            }
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // E�er �arp��an obje listede varsa, listeden ��kar
        if (collidingObjects.Contains(collision.gameObject))
        {
            collidingObjects.Remove(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyTrooper;
    Transform parent;
    public bool onDestroy =false;
    public bool InsLock =false;
    GameObject barrackColl;

    private void Start()
    {
        parent = transform.parent;
        parent.GetComponent<Barrack>();
        foreach (Transform item in gameObject.transform.parent)
        {
            if (item.GetComponent<EnemyBarracColl>())
            {
                barrackColl = item.transform.gameObject;
            }
        }

    }
    private void Update()
    {
        if (barrackColl.GetComponent<EnemyBarracColl>().collidingObjects == null)
        {
            InsLock = false;
        }
        
    }
    IEnumerator Spawn()
    {

        yield return new WaitForSecondsRealtime(2f);
        if (InsLock)
        {
            Shoot();
        }
        
    }
    public void Shoot()
    {
        // Quaternion.Euler kullanarak y ekseninde 180 derece döndürülmüþ bir quaternion oluþtur
        Quaternion rotation = Quaternion.Euler(0, 180, 0);

        // enemyTrooper'ý bu dönüþümle instantiate et
        Instantiate(enemyTrooper, transform.position, rotation);
        StartCoroutine(Spawn());
        //Invoke("GetThePool", 2);

    }
    public void GetThePool()
    {
        if (onDestroy)
        {
            Shoot();
        }

    }
}

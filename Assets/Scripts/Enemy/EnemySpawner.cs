using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyTrooper;
    private void Start()
    {
        Shoot();
    }

    private void Shoot()
    {
        // Quaternion.Euler kullanarak y ekseninde 180 derece döndürülmüþ bir quaternion oluþtur
        Quaternion rotation = Quaternion.Euler(0, 180, 0);

        // enemyTrooper'ý bu dönüþümle instantiate et
        Instantiate(enemyTrooper, transform.position, rotation);
        Invoke("GetThePool", 1);
    }
    public void GetThePool()
    {
        
        Shoot();
    }
}

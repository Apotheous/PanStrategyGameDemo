using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControlls : MonoBehaviour
{
    void Start()
    {
        // Bu nesnenin BoxCollider2D bileþeni olup olmadýðýný kontrol eder ve yoksa ekler
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider == null)
        {
            boxCollider = gameObject.AddComponent<BoxCollider2D>();
        }

        // BoxCollider2D'yi tetikleyici olarak ayarlar
        boxCollider.isTrigger = true;
    }

    // Tetikleyiciye giriþ yapýldýðýnda tetiklenir
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player tetikleyiciye girdi.");
            other.GetComponent<Tile>().isOccupied= true;
        }
    }

    // Tetikleyici içinde kalýndýðýnda her frame'de tetiklenir
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player tetikleyici içinde.");
        }
    }

    // Tetikleyiciden çýkýldýðýnda tetiklenir
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player tetikleyiciden çýktý.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControlls : MonoBehaviour
{
    void Start()
    {
        // Bu nesnenin BoxCollider2D bile�eni olup olmad���n� kontrol eder ve yoksa ekler
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider == null)
        {
            boxCollider = gameObject.AddComponent<BoxCollider2D>();
        }
        // BoxCollider2D'yi tetikleyici olarak ayarlar
        boxCollider.isTrigger = true;
    }

    // Tetikleyiciye giri� yap�ld���nda tetiklenir
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            other.GetComponent<Tile>().isOccupied= true;
        }
    }
}

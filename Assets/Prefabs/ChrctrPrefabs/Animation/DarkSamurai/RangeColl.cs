using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangeColl : MonoBehaviour
{

    public GameObject momObject;
    public GameObject trgtObject;
    float distanceTarget;

    // Update is called once per frame
    void Update()
    {
        distanceTarget = Vector3.Distance(momObject.transform.position, trgtObject.transform.position);
        RangeObject(trgtObject);
    }

    private void RangeObject(GameObject targetObject)
    {
        if (targetObject!= null&&targetObject.activeSelf) 
        {
            if (distanceTarget < momObject.GetComponent<Unit>().attackRange)
            {
                momObject.transform.DOKill();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Enemy") 
        {
            trgtObject = collision.gameObject;
        }
    }
}

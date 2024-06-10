using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRange : MonoBehaviour
{
    public GameObject parent;
    public string _myCountryCode;

    private void Start()
    {
        parent = gameObject.transform.parent.gameObject;
        parent.GetComponent<Unit>();
        Debug.Log("ShootRange" + parent.name + _myCountryCode);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //parent.GetComponent<BulletPool>().enabled=false;
    }


}

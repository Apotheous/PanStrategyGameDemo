using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    private GameObject selectedObject;
    
    public LayerMask selectableLayers; // Seçilebilir layer'lar
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, selectableLayers);

            if (hit.collider != null)
            {
                if (selectedObject!=null&& selectedObject != hit.collider.gameObject)
                {
                    selectedObject.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = false;
                }
                    selectedObject = hit.collider.gameObject;
                Debug.Log("Selected Object2233333: " + selectedObject.name);
                selectedObject.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = true;

            }
            else 
            {
                selectedObject.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = false;
                Debug.Log("Selected Ground: " + selectedObject.name);
                selectedObject = null;

            }
        }
    }

    public GameObject GetSelectedObject()
    {
        return selectedObject;
    }
}

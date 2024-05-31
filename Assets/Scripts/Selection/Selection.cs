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
                Debug.Log("Selected Object: " + selectedObject.name);
                selectedObject.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = true;

            }
            else 
            {
                selectedObject.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = false;
                Debug.Log("Selected Ground: " + selectedObject.name);
                selectedObject = null;

            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("RightClick : " + selectedObject.name);
            if (selectedObject!= null)
            {
                Debug.Log("RightClick1 : " + selectedObject.name);


                    Debug.Log("RightClick2 : " + selectedObject.name);
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, selectableLayers);

                        Debug.Log("RightClick3 : " + selectedObject.name);
                        Unit b = selectedObject.GetComponent<Unit>();
                        if (b != null)
                        {
                            Debug.Log("RightClick4 : " + selectedObject.name);
                            b.Move(hit.point);
                        }

            }
        }
    }

    public GameObject GetSelectedObject()
    {
        return selectedObject;
    }
}

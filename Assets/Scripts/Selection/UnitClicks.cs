using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClicks : MonoBehaviour
{
    public LayerMask selectableLayers; // Seçilebilir layer'lar

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //if we hit a clickable object
            //RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, selectableLayers);

            if (hit.transform!=null)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    //shift clicked
                    UnitSelections.Instance.ShiftClickSelect(hit.collider.gameObject);
                    Debug.Log("LeftShiftClick" + hit.collider.name);

                }
                else
                {
                //normal clicked
                UnitSelections.Instance.ClickSelect(hit.collider.gameObject);
                    if (hit.collider.tag=="Building")
                    {
                        BuildingSelected.Instance.ClickSelect(hit.collider.gameObject);
                    }
                }

            }
            if (hit.transform==null )
            {
                if (UnitSelections.Instance.unitsSelected != null) { UnitSelections.Instance.DeselectAll(); } else { Debug.Log("object not choose"); }

            }
            //else
            //{
            //    //if we didn't && we're not shift clicking
            //    if (!Input.GetKey(KeyCode.LeftShift))
            //    {
            //        UnitSelections.Instance.DeselectAll();
            //    }

            //}
        }
    }
}

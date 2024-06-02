using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class SelectedObject : MonoBehaviour
{
    public Image soldierImage;
    public Image buildingImage;

    void Start()
    {
        soldierImage.enabled=false;
        buildingImage.enabled=false;

    }
    void Update()
    {
        //if (Input.GetMouseButtonUp(0))
        //{
            Debug.Log("UnitSelectedList Count: " + UnitSelections.Instance.unitsSelected.Count);
            if (UnitSelections.Instance.unitsSelected.Count == 1)
            {
                GameObject selectedUnit = UnitSelections.Instance.unitsSelected[0];
                Debug.Log("Selected Unit333: " + selectedUnit.name);

                if (selectedUnit.transform.gameObject.layer==7) 
                {
                    soldierImage.sprite = selectedUnit.GetComponent<SpriteRenderer>().sprite;
                    if (soldierImage != null)
                    {
                        soldierImage.enabled = true;
                        Debug.Log("Selected Object Layer = " + selectedUnit.transform.gameObject.layer.ToString());
                    }
                    else
                    {
                        Debug.LogWarning("SpriteRenderer component not found on the selected unit.");
                    }
                } if (selectedUnit.transform.gameObject.layer==6) 
                {
                    buildingImage.sprite = selectedUnit.GetComponent<SpriteRenderer>().sprite;
                    if (buildingImage != null)
                    {
                        buildingImage.enabled = true;
                        Debug.Log("Selected Object Layer = " + selectedUnit.transform.gameObject.layer.ToString());
                    }
                    else
                    {
                        Debug.LogWarning("SpriteRenderer component not found on the selected unit.");
                    }
                }
                
            }
            else
            {
                // Eðer birden fazla seçili ünite varsa, SoldierRenderer'ý devre dýþý býrak
                if (soldierImage != null)
                {
                    soldierImage.enabled = false;
                }
                if (buildingImage != null)
                {
                    buildingImage.enabled = false;
                }
            }
        //}
    }

}

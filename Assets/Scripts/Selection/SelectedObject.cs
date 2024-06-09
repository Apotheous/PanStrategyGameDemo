using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;
using static Unit;

public class SelectedObject : MonoBehaviour
{
    public Image soldierImage;
    public Text soldierText;
    public Text structureText;
    public Image buildingImage;


    void Start()
    {
        
        soldierImage.enabled=false;
        buildingImage.enabled=false;

    }
 
    void Update()
    {
        if (UnitSelections.Instance.unitsSelected.Count == 1)
        {
            GameObject selectedUnit = UnitSelections.Instance.unitsSelected[0];

            if (selectedUnit != null && selectedUnit.transform.gameObject.layer == 7)//**---
            {
                soldierImage.sprite = selectedUnit.GetComponent<SpriteRenderer>().sprite;
                if (soldierImage != null)
                {
                    soldierImage.enabled = true;
                    Character selectCha = selectedUnit.GetComponent<Character>();
                    soldierText.text = "Name = " + (selectCha.name.ToString()) +
                                      " Health = " + (selectCha.health.ToString()) +
                                      " Damage = " + (selectCha.damage.ToString());
                }
                else
                {
                    Debug.LogWarning("SpriteRenderer component not found on the selected unit.");
                }
            }
            if (selectedUnit != null && selectedUnit.transform.gameObject.layer == 6)
            {
                
                buildingImage.sprite = selectedUnit.GetComponent<SpriteRenderer>().sprite;
                if (buildingImage != null)
                {
                    buildingImage.enabled = true;
                    Structure selectStr = selectedUnit.GetComponent<Structure>();
                    structureText.text = "Name = " + (selectStr.name.ToString()) +
                                  " Health = " + (selectStr.health.ToString());
                }
                else
                {
                    Debug.LogWarning("SpriteRenderer component not found on the selected unit.");
                }
            }
        }
        else
        {
            //Eðer birden fazla seçili ünite varsa, SoldierRenderer'ý devre dýþý býrak
            if (soldierImage != null)
            {
                soldierImage.enabled = false;
                soldierText.text = "No Soldiers Selected";

            }
            if (buildingImage != null)
            {
                buildingImage.enabled = false;
                structureText.text = "No Structure Selected";
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductionMenuManager : MonoBehaviour
{
    public GameObject productionScr;
    public List<GameObject> pruducts = new List<GameObject>();
    void Start()
    {
        ScroolChildsFalse();
    }

    private void ScroolChildsFalse()
    {
        foreach (Transform child in productionScr.transform)
        {
            Debug.Log("Production Menu Items False = " + child.name);
            if (child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        UnitSelections selectionManager2 = FindObjectOfType<UnitSelections>();
        List<GameObject> selectedUnits = selectionManager2.GetUnitsSelected();
        if (selectedUnits != null && selectedUnits.Count > 0)
        {
            if (selectedUnits[0].name == "Central Building")
            {
                foreach (Transform child in productionScr.transform)
                {
                    if (child.gameObject.tag == "Building")
                    {
                        child.gameObject.SetActive(true);
                    }
                    else
                    {
                        child.gameObject.SetActive(false);
                    }
                }
            }
            else if (selectedUnits[0].name == "Barrack(Clone)")
            {
                foreach (Transform child in productionScr.transform)
                {
                    if (child.gameObject.tag == "Soldier")
                    {
                        child.gameObject.SetActive(true);
                    }
                    else
                    {
                        child.gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                ScroolChildsFalse();
            }

        }

    }
}

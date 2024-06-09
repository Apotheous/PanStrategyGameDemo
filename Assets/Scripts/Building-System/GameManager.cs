using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gold;
    private Building buildingToPlace;
    public GameObject grid;
    public CustomCursor cursor;
    public Tile[] tiles;
    private void Update()
    {
        if (Input.GetMouseButton(0)&&buildingToPlace!=null)
        {
            Tile nearesTile = null;
            float nearestDistance = float.MaxValue;
            foreach (Tile tile in tiles)
            {
                float dist = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (dist < nearestDistance) 
                { 
                    nearestDistance = dist;
                    nearesTile = tile; 
                }
            }
            if (nearesTile.isOccupied == false) 
            {
                if(buildingToPlace.tag == "Building") //**buildingToPlace.gameObject.layer==6
                {
                    Instantiate(buildingToPlace, nearesTile.transform.position, Quaternion.identity);
                }
                buildingToPlace = null;
                nearesTile.isOccupied = true;
                cursor.gameObject.SetActive(false);
                Cursor.visible = true;
            }
        }
    }

    public void SoldierSpawn(Building Soldier)
    {
        foreach (Transform t in BuildingSelected.Instance._selectedBuilding.transform)
        {
            if (t.name == "Spawner")
            {
                Instantiate(Soldier, t.transform.position, Quaternion.identity);
            }
        }
    }
    public void BuyBuilding(Building building)
    {
            cursor.gameObject.SetActive(true);
            cursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;  
            Cursor.visible = false;
            buildingToPlace = building;
    }
}

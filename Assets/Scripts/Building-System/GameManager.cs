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
    private void Start()
    {

        
    }
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
                Instantiate(buildingToPlace,nearesTile.transform.position,Quaternion.identity);
                buildingToPlace = null;
                nearesTile.isOccupied = true;

                //grid.SetActive(false);
                cursor.gameObject.SetActive(false);
                Cursor.visible = true;

            }

        }
    }


    public void BuyBuilding(Building building)
    {
        //if (gold>=building.cost)
        //{
            cursor.gameObject.SetActive(true);
            cursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;  
            Cursor.visible = false;
            //gold-=building.cost;
            //Debug.Log("wht is it Building?" + buildingToPlace.name);
            buildingToPlace = building;
            //Debug.Log("wht is it Building?" + buildingToPlace.name);
            //grid.SetActive(true);
        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Building buildingToPlace;
    public CustomCursor cursor;
    public Tile[] tiles;
    public float placementDistanceThreshold = 1.0f; // Threshold for building placement distance
    public SpriteRenderer unSelectArea;
    public Text Text;
    private void Update()
    {
        if (Input.GetMouseButton(0) && buildingToPlace != null)
        {
            Tile nearestTile = null;
            float nearestDistance = float.MaxValue;

            foreach (Tile tile in tiles)
            {
                float dist = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (dist < nearestDistance)
                {
                    nearestDistance = dist;
                    nearestTile = tile;
                }
            }

            // Check the nearest distance
            if (nearestDistance > placementDistanceThreshold)
            {
                Text.text = "The selected position is too far to place the building!";
                Debug.Log("The selected position is too far to place the building!");
                StartCoroutine(TextReset());
                return;
            }

            if (nearestTile.isOccupied == false)
            {
                if (buildingToPlace.tag == "Building")
                {

                    Instantiate(buildingToPlace, nearestTile.transform.position, Quaternion.identity);
                    unSelectArea.gameObject.SetActive(false);
                }
                buildingToPlace = null;
                nearestTile.isOccupied = true;
                cursor.gameObject.SetActive(false);
                Cursor.visible = true;
            }
            else
            {
                Debug.Log("The selected tile is already occupied!");
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
        if (building.tag == "Building")
        {
            unSelectArea.gameObject.SetActive(true);
        }
        Cursor.visible = false;
        buildingToPlace = building;
    }

    IEnumerator TextReset()
    {

        yield return new WaitForSecondsRealtime(3f);
        Text.text = "";
    }
}

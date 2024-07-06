using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Toolbox;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;


public class DemoPathFinding : MonoBehaviour
{
    public Transform endPos;
    //private Selection selectionManager;
    public Tilemap tilemap;
    public LineRenderer linePath;
    private List<Vector3> wayPoints;


    public GameObject attackingBuilding;

    public LayerMask enemyBuildingLayerMask;
    public Text DebugText;
    public float attackRange = 2f; // Attack range
    private void Start()
    {
        wayPoints = new List<Vector3>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            // Convert screen coordinates to world coordinates
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

            // Raycast
            RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero, Mathf.Infinity, enemyBuildingLayerMask);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy building is at the mouse position: " + hit.transform.name);
                }
                else
                {
                    Debug.Log("There is something else at the mouse position.");
                }
            }
            else
            {
                Debug.Log("There is nothing at the mouse position.");
            }

            UnitSelections selectionManager2 = FindObjectOfType<UnitSelections>();
            List<GameObject> selectedUnits = selectionManager2.GetUnitsSelected();
            foreach (GameObject unit in selectedUnits)
            {
                if (unit.layer == 7 && unit.CompareTag("Player"))
                {
                    if (unit != null && hit.collider != null)
                    {
                        Vector3 enemyBuildingPosition = hit.transform.position;
                        DebugText.text = "Attacking building: " + hit.transform.name;
                        MoveForAttack(unit, enemyBuildingPosition, 1.5f);
                    }
                    else
                    {
                        MoveForGlory(unit, 1.5f);
                    }
                }
            }
        }
    }

    void MoveForGlory(GameObject obj, float speed)
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos.y = mousePos.y + Random.Range(-0.75f, 0.75f);
        mousePos.x = mousePos.x + Random.Range(-0.75f, 0.75f);
        endPos.position = mousePos;

        UnitSelections selectionManager2 = FindObjectOfType<UnitSelections>();
        if (selectionManager2 != null)
        {
            wayPoints = AStar.FindPathClosest(tilemap, obj.transform.position, endPos.position);
        }
        else
        {
            Debug.LogWarning("UnitSelectionManager not found!");
        }
        if (wayPoints != null)
        {
            linePath.positionCount = wayPoints.Count;
            linePath.SetPositions(wayPoints.ToArray());

            if (selectionManager2 != null)
            {
                
                float distance = Vector3.Distance(obj.transform.position, endPos.position);

               
                float duration = distance / speed;

                obj.transform.DOPath(wayPoints.ToArray(), duration, PathType.Linear);
            }
            else
            {
                Debug.LogWarning("UnitSelectionManager not found!");
            }
        }
    }

    void MoveForAttack(GameObject unit, Vector3 enemyPosition, float speed)
    {
        endPos.position = enemyPosition;
        UnitSelections selectionManager2 = FindObjectOfType<UnitSelections>();
        if (selectionManager2 != null)
        {
            wayPoints = AStar.FindPathClosest(tilemap, unit.transform.position, endPos.position);
        }
        else
        {
            Debug.LogWarning("UnitSelectionManager not found!");
        }
        if (wayPoints != null)
        {
            linePath.positionCount = wayPoints.Count;
            linePath.SetPositions(wayPoints.ToArray());

            if (selectionManager2 != null)
            {

                float distanceToTarget = Vector3.Distance(unit.transform.position, enemyPosition);

                float duration = distanceToTarget / speed;
                unit.transform.DOPath(wayPoints.ToArray(), duration, PathType.Linear)
                    .SetEase(Ease.Linear)
                    .OnUpdate(() =>
                    {
                        float distanceToTargetUpdate = Vector3.Distance(unit.transform.position, enemyPosition);
                        if (distanceToTargetUpdate <= unit.GetComponent<Unit>().attackRange)
                        {
                            unit.transform.DOKill(); // Stop the movement
                            Debug.Log("Unit is within attack range. Stopping movement.");
                        }
                    });
            }
            else
            {
                Debug.LogWarning("UnitSelectionManager not found!");
            }
        }
    }
}

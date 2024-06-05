using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCntrllr : MonoBehaviour
{
    public float speed = 5f;
    private Selection selectionManager;

    void Start()
    {
        selectionManager = FindObjectOfType<Selection>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && selectionManager.GetSelectedObject() != null)
        {
            Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject selectedObject = selectionManager.GetSelectedObject();
            StartCoroutine(MoveToObject(selectedObject, targetPosition));
        }
    }
    private IEnumerator MoveToObject(GameObject obj, Vector2 targetPosition)
    {
        while ((Vector2)obj.transform.position != targetPosition)
        {
            obj.transform.position = Vector2.MoveTowards(obj.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasOn : MonoBehaviour
{
    public GameObject Canvas;
    void Start()
    {
        if (!Canvas.gameObject.activeSelf)
        {
            Canvas.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

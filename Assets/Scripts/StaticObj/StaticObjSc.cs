using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticObjSc : MonoBehaviour
{
    public Text debugText;
    public GameObject Canvas;
    void Start()
    {
        debugText=GetComponent<Text>();
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

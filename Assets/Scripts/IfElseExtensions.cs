using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class IfElseExtensions 
{
    public static void IfElseObjArrayCheck(GameObject[] extObjcts)
    {
        //PublicToPrefab.DebugText.text = "==1" ;
        Debug.Log("==1" );
        foreach (GameObject obj in extObjcts)
        {
            if (obj!=null)
            {
                if (obj.activeSelf)
                {
                     //PublicToPrefab.DebugText.text = obj.name+"==1"+obj.active;
                     Debug.Log(obj.name + "==1" + obj.active);
                }
                else if (!obj.activeSelf)
                {
                    //PublicToPrefab.DebugText.text = obj.name + "==1" + obj.active;
                    Debug.Log(obj.name.ToString() + "==1" + obj.active);
                }
                else
                {
                    //PublicToPrefab.DebugText.text = "This Problem!" + obj.name + "==1" + obj.active;
                    Debug.Log("This Problem!" + obj.name + "==1" + obj.active);
                }
            }
            else if (obj==null)
            {
                Debug.Log("This Problem! obj ==1 Null");
            }
            else
            {
                Debug.Log("This Problem! ==1 Else");
            }
        }
    }
    public static void IfElseObjectCheck(GameObject obj)
    {
        if (obj == null)
        {
            Debug.Log("IfElseObjectCheck null geldi: " + obj);
        }
        else
        {
            Debug.Log("IfElseObjectCheck Adý: " + obj.name + " object defined.");
            //obj.SetActive(false);
        }
    }
    public static void GameObjSetActToFalse(GameObject obj)
    {
        if (obj == true)
        {
            obj.SetActive(false);
        }
        else
        {
            Debug.Log("Obje False Baþladý Object Name: " + obj.name);
        }
    }
    public static void NetworkErrorsCheck(UnityWebRequest request)
    {
        if (request.isNetworkError)
        {
            Debug.Log("network error" + request.error);
        }
        else if (request.isHttpError)
        {
            Debug.Log("http error " + request.error);
        }
        else
        {
            Debug.Log("Succes Controll " + request.url);
        }
    }
}

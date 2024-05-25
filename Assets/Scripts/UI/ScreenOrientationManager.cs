using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientationManager : MonoBehaviour
{
    public delegate void OrientationChangeHandler(ScreenOrientation newOrientation);
    public static event OrientationChangeHandler OnOrientationChanged;

    /*
     * Bu siniff baslangicta�ali�iyor
     * sonrasinda examleListener tarafindan ekran Y�nelimi her de�i�ti�inde �agiriliyor
     * */

    private void Start()
    {
        float width, height;
        if (Screen.width > Screen.height)
        {
            width = Screen.width / 10f;
            height = Screen.height / 20;

        }
        else if (Screen.height > Screen.width)
        {

            width = Screen.width / 6f;
            height = Screen.height / 40;

        }
        else
        {
            Debug.Log("");
        }
        // Ba�lang��ta ekran y�nelimini kontrol et
        CheckOrientation();
    }

    private void Update()
    {
        // Ekran y�nelimi de�i�ti�inde kontrol et
        CheckOrientation();
    }

    private void CheckOrientation()
    {
        ScreenOrientation currentOrientation = Screen.orientation;
        if (currentOrientation != lastOrientation)
        {
            lastOrientation = currentOrientation;
            OnOrientationChanged?.Invoke(currentOrientation);
        }
    }

    private ScreenOrientation lastOrientation;
}

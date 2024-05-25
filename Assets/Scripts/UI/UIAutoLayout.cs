using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public static class UIAutoLayout 
{
    public static void SetConstraints(GameObject UIElements, float panelsHeight, float offsetX = 20f, float offsetY = 30f, float? posX = null, Vector2 ? size = null)
    {
        // 'UIElements' GameObject'inin RectTransform ögesini al
        RectTransform rectTransform = UIElements.GetComponent<RectTransform>();

        // Offset ayarlarını belirle
        SetOffsets(rectTransform, offsetX, offsetY, panelsHeight);

        // posX değeri sağlanmışsa, X pozisyonunu ayarla
        if (posX.HasValue)
        {
            SetPosX(rectTransform, posX.Value);
        }
        // size değeri sağlanmışsa, boyutu ayarla
        if (size.HasValue)
        {
            SetSize(rectTransform, size.Value);
        }

    }

    public static void SetOffsets(RectTransform rectTransform, float offsetX, float offsetY, float panelsHeight)
    {
        rectTransform.offsetMin = new Vector2(offsetX, offsetY);
        rectTransform.offsetMax = new Vector2(-offsetX, panelsHeight);
    }

    public static void SetPosX(RectTransform rectTransform, float posX)
    {
        // Mevcut y pozisyonunu al ve sadece x pozisyonunu değiştir
        Vector2 newPosition = new Vector2(posX, rectTransform.anchoredPosition.y);
        rectTransform.anchoredPosition = newPosition;
    }

    public static void SetSize(RectTransform rectTransform, Vector2 size)
    {
        // RectTransform'un boyutunu ayarla
        rectTransform.sizeDelta = size;
    }
}

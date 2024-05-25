using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PublicToPrefab : MonoBehaviour
{
    public static GameObject ProductuonMenuBg, ProductuonMenuPanel, ProductuonMenuContainer, ProductuonMenuImage;
    public static GameObject InformationMenuBg, ProductuonMenuPanel2, ProductuonMenuContainer2, InformationMenuImage, ChooseBuilding;

    void Start()
    {
        ForBeginLeftPanelElements();
        ForBeginLeftPanelElements2();
    }

    private static void ForBeginLeftPanelElements()
    {
        ProductuonMenuBg = GameObject.Find("ProductionMenuBg");
        IfElseExtensions.IfElseObjectCheck(ProductuonMenuBg);
        ProductuonMenuPanel = GameObject.Find("ProductuonMenuPanel");
        IfElseExtensions.IfElseObjectCheck(ProductuonMenuPanel);
        ProductuonMenuContainer = GameObject.Find("ProductuonMenuContainer");
        IfElseExtensions.IfElseObjectCheck(ProductuonMenuContainer);
        ProductuonMenuImage = GameObject.Find("ProductuonMenuImage");
        IfElseExtensions.IfElseObjectCheck(ProductuonMenuImage);
    }    
    private static void ForBeginLeftPanelElements2()
    {
        InformationMenuBg = GameObject.Find("InformationMenuBg");
        IfElseExtensions.IfElseObjectCheck(InformationMenuBg);
        ChooseBuilding = GameObject.Find("ChooseBuilding");
        IfElseExtensions.IfElseObjectCheck(ChooseBuilding);
        //ProductuonMenuPanel2 = GameObject.Find("ProductuonMenuPanel2");
        //IfElseExtensions.IfElseObjectCheck(ProductuonMenuPanel);
        //ProductuonMenuContainer2 = GameObject.Find("ProductuonMenuContainer2");
        //IfElseExtensions.IfElseObjectCheck(ProductuonMenuContainer);
        InformationMenuImage = GameObject.Find("InformationMenuImage");
        IfElseExtensions.IfElseObjectCheck(InformationMenuImage);
    }

}

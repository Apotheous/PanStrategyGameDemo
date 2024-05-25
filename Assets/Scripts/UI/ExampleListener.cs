using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine.UI;
using UnityEngine;

public class ExampleListener : MonoBehaviour
{
    
    public float ScreenHei = Screen.height;
    public float ScreenWidth = Screen.width;

    public float ScrX = Screen.width / (-10);  
    public float ScrY = Screen.height / 10;

    float uýObjDisVAncForPotrait ;
    float uýObjDisVAncForLandspace;
    private void Update()
    {
         ScreenHei = Screen.height;
         ScreenWidth = Screen.width;
}
    private void OnEnable()
    {
        ScreenOrientationManager.OnOrientationChanged += HandleOrientationChange;

    }

    private void OnDisable()
    {
        ScreenOrientationManager.OnOrientationChanged -= HandleOrientationChange;
    }

    private void HandleOrientationChange(ScreenOrientation newOrientation)
    {
        Debug.Log("Ekran yönelimi deðiþti: " + newOrientation);
        float width, height,bttnsHeight,bttnsWidth;
        width = Screen.width * 0.1f;
        height = Screen.height * 0.06f;
        if (Screen.width > Screen.height)
        {
            width = Screen.width *0.1f;
            height = Screen.height *0.06f;

            UIAutoLayout.SetConstraints(PublicToPrefab.ProductuonMenuBg, 0, -width, 0, width);
            UIAutoLayout.SetConstraints(PublicToPrefab.ProductuonMenuPanel,-height, -width, width, width);
            UIAutoLayout.SetConstraints(PublicToPrefab.ProductuonMenuContainer, -(Screen.height * 0.01f), -width, 0, width);
            UIAutoLayout.SetConstraints(PublicToPrefab.ProductuonMenuImage, -(Screen.width * 0.01f), -(Screen.width * 0.09f), - height, 0);
            PublicToPrefab.ProductuonMenuContainer.GetComponent<GridLayoutGroup>().spacing=new Vector2((Screen.width * 0.001f), (Screen.height * 0.001f));

            //Panels2
            UIAutoLayout.SetConstraints(PublicToPrefab.InformationMenuBg, 0, -width, 0, -width);
            //UIAutoLayout.SetConstraints(PublicToPrefab.ProductuonMenuPanel2,-height, -width, width, -width);
            //UIAutoLayout.SetConstraints(PublicToPrefab.ProductuonMenuContainer2, -(Screen.height * 0.01f), -width, 0, -width);
            UIAutoLayout.SetConstraints(PublicToPrefab.InformationMenuImage, -(Screen.width * 0.01f), -(Screen.width * 0.09f), - height, 0);
            UIAutoLayout.SetConstraints(PublicToPrefab.ChooseBuilding, 0, 0, 100, 0) ;
            //PublicToPrefab.ProductuonMenuContainer.GetComponent<GridLayoutGroup>().spacing=new Vector2((Screen.width * 0.001f), (Screen.height * 0.001f));
        }
        else
        {
            width = Screen.width *0.1f;
            height = Screen.height * 0.03f;

            UIAutoLayout.SetConstraints(PublicToPrefab.ProductuonMenuBg, 0, -width, 0, width);
            UIAutoLayout.SetConstraints(PublicToPrefab.ProductuonMenuPanel,-height, -width, width, width);
            UIAutoLayout.SetConstraints(PublicToPrefab.ProductuonMenuContainer, -(Screen.height * 0.01f), -width, 0, width);
            UIAutoLayout.SetConstraints(PublicToPrefab.ProductuonMenuImage, -(Screen.width * 0.01f), -(Screen.width * 0.09f), -height, 0);
            PublicToPrefab.ProductuonMenuContainer.GetComponent<GridLayoutGroup>().spacing = new Vector2((Screen.width * 0.001f), (Screen.height * 0.001f));

            //Panels2
            UIAutoLayout.SetConstraints(PublicToPrefab.InformationMenuBg, 0, -width, 0, -width);
            //UIAutoLayout.SetConstraints(PublicToPrefab.ProductuonMenuPanel2,-height, -width, width, -width);
            //UIAutoLayout.SetConstraints(PublicToPrefab.ProductuonMenuContainer2, -(Screen.height * 0.01f), -width, 0, -width);
            UIAutoLayout.SetConstraints(PublicToPrefab.InformationMenuImage, -(Screen.width * 0.01f), -(Screen.width * 0.09f), -height, 0);
            UIAutoLayout.SetConstraints(PublicToPrefab.ChooseBuilding, 0, 0, 100, 0);//(Screen.height * 0.1f), -(Screen.width * 0.09f), -(Screen.height * 0.1f), 0)
            //PublicToPrefab.ProductuonMenuContainer.GetComponent<GridLayoutGroup>().spacing = new Vector2((Screen.width * 0.001f), (Screen.height * 0.001f));
        }
    }


}

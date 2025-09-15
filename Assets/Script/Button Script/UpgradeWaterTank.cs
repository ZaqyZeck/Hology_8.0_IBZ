using TMPro;
using UnityEngine;

public class UpgradeWaterTank : MonoBehaviour
{
    [SerializeField] private PlantSystem plantSystem;

    [SerializeField] private GameObject tutorialUI;

    [SerializeField] private TextMeshPro UiText;
    int lv;

    private void OnMouseExit()
    {
        UiText.text = "";
    }

    private void OnMouseEnter()
    {
        CheckPrice();
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (tutorialUI.activeSelf) 
            {
                tutorialUI.SetActive(false);
                alurTutorial.alur[1] = true;
            } 
            plantSystem.UpgradeWaterTank();
            CheckPrice();
            Debug.Log("terpencet");
        }
    }

    void CheckPrice()
    {
        lv = plantSystem.waterTankLevel;
        switch (lv)
        {
            case 0:
                lv = 200;
                break;
            case 1:
                lv = 600;
                break;
            case 2:
                lv = 1000;
                break;
        }

        UiText.text = $"Upgrade for\n{lv} G";
    }
}

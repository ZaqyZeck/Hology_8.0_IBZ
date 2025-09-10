using UnityEngine;

public class UpgradeWaterTank : MonoBehaviour
{
    [SerializeField] private PlantSystem plantSystem;

    [SerializeField] private GameObject tutorialUI;

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
            Debug.Log("terpencet");
        }
    }
}

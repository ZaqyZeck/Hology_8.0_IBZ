using UnityEngine;
using UnityEngine.UI;

public class FarmUpgrade : MonoBehaviour
{

    // save data
    public int farmLevel;
    //public int bonusYields;
    public int[] upgradePrice;

    public string farmType;


    [SerializeField] private InventorySystem inventorySystem;
    [SerializeField] private Text priceUiCounter;
    private LandLot[] landLot;
    public void UpgradeFarm()
    {
        if (farmLevel >= upgradePrice.Length) return;
        if (upgradePrice[farmLevel] > inventorySystem.coins) return;

        inventorySystem.coins -= upgradePrice[farmLevel];
        farmLevel++;

        
        LoadUpgradeLandLot();
    }

    public void LoadUpgradeLandLot()
    {
        if (farmLevel < upgradePrice.Length) priceUiCounter.text = $"G {upgradePrice[farmLevel]}";
        else priceUiCounter.text = "MAX";
        landLot = GetComponentsInChildren<LandLot>();
        foreach (LandLot lot in landLot)
        {
            lot.farmLevel = farmLevel;
            lot.farmType = farmType;
        }
    }
}

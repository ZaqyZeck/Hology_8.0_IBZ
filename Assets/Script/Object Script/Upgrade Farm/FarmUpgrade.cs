using UnityEngine;

public class FarmUpgrade : MonoBehaviour
{

    // save data
    public int farmLevel;
    //public int bonusYields;
    public int[] upgradePrice;

    public string farmType;


    [SerializeField] private InventorySystem inventorySystem;
    private LandLot[] landLot;
    public void UpgradeFarm()
    {
        if (farmLevel >= landLot.Length) return;
        if (upgradePrice[farmLevel] > inventorySystem.coins) return;

        farmLevel++;
        LoadUpgradeLandLot();
    }

    public void LoadUpgradeLandLot()
    {
        landLot = GetComponentsInChildren<LandLot>();
        foreach (LandLot lot in landLot)
        {
            lot.farmLevel = farmLevel;
            lot.farmType = farmType;
        }
    }
}

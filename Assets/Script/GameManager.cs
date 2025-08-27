using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int day = 0;
    [SerializeField] private PlantSystem plantSystem;
    [SerializeField] private PowerStorage powerStorage;
    [SerializeField] private InventorySystem inventory;
    public void skipDays()
    {
        day += 6;
        plantSystem.GetAllPlant();
        plantSystem.ResetAll();
        plantSystem.WaterAll();
        plantSystem.GrowAll();
        powerStorage.GiveEnergy();
        powerStorage.BuffAllPlant();
    }

    public void saveAllData()
    {
        plantSystem.SavePlantsData();
        inventory.SaveInventory();
        powerStorage.SaveAllGenerators();
        powerStorage.SaveMachines();
    }

    public void loadAllData()
    {
        plantSystem.LoadPlantsData();
        inventory.LoadInventoryData();
        powerStorage.LoadGenerators();
        powerStorage.LoadMachines();
    }
}

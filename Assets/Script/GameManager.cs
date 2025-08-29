using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int day = 0;
    [SerializeField] private PlantSystem plantSystem;
    [SerializeField] private PowerStorage powerStorage;
    [SerializeField] private InventorySystem inventory;
    [SerializeField] private QuestSystem questSystem;

    [SerializeField] private UiController ui;
    public void skipDays()
    {
        questSystem.autoComplete();
        questSystem.CekQuest();
        day += 6;
        plantSystem.GetAllPlant();
        plantSystem.ResetAll();
        plantSystem.WaterAll();
        plantSystem.GrowAll();
        powerStorage.GiveEnergy();
        powerStorage.BuffAllPlant();

        ui.countDate(day);

        saveAllData();
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

    public void GameOver()
    {
        Debug.LogError("Game selesai");
    }

}

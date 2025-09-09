using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int day = 0;
    [SerializeField] private PlantSystem plantSystem;
    [SerializeField] private PowerStorage powerStorage;
    [SerializeField] private InventorySystem inventory;
    [SerializeField] private QuestSystem questSystem;

    [SerializeField] private UiController ui;

    [SerializeField] private EnemyScript enemyScript;

    [SerializeField] private GameObject loseUI;

    bool gameOver;
    private void Start()
    {
        loadAllData();
    }

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

        // system/event  untuk enemy competition
        enemyScript.EnemyGetYields();
        CheckDayEvent();

        ui.countDate(day);

        if (!gameOver) saveAllData();
    }

    void CheckDayEvent()
    {
        switch (day)
        {
            case 90:
                enemyScript.FinalDay(); 
                break;
            case 96:
                enemyScript.ChangeEnemy();
                break;
            case 180: 
                enemyScript.FinalDay();
                break;
            case 186:
                enemyScript.ChangeEnemy();
                break;
            case 270:
                enemyScript.FinalDay();
                break;
            case 276:
                enemyScript.ChangeEnemy();
                break;
            case 360:
                enemyScript.FinalDay();
                break;
            case 366:
                // Game Ending
                break;
        }
    }

    public void saveAllData()
    {
        SaveGameData();

        plantSystem.SaveWaterTank();

        plantSystem.SavePlantsData();

        plantSystem.SaveFarmUpgradeData();

        inventory.SaveInventory();
        powerStorage.SaveAllGenerators();
        powerStorage.SaveMachines();

        enemyScript.SaveEnemyData();
    }

    public void loadAllData()
    {
        LoadGameData();

        plantSystem.LoadWaterTank();

        plantSystem.LoadPlantsData();

        plantSystem.LoadFarmUpgradeData();

        inventory.LoadInventoryData();
        powerStorage.LoadGenerators();
        powerStorage.LoadMachines();

        enemyScript.LoadEnemyData();

        ui.countDate(day);
    }

    public void DeleteAllData()
    {
        MainSaveSystem.SaveFarmUpgradeData(null);
        MainSaveSystem.SaveGameData(0);
        MainSaveSystem.SaveWaterTankData(0);
        MainSaveSystem.SaveGeneratorsData(null);
        MainSaveSystem.SaveInventoryData(null, 0);
        MainSaveSystem.SaveMachinesData(null);
        MainSaveSystem.SavePlantsData(null);
        MainSaveSystem.SaveEnemyData(null, 0);
    }

    public void GameOver()
    {
        gameOver = true;
        loseUI.SetActive(true);
        DeleteAllData();
        Debug.LogError("Game selesai");
    }

    void SaveGameData()
    {
        MainSaveSystem.SaveGameData(day);
    }

    void LoadGameData()
    {
        GameData gameData = MainSaveSystem.LoadGameData();
        if (gameData != null ) day = gameData.day;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

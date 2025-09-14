using System.Collections;
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
    [SerializeField] private GameObject skipDayButton, duelButton;

    [SerializeField] private TutorialSystem tutorialSystem;

    [SerializeField] private GlobarWarmingSystem globarWarmingSystem;

    [SerializeField] private Text[] turnsLeftTexts;
    
    bool gameOver;

    //[Header("skip animation")]
    [SerializeField] GameObject blackScreen, textNextTurn, challengingSprite, turnCounter;
    //int GW_level;  
    
    private void Start()
    {
        loadAllData();
    }
    public void skipDays()
    {
        StopAllCoroutines();
        StartCoroutine(SkipDaysCoroutine());
    }

    private IEnumerator SkipDaysCoroutine()
    {
        // jalankan animasi skip
        SkipDayAnimation();

        // tunggu 1 detik (biar animasi sempat kelihatan dulu)
        yield return new WaitForSeconds(1f);

        try { questSystem.autoComplete(); }
        catch (System.Exception e) { Debug.LogError("autoComplete Error: " + e.Message); }

        try { questSystem.CekQuest(); }
        catch (System.Exception e) { Debug.LogError("CekQuest Error: " + e.Message); }

        try { day += 6; }
        catch (System.Exception e) { Debug.LogError("day increment Error: " + e.Message); }

        try { powerStorage.GiveEnergyToWaterTank(); }
        catch (System.Exception e) { Debug.LogError("GiveEnergyToWaterTank Error: " + e.Message); }

        try { plantSystem.GetAllPlant(); }
        catch (System.Exception e) { Debug.LogError("GetAllPlant Error: " + e.Message); }

        try { plantSystem.ResetAll(); }
        catch (System.Exception e) { Debug.LogError("ResetAll Error: " + e.Message); }

        try { plantSystem.WaterAll(); }
        catch (System.Exception e) { Debug.LogError("WaterAll Error: " + e.Message); }

        try { plantSystem.GrowAll(); }
        catch (System.Exception e) { Debug.LogError("GrowAll Error: " + e.Message); }

        try { powerStorage.GiveEnergy(); }
        catch (System.Exception e) { Debug.LogError("GiveEnergy Error: " + e.Message); }

        try { powerStorage.BuffAllPlant(); }
        catch (System.Exception e) { Debug.LogError("BuffAllPlant Error: " + e.Message); }

        try { enemyScript.EnemyGetYields(); }
        catch (System.Exception e) { Debug.LogError("EnemyGetYields Error: " + e.Message); }

        try { CheckDayEvent(); }
        catch (System.Exception e) { Debug.LogError("CheckDayEvent Error: " + e.Message); }

        try { ui.countDate(day); }
        catch (System.Exception e) { Debug.LogError("countDate Error: " + e.Message); }

        countTurnLeft();

        try { if (!gameOver) saveAllData(); }
        catch (System.Exception e) { Debug.LogError("saveAllData Error: " + e.Message); }
    }


    void CheckDayEvent()
    {
        switch (day)
        {
            case 6:
                alurTutorial.alur[5] = true;
                skipDayButton.SetActive(false);
                break;
            case 12:
                alurTutorial.alur[9] = true;
                break;
            case 90:
                skipDayButton.SetActive(false);
                duelButton.SetActive(true);
                //enemyScript.FinalDay(); 
                break;
            case 96:
                enemyScript.ChangeEnemy();
                break;
            case 180:
                skipDayButton.SetActive(false);
                duelButton.SetActive(true);
                break;
            case 186:
                enemyScript.ChangeEnemy();
                break;
            case 270:
                skipDayButton.SetActive(false);
                duelButton.SetActive(true);
                break;
            case 276:
                enemyScript.ChangeEnemy();
                break;
            case 360:
                skipDayButton.SetActive(false);
                duelButton.SetActive(true);
                break;
            case 366:
                GoToEnding();
                break;
        }
    }

    public void saveAllData()
    {
        try { SaveGameData(); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveGameData Error: " + e.Message); }

        try { plantSystem.SaveWaterTank(); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveWaterTank Error: " + e.Message); }

        try { plantSystem.SavePlantsData(); } catch (System.Exception e) { UnityEngine.Debug.LogError("SavePlantsData Error: " + e.Message); }

        try { plantSystem.SaveFarmUpgradeData(); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveFarmUpgradeData Error: " + e.Message); }

        try { inventory.SaveInventory(); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveInventory Error: " + e.Message); }

        try { powerStorage.SaveAllGenerators(); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveAllGenerators Error: " + e.Message); }

        try { powerStorage.SaveMachines(); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveMachines Error: " + e.Message); }

        try { enemyScript.SaveEnemyData(); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveEnemyData Error: " + e.Message); }

        try { tutorialSystem.SaveTutorialData(); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveTutorialData Error: " + e.Message); }

        globarWarmingSystem.loadGWLevelUI();
        //SaveGameData();

        //plantSystem.SaveWaterTank();

        //plantSystem.SavePlantsData();

        //plantSystem.SaveFarmUpgradeData();

        //inventory.SaveInventory();
        //powerStorage.SaveAllGenerators();
        //powerStorage.SaveMachines();

        //enemyScript.SaveEnemyData();

        //tutorialSystem.SaveTutorialData();
    }

    public void loadAllData()
    {
        try { LoadGameData(); } catch (System.Exception e) { UnityEngine.Debug.LogError("LoadGameData Error: " + e.Message); }

        try { plantSystem.LoadWaterTank(); } catch (System.Exception e) { UnityEngine.Debug.LogError("LoadWaterTank Error: " + e.Message); }

        try { plantSystem.LoadPlantsData(); } catch (System.Exception e) { UnityEngine.Debug.LogError("LoadPlantsData Error: " + e.Message); }

        try { plantSystem.LoadFarmUpgradeData(); } catch (System.Exception e) { UnityEngine.Debug.LogError("LoadFarmUpgradeData Error: " + e.Message); }

        try { inventory.LoadInventoryData(); } catch (System.Exception e) { UnityEngine.Debug.LogError("LoadInventoryData Error: " + e.Message); }

        try { powerStorage.LoadGenerators(); } catch (System.Exception e) { UnityEngine.Debug.LogError("LoadGenerators Error: " + e.Message); }

        try { powerStorage.LoadMachines(); } catch (System.Exception e) { UnityEngine.Debug.LogError("LoadMachines Error: " + e.Message); }

        try { enemyScript.LoadEnemyData(); } catch (System.Exception e) { UnityEngine.Debug.LogError("LoadEnemyData Error: " + e.Message); }

        try { tutorialSystem.LoadTutorialData(); } catch (System.Exception e) { UnityEngine.Debug.LogError("LoadTutorialData Error: " + e.Message); }

        try { ui.countDate(day); } catch (System.Exception e) { UnityEngine.Debug.LogError("countDate Error: " + e.Message); }

        countTurnLeft();

        globarWarmingSystem.loadGWLevelUI();
        //LoadGameData();

        //plantSystem.LoadWaterTank();

        //plantSystem.LoadPlantsData();

        //plantSystem.LoadFarmUpgradeData();

        //inventory.LoadInventoryData();
        //powerStorage.LoadGenerators();
        //powerStorage.LoadMachines();

        //enemyScript.LoadEnemyData();

        //tutorialSystem.LoadTutorialData();

        //ui.countDate(day);

    }

    public void DeleteAllData()
    {
        try { MainSaveSystem.SaveFarmUpgradeData(null); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveFarmUpgradeData Error: " + e.Message); }

        try { MainSaveSystem.SaveGameData(0, globarWarmingSystem.startingLevel); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveGameData Error: " + e.Message); }

        try { MainSaveSystem.SaveWaterTankData(0, 0); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveWaterTankData Error: " + e.Message); }

        try { MainSaveSystem.SaveGeneratorsData(null, 0, 0); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveGeneratorsData Error: " + e.Message); }

        try { MainSaveSystem.SaveInventoryData(null, 9999); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveInventoryData Error: " + e.Message); }

        try { MainSaveSystem.SaveMachinesData(null); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveMachinesData Error: " + e.Message); }

        try { MainSaveSystem.SavePlantsData(null); } catch (System.Exception e) { UnityEngine.Debug.LogError("SavePlantsData Error: " + e.Message); }

        try { MainSaveSystem.SaveEnemyData(null, 0); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveEnemyData Error: " + e.Message); }

        try { MainSaveSystem.SaveTutorialData(null); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveTutorialData Error: " + e.Message); }

        //MainSaveSystem.SaveFarmUpgradeData(null);
        //MainSaveSystem.SaveGameData(0, globarWarmingSystem.startingLevel);
        //MainSaveSystem.SaveWaterTankData(0);
        //MainSaveSystem.SaveGeneratorsData(null);
        //MainSaveSystem.SaveInventoryData(null, 450);
        //MainSaveSystem.SaveMachinesData(null);
        //MainSaveSystem.SavePlantsData(null);
        //MainSaveSystem.SaveEnemyData(null, 0);
        //MainSaveSystem.SaveTutorialData(null);
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
        MainSaveSystem.SaveGameData(day, globarWarmingSystem.currentLevel);
    }

    void LoadGameData()
    {
        GameData gameData = MainSaveSystem.LoadGameData();
        if (gameData != null)
        {
            day = gameData.day;
            globarWarmingSystem.currentLevel = gameData.GW_level;
            globarWarmingSystem.loadGWLevelUI();
        }

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToEnding()
    {
        DeleteAllData();
        if (globarWarmingSystem.currentLevel < 1)
        {
            SceneManager.LoadScene("Ending3");
        }
        else if (globarWarmingSystem.currentLevel >= 400)
        {
            SceneManager.LoadScene("Ending1");
        }
        else SceneManager.LoadScene("Ending2");
    }

    public void countTurnLeft()
    {
        int turnLeft;
        if (day < 12)
        {
            return;
        }
        turnLeft = (90 + (90 * enemyScript.enemyEncounter) - day) / 6;

        foreach( Text text in turnsLeftTexts)
        {
            text.text = $"{turnLeft} turns left";
            
        }

        if ((turnLeft == 15 && day != 6) || day == 12)
        {
            turnsLeftTexts[1].text = "A new enemy has arrived1";
        }
    }

    public void SkipDayAnimation()
    {
        blackScreen.SetActive(true);
        int turnLeft = (90 + (90 * enemyScript.enemyEncounter) - day) / 6;
        turnCounter.SetActive(true);
        turnCounter.GetComponent<Text>().text = $"Turn {(day + 6) / 6}";
        if ((turnLeft == 15 && day != 0) || day == 6) challengingSprite.SetActive(true);
        else 
        { 
            textNextTurn.SetActive(true);
            //turnsLeftTexts[1].text = $"{turnLeft} turn left";
        }
    }
    //public void skipDays()
    //{
    //    SkipDayAnimation();
    //    try { questSystem.autoComplete(); }
    //    catch (System.Exception e) { Debug.LogError("autoComplete Error: " + e.Message); }

    //    try { questSystem.CekQuest(); }
    //    catch (System.Exception e) { Debug.LogError("CekQuest Error: " + e.Message); }

    //    try { day += 6; }
    //    catch (System.Exception e) { Debug.LogError("day increment Error: " + e.Message); }

    //    try { powerStorage.GiveEnergyToWaterTank(); }
    //    catch (System.Exception e) { Debug.LogError("GiveEnergyToWaterTank Error: " + e.Message); }

    //    try { plantSystem.GetAllPlant(); }
    //    catch (System.Exception e) { Debug.LogError("GetAllPlant Error: " + e.Message); }

    //    try { plantSystem.ResetAll(); }
    //    catch (System.Exception e) { Debug.LogError("ResetAll Error: " + e.Message); }

    //    try { plantSystem.WaterAll(); }
    //    catch (System.Exception e) { Debug.LogError("WaterAll Error: " + e.Message); }

    //    try { plantSystem.GrowAll(); }
    //    catch (System.Exception e) { Debug.LogError("GrowAll Error: " + e.Message); }

    //    try { powerStorage.GiveEnergy(); }
    //    catch (System.Exception e) { Debug.LogError("GiveEnergy Error: " + e.Message); }

    //    try { powerStorage.BuffAllPlant(); }
    //    catch (System.Exception e) { Debug.LogError("BuffAllPlant Error: " + e.Message); }

    //    // system/event untuk enemy competition
    //    try { enemyScript.EnemyGetYields(); }
    //    catch (System.Exception e) { Debug.LogError("EnemyGetYields Error: " + e.Message); }

    //    try { CheckDayEvent(); }
    //    catch (System.Exception e) { Debug.LogError("CheckDayEvent Error: " + e.Message); }

    //    try { ui.countDate(day); }
    //    catch (System.Exception e) { Debug.LogError("countDate Error: " + e.Message); }

    //    countTurnLeft();

    //    try { if (!gameOver) saveAllData(); }
    //    catch (System.Exception e) { Debug.LogError("saveAllData Error: " + e.Message); }

    //    //questSystem.autoComplete();
    //    //questSystem.CekQuest();

    //    //day += 6;

    //    //powerStorage.GiveEnergyToWaterTank();

    //    //plantSystem.GetAllPlant();
    //    //plantSystem.ResetAll();
    //    //plantSystem.WaterAll();
    //    //plantSystem.GrowAll();

    //    //powerStorage.GiveEnergy();
    //    //powerStorage.BuffAllPlant();

    //    //// system/event  untuk enemy competition
    //    //enemyScript.EnemyGetYields();
    //    //CheckDayEvent();

    //    //ui.countDate(day);

    //    //if (!gameOver) saveAllData();
    //}
}

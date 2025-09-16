using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayScene(int fileNumber)
    {
        PlayerPrefs.SetInt("fileNumber", fileNumber);
        PlayerPrefs.SetString("playerName", "redacted");
        PlayerPrefs.Save();

        SceneManager.LoadScene("MainScene");
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void DeleteAllData(int indexFile)
    {
        PlayerPrefs.SetInt("fileNumber", indexFile);

        try { MainSaveSystem.SaveFarmUpgradeData(null); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveFarmUpgradeData Error: " + e.Message); }

        try { MainSaveSystem.SaveGameData(0, 300); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveGameData Error: " + e.Message); }

        try { MainSaveSystem.SaveWaterTankData(0, 0); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveWaterTankData Error: " + e.Message); }

        try { MainSaveSystem.SaveGeneratorsData(null, 0, 0); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveGeneratorsData Error: " + e.Message); }

        try { MainSaveSystem.SaveInventoryData(null, 500); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveInventoryData Error: " + e.Message); }

        try { MainSaveSystem.SaveMachinesData(null); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveMachinesData Error: " + e.Message); }

        try { MainSaveSystem.SavePlantsData(null); } catch (System.Exception e) { UnityEngine.Debug.LogError("SavePlantsData Error: " + e.Message); }

        try { MainSaveSystem.SaveEnemyData(null, 0); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveEnemyData Error: " + e.Message); }

        try { MainSaveSystem.SaveTutorialData(null); } catch (System.Exception e) { UnityEngine.Debug.LogError("SaveTutorialData Error: " + e.Message); }
    }
}

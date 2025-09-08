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
}

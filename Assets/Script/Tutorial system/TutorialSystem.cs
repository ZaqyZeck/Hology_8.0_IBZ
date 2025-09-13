using UnityEngine;

public class TutorialSystem : MonoBehaviour
{
    //public static bool[] alur = new bool[10];
    public GameObject[] arrow;
    public PlantSystem plantSystem;

    [SerializeField] private GameObject ShopUI;
    [SerializeField] private GameObject skipDayButton, tutorialSlideButton;

    private void Update()
    {
        // ccek alur
        //for(int i = 0; i < alurTutorial.alur.Length; i++)
        //{
        //    if (alurTutorial.alur[i]) continue;
        //    Debug.Log($"alur ke: {i}");
        //    break;
        //}

        GameObject currentBotton = ButtonStorage.getCurrentButton();
        if (!alurTutorial.alur[0])
        {

            if (currentBotton != null)
            {
                if (currentBotton.gameObject.activeSelf && currentBotton.name == "Land Lot Button")
                {
                    arrow[0].SetActive(false);
                    return;
                }
            }

            arrow[0].SetActive(true);
        }
        else if (alurTutorial.alur[0] && !alurTutorial.alur[1])
        {
            if (plantSystem.waterTankLevel > 0)
            {
                alurTutorial.alur[1] = true;
                return;
            }
            if (currentBotton != null)
            {
                if (currentBotton.gameObject.activeSelf && currentBotton.name == "Water Tank UI")
                {
                    arrow[1].SetActive(false);
                    return;
                }
            }

            arrow[1].SetActive(true);
        }
        else if (alurTutorial.alur[1] && !alurTutorial.alur[2])
        {
            if (ShopUI.activeSelf)
            {
                arrow[2].SetActive(false);
            }
            arrow[2].SetActive(true);
        }
        else if (alurTutorial.alur[3] && !alurTutorial.alur[4])
        {
            tutorialSlideButton.SetActive(true);
            //skipDayButton.SetActive(true);
            //alurTutorial.alur[4] = true;
        }
        else if ((alurTutorial.alur[6] && !alurTutorial.alur[7]) || (alurTutorial.alur[7] && !alurTutorial.alur[8]))
        {
            if (ShopUI.activeSelf)
            {
                arrow[2].SetActive(false);
            }
            arrow[2].SetActive(true);
        }
        else if(alurTutorial.alur[6] && alurTutorial.alur[7] && alurTutorial.alur[8] && !alurTutorial.alur[9] && !skipDayButton.activeSelf)
        {
            skipDayButton.SetActive(true);
        }
        if (alurTutorial.alur[9])
        {
            skipDayButton.SetActive(true);
            this.enabled = false;
        }
    }

    public void SaveTutorialData()
    {
        MainSaveSystem.SaveTutorialData(alurTutorial.alur);
    }

    public void LoadTutorialData()
    {
        var data = MainSaveSystem.LoadTutorialData();
        if (data != null)
        {
            for (int i = 0; data.alur.Length > i && i < alurTutorial.alur.Length; i++)
            {
                alurTutorial.alur[i] = data.alur[i];
            }
        }
    }
}

public static class alurTutorial
{
    public static bool[] alur = new bool[10];
}

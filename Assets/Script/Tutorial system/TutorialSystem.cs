using UnityEngine;

public class TutorialSystem : MonoBehaviour
{
    //public static bool[] alur = new bool[10];
    public GameObject[] arrow;
    public PlantSystem plantSystem;

    private void Update()
    {
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
    }
}

public static class alurTutorial
{
    public static bool[] alur = new bool[10];
}

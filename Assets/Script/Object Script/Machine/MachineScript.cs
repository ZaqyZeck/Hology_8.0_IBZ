using UnityEngine;

public class MachineScript : MonoBehaviour
{
    public int powerNeed;
    public int powerGot;
    public int bonus;
    public string type; // strength = memperbanyak hasil panen. speed = mempercepat pertumbuhan
    protected PlantScript[] _plantScript;
    public GameObject plantGrid;

    //private void Awake()
    //{
    //    GetAllPlant();
    //}

    public void GetAllPlant()
    {
        _plantScript = plantGrid.GetComponentsInChildren<PlantScript>();
    }

    public void BuffPlants()
    {
        if (powerGot < powerNeed) return;
        
        GetAllPlant();
        foreach (PlantScript plant in _plantScript)
        {
            if (type == "speed") plant._bonus += bonus;
            else plant._bonusYield = bonus;
        }
    }
}

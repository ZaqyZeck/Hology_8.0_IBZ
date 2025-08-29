using Unity.VisualScripting;
using UnityEngine;

public class MachineScript : MonoBehaviour
{
    // old save data
    public int id;
    public int signId;
    public int powerGot;

    // new save data
    public int upgradeLevel;
    public int extraWater;
    
    public int powerNeed;
    public int bonus;
    public string type; // strength = memperbanyak hasil panen. speed = mempercepat pertumbuhan
    protected PlantScript[] _plantScript;
    public GameObject plantGrid;

    public int upgradePrice = 1000;

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
            if (type == "speed")
            {
                plant._bonus += bonus;
                //continue;
                plant._bonusYield = 0;
            }
            else 
            {
                plant._bonusYield = bonus;
                plant._bonus = 0;
            }
            
        }
    }

    public void DebuffPlants()
    {
        if (powerGot < powerNeed || type !="strength") return;

        foreach (PlantScript plant in _plantScript)
        {
            plant.extraWater = extraWater;
        }
    }

    public void UpgradeMachine()
    {
        if (type == "speed") bonus += 2;
        else 
        {
            bonus += 1;
            extraWater += 10;
        } 

        upgradeLevel++;
    }
}

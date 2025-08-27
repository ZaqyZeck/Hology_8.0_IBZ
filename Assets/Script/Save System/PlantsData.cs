using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

[System.Serializable]
public class PlantsData : Data
{
    public int[] typeId = new int[36];
    public int[] lotId = new int[36];
    public int[] age = new int[36];
    public int[] bonusYield = new int[36];
    public float[] waterGot = new float[36];
    public bool[] fertilized = new bool[36];
    public int[] bonus = new int[36];
    public int[] currentPhase = new int[36];
    public bool[] notNull = new bool[36];

    public PlantsData(List<PlantScript> plants)
    {
        int i = 0;
        foreach (PlantScript plant in plants)
        {
            if (plant == null)
            {
                Debug.LogError("plant nya null bang, mampus kamu, kodemu tai anjing");
                break;
            }
            int index = plant._LotID;
            typeId[index] = plant._ID;
            lotId[index] = plant._LotID;
            age[index] = plant._age;
            bonusYield[index] = plant._bonusYield;
            bonus[index] = plant._bonus;
            waterGot[index] = plant.waterGot;
            fertilized[index] = plant.fertilized;
            currentPhase[index] = plant._currentPhase;
            notNull[index] = true;
            i++;
        }
    }
}

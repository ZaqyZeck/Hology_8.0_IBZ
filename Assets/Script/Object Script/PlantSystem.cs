using System.Collections.Generic;
using UnityEngine;

public class PlantSystem : MonoBehaviour
{
    public PlantScript[] _plantList;
    public float _water;
    public float _maxWater;
    //private InventorySystem _inventory;

    private void Awake()
    {
        //_inventory = FindAnyObjectByType<InventorySystem>();
    }
    public void GetAllPlant()
    {
        _plantList = gameObject.GetComponentsInChildren<PlantScript>();
    }
    public void WaterAll()
    {
        float waterNeed;
        foreach (var plant in _plantList)
        {
            if (plant.waterGot >= plant.waterNeeded) continue;
            waterNeed = plant.waterNeeded;
            if (_water > waterNeed)
            {
                plant.WaterThePlant(waterNeed);
                _water -= waterNeed;
            }
            else if(_water > 0)
            {
                plant.WaterThePlant(_water);
                _water = 0;
                break;
            }
            else
            {
                break;
            }
        }
    }

    public void ResetAll()
    {
        foreach (var plant in _plantList)
        {
            plant.WaterReset();
        }
        _water = _maxWater;
    }

    public void GrowAll()
    {
        foreach (var plant in _plantList)
        {
            plant.GrowThePlant();
        }
    }
}

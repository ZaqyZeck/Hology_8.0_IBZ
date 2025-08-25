using System.Collections.Generic;
using System.Linq;
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
        if (_plantList == null || _plantList.Length == 0) return;

        // Sort tanaman dulu sesuai prioritas
        var sortedPlants = _plantList
            .OrderBy(p =>
            {
                // Kalau sudah max age, kasih prioritas paling rendah
                if (p._age >= p._maxAge) return int.MaxValue;

                // Semakin dekat ke maxAge semakin kecil (lebih prioritas)
                return p._maxAge - p._age;
            })
            .ToList();

        float waterNeed;
        foreach (var plant in sortedPlants)
        {
            if (plant.waterGot >= plant.waterNeeded) continue;

            waterNeed = plant.waterNeeded - plant.waterGot;
            if (_water >= waterNeed)
            {
                plant.WaterThePlant(waterNeed);
                _water -= waterNeed;
            }
            else if (_water > 0)
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

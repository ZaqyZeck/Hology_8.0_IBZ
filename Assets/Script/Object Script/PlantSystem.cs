using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlantSystem : MonoBehaviour
{
    public PlantScript[] _plantList;
    public LandLot[] LandLots;
    public GameObject[] Plants_Prefab;
    public float _water;
    public float _maxWater;

    [SerializeField]private InventorySystem inventory;
    [SerializeField]private GameObject upgradeButton;
    [SerializeField] private TextMeshPro waterCounter;

    //new
    public int waterTankLevel;

    private static readonly int[] upgradeCost = { 200, 500, 1000 };

    private int[][] waterStorage =
    {
    new int[] { 250,  upgradeCost[0] },
    new int[] { 600,  upgradeCost[1] },
    new int[] { 1000, upgradeCost[2] }
};

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
            if (plant.extraWater > 0) waterNeed += plant.waterNeeded / plant.extraWater;

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

    public void updateWaterCounter()
    {
        waterCounter.text = $"Water Storage\n{_water} / {_maxWater}";
    }

    public void UpgradeWaterTank()
    {
        int price = waterStorage[waterTankLevel][1];
        if (inventory.coins < price) return;
        inventory.coins -= price;

        _maxWater = waterStorage[waterTankLevel][0];
        waterTankLevel++;
        updateWaterCounter();
        if(waterTankLevel >= 3)
        {
            upgradeButton.SetActive(false);
        }
    }


    public void SavePlantsData()
    {
        GetAllPlant();
        List<PlantScript> plantList = new List<PlantScript>();
        foreach (PlantScript plant in _plantList)
        {
            plantList.Add(plant);
        }
        MainSaveSystem.SavePlantsData(plantList);
    }

    public void LoadPlantsData()
    {
        PlantsData plantsData = MainSaveSystem.LoadPlants();

        foreach (int plantLotId in plantsData.lotId)
        {
            if (!plantsData.notNull[plantLotId]) continue;
            Debug.Log(LandLots[plantLotId].name + " and " + plantsData.typeId[plantLotId]);
            LandLot lot = LandLots[plantLotId];
            PlantScript plantScript = lot.LoadPlantBy(plantsData.typeId[plantLotId]);

            plantScript._ID = plantsData.typeId[plantLotId];
            plantScript._LotID = plantsData.lotId[plantLotId];
            plantScript._age = plantsData.age[plantLotId];
            plantScript._bonusYield = plantsData.bonusYield[plantLotId];
            plantScript.waterGot = plantsData.waterGot[plantLotId];
            plantScript.fertilized = plantsData.fertilized[plantLotId];
            plantScript._bonus = plantsData.bonus[plantLotId];
            plantScript._currentPhase = plantsData.currentPhase[plantLotId];
            plantScript.load();
        }
    }
}

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int day = 0;
    [SerializeField] private PlantSystem _plantSystem;
    [SerializeField] private PowerStorage _powerStorage;
    public void skipDays()
    {
        day += 6;
        _plantSystem.GetAllPlant();
        _plantSystem.ResetAll();
        _plantSystem.WaterAll();
        _plantSystem.GrowAll();
        _powerStorage.GiveEnergy();
        _powerStorage.BuffAllPlant();
    }

}

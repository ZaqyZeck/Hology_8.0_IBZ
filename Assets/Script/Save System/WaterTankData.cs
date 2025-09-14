using UnityEngine;

[System.Serializable]
public class WaterTankData : Data
{
    public int waterTankLevel, waterAmount;

    public WaterTankData()
    {
    }

    public WaterTankData(int waterTankLevel, int waterAmount)
    {
        this.waterTankLevel = waterTankLevel;
        this.waterAmount = waterAmount;
    }
}

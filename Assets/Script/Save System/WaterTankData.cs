using UnityEngine;

[System.Serializable]
public class WaterTankData : Data
{
    public int waterTankLevel;

    public WaterTankData()
    {
    }

    public WaterTankData(int waterTankLevel)
    {
        this.waterTankLevel = waterTankLevel;
    }
}

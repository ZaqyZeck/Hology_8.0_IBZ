using UnityEngine;

[System.Serializable]
public class FarmUpgradeData : Data
{
    public int[] farmLevel = new int[4];

    public FarmUpgradeData(int[] farmLevel)
    {
        if (farmLevel == null) return;
        for(int i = 0; i < farmLevel.Length; i++)
        {
            this.farmLevel[i] = farmLevel[i];
        }
    }
}

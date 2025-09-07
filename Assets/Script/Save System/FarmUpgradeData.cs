using UnityEngine;

public class FarmUpgradeData : MonoBehaviour
{
    public int[] farmLevel = new int[4];

    public FarmUpgradeData(int[] farmLevel)
    {
        foreach (int i in farmLevel)
        {
            farmLevel[i] = i;
        }
    }
}

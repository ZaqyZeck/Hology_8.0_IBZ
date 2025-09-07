using UnityEngine;

[System.Serializable]
public class MachineData : Data
{
    public int[] id = new int[4];
    public int[] signId = new int[4];
    public int[] powerGot = new int[4];
    public bool[] notNull = new bool[4];

    //new data

    public int[] upgradeLevel = new int[4];
    public int[] extraWater = new int[4];
    public MachineData(MachineScript[] machineScripts)
    {
        foreach (MachineScript script in machineScripts)
        {
            int index = script.signId;
            id[index] = script.id;
            signId[index] = script.signId;
            powerGot[index] = script.powerGot;

            upgradeLevel[index] = script.upgradeLevel;
            extraWater[index] = script.extraWater;

            notNull[index] = true;
        }
    }
}

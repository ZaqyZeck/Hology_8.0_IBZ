using UnityEngine;

[System.Serializable]
public class EnemyData : Data
{
    public int[] yieldsTotal_Array = new int[4];
    public int enemyEncounter;

    public EnemyData(int[] yields_Array, int enemyEncounter)
    {
        yieldsTotal_Array = yields_Array;
        this.enemyEncounter = enemyEncounter;
    }
}

using UnityEngine;

[System.Serializable]
public class GeneratorData : Data
{
    public int[] id = new int[3];
    public float[] location_x = new float[3];
    public float[] location_y = new float[3];
    public float[] location_z = new float[3];
    public bool[] havefuel = new bool[3];

    public GeneratorData(GeneratorScript[] generatorScripts)
    {
        int i = 0;
        foreach (GeneratorScript generator in generatorScripts)
        {
            id[i] = generator.id - 1;
            location_x[i] = generator.location.x;
            location_y[i] = generator.location.y; 
            location_z[i] = generator.location.z;
            havefuel[i] = generator.havefuel;
            i++;
        }
    }
}

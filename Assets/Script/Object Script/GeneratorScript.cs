using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public int id;
    public int producePower;
    public int globalWarm;
    public string type;

    public int GeneratePower()
    {
        return producePower;
    }
}

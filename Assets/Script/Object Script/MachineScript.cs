using UnityEngine;

public class MachineScript : MonoBehaviour
{
    public int powerNeed;
    public int powerGot;
    private PlantScript[] _plantScript;

    //private void Awake()
    //{
    //    GetAllPlant();
    //}

    public void GetAllPlant()
    {
        _plantScript = GetComponentsInChildren<PlantScript>();
    }

    public void BuffPlants()
    {
        GetAllPlant();
        foreach (PlantScript plant in _plantScript)
        {
            plant._bonus += 2;
        }
    }
}

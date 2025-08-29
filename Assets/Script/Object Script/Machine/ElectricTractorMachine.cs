using UnityEngine;

public class ElectricTractorMachine : MachineScript
{
    private void Awake()
    {
        powerNeed = 5;
        powerGot = 0;
        bonus = 1;
        type = "strength"; // strength = memperbanyak hasil panen, speed = mempercepat pertumbuhan
        extraWater = 10;
    }
}

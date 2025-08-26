using UnityEngine;

public class ElectricTractorMachine : MachineScript
{
    private void Awake()
    {
        powerNeed = 5;
        powerGot = 0;
        bonus = 2;
        type = "strength"; // strength = memperbanyak hasil panen, speed = mempercepat pertumbuhan
    }
}

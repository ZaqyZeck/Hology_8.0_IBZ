using UnityEngine;

public class PowerStorage : MonoBehaviour
{
    public GeneratorScript[] generators;
    public MachineScript[] machines;
    public int totalPower;

    void getGenerator()
    {
        generators = FindObjectsByType<GeneratorScript>(FindObjectsSortMode.None);
    }

    public void GetEnergy()
    {
        getGenerator();
        foreach (GeneratorScript generator in generators)
        {
            totalPower += generator.GeneratePower();
        }
    }

    public void GetMachines()
    {
        machines = FindObjectsByType<MachineScript>(FindObjectsSortMode.None);
    }

    public void GiveEnergy()
    {
        GetEnergy();
        GetMachines();
        foreach (MachineScript machine in machines)
        {
            int powerneeded = machine.powerNeed;
            if (totalPower > powerneeded)
            {
                machine.powerGot = powerneeded;
                totalPower -= powerneeded;
            }
            else if (totalPower < powerneeded && totalPower > 0)
            {
                machine.powerGot = totalPower;
                totalPower = 0;
            }
            else break;
        }
    }

    public void BuffAllPlant()
    {
        GetMachines();
        foreach (MachineScript machine in machines)
        {
            machine.BuffPlants();
        }
    }
}

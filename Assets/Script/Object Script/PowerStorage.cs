using UnityEngine;

public class PowerStorage : MonoBehaviour
{
    public GeneratorScript[] generators;
    public MachineScript[] machine;
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
            generator.GeneratePower();
        }
    }

    public void GiveEnergy()
    {
        GetEnergy();
        machine = FindObjectsByType<MachineScript>(FindObjectsSortMode.None);
        foreach (MachineScript machine in machine)
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
}

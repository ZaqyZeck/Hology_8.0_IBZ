using UnityEngine;

public class PowerStorage : MonoBehaviour
{
    public GeneratorScript[] generators;
    public MachineScript[] machines;
    public int totalPower;
    private PlaceMentSystem PlaceMentSystem;
    public MachinePlacement[] machinePlacements;
    private void Awake()
    {
        PlaceMentSystem = FindAnyObjectByType<PlaceMentSystem>();
    }

    public void getGenerator()
    {
        generators = FindObjectsByType<GeneratorScript>(FindObjectsSortMode.None);
    }

    public void GetEnergy()
    {
        getGenerator();
        totalPower = 0;
        foreach (GeneratorScript generator in generators)
        {
            if (generator.gameObject.name.Contains("Preview"))
            {
                continue;
            }
                
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
            machine.DebuffPlants();
        }
    }

    public void SaveAllGenerators()
    {
        PlaceMentSystem.StopPlacement();
        getGenerator();

        foreach (GeneratorScript generator in generators)
        {
            generator.setGeneratorLocation();
        }
        MainSaveSystem.SaveGeneratorsData(generators);
    }

    public void LoadGenerators()
    {
        GeneratorData generatorData = MainSaveSystem.LoadGenerators();
        for(int index = 0; index < generatorData.id.Length; index++) 
        {
            if (generatorData.id[index] == 0) continue;
            Debug.Log(generatorData.location_x[index] + generatorData.location_y[index] + generatorData.location_z[index]);
            float @location_X = generatorData.location_x[index];
            float @location_Y = generatorData.location_y[index];
            float @location_Z = generatorData.location_z[index];
            Vector3 location = new Vector3(location_X, location_Y, location_Z);

            int @idType = generatorData.id[index];
            PlaceMentSystem.PlaceStructureByLocation(location, idType);
        }
    }

    public void SaveMachines()
    {
        GetMachines();
        MainSaveSystem.SaveMachinesData(machines);
    }

    public void LoadMachines()
    {
        MachineData machineData = MainSaveSystem.LoadMachines();

        foreach(int index in machineData.signId)
        {
            if (!machineData.notNull[index]) continue;
            machinePlacements[index].AddMachine(machineData.id[index]);
        }
    }
}

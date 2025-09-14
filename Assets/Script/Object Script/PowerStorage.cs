using UnityEngine;

public class PowerStorage : MonoBehaviour
{
    public GeneratorScript[] generators;
    public MachineScript[] machines;
    public int totalPower, maxPower;
    private PlaceMentSystem PlaceMentSystem;
    public MachinePlacement[] machinePlacements;

    [SerializeField] private PlantSystem plantSystem;
    private void Awake()
    {
        PlaceMentSystem = FindAnyObjectByType<PlaceMentSystem>();
    }

    public void getGenerator()
    {
        //generators = FindObjectsByType<GeneratorScript>(FindObjectsSortMode.None);
        generators = GetComponentsInChildren<GeneratorScript>();
    }

    public void GetEnergy()
    {
        getGenerator();
        totalPower = 0;

        if (generators == null)
        {
            Debug.LogError("awbdhgawjd");
            return;
        }

        foreach (GeneratorScript generator in generators)
        {
            if (generator.gameObject.name.Contains("Preview"))
            {
                continue;
            }
            totalPower += generator.GeneratePower();
            generator.havefuel = false;
        }

        maxPower = totalPower;

        return;
        Debug.Log("apakah energy yg tersisa mau disimpan selama energy tambahan tidak melebihi maxPower?");

    }

    public void GetMachines()
    {
        machines = FindObjectsByType<MachineScript>(FindObjectsSortMode.None);
    }

    public void GiveEnergyToWaterTank()
    {
        GetEnergy();
        float waterPower = plantSystem._maxWater / 20;
        if (totalPower < waterPower)
        {
            plantSystem.energyGet += totalPower;
            totalPower = 0;
        }
        else
        {
            plantSystem.energyGet += waterPower;
            totalPower -= (int)waterPower;
        }
    }

    public void GiveEnergy()
    {
        
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
        MainSaveSystem.SaveGeneratorsData(generators, totalPower, maxPower);
    }

    public void LoadGenerators()
    {
        GeneratorData generatorData = MainSaveSystem.LoadGenerators();

        totalPower = generatorData.powerAmounr;
        maxPower = generatorData.maxPower;
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

            int @machineLevel = generatorData.machineLevel[index];

            getGenerator();

            foreach (GeneratorScript generatorScript in generators)
            {
                if (generatorScript.haveLoaded) continue;
                generatorScript.machineLevel = machineLevel;
                generatorScript.LoadLevel();
                generatorScript.haveLoaded = true;
            }
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
            machinePlacements[index].machine.upgradeLevel = machineData.upgradeLevel[index];
            machinePlacements[index].machine.LoadLevel();
            machinePlacements[index].deAcvtivateUpgradeButton();
        }
    }
}

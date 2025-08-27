using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine;
using System.Collections.Generic;

public static class MainSaveSystem
{
    public static void SaveInventoryData(List<InventoryObject> inventory)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/inventory.dt";
        FileStream stream = new FileStream(path, FileMode.Create);

        InventoryData inventoryData = new InventoryData(inventory);

        formatter.Serialize(stream, inventoryData);
        stream.Close();
    }

    public static InventoryData LoadInventory()
    {
        string path = Application.persistentDataPath + "/inventory.dt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            InventoryData inventoryData = formatter.Deserialize(stream) as InventoryData;

            stream.Close();
            return inventoryData;
        }
        else
        {
            Debug.LogError("not found in " + path);
            return null;
        }
    }

    public static void SavePlantsData(List<PlantScript> plants)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/plants.dt";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlantsData inventoryData = new PlantsData(plants);

        formatter.Serialize(stream, inventoryData);
        stream.Close();
    }

    public static PlantsData LoadPlants()
    {
        string path = Application.persistentDataPath + "/plants.dt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlantsData plantData = formatter.Deserialize(stream) as PlantsData;

            stream.Close();
            return plantData;
        }
        else
        {
            Debug.LogError("not found in " + path);
            return null;
        }
    }

    public static void SaveGeneratorsData(GeneratorScript[] generator)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/generators.dt";
        FileStream stream = new FileStream(path, FileMode.Create);

        GeneratorData generatorData = new GeneratorData(generator);

        formatter.Serialize(stream, generatorData);
        stream.Close();
    }

    public static GeneratorData LoadGenerators()
    {
        string path = Application.persistentDataPath + "/generators.dt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GeneratorData generatorData = formatter.Deserialize(stream) as GeneratorData;

            stream.Close();
            return generatorData;
        }
        else
        {
            Debug.LogError("not found in " + path);
            return null;
        }
    }

    public static void SaveMachinesData(MachineScript[] machines)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/machines.dt";
        FileStream stream = new FileStream(path, FileMode.Create);

        MachineData machineData = new MachineData(machines);

        formatter.Serialize(stream, machineData);
        stream.Close();
    }

    public static MachineData LoadMachines()
    {
        string path = Application.persistentDataPath + "/machines.dt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            MachineData machineData = formatter.Deserialize(stream) as MachineData;

            stream.Close();
            return machineData;
        }
        else
        {
            Debug.LogError("not found in " + path);
            return null;
        }
    }
}

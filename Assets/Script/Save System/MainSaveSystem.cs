using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine;
using System.Collections.Generic;

public static class MainSaveSystem
{
    public static void SaveInventoryData(List<InventoryObject> inventory, long coin)
    {
        int fileNumber = 0;
        if (PlayerPrefs.HasKey("fileNumber")) fileNumber = PlayerPrefs.GetInt("fileNumber");

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/inventory{fileNumber}.dt";
        FileStream stream = new FileStream(path, FileMode.Create);

        InventoryData inventoryData = new InventoryData(inventory, coin);

        formatter.Serialize(stream, inventoryData);
        stream.Close();
    }

    public static InventoryData LoadInventory()
    {
        int fileNumber = 0;
        if (PlayerPrefs.HasKey("fileNumber")) fileNumber = PlayerPrefs.GetInt("fileNumber");

        string path = Application.persistentDataPath + $"/inventory{fileNumber}.dt";
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
        int fileNumber = 0;
        if (PlayerPrefs.HasKey("fileNumber")) fileNumber = PlayerPrefs.GetInt("fileNumber");

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/plants{fileNumber}.dt";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlantsData inventoryData = new PlantsData(plants);

        formatter.Serialize(stream, inventoryData);
        stream.Close();
    }

    public static PlantsData LoadPlants()
    {
        int fileNumber = 0;
        if (PlayerPrefs.HasKey("fileNumber")) fileNumber = PlayerPrefs.GetInt("fileNumber");

        string path = Application.persistentDataPath + $"/plants{fileNumber}.dt";
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
        int fileNumber = 0;
        if (PlayerPrefs.HasKey("fileNumber")) fileNumber = PlayerPrefs.GetInt("fileNumber");

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/generators{fileNumber}.dt";
        FileStream stream = new FileStream(path, FileMode.Create);

        GeneratorData generatorData = new GeneratorData(generator);

        formatter.Serialize(stream, generatorData);
        stream.Close();
    }

    public static GeneratorData LoadGenerators()
    {
        int fileNumber = 0;
        if (PlayerPrefs.HasKey("fileNumber")) fileNumber = PlayerPrefs.GetInt("fileNumber");

        string path = Application.persistentDataPath + $"/generators{fileNumber}.dt";
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
        int fileNumber = 0;
        if (PlayerPrefs.HasKey("fileNumber")) fileNumber = PlayerPrefs.GetInt("fileNumber");

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/machines{fileNumber}.dt";
        FileStream stream = new FileStream(path, FileMode.Create);

        MachineData machineData = new MachineData(machines);

        formatter.Serialize(stream, machineData);
        stream.Close();
    }

    public static MachineData LoadMachines()
    {
        int fileNumber = 0;
        if (PlayerPrefs.HasKey("fileNumber")) fileNumber = PlayerPrefs.GetInt("fileNumber");

        string path = Application.persistentDataPath + $"/machines{fileNumber}.dt";
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

    public static void SaveWaterTankData(int waterTankLevel)
    {
        int fileNumber = 0;
        if (PlayerPrefs.HasKey("fileNumber")) fileNumber = PlayerPrefs.GetInt("fileNumber");

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/WaterTank{fileNumber}.dt";
        FileStream stream = new FileStream(path, FileMode.Create);

        WaterTankData waterTankData = new WaterTankData(waterTankLevel);

        formatter.Serialize(stream, waterTankData);
        stream.Close();
    }

    public static WaterTankData LoadWaterTank()
    {
        int fileNumber = 0;
        if (PlayerPrefs.HasKey("fileNumber")) fileNumber = PlayerPrefs.GetInt("fileNumber");

        string path = Application.persistentDataPath + $"/WaterTank{fileNumber}.dt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            WaterTankData WaterTankData = formatter.Deserialize(stream) as WaterTankData;

            stream.Close();
            return WaterTankData;
        }
        else
        {
            Debug.LogError("not found in " + path);
            return null;
        }
    }

    public static void SaveFarmUpgradeData(int[] farmLevels)
    {
        int fileNumber = 0;
        if (PlayerPrefs.HasKey("fileNumber")) fileNumber = PlayerPrefs.GetInt("fileNumber");

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/FarmUpgrade{fileNumber}.dt";
        FileStream stream = new FileStream(path, FileMode.Create);

        FarmUpgradeData farmUpgradeData = new FarmUpgradeData(farmLevels);

        formatter.Serialize(stream, farmUpgradeData);
        stream.Close();
    }

    public static FarmUpgradeData LoadFarmUpgrade()
    {
        int fileNumber = 0;
        if (PlayerPrefs.HasKey("fileNumber")) fileNumber = PlayerPrefs.GetInt("fileNumber");

        string path = Application.persistentDataPath + $"/FarmUpgrade{fileNumber}.dt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FarmUpgradeData FarmUpgradeData = formatter.Deserialize(stream) as FarmUpgradeData;

            stream.Close();
            return FarmUpgradeData;
        }
        else
        {
            Debug.LogError("not found in " + path);
            return null;
        }
    }

    public static void SaveGameData(int day)
    {
        int fileNumber = 0;
        if (PlayerPrefs.HasKey("fileNumber")) fileNumber = PlayerPrefs.GetInt("fileNumber");

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/game{fileNumber}.dt";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData gameData = new GameData(day);

        formatter.Serialize(stream, gameData);
        stream.Close();
    }

    public static GameData LoadGameData()
    {
        int fileNumber = 0;
        if (PlayerPrefs.HasKey("fileNumber")) fileNumber = PlayerPrefs.GetInt("fileNumber");

        string path = Application.persistentDataPath + $"/game{fileNumber}.dt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData gameData = formatter.Deserialize(stream) as GameData;

            stream.Close();
            return gameData;
        }
        else
        {
            Debug.LogError("not found in " + path);
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public long coins;
    public List<InventoryObject> inventory = new();
    

    public InventoryObject GetInventoryObjectBy(int id)
    {
        foreach (InventoryObject obj in inventory)
        {
            if(obj.ID == id) return obj;
        }
        return null;
    }
    public void addOneTo(int ID)
    {
        foreach (var _obj in inventory)
        {
            if (_obj.ID == ID)
            {
                if (_obj.amount + 1 > _obj.maxAmount) break;
                _obj.amount++;
                break;
            }
        }
    }

    public void subtractOneTo(int ID)
    {
        foreach (var _obj in inventory)
        {
            if (_obj.ID == ID)
            {
                if (_obj.amount - 1 < 0) break;
                _obj.amount--;
                break;
            }
        }
    }

    public void addInventoryFor(int ID, int num)
    {
        foreach (var _obj in inventory)
        {
            if (_obj.ID == ID)
            {
                if (_obj.amount + num > _obj.maxAmount) break;
                _obj.amount += num;
                break;
            }
        }
    }

    public void subtractInventoryFor(int _ID, int num)
    {
        foreach (var _obj in inventory)
        {
            if (_obj.ID == _ID)
            {
                if (_obj.amount - num < 0) break;
                _obj.amount -= num;
                break;
            }
        }
    }

    public void SaveInventory()
    {
        MainSaveSystem.SaveInventoryData(inventory);
    }
    public void LoadInventoryData()
    {
        InventoryData inventoryData = MainSaveSystem.LoadInventory();
        if(inventoryData == null)
        {
            Debug.LogError("Tidak ada data");
            return;
        }
        foreach (InventoryObject inventory in inventory)
        {
            if (inventory.ID != inventoryData.InventoryID[inventory.ID])
            {
                Debug.LogError("id tidak sesuai");
                break;
            }
            inventory.amount = inventoryData.InventoryAmount[inventory.ID];
        }
    }
}

[Serializable]
public class InventoryObject
{
    [field: SerializeField]
    public GameObject prefab { get; private set; }
    [field: SerializeField]
    public string name { get; private set; }
    [field: SerializeField]
    public int ID { get; private set; }
    [field: SerializeField]
    public int amount { get; set; }
    [field: SerializeField]
    public int maxAmount { get; private set; }
    [field: SerializeField]
    public int price { get; set; }
    public InventoryObject()
    {
    }
}

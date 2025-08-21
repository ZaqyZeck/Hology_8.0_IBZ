using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public List<InventoryObject> inventory = new();

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
    public InventoryObject()
    {
    }
}

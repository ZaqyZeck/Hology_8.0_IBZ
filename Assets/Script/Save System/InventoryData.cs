using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryData : Data
{
    public int[] InventoryID = new int[100];
    public int[] InventoryAmount = new int[100];


    public InventoryData(List<InventoryObject> inventory)
    {
        int i = 0;
        foreach (InventoryObject data in inventory)
        {
            if(data == null)
            {
                InventoryAmount[i] = 999;
                InventoryID[i++] = 999;
                Debug.LogError("Data null");
                break;
            } 
            else
            {
                InventoryAmount[i] = data.amount;
                InventoryID[i++] = data.ID;
            }
                
        }
    }
}

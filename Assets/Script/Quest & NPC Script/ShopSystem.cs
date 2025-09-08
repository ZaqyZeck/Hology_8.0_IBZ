using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] private InventorySystem inventorySystem;
    [SerializeField] private PowerStorage powerStorage;
    [SerializeField] private PlaceMentSystem placeMentSystem;

    public void SellRegulerItemBy(int id, int amount)
    {
        InventoryObject inventoryObject = inventorySystem.GetInventoryObjectBy(id);
        if (inventoryObject == null)
        {
            Debug.LogError("id tidak ditemukan");
            return;
        }
        if (inventoryObject.amount < amount) return;
        int price = inventoryObject.price * amount;
        inventorySystem.SubtractCoins(-price);

        Debug.Log(inventorySystem.coins);
        inventoryObject.amount -= amount;
    }

    public void BuyRegulerItemBy(int id, int amount)
    {
        InventoryObject inventoryObject = inventorySystem.GetInventoryObjectBy(id);
        if (inventoryObject == null)
        {
            Debug.LogError("id tidak ditemukan");
            return;
        }

        int price = inventoryObject.price * amount;
        //Debug.Log(inventorySystem.coins);
        if (price > inventorySystem.coins) return;

        inventorySystem.coins -= price;
        inventoryObject.amount += amount;
    }

    public void BuyGenerator(int id)
    {
        powerStorage.getGenerator();
        if (powerStorage.generators.Length >= 3) return;
        placeMentSystem.StartPlacement(id);
    }

    //public int GetItemPrice(int id)
    //{

    //}
}

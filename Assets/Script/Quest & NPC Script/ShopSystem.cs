using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    private InventorySystem inventorySystem;
    private PowerStorage powerStorage;
    private PlaceMentSystem placeMentSystem;

    private void Awake()
    {
        inventorySystem = FindAnyObjectByType<InventorySystem>();
        powerStorage = FindAnyObjectByType<PowerStorage>();
        placeMentSystem = FindAnyObjectByType<PlaceMentSystem>();
    }

    public void sellRegulerItemBy(int id, int amount)
    {
        InventoryObject inventoryObject = inventorySystem.GetInventoryObjectBy(id);
        if (inventoryObject == null)
        {
            Debug.LogError("id tidak ditemukan");
            return;
        }
        if (inventoryObject.amount < amount) return;
        inventorySystem.coins += inventoryObject.price * amount;

    }

    public void buyRegulerItemBy(int id)
    {
        InventoryObject inventoryObject = inventorySystem.GetInventoryObjectBy(id);
        if (inventoryObject == null)
        {
            Debug.LogError("id tidak ditemukan");
            return;
        }

        if (inventoryObject.price > inventorySystem.coins) return;

        inventorySystem.coins -= inventoryObject.price;
        inventoryObject.amount++;
    }

    public void buyGenerator(int id)
    {
        powerStorage.getGenerator();
        if (powerStorage.generators.Length >= 3) return;
        placeMentSystem.StartPlacement(id);
    }
}

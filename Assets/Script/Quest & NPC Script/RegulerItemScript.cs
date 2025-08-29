using UnityEngine;
using UnityEngine.UI;

public class RegulerItemScript : MonoBehaviour
{
    [SerializeField] private ShopSystem shopSystem;
    [SerializeField] private Text amountCounter;
    public int amount = 1;
    //public int itemId;

    public void buyItem(int itemId)
    {
        shopSystem.buyRegulerItemBy(itemId, amount);
    }

    public void sellItem(int itemId)
    {
        shopSystem.sellRegulerItemBy(itemId, amount);
    }

    public void increaseAmount()
    {
        if (amount >= 10) return;
        amount++;
        amountCounter.text = amount.ToString();
    }

    public void decreaseAmount()
    {
        if (amount <= 0) return;
        amount--;
        amountCounter.text = amount.ToString();
    }
    

}

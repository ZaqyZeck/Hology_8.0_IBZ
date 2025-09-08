using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RegulerItemScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ShopSystem shopSystem;
    public ItemUI itemUI;
    [SerializeField] private Text amountCounter, priceCounter;
    public Image itemImage;
    public int amount = 1;
    public int price = 10, itemID;
    public string itemName;
    //public int itemId;


    private bool isHovering = false;

    private void Update()
    {
        // klik kanan = 1 (left = 0, right = 1, middle = 2)
        if (Input.GetMouseButtonDown(0) && !isHovering)
        {
            DestroyUI();
        }
        //if (isHovering)
        //{
        //    Debug.Log("dbhjawd");
        //}
        //else Debug.Log("mmmmm");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }
    public void LoadPrice()
    {
        priceCounter.text = $"Price: \n {price * amount}";
    }
    public void buyItem()
    {
        shopSystem.BuyRegulerItemBy(itemID, amount);
    }

    public void sellItem()
    {
        shopSystem.SellRegulerItemBy(itemID, amount);
    }

    public void increaseAmount()
    {
        if (amount >= 10) return;
        amount++;
        LoadPrice();
        amountCounter.text = amount.ToString();
    }

    public void decreaseAmount()
    {
        if (amount <= 0) return;
        amount--;
        LoadPrice();
        amountCounter.text = amount.ToString();
    }
    
    public void DestroyUI()
    {
        itemUI.DestroyItemUI();
    }
}

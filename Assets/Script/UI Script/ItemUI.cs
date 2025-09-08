using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private GameObject itemUI, UiParent;
    [SerializeField] private ShopSystem shopSystem;

    private static GameObject SelectedItemUI;

    public int itemID, itemPrice;
    public string itemName;
    //public string shopType;

    public Sprite itemSprite;

    public void CreateItemUI()
    {
        if (SelectedItemUI != null) return;

        //GameObject[] UiChild = UiParent.GetComponentsInChildren<GameObject>();

        //if (UiChild != null && UiChild.Length > 0)
        //{
        //    foreach (GameObject uiChild in UiChild)
        //    {
        //        Destroy(uiChild);
        //    }
        //}

        SelectedItemUI = Instantiate(itemUI, UiParent.transform);

        RegulerItemScript itemScript = SelectedItemUI.GetComponent<RegulerItemScript>();

        if (itemScript != null)
        {
            itemScript.price = itemPrice;
            itemScript.name = itemName;
            itemScript.itemName = itemName;
            itemScript.itemID = itemID;
            itemScript.itemImage.sprite = itemSprite;
            itemScript.shopSystem = shopSystem;
            itemScript.itemUI = this;
            itemScript.LoadPrice();
        }
    }

    public void DestroyItemUI()
    {
        if (SelectedItemUI == null) return;

        Destroy(SelectedItemUI);
        SelectedItemUI = null;
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public static class ButtonStorage
{
    public static GameObject selectedButton;
    //public static GameObject selectedItemUI;
    //[SerializeField] static GameObject ShopItemUIParent;
    public static bool IsPointerOverUI() => EventSystem.current.IsPointerOverGameObject();
    public static void changeButton(GameObject button)
    {
        if (IsPointerOverUI())
        {
            if (selectedButton != null) selectedButton.SetActive(false);
            return;
        }
            
        if (selectedButton == button)
        {
            selectedButton.SetActive(!selectedButton.activeSelf);
            return;
        }
        if (selectedButton != null) selectedButton.SetActive(false);
        selectedButton = button;
        selectedButton.SetActive(true);
    }

    //public static void ChangeItemUI(GameObject itemUI)
    //{

    //}
}

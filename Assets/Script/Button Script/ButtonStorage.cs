using UnityEngine;

public static class ButtonStorage
{
    public static GameObject selectedButton;

    public static void changeButton(GameObject button)
    {
        if (selectedButton == button)
        {
            selectedButton.SetActive(!selectedButton.activeSelf);
            return;
        }
        if (selectedButton != null) selectedButton.SetActive(false);
        selectedButton = button;
        selectedButton.SetActive(true);
    }
}

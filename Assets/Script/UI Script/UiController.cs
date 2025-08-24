using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] protected static GameObject uiPlacement;
    static GameObject ui;
    static public bool haveUiTable;

    public void CreateUi(GameObject uiPrefab)
    {
        ui = Instantiate(uiPrefab);
        ui.transform.SetParent(uiPlacement.transform);
        haveUiTable = true;
    }

    public void DestroyUi()
    {
        Destroy(ui);
        haveUiTable = false;
    }
}

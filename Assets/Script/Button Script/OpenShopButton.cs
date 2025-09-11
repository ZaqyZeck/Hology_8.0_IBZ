using UnityEngine;

public class OpenShopButton : MonoBehaviour
{
    [SerializeField] private RotationControl _rotationControl;
    [SerializeField] private GameObject ShopUI;
    [SerializeField] private GameObject directionArrow;
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !_rotationControl._isRotating && !ButtonStorage.IsPointerOverUI())
        {
            ShopUI.SetActive(true);
        }
    }

    private void Update()
    {
        if (alurTutorial.alur[2] && directionArrow.activeSelf && !alurTutorial.alur[6])
        {
            directionArrow.SetActive(false);
        }
        if (alurTutorial.alur[7] && alurTutorial.alur[8] && directionArrow.activeSelf)
        {
            directionArrow.SetActive(false);
        }
    }
}

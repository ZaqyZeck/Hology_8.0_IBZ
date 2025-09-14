using UnityEngine;

public class OpenStorageButton : MonoBehaviour
{
    [SerializeField] private RotationControl _rotationControl;
    [SerializeField] private GameObject StorageUI;
    [SerializeField] private GameObject transparentCube;
    [SerializeField] private UiController uiController;
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !_rotationControl._isRotating && !ButtonStorage.IsPointerOverUI())
        {
            uiController.countStorageAmount();
            StorageUI.SetActive(true);
            
        }
    }

    private void OnMouseEnter()
    {
        transparentCube.SetActive(true);
    }

    private void OnMouseExit()
    {
        transparentCube.SetActive(false);
    }
}

using UnityEngine;

public class WaterTank : MonoBehaviour
{
    [SerializeField] private GameObject WaterTankUI;
    [SerializeField] private RotationControl rotationControl;
    [SerializeField] private PlantSystem plantSystem;

    [SerializeField] private GameObject tutorilUI;
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !rotationControl._isRotating)
        {
            if (plantSystem.waterTankLevel > 0 && tutorilUI.activeSelf)
            {
                tutorilUI.SetActive(false);
            }
            ButtonStorage.changeButton(WaterTankUI);
            WaterTankUI.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, rotationControl._currentAngle, gameObject.transform.rotation.z);
            plantSystem.UpdateWaterCounter();
            Debug.Log("terpencet");
        }
    }
}

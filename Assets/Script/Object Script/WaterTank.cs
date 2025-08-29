using UnityEngine;

public class WaterTank : MonoBehaviour
{
    [SerializeField] private GameObject WaterTankUI;
    [SerializeField] private RotationControl rotationControl;
    [SerializeField] private PlantSystem plantSystem;
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !rotationControl._isRotating)
        {
            ButtonStorage.changeButton(WaterTankUI);
            WaterTankUI.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, rotationControl._currentAngle, gameObject.transform.rotation.z);
            plantSystem.updateWaterCounter();
            Debug.Log("terpencet");
        }
    }
}

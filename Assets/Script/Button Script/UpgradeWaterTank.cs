using UnityEngine;

public class UpgradeWaterTank : MonoBehaviour
{
    [SerializeField] private PlantSystem plantSystem;

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            plantSystem.UpgradeWaterTank();
            Debug.Log("terpencet");
        }
    }
}

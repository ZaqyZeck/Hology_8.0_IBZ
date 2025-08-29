using UnityEngine;

public class UpgradeMachineButton : MonoBehaviour
{
    private MachinePlacement machinePlacement;

    private void Awake()
    {
        machinePlacement = gameObject.GetComponentInParent<MachinePlacement>();
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            machinePlacement.upgradeMachine();
            Debug.Log("terpencet");
        }
    }
}

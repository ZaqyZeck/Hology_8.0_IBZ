using UnityEngine;

public class PlaceMachine : ButtonScript
{
    public int _machineId;
    private MachinePlacement machinePlacement;

    private void Awake()
    {
        machinePlacement = gameObject.GetComponentInParent<MachinePlacement>();
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            machinePlacement.AddMachine(_machineId);
            Debug.Log("terpencet");
        }
    }
}

using UnityEngine;

public class PlaceMachine : ButtonScript
{
    public int _machineId;
    private MachinePlacement machinePlacement;
    [SerializeField] private GameObject textButton;

    private void OnMouseEnter()
    {
        textButton.SetActive(true);
    }

    private void OnMouseExit()
    {
        textButton.SetActive(false);
    }

    private void Awake()
    {
        machinePlacement = gameObject.GetComponentInParent<MachinePlacement>();
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            machinePlacement.AddMachine(_machineId);
            if (machinePlacement.haveMachine) textButton.SetActive(false);
            Debug.Log("terpencet");
        }
    }
}

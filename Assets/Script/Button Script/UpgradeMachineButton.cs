using UnityEngine;

public class UpgradeMachineButton : MonoBehaviour
{
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
            machinePlacement.upgradeMachine();
            Debug.Log("terpencet");
        }
    }
}

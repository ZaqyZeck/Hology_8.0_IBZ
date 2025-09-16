using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeMachineButton : MonoBehaviour
{
    private MachinePlacement machinePlacement;

    [SerializeField] private GameObject textButton;
    [SerializeField] private TextMeshPro UiText;

    private void OnMouseEnter()
    {
        textButton.SetActive(true);
        int price = 1000 + (machinePlacement.machine.upgradeLevel * machinePlacement.machine.upgradePrice);
        UiText.text = $"Upgrade\n{price} G";
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

            int price = 1000 + (machinePlacement.machine.upgradeLevel * machinePlacement.machine.upgradePrice);
            UiText.text = $"Upgrade\n{price} G";
            //Debug.Log("terpencet");
        }
    }
}

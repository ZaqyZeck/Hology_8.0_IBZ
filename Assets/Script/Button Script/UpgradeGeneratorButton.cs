using TMPro;
using UnityEngine;

public class UpgradeGeneratorButton : MonoBehaviour
{
    [SerializeField] private GeneratorScript generatorScript;
    [SerializeField] private GameObject textButton;
    [SerializeField] private TextMeshPro UiText;

    [SerializeField] private GeneratorPowerUI powerUI;

    private void OnMouseEnter()
    {
        textButton.SetActive(true);
        int price = generatorScript.getUpgradePrice(generatorScript.machineLevel);
        UiText.text = $"Upgrade\n{price} G";
    }

    private void OnMouseExit()
    {
        textButton.SetActive(false);
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            generatorScript.UpgradeMachine();
            //if(generatorScript.machineLevel >= 2) gameObject.SetActive(false);
            int price =generatorScript.getUpgradePrice(generatorScript.machineLevel);
            powerUI.UpdatePowerUI();

            UiText.text = $"Upgrade\n{price} G";
        }
    }
}

using UnityEngine;

public class UpgradeGeneratorButton : MonoBehaviour
{
    [SerializeField] private GeneratorScript generatorScript;
    [SerializeField] private GameObject textButton;

    private void OnMouseEnter()
    {
        textButton.SetActive(true);
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
        }
    }
}

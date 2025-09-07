using UnityEngine;

public class UpgradeGeneratorButton : MonoBehaviour
{
    [SerializeField] private GeneratorScript generatorScript;

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            generatorScript.UpgradeMachine();
            //if(generatorScript.machineLevel >= 2) gameObject.SetActive(false);
        }
    }
}

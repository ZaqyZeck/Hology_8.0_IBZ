using TMPro;
using UnityEngine;

public class GeneratorPowerUI : MonoBehaviour
{
    [SerializeField] TextMeshPro powerText;
    [SerializeField] GeneratorScript generatorScript;

    private void OnEnable()
    {
        UpdatePowerUI();
    }
    public void UpdatePowerUI()
    {
        powerText.text = $"{generatorScript.producePower} W";
    }
}

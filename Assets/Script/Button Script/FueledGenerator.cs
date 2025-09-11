using UnityEngine;

public class FueledGenerator : MonoBehaviour
{
    private RotationControl _rotationControl;

    [SerializeField] GameObject generatorFuelTutorial;
    [SerializeField] GeneratorScript generatorScript;

    private void Awake()
    {
        _rotationControl = FindAnyObjectByType<RotationControl>();
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !_rotationControl._isRotating)
        {
            if (!alurTutorial.alur[3])
            {
                alurTutorial.alur[3] = true;
                generatorFuelTutorial.SetActive(false);
            }
                
            generatorScript.FueledGenerator();
        }
    }

    private void OnEnable()
    {
        if (alurTutorial.alur[2] && !alurTutorial.alur[3])
        {
            generatorFuelTutorial.SetActive(true);
        }
        else
        {
            generatorFuelTutorial.SetActive(false);
        }
    }
}

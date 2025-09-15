using UnityEngine;

public class DestroyGeneratorButton : MonoBehaviour
{
    private RotationControl _rotationControl;
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
    private void Awake()
    {
        _rotationControl = FindAnyObjectByType<RotationControl>();
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !_rotationControl._isRotating && !ButtonStorage.IsPointerOverUI())
        {
            generatorScript.DestroyGenerator();
            Debug.Log("terpencet");
        }
    }
}

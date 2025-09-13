using UnityEngine;

public class DestroyGeneratorButton : MonoBehaviour
{
    private RotationControl _rotationControl;
    [SerializeField] private GeneratorScript generatorScript;
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

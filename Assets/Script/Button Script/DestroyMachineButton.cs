using UnityEngine;

public class DestroyMachineButton : ButtonScript
{
    private MachinePlacement MachinePlacement;
    private RotationControl _rotationControl;

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
        MachinePlacement = GetComponentInParent<MachinePlacement>();
        _rotationControl = FindAnyObjectByType<RotationControl>();
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !_rotationControl._isRotating)
        {
            MachinePlacement.DestryMachine();
            Debug.Log("terpencet");
        }
    }


}

using UnityEngine;

public class DestroyMachineButton : ButtonScript
{
    private MachinePlacement MachinePlacement;
    private RotationControl _rotationControl;

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

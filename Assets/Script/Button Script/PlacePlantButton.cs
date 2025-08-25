using UnityEngine;

public class PlacePlantButton : ButtonScript
{
    public int _plantId;
    private LandLot _landLot;
    private RotationControl _rotationControl;

    private void Awake()
    {
        _landLot = gameObject.GetComponentInParent<LandLot>();
        _rotationControl = FindAnyObjectByType<RotationControl>();
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !_rotationControl._isRotating)
        {
            _landLot.PlacePlantBy(_plantId);
            Debug.Log("terpencet");
        }
    }
}

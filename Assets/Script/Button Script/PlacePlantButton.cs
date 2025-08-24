using UnityEngine;

public class PlacePlantButton : ButtonScript
{
    public int _plantId;
    private LandLot _landLot;

    private void Awake()
    {
        _landLot = gameObject.GetComponentInParent<LandLot>();
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _landLot.PlacePlantBy(_plantId);
            Debug.Log("terpencet");
        }
    }
}

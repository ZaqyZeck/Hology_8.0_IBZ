using UnityEngine;

public class DestroyPlant : ButtonScript
{
    private PlaceMentSystem _ps;
    //[SerializeField] private PlantScript _plant;
    [SerializeField] private LandLot _landLot;

    private void Awake()
    {
        //_plant = gameObject.GetComponentInParent<PlantScript>();
        _ps = FindAnyObjectByType<PlaceMentSystem>();
        _landLot = gameObject.GetComponentInParent<LandLot>();
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !_ps.isBuilding)
        {
            _landLot.RemovePlant();
        }
    }
}

using UnityEngine;

public class HarvestPlant : ButtonScript
{
    private PlantScript _plant;
    private PlaceMentSystem _ps;

    private void Awake()
    {
        _plant = GetComponentInParent<PlantScript>();
        _ps = FindAnyObjectByType<PlaceMentSystem>();
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !_ps.isBuilding && _plant.harvestable)
        {
            _plant.HarvestPlant();
        }
    }
}

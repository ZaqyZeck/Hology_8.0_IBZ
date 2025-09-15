using UnityEngine;

public class HarvestPlant : ButtonScript
{
    private PlantScript _plant;
    private PlaceMentSystem _ps;

    [SerializeField] GameObject directionUI;

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
        _plant = GetComponentInParent<PlantScript>();
        _ps = FindAnyObjectByType<PlaceMentSystem>();
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !_ps.isBuilding && _plant.harvestable)
        {
            _plant.HarvestPlant();
            if (alurTutorial.alur[5] && !alurTutorial.alur[6])
            {
                alurTutorial.alur[6] = true;
                directionUI.SetActive(false);
            }
                
        }
    }

    private void OnEnable()
    {
        if (directionUI == null) return;
        if(alurTutorial.alur[5] && !alurTutorial.alur[6]) directionUI.SetActive(true);
        else directionUI.SetActive(false);
    }
}

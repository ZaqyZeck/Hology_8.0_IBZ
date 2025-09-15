using UnityEngine;

public class DestroyPlant : ButtonScript
{
    private PlaceMentSystem _ps;
    //[SerializeField] private PlantScript _plant;
    [SerializeField] private LandLot _landLot;

    [SerializeField] SpriteRenderer buttonSprite, iconSprite;
    [SerializeField] private Collider buttonCollider;

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

    private void OnEnable()
    {
        if (buttonSprite == null || buttonCollider == null) return;
        if (!alurTutorial.alur[6])
        {
            buttonSprite.enabled = false;
            buttonCollider.enabled = false;
            iconSprite.enabled = false;
        }
        else
        {
            buttonSprite.enabled = true;
            buttonCollider.enabled = true;
            iconSprite.enabled = true;
        }
    }
}

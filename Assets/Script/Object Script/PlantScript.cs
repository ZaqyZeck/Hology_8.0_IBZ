using System.IO;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public int _ID;
    public int _yieldsId;
    public int _yieldsAmount;
    public int _bonusYield;
    public int _maxAge;
    public int _age;

    public bool fertilized;
    public bool harvestable;
    public float waterNeeded;
    public float waterGot;

    public int _bonus = 0;

    [SerializeField] private GameObject _buttonObject;
    private PlaceMentSystem _ps;
    private InventorySystem _inventory;
    [SerializeField] private LandLot _lot;

    [SerializeField] private Sprite[] phaseSprite;
    private SpriteRenderer _spriteRenderer;
    private int _currentPhase;
    private RotationControl rotationControl;

    private void Awake()
    {
        _ps = FindAnyObjectByType<PlaceMentSystem>();
        _lot = GetComponentInParent<LandLot>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _inventory = FindAnyObjectByType<InventorySystem>();
        rotationControl = FindAnyObjectByType<RotationControl>();
        gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, rotationControl._currentAngle, gameObject.transform.rotation.z);
    }
    void OnMouseOver()
    {
        // Check if the right mouse button is clicked while the cursor is over this object
        if (Input.GetMouseButtonDown(0) && !_ps.isBuilding) // 1 = Right Mouse Button
        {
            _buttonObject.SetActive(!_buttonObject.activeSelf);
        }
    }

    public void WaterThePlant(float _waterAmount)
    {
        waterGot += _waterAmount;
    }

    public void WaterReset()
    {
        waterGot = 0;
    }

    public void GrowThePlant()
    {
        if (waterGot / waterNeeded < 0.3)
        {
            _ps.RemoveStrcture(_ID);
            // _lot.RemovePlant();
            return;
        }
        if (fertilized) _bonus += 6;

        if (waterGot / waterNeeded <= 0.5)
        {
            _age += (_bonus + 6) / 2;
        }
        else
        {
            _age += _bonus + 6;
        }

        if (_age >= _maxAge)
        {
            _age = _maxAge;
            harvestable = true;
        }

        _bonus = 0;

        _currentPhase = _age / 6;
        _spriteRenderer.sprite = phaseSprite[_currentPhase];

    }

    public void HarvestPlant()
    {
        _inventory.inventory[_yieldsId].amount += _yieldsAmount + _bonusYield;
        _lot = GetComponentInParent<LandLot>();
        _lot.RemovePlant();
    }

    public void FertilizesPlant()
    {
        fertilized = true;
    }
}

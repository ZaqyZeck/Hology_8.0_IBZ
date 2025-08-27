using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public int _ID;
    public int _LotID;
    public int _age;
    public int _bonusYield;
    public float waterGot;
    public bool fertilized;
    public int _bonus = 0;
    public int _currentPhase;

    public int _yieldsId;
    public int _yieldsAmount;
    
    public int _maxAge;
    
    public bool harvestable;
    public float waterNeeded;
    
    public int tallPhase, middlePhase;
    

    [SerializeField] private GameObject _buttonObject;
    private PlaceMentSystem _ps;
    private InventorySystem _inventory;
    public LandLot _lot;

    [SerializeField] private Sprite[] phaseSprite;
    private SpriteRenderer _spriteRenderer;
    private RotationControl rotationControl;
    private BoxCollider _collider;

    private void Awake()
    {
        _ps = FindAnyObjectByType<PlaceMentSystem>();
        _lot = GetComponentInParent<LandLot>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _inventory = FindAnyObjectByType<InventorySystem>();
        rotationControl = FindAnyObjectByType<RotationControl>();
        gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, rotationControl._currentAngle, gameObject.transform.rotation.z);
        _collider = GetComponent<BoxCollider>();
        //_lot = GetComponentInParent<LandLot>();

        //_spriteRenderer.sprite = phaseSprite[_currentPhase];
        //if (_age == _maxAge) harvestable = true;
        //_LotID = _lot.lotId;
        //load();
    }

    public void load()
    {
        //_lot = GetComponentInParent<LandLot>();
        //Debug.Log(_lot.name);
        _spriteRenderer.sprite = phaseSprite[_currentPhase];
        if (_age == _maxAge) harvestable = true;
        _LotID = _lot.lotId;
    }
    void OnMouseOver()
    {
        // Check if the right mouse button is clicked while the cursor is over this object
        if (Input.GetMouseButtonDown(0) && !_ps.isBuilding) // 1 = Right Mouse Button
        {
            //_buttonObject.SetActive(!_buttonObject.activeSelf);
            ButtonStorage.changeButton(_buttonObject);
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

        if (_currentPhase >= tallPhase)
        {
            Vector3 c = _collider.center;
            c.y = 0.5f;
            _collider.center = c;
        }
        else if (_currentPhase >= middlePhase)
        {
            Vector3 c = _collider.center;
            c.y = 0.25f;
            _collider.center = c;
        }
        else
        {
            Vector3 c = _collider.center;
            c.y = 0f;
            _collider.center = c;
        }
    }

    public void HarvestPlant()
    {
        _inventory.inventory[_yieldsId].amount += _yieldsAmount + _bonusYield;
        _lot.RemovePlant();
    }

    public void FertilizesPlant()
    {
        fertilized = true;
    }
}

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

    // new save data
    public int extraWater;

    public int _yieldsId;
    public int _yieldsAmount;
    
    public int _maxAge;
    
    public bool harvestable;
    public float waterNeeded;
    
    public int tallPhase, middlePhase;

    // new upgrade data

    public int plantLevel;
    public string plantFarmType;


    [SerializeField] private GameObject _buttonObject;
    private PlaceMentSystem _ps;
    private InventorySystem _inventory;
    public LandLot _lot;

    [SerializeField] private Sprite[] phaseSprite;
    private SpriteRenderer _spriteRenderer;
    private RotationControl rotationControl;
    private BoxCollider _collider;


    [SerializeField] GameObject directionArrow, havestButton;

    [SerializeField] Sprite[] verticalSprites, horizontalSprites;

    [SerializeField] SoundManager soundManager;
    private void Awake()
    {
        _ps = FindAnyObjectByType<PlaceMentSystem>();
        _lot = GetComponentInParent<LandLot>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _inventory = FindAnyObjectByType<InventorySystem>();
        rotationControl = FindAnyObjectByType<RotationControl>();
        gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, rotationControl._currentAngle, gameObject.transform.rotation.z);
        _collider = GetComponent<BoxCollider>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        //_lot = GetComponentInParent<LandLot>();

        //_spriteRenderer.sprite = phaseSprite[_currentPhase];
        //if (_age == _maxAge) harvestable = true;
        //_LotID = _lot.lotId;
        //load();
    }

    private void Update()
    {
        if (_ID != 1) return;
        if (!alurTutorial.alur[6] && alurTutorial.alur[5])
        {
            if (ButtonStorage.getCurrentButton() == null)
            {
                directionArrow.SetActive(true);
                return;
                
            }
                
            if (ButtonStorage.getCurrentButton().name == "Button" && ButtonStorage.getCurrentButton().activeSelf) directionArrow.SetActive(false);
            else directionArrow.SetActive(true);
        }
    }

    public void load()
    {
        //_lot = GetComponentInParent<LandLot>();
        //Debug.Log(_lot.name);
        _spriteRenderer.sprite = phaseSprite[_currentPhase];
        if (_age == _maxAge) harvestable = true;
        _LotID = _lot.lotId;

        if (_age >= _maxAge)
        {
            _age = _maxAge;
            harvestable = true;
            havestButton.SetActive(true);
        }
    }

    public void LoadUpgradeFarm(int farmLevel, string farmType)
    {
        plantLevel = farmLevel;
        plantFarmType = farmType;

        if (farmType == "vertical")
        {
            if(farmLevel > 0)
            {
                for(int i = 0; i < phaseSprite.Length; i++)
                {
                    phaseSprite[i] = verticalSprites[i];
                }
                gameObject.transform.localScale = new Vector3(0.8f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                _buttonObject.gameObject.transform.localScale = new Vector3(1.2f, _buttonObject.gameObject.transform.localScale.y, _buttonObject.gameObject.transform.localScale.z);
            }
            if(farmLevel == 1)
            {
                _yieldsAmount += 1;
            }
            else if(farmLevel == 2)
            {
                _yieldsAmount += 2;
                waterNeeded += waterNeeded / 10;
            }
            else if(farmLevel == 3)
            {
                _yieldsAmount += 3;
                waterNeeded += waterNeeded / 20;
            }
        }
        else
        {
            if (farmLevel > 0)
            {
                for (int i = 0; i < phaseSprite.Length; i++)
                {
                    phaseSprite[i] = horizontalSprites[i];
                }
                gameObject.transform.localScale = new Vector3(0.5f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                _buttonObject.gameObject.transform.localScale = new Vector3(2f, _buttonObject.gameObject.transform.localScale.y, _buttonObject.gameObject.transform.localScale.z);
            }
            if (farmLevel == 2)
            {
                waterNeeded -= waterNeeded / 10;
            }
        }
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

    private void OnMouseEnter()
    {
        _spriteRenderer.color = new Color(1f, 1f, 1f, 160f / 255f);
    }

    private void OnMouseExit()
    {
        _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
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
        if (plantFarmType == "horizontal")
        {
            if(plantLevel == 1)
            {
                _bonus += 2;
            }
            else if (plantLevel == 2)
            {
                _bonus += 3;
            }
        }
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
            havestButton.SetActive(true);
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
        soundManager.PlaySFX(soundManager.harvestPlant);
        

        if(!alurTutorial.alur[6] && alurTutorial.alur[5])
        {
            alurTutorial.alur[6] = true;
            directionArrow.SetActive(false);
        }
    }

    public void FertilizesPlant()
    {
        fertilized = true;
    }
}

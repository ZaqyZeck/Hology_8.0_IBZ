using UnityEngine;
using UnityEngine.UIElements;

public class GeneratorScript : MonoBehaviour
{
    public int id, placementId = -1;
    public Vector3 location;
    public bool havefuel;

    public int producePower;
    public int globalWarm;
    public string type;
    private Vector3 _originalScale;
    private GlobarWarmingSystem GW_system;

    [SerializeField] private GameObject machineButton, upgradeButton;
    private RotationControl rotationControl;
    private InventorySystem inventorySystem;
    [SerializeField] private int[] upgradesPrice, upgradePower;
    [SerializeField] private GameObject[] bilahWindTurbine;

    // new data
    public int machineLevel;

    public bool haveLoaded;

    [SerializeField] GameObject directionArrow;
    private PlaceMentSystem placeMentSystem;

    [SerializeField] GameObject transparentCube;

    private void Awake()
    {
        _originalScale = transform.localScale;
        GW_system = FindAnyObjectByType<GlobarWarmingSystem>();
        rotationControl = FindAnyObjectByType<RotationControl>();
        inventorySystem = FindAnyObjectByType<InventorySystem>();
        placeMentSystem = FindAnyObjectByType<PlaceMentSystem>();
        //location = transform.localPosition;

    }

    public void setGeneratorLocation()
    {
        location = transform.localPosition;
    }

    public int GeneratePower()
    {
        if (!havefuel && type == "Diesel") return 0;
        if (havefuel) GW_system.lowerTheLevelBy(globalWarm);
        
        return producePower;
    }

    private void Update()
    {
        
        if (alurTutorial.alur[2] && !alurTutorial.alur[3])
        {
            GameObject currentButton = ButtonStorage.getCurrentButton();
            if (currentButton != null)
            {
                if (currentButton.name == "Generator Button" && currentButton.activeSelf)
                {
                    directionArrow.SetActive(false);
                }
                else
                {
                    directionArrow.SetActive(true);
                } 
            }
             
            
        }
        if (type == "Diesel")
        {
            if (havefuel)
            {
                // membuat mesin bergerak
                float frequency = 3f; // makin besar makin cepat
                float amplitude = 0.1f; // makin besar makin terlihat goyang

                float scaleY = _originalScale.y + Mathf.Sin(Time.time * frequency) * amplitude;

                transform.localScale = new Vector3(
                    _originalScale.x,
                    scaleY,
                    _originalScale.z
                );
            }
            else transform.localScale = _originalScale;
            
        }
        if(type == "Wind")
        {
            if (bilahWindTurbine != null && bilahWindTurbine.Length > 0)
            {
                foreach (GameObject bilah in bilahWindTurbine)
                {
                    if (bilah != null)
                    {
                        // rotasi searah jarum jam (clockwise) di sumbu Z
                        bilah.transform.Rotate(0f, 0f, -200f * Time.deltaTime);
                    }
                }
            }
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !rotationControl._isRotating)
        {
            ButtonStorage.changeButton(machineButton);
        }
        transparentCube.SetActive(true);
    }

    private void OnMouseExit()
    {
        transparentCube.SetActive(false);
    }

    public void DestroyGenerator()
    {
        placeMentSystem.RemoveStrcture(placementId);

    }

    public void UpgradeMachine()
    {
        if (machineLevel >= 2) return;

        int price = upgradesPrice[machineLevel];

        if (inventorySystem.coins < price) return;

        inventorySystem.coins -= price;
        machineLevel++;

        LoadLevel();
    }

    public void FueledGenerator()
    {
        if (inventorySystem.coins < 20 || havefuel) return;
        inventorySystem.coins -= 20;
        havefuel = true;
    }
    public void LoadLevel()
    {
        producePower = upgradePower[machineLevel];
        if (machineLevel >= 2) upgradeButton.SetActive(false);
    }
}

using UnityEngine;

public class LandLot : MonoBehaviour
{
    public Vector3Int _location;
    public bool _havePlant;
    public int _plantId;
    public int lotId;

    public GameObject _buttonObject;
    private GameObject _plant;
    private RotationControl rotationControl;
    private InventorySystem _inventory;
    private Collider _lotCollider;

    [SerializeField] private ObjectDatabaseSO _database;

    private void Awake()
    {
        rotationControl = FindAnyObjectByType<RotationControl>();
        _inventory = FindAnyObjectByType<InventorySystem>();
        _lotCollider = GetComponent<Collider>();
    }

    private void Update()
    {
    }

    void OnMouseOver()
    {
        // Check if the right mouse button is clicked while the cursor is over this object
        if (Input.GetMouseButtonDown(0) && !rotationControl._isRotating) // 1 = Right Mouse Button
        {
            //_buttonObject.SetActive(!_buttonObject.activeSelf);
            ButtonStorage.changeButton(_buttonObject);
            _buttonObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, rotationControl._currentAngle, gameObject.transform.rotation.z);
        }
    }

    public void PlacePlantBy(int _id)
    {
        //Debug.Log(_inventory.inventory[_id].name);
        if (_plant != null || _inventory.inventory[_id].amount <= 0)
        {
            Debug.LogError("terdapat tanaman " + _plant);
            return;
        }
        FindIdInDB(_id);
        _plant = Instantiate(_database._objectsData[_plantId].Prefab);
        _plant.transform.SetParent(gameObject.transform);
        _plant.transform.position = _location + _database._objectsData[_plantId].Location;
        _plant.GetComponent<PlantScript>()._ID = _id;
        _inventory.subtractOneTo(_id);
        _havePlant = true;
        _lotCollider.enabled = false;
        _buttonObject.SetActive(!_buttonObject.activeSelf);

        PlantScript plantScript = _plant.GetComponent<PlantScript>();
        plantScript._lot = GetComponent<LandLot>();
        plantScript.load();
    }

    public PlantScript LoadPlantBy(int _id)
    {
        //Debug.Log(_inventory.inventory[_id].name);
        if (_plant != null)
        {
            Debug.LogError("terdapat tanaman " + _plant);
            return null;
        }
        FindIdInDB(_id);
        //Debug.Log(_plantId + " dan " + _id);
        _plant = Instantiate(_database._objectsData[_plantId].Prefab);
        _plant.transform.SetParent(gameObject.transform);
        _plant.transform.position = _location + _database._objectsData[_plantId].Location;
        //_plant.GetComponent<PlantScript>()._ID = _id;

        PlantScript plantScript = _plant.GetComponent<PlantScript>();
        plantScript._lot = GetComponent<LandLot>();
        plantScript.load();
        //_inventory.subtractOneTo(_id);
        _havePlant = true;
        _lotCollider.enabled = false;
        _buttonObject.SetActive(false);
        return plantScript;
    }

    public void RemovePlant()
    {
        _havePlant = false;
        _lotCollider.enabled = true;
        Destroy(_plant);
    }

    public void FindIdInDB(int _id)
    {
        _plantId = _database._objectsData.FindIndex(data => data.ID == _id);
    }
}

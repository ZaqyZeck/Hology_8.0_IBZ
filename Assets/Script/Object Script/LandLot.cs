using UnityEngine;

public class LandLot : MonoBehaviour
{
    public Vector3Int _location;
    public bool _havePlant;
    public int _plantId;

    public GameObject _buttonObject;
    private GameObject _plant;
    private PlaceMentSystem _ps;
    private InventorySystem _inventory;
    private Collider _lotCollider;

    [SerializeField] private ObjectDatabaseSO _database;

    private void Awake()
    {
        _ps = FindAnyObjectByType<PlaceMentSystem>();
        _inventory = FindAnyObjectByType<InventorySystem>();
        _lotCollider = GetComponent<Collider>();
    }

    private void Update()
    {
    }

    void OnMouseOver()
    {
        // Check if the right mouse button is clicked while the cursor is over this object
        if (Input.GetMouseButtonDown(0) && !_ps.isBuilding) // 1 = Right Mouse Button
        {
            _buttonObject.SetActive(!_buttonObject.activeSelf);
        }
    }

    public void PlacePlantBy(int _id)
    {
        if (_plant != null)
        {
            Debug.LogError("terdapat tanaman " + _plant);
            return;
        }
        FindIdInDB(_id);
        _plant = Instantiate(_database._objectsData[_plantId].Prefab);
        _plant.transform.SetParent(gameObject.transform);
        _plant.transform.position = _location + _database._objectsData[_plantId].Location;

        _havePlant = true;
        _lotCollider.enabled = false;
        _buttonObject.SetActive(!_buttonObject.activeSelf);
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

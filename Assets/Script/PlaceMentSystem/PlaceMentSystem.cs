//using System;
//using System.Data;
using UnityEngine;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using System.Data;

public class PlaceMentSystem : MonoBehaviour
{
    [SerializeField] GameObject _mouseIndicator, _cellIndicator;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Grid _grid;
    [SerializeField] private GameObject _gridVisualization;
    [SerializeField] private ObjectDatabaseSO _database;
    private RotationControl _rotation;
    [SerializeField] private GameObject _objectPlacement;

    [SerializeField] private int _selectedObjectIndex = -1;

    [SerializeField] private ObjectList _objectList;
    [SerializeField] private GridData _floorData, _furnitureData;

    private Renderer _previewRenderer;
    private GameObject _previewObject;
    private InventorySystem _inventory;

    public bool isBuilding = false;
    //private List<GameObject> _placedGameObject = new();
    private void Start()
    {
        StopPlacement();
        _rotation = FindAnyObjectByType<RotationControl>();
        
        _floorData = new();
        _furnitureData = new();
        _inventory = FindAnyObjectByType<InventorySystem>();

    }

    public void StopPlacement()
    {
        if (_previewObject != null)
        {
            Destroy(_previewObject);
            _previewObject = null;
            _previewRenderer = null;
        }

        _selectedObjectIndex = -1;
        _gridVisualization.SetActive(false);
        _cellIndicator.SetActive(false);
        _inputManager.OnClicked -= PlaceStructure;
        _inputManager.OnExit -= StopPlacement;
        isBuilding = false;
        //_inputManager.OnRightClicked -= RemoveStrcture;
    }


    public void StartPlacement(int ID)
    {
        if (_rotation._isRotating || _inventory.inventory[ID].amount <= 0)
        {
            return;
        }
        StopPlacement();
        _selectedObjectIndex = _database._objectsData.FindIndex(data => data.ID == ID);
        if (_selectedObjectIndex < 0)
        {
            Debug.LogError($"No Id Found {ID}");
            return;
        }
        _gridVisualization.SetActive(true);
        _cellIndicator.SetActive(true);
        isBuilding = true;

        ObjectData _data = _database._objectsData[_selectedObjectIndex];

        _previewObject = Instantiate(_data.Prefab);
        _previewObject.name = $"{_data.Name}_Preview";
        _previewObject.transform.SetParent(_objectPlacement.transform);
        _previewObject.transform.position = _cellIndicator.transform.position + _data.Location;

        Collider _previewCollider = _previewObject.GetComponent<Collider>();
        if (_previewCollider != null)
        {
            _previewCollider.enabled = false;
        }

        Vector3 euler = _previewObject.transform.rotation.eulerAngles;
        _previewObject.transform.rotation = Quaternion.Euler(euler.x, _rotation._currentAngle, euler.z);

        _previewRenderer = _previewObject.GetComponentInChildren<Renderer>();
        _previewRenderer.sortingOrder = 1;

        _inputManager.OnClicked += PlaceStructure;
        _inputManager.OnExit += StopPlacement;
        //_inputManager.OnRightClicked += RemoveStrcture;

        //if(_mouseIndicator.transform.localPosition == new Vector3(0f, 0f, 0f))
        //{
        //    _mouseIndicator.transform.localPosition = new Vector3(2f, 0f, 2f); 
        //}
    }

    private void PlaceStructure()
    {
        if (_inputManager.IsPointerOverUI() || _rotation._isRotating)
        {
            return;
        }

        Vector3 _mousePosition = _inputManager.GetSelectedMapPosition();
        Vector3Int _gridPosition = _grid.WorldToCell(_mousePosition);

        bool _placementValidity = CheckPlacementValidity(_gridPosition, _selectedObjectIndex);
        if (_placementValidity == false) return;

        ObjectData _data = _database._objectsData[_selectedObjectIndex];
        int _inventoryIndex = _selectedObjectIndex + 1;
        if (_inventory.inventory[_inventoryIndex].amount <= 0)
        {
            return;
        }

        _inventory.subtractInventoryFor(_inventoryIndex, 1);

        Vector3 _objectLocation = _grid.CellToWorld(_gridPosition) + _data.Location;

        int _objekID = _objectList.PlaceObject(_data.Prefab, _objectLocation, _rotation._currentAngle, _data.Location, _data.ID); //

        GridData _selectedData = _data.ID == 0 ? _floorData : _furnitureData;
        _selectedData.AddObjectAt(_gridPosition, _data.Size, _objekID);

        if (_inventory.inventory[_inventoryIndex].amount == 0)
        {
            StopPlacement();
        }
    }

    public void PlaceStructureById(int _id, Vector3Int _location)
    {
        if (_inputManager.IsPointerOverUI() || _rotation._isRotating)
        {
            return;
        }

        bool _placementValidity = CheckPlacementValidity(_location, _id);
        if (_placementValidity == false) return;

        ObjectData _data = _database._objectsData[_id];
        int _inventoryIndex = _id;
        if (_inventory.inventory[_id].amount <= 0)
        {
            return;
        }

        _inventory.subtractInventoryFor(_id, 1);

        Vector3 _objectLocation = _grid.CellToWorld(_location) + _data.Location;

        int _objekID = _objectList.PlaceObject(_data.Prefab, _objectLocation, _rotation._currentAngle, _data.Location, _data.ID); //

        GridData _selectedData = _data.ID == 0 ? _floorData : _furnitureData;
        _selectedData.AddObjectAt(_location, _data.Size, _objekID);

        if (_inventory.inventory[_inventoryIndex].amount == 0)
        {
            StopPlacement();
        }
    }

    public void RemoveStrcture(int ID)
    {
        if (_rotation._isRotating)
        {
            return;
        }

        _objectList.RemoveObjectWith(ID);
        _furnitureData.RemoveObjectWith(ID);

        int _inventoryIdIndex = ID / 1000;
        _inventory.addOneTo(_inventoryIdIndex);
    }

    private bool CheckPlacementValidity(Vector3Int _gridPosition, int selectedObjectIndex)
    {
        GridData _selectedData = _database._objectsData[_selectedObjectIndex].ID == 0 ? _floorData : _furnitureData;
        return _selectedData.CanPlaceObjectAt(_gridPosition, _database._objectsData[_selectedObjectIndex].Size);
    }

    private void Update()
    {
        if (_selectedObjectIndex < 0 || _previewRenderer == null)
        {
            return ;
        }

        Vector3 _mousePosition = _inputManager.GetSelectedMapPosition();
        Vector3Int _gridPosition = _grid.WorldToCell(_mousePosition);

        bool _placementValidity = CheckPlacementValidity(_gridPosition, _selectedObjectIndex);
        _previewRenderer.material.color = _placementValidity ? Color.white : Color.red;
        //if (_placementValidity == false) return;

        _mouseIndicator.transform.position = _mousePosition;
        _cellIndicator.transform.position = _grid.CellToWorld(_gridPosition);

        if (_previewObject != null)
        {
            _previewObject.transform.position = _cellIndicator.transform.position + _database._objectsData[_selectedObjectIndex].Location;
        }
    }
}

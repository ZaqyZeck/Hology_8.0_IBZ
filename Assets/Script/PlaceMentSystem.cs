//using System;
//using System.Data;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Data;

public class PlaceMentSystem : MonoBehaviour
{
    [SerializeField] GameObject _mouseIndicator, _cellIndicator;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Grid _grid;
    [SerializeField] private GameObject _gridVisualization;
    [SerializeField] private ObjectDatabaseSO _database;
    [SerializeField] private RotationControl _rotation;
    [SerializeField] private GameObject _objectPlacement;

    [SerializeField] private int _selectedObjectIndex = -1;

    private GridData _floorData, _furnitureData;
    private Renderer _previewRenderer;
    private GameObject _previewObject;
    private List<GameObject> _placedGameObject = new();
    private void Start()
    {
        StopPlacement();
        _rotation = FindAnyObjectByType<RotationControl>();
        
        _floorData = new();
        _furnitureData = new();
        //_previewRenderer = _objectPlacement.GetComponentInChildren<Renderer>();
        //_previewRenderer.sortingOrder = 1;

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
    }


    public void StartPlacement(int ID)
    {
        StopPlacement();
        _selectedObjectIndex = _database._objectsData.FindIndex(data => data.ID == ID);
        if (_selectedObjectIndex < 0)
        {
            Debug.LogError($"No Id Found {ID}");
            return;
        }
        _gridVisualization.SetActive(true);
        _cellIndicator.SetActive(true);
        _inputManager.OnClicked += PlaceStructure;
        _inputManager.OnExit += StopPlacement;

        // Ambil data sesuai index
        ObjectData _data = _database._objectsData[_selectedObjectIndex];

        _previewObject = Instantiate(_data.Prefab);
        _previewObject.name = $"{_data.Name}_Preview";
        _previewObject.transform.SetParent(_objectPlacement.transform);
        _previewObject.transform.position = _cellIndicator.transform.position + _data.Location;

        Vector3 euler = _previewObject.transform.rotation.eulerAngles;
        _previewObject.transform.rotation = Quaternion.Euler(euler.x, _rotation._currentAngle, euler.z);

        _previewRenderer = _previewObject.GetComponentInChildren<Renderer>();
        _previewRenderer.sortingOrder = 1;

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
        GameObject _newObject = Instantiate(_data.Prefab);
        _newObject.transform.position = _grid.CellToWorld(_gridPosition);
        _newObject.transform.position += _data.Location;
        Vector3 euler = _newObject.transform.rotation.eulerAngles;
        _newObject.transform.rotation = Quaternion.Euler(euler.x, _rotation._currentAngle, euler.z);

        _placedGameObject.Add(_newObject);
        GridData _selectedData = _database._objectsData[_selectedObjectIndex].ID == 0 ? _floorData : _furnitureData;
        _selectedData.AddObjectAt(_gridPosition, _database._objectsData[_selectedObjectIndex].Size, _database._objectsData[_selectedObjectIndex].ID, _placedGameObject.Count - 1);
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

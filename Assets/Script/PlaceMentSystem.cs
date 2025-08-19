using System;
using System.Data;
using UnityEngine;

public class PlaceMentSystem : MonoBehaviour
{
    [SerializeField] GameObject _mouseIndicator, _cellIndicator;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Grid _grid;
    [SerializeField] private GameObject _gridVisualization;
    [SerializeField] private ObjectDatabaseSO _database;
    [SerializeField] private RotationControl _rotation;

    [SerializeField] private int _selectedObjectIndex = -1;

    private void Start()
    {
        StopPlacement();
        _rotation = FindAnyObjectByType<RotationControl>();
    }

    public void StopPlacement()
    {
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
    }

    private void PlaceStructure()
    {
        if (_inputManager.IsPointerOverUI() || _rotation._isRotating)
        {
            return;
        }

        Vector3 _mousePosition = _inputManager.GetSelectedMapPosition();
        Vector3Int _gridPosition = _grid.WorldToCell(_mousePosition);
        GameObject _newObject = Instantiate(_database._objectsData[_selectedObjectIndex].Prefab);
        _newObject.transform.position = _grid.CellToWorld(_gridPosition);
        _newObject.transform.position += new Vector3(0.5f, 0.5f, 0.5f);
        Vector3 euler = _newObject.transform.rotation.eulerAngles;
        _newObject.transform.rotation = Quaternion.Euler(euler.x, _rotation._currentAngle, euler.z);
    }

    private void Update()
    {
        if (_selectedObjectIndex < 0)
        {
            return ;
        }

        Vector3 _mousePosition = _inputManager.GetSelectedMapPosition();
        Vector3Int _gridPosition = _grid.WorldToCell(_mousePosition);
        _mouseIndicator.transform.position = _mousePosition;
        _cellIndicator.transform.position = _grid.CellToWorld(_gridPosition);


    }
}

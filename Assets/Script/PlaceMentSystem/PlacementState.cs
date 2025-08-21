using UnityEngine;

public class PlacementState
{
    private int _selectedObjectIndex = -1;
    int _ID;
    Grid _grid;
    //PreviewSystem previewSystem
    ObjectDatabaseSO _database;
    GridData _floorData;
    GridData _furnitureData;
    ObjectList _objectPlacer;

    public PlacementState()
    {
    }

    public PlacementState(int selectedObjectIndex, int iD, Grid grid, ObjectDatabaseSO database, GridData floorData, GridData furnitureData, ObjectList objectPlacer)
    {
        _selectedObjectIndex = selectedObjectIndex;
        _ID = iD;
        _grid = grid;
        _database = database;
        _floorData = floorData;
        _furnitureData = furnitureData;
        _objectPlacer = objectPlacer;

        _selectedObjectIndex = _database._objectsData.FindIndex(data => data.ID == _ID);
        if (_selectedObjectIndex < 0)
        {
            Debug.LogError($"No Id Found {_ID}");
            return;
        }

        //_gridVisualization.SetActive(true);
        //_cellIndicator.SetActive(true);

        //ObjectData _data = _database._objectsData[_selectedObjectIndex];

        //GameObject _previewObject = Instantiate(_data.Prefab);
        //_previewObject.name = $"{_data.Name}_Preview";
        //_previewObject.transform.SetParent(_objectPlacement.transform);
        //_previewObject.transform.position = _cellIndicator.transform.position + _data.Location;

        //Vector3 euler = _previewObject.transform.rotation.eulerAngles;
        //_previewObject.transform.rotation = Quaternion.Euler(euler.x, _rotation._currentAngle, euler.z);

        //Renderer _previewRenderer = _previewObject.GetComponentInChildren<Renderer>();
        //_previewRenderer.sortingOrder = 1;
    }
}

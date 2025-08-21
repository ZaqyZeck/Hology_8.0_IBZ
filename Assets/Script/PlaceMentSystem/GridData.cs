using System;
using System.Collections.Generic;
using UnityEngine;

public class GridData
{
    Dictionary<Vector3Int, PlacementData> _placedObjects = new();
    List<PlacementData> _placedObjectsList = new();
    //private HashSet<int> _usedIDs = new();

    public void AddObjectAt(Vector3Int _gridPosition, Vector2Int _objectSize, int _ID)
    {
        List<Vector3Int> _positionToOccupy = CalculatePositions(_gridPosition, _objectSize);
        //_ID = GenerateNewID(_ID * 1000);
        PlacementData data = new PlacementData(_positionToOccupy, _ID);
        _placedObjectsList.Add(data);
        foreach (var pos in _positionToOccupy)
        {
            if (_placedObjects.ContainsKey(pos)) throw new Exception($"Dictionary already contains this cell position {pos}");
            _placedObjects[pos] = data;
        }
    }

    public void RemoveObjectWith(int ID)
    {
        for (int i = _placedObjectsList.Count - 1; i >= 0; i--)
        {
            if (_placedObjectsList[i].ID == ID)
            {
                // hapus semua pos dari dictionary juga
                foreach (var pos in _placedObjectsList[i].occupiedPositions)
                {
                    _placedObjects.Remove(pos);
                }

                _placedObjectsList.RemoveAt(i);
                break; // kalau cuma 1 object per ID
            }
        }
    }

    private List<Vector3Int> CalculatePositions(Vector3Int _gridPosition, Vector2Int _objectSize)
    {
        List<Vector3Int> _returnVal = new();
        for(int x = 0; x < _objectSize.x; x++)
        {
            for (int y = 0; y < _objectSize.y; y++)
            {
                _returnVal.Add(_gridPosition + new Vector3Int(x, 0, y));
            }
        }

        return _returnVal;
    }

    public bool CanPlaceObjectAt(Vector3Int _gridPosition, Vector2Int _objectSize)
    {
        List<Vector3Int> _positionToOccupy = CalculatePositions(_gridPosition, _objectSize);
        foreach (var pos in _positionToOccupy)
        {
            if (_placedObjects.ContainsKey(pos)) return false;
            
        }
        return true;
    }
}

public class PlacementData
{
    public List<Vector3Int> occupiedPositions { get; private set; }
    public int ID {  get; private set; }
    //public int PlaceObjectIndex { get; private set; }
    
    public PlacementData(List<Vector3Int> occupiedPositions, int iD)
    {
        this.occupiedPositions = occupiedPositions;
        ID = iD;
        //PlaceObjectIndex = placeObjectIndex;
    }

}

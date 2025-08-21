using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour
{
    [SerializeField] private List<Objek> _objectData = new();
    [SerializeField] private GameObject _BuildPlace;
    private HashSet<int> _usedIDs = new();

    public int PlaceObject(GameObject _prefab, Vector3 _objectLocation, float _rotation, Vector3 _extraLocation, int _ID)
    {
        GameObject _newObject = Instantiate(_prefab);
        //_newObject.transform.position = _grid.CellToWorld(_gridPosition);
        _newObject.transform.position = _objectLocation;
        Vector3 euler = _newObject.transform.rotation.eulerAngles;
        _newObject.transform.rotation = Quaternion.Euler(euler.x, _rotation, euler.z);
        _newObject.transform.SetParent(_BuildPlace.transform);

        PlantScript _object = _newObject.GetComponent<PlantScript>();
        _ID = GenerateNewID(_ID * 1000);

        if (_object != null)
            _object._ID = _ID;

        _objectData.Add(new Objek(_newObject, _extraLocation, _ID));
        return _ID;
    }

    public void RemoveObjectWith(int _ID)
    {
        for (int i = _objectData.Count - 1; i >= 0; i--)
        {
            if (_objectData[i]._ID == _ID)
            {
                _usedIDs.Remove(_ID);
                Destroy(_objectData[i]._object);
                _objectData.RemoveAt(i);
                break; // kalau hanya ada 1 objek per ID, aman langsung break
            }
        }
    }

    public bool IsIDAvailable(int iD)
    {
        return !_usedIDs.Contains(iD);
    }

    public int GenerateNewID(int typeID)
    {
        // typeID harus kelipatan 1000 (contoh: 1000, 2000, 3000)
        if (typeID % 1000 != 0)
            throw new Exception("TypeID harus kelipatan 1000, contoh: 1000, 2000, 3000");

        for (int i = 1; i < 1000; i++)
        {
            int newID = typeID + i;
            if (IsIDAvailable(newID))
            {
                _usedIDs.Add(newID);
                return newID;
            }
                
        }

        throw new Exception($"Tidak ada ID tersedia untuk type {typeID}");
    }
}
public class Objek
{
    public GameObject _object;
    public Vector3 _extraLocation;
    public int _ID;

    public Objek(GameObject @object, Vector3 _extraLocation, int iD)
    {
        this._object = @object;
        this._extraLocation = new Vector3 (_extraLocation.x, 1 - _extraLocation.y, _extraLocation.z);
        this._ID = iD;
    }
}

using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "ObjectDatabaseSO", menuName = "Scriptable Objects/ObjectDatabaseSO")]
public class ObjectDatabaseSO : ScriptableObject
{
    public List<ObjectData> _objectsData;
}

[Serializable]
public class ObjectData
{
    [field: SerializeField] 
    public string Name {  get; private set; }
    [field: SerializeField] 
    public int ID {  get; private set; }
    [field: SerializeField]
    public Vector2Int Size { get; private set; } = Vector2Int.one;
    [field: SerializeField]
    public Vector3 Location { get; private set; } = Vector3.one;
    [field: SerializeField] 
    public GameObject Prefab { get; private set; }
    
}

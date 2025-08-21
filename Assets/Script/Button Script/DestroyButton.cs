using Unity.VisualScripting;
using UnityEngine;

public class DestroyButton : ButtonScript
{
    private PlaceMentSystem _ps;
    private PlantScript _obj;

    private void Awake()
    {
        _obj = gameObject.GetComponentInParent<PlantScript>();
        _ps = FindAnyObjectByType<PlaceMentSystem>();
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !_ps.isBuilding)
        {
            _ps.RemoveStrcture(_obj._ID);
            
        }
    }
}

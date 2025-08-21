using System.IO;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public int _ID;
    public int _maxAge;
    public int _age;

    public bool fertilized;
    public float waterNeeded;
    public float waterGot;

    [SerializeField] private GameObject _buttonObject;
    [SerializeField] private PlaceMentSystem _ps;

    private void Awake()
    {
        _ps = FindAnyObjectByType<PlaceMentSystem>();
    }
    void OnMouseOver()
    {
        // Check if the right mouse button is clicked while the cursor is over this object
        if (Input.GetMouseButtonDown(0) && !_ps.isBuilding) // 1 = Right Mouse Button
        {
            _buttonObject.SetActive(!_buttonObject.activeSelf);
        }
    }

    public void WaterThePlant(float _waterAmount)
    {
        waterGot += _waterAmount;
    }

    public void WaterReset()
    {
        waterGot = 0;
    }

    public void GrowThePlant()
    {
        if (waterGot / waterNeeded < 0.3)
        {
            _ps.RemoveStrcture(_ID);
        }
        int _bonus = 0;
        if (fertilized) _bonus += 6;

        if (waterGot / waterNeeded <= 0.5)
        {
            _age += (_bonus + 6) / 2;
        }
        else
        {
            _age += _bonus + 6;
        }

        if (_age > _maxAge) _age = _maxAge;
    }
}

using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public int ID;
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
}

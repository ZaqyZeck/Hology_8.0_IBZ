using UnityEngine;

public class PlaceMentSystem : MonoBehaviour
{
    [SerializeField] GameObject _mouseIndicator, _cellIndicator;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Grid _grid;

    private void Update()
    {
        Vector3 _mousePosition = _inputManager.GetSelectedMapPosition();
        Vector3Int _gridPosition = _grid.WorldToCell(_mousePosition);
        _mouseIndicator.transform.position = _mousePosition;
        _cellIndicator.transform.position = _grid.CellToWorld(_gridPosition);


    }
}

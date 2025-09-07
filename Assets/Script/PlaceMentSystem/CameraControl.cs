using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform _target;      // titik pusat kamera
    public float _radius = 10f;    // jarak kamera dari target
    public float _height = 8f;     // tinggi kamera
    public float _duration = 2f;   // waktu transisi

    [Header("Radius Clamp")]
    public float minRadius = 6f;
    public float maxRadius = 18f;

    [Header("Rotasi X berdasarkan zoom")]
    public float minXRotation = 30f; // saat radius minimum
    public float maxXRotation = 10f; // saat radius maksimum

    private float _currentAngle;
    private float _startAngle;
    private float _targetAngle;
    private float _t;
    private bool _isMoving = false;

    void Start()
    {
        _currentAngle = 225f;
        _targetAngle = 225f;
        UpdateCameraPosition();
    }

    void Update()
    {
        if (!_isMoving)
        {
            // Rotasi snap kanan
            if (Input.GetKeyDown(KeyCode.E))
            {
                _startAngle = _currentAngle;
                _targetAngle = _startAngle + 90f;
                _t = 0f;
                _isMoving = true;
            }

            // Rotasi snap kiri
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _startAngle = _currentAngle;
                _targetAngle = _startAngle - 90f;
                _t = 0f;
                _isMoving = true;
            }

            // Zoom pakai scroll wheel
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (Mathf.Abs(scroll) > 0.01f)
            {
                _radius -= scroll * 10f;
                _radius = Mathf.Clamp(_radius, minRadius, maxRadius);
                UpdateCameraPosition();
            }
        }

        if (_isMoving)
        {
            _t += Time.deltaTime / _duration;
            _currentAngle = Mathf.Lerp(_startAngle, _targetAngle, _t);

            UpdateCameraPosition();

            if (_t >= 1f)
            {
                _currentAngle = (_currentAngle % 360f + 360f) % 360f;
                _isMoving = false;
            }
        }
    }

    void UpdateCameraPosition()
    {
        float _rad = _currentAngle * Mathf.Deg2Rad;
        float _x = _target.position.x + Mathf.Cos(_rad) * _radius;
        float _z = _target.position.z + Mathf.Sin(_rad) * _radius;
        transform.position = new Vector3(_x, _height, _z);

        // Hitung rotasi X berdasarkan radius (semakin dekat semakin naik)
        float tZoom = Mathf.InverseLerp(minRadius, maxRadius, _radius);
        float xRotation = Mathf.Lerp(minXRotation, maxXRotation, tZoom);

        // Kamera selalu menghadap target
        Vector3 _lookDir = (_target.position - transform.position).normalized;
        Quaternion _lookRot = Quaternion.LookRotation(_lookDir);

        Vector3 _euler = _lookRot.eulerAngles;
        _lookRot = Quaternion.Euler(xRotation, _euler.y, 0);

        transform.rotation = _lookRot;
    }
}

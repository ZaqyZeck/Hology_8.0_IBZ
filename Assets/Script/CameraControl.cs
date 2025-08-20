//using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform _target;      // titik pusat kamera
    public float _radius = 10f;    // jarak kamera dari target
    public float _height = 8f;     // tinggi kamera
    public float _duration = 2f;   // waktu transisi

    private float _currentAngle;
    private float _startAngle;
    private float _targetAngle;
    private float _t;
    private bool _isMoving = false;

    void Start()
    {
        // Mulai dari 225° (misalnya default)
        _currentAngle = 225f;
        _targetAngle = 225f;
        UpdateCameraPosition();
    }

    void Update()
    {
        if (!_isMoving)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _startAngle = _currentAngle;

                // geser 90° searah jarum jam
                _targetAngle = _startAngle + 90f;

                _t = 0f;
                _isMoving = true;

            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                _startAngle = _currentAngle;

                // geser 90° searah jarum jam
                _targetAngle = _startAngle - 90f;

                _t = 0f;
                _isMoving = true;
            }
                
        }

        if (_isMoving)
        {
            _t += Time.deltaTime / _duration;
            _currentAngle = Mathf.Lerp(_startAngle, _targetAngle, _t);

            UpdateCameraPosition();

            if (_t >= 1f)
            {
                // normalisasi biar selalu 0–360
                _currentAngle = (_currentAngle % 360f + 360f) % 360f;
                _isMoving = false;
                //StartCoroutine(setIsRotating());
            }
        }
    }

    //IEnumerator setIsRotating()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    _isMoving = false;
    //    yield return null;
    //}

    void UpdateCameraPosition()
    {
        float _rad = _currentAngle * Mathf.Deg2Rad;
        float _x = _target.position.x + Mathf.Cos(_rad) * _radius;
        float _z = _target.position.z + Mathf.Sin(_rad) * _radius;
        transform.position = new Vector3(_x, _height, _z);

        // Kamera lihat ke target, tapi simpan rotasi X lama
        Vector3 _lookDir = (_target.position - transform.position).normalized;
        Quaternion _lookRot = Quaternion.LookRotation(_lookDir);

        Vector3 _euler = _lookRot.eulerAngles;
        float _savedX = transform.rotation.eulerAngles.x;
        _lookRot = Quaternion.Euler(_savedX, _euler.y, 0);

        transform.rotation = _lookRot;
    }


}

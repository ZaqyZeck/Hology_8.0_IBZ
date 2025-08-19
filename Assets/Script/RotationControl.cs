//using System.Collections;
using UnityEngine;

public class RotationControl : MonoBehaviour
{
    public float _duration = 1.5f; // waktu transisi putar
    public float _currentAngle;
    private float _startAngle;
    private float _targetAngle;
    private float _t;
    public bool _isRotating = false;

    private GameObject[] _objects2D;

    void Start()
    {
        get2dObject();

        // set semua ke 225° (awal)
        foreach (GameObject obj in _objects2D)
        {
            Vector3 euler = obj.transform.rotation.eulerAngles;
            obj.transform.rotation = Quaternion.Euler(euler.x, 225f, euler.z);
        }
        _currentAngle = 225f;
    }

    public void get2dObject()
    {
        _objects2D = GameObject.FindGameObjectsWithTag("Object2D");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isRotating)
        {
            get2dObject();
            _startAngle = _currentAngle;

            // pindah 90° counter-clockwise (ubah ke +90f kalau mau clockwise)
            _targetAngle = _startAngle - 90f;

            _t = 0f;
            _isRotating = true;
        }

        if (_isRotating)
        {
            _t += Time.deltaTime / _duration;
            _currentAngle = Mathf.Lerp(_startAngle, _targetAngle, _t);

            // apply rotasi ke semua Object2D
            foreach (GameObject obj in _objects2D)
            {
                Vector3 euler = obj.transform.rotation.eulerAngles;
                obj.transform.rotation = Quaternion.Euler(euler.x, _currentAngle, euler.z);
            }

            if (_t >= 1f)
            {
                // normalisasi biar 0–360
                _currentAngle = (_currentAngle % 360f + 360f) % 360f;
                _isRotating = false;
                //StartCoroutine(setIsRotating());
            }
        }
    }

    //IEnumerator setIsRotating()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    _isRotating = false;
    //    yield return null;
    //}

}

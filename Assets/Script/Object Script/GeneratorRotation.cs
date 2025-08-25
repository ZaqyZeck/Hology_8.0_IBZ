using UnityEngine;

public class GeneratorRotation : MonoBehaviour
{
    public float _duration = 1.5f; // waktu transisi per putaran
    private bool _isRotating = false;
    private float _t;

    private GameObject[] _generators;

    // Simpan data rotasi masing-masing generator
    private float[] _startAngles;
    private float[] _targetAngles;

    void Start()
    {
        getGenerator();
    }

    public void getGenerator()
    {
        _generators = GameObject.FindGameObjectsWithTag("Generator");
        _startAngles = new float[_generators.Length];
        _targetAngles = new float[_generators.Length];
    }

    void Update()
    {
        if (!_isRotating)
        {
            if (Input.GetKeyDown(KeyCode.E)) // putar -90 derajat
            {
                RotateGenerators(-90f);
            }
            if (Input.GetKeyDown(KeyCode.Q)) // putar +90 derajat
            {
                RotateGenerators(+90f);
            }
        }

        if (_isRotating)
        {
            _t += Time.deltaTime / _duration;
            for (int i = 0; i < _generators.Length; i++)
            {
                if (_generators[i] == null) continue;

                float currentAngle = Mathf.LerpAngle(_startAngles[i], _targetAngles[i], _t);
                Vector3 euler = _generators[i].transform.rotation.eulerAngles;
                _generators[i].transform.rotation = Quaternion.Euler(euler.x, currentAngle, euler.z);
            }

            if (_t >= 1f)
            {
                _isRotating = false;
            }
        }
    }

    void RotateGenerators(float delta)
    {
        getGenerator();
        _t = 0f;
        _isRotating = true;

        for (int i = 0; i < _generators.Length; i++)
        {
            if (_generators[i] == null) continue;

            float currentY = _generators[i].transform.rotation.eulerAngles.y;
            _startAngles[i] = currentY;
            _targetAngles[i] = currentY + delta;
        }
    }
}

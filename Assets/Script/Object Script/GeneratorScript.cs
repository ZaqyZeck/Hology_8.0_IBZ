using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public int id;
    public int producePower;
    public int globalWarm;
    public string type;
    private Vector3 _originalScale;

    private void Start()
    {
        _originalScale = transform.localScale;
    }

    public int GeneratePower()
    {
        return producePower;
    }

    

    private void Update()
    {
        if (type == "Diesel")
        {
            // frekuensi (kecepatan goyang) & amplitudo (seberapa tinggi goyang)
            float frequency = 3f; // makin besar makin cepat
            float amplitude = 0.1f; // makin besar makin terlihat goyang

            float scaleY = _originalScale.y + Mathf.Sin(Time.time * frequency) * amplitude;

            transform.localScale = new Vector3(
                _originalScale.x,
                scaleY,
                _originalScale.z
            );
        }
    }
}

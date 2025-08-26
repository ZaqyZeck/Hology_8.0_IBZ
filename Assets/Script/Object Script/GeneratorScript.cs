using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public int id;
    public int producePower;
    public int globalWarm;
    public string type;
    private Vector3 _originalScale;
    private GlobarWarmingSystem GW_system;

    private void Awake()
    {
        _originalScale = transform.localScale;
        GW_system = FindAnyObjectByType<GlobarWarmingSystem>();
    }

    public int GeneratePower()
    {
        GW_system.lowerTheLevelBy(globalWarm);
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
        return;
        if(type == "Wind")
        {
            // aku mau object berputar dengan arah z dan titik pivot ada di tengah object, jadi kaya kincir angin;
            Vector3 center = GetComponent<Renderer>().bounds.center;

            transform.RotateAround(center, Vector3.forward, 100f * Time.deltaTime);
        }
    }
}

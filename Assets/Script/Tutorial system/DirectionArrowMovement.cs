using UnityEngine;

public class DirectionArrowMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float floatAmplitude = 0.5f; // tinggi gerakan naik-turun
    [SerializeField] private float floatSpeed = 2f;       // kecepatan naik-turun

    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 30f;   // derajat per detik

    private Vector3 startPos;

    public bool is2D;

    void Start()
    {
        // Simpan posisi awal
        if (is2D) startPos = transform.localPosition;
        else startPos = transform.position;
    }

    void Update()
    {
        if (is2D)
        {
            // Gerakan naik-turun (sin wave)
            float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
            transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
        }
        else
        {
            // Gerakan naik-turun (sin wave)
            float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // Rotasi perlahan di sumbu Y
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
        }
        
    }
}

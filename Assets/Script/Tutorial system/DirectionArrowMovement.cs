using UnityEngine;

public class DirectionArrowMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float floatAmplitude = 0.5f; // tinggi gerakan naik-turun
    [SerializeField] private float floatSpeed = 2f;       // kecepatan naik-turun

    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 30f;   // derajat per detik

    private Vector3 startPos;

    void Start()
    {
        // Simpan posisi awal
        startPos = transform.position;
    }

    void Update()
    {
        // Gerakan naik-turun (sin wave)
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Rotasi perlahan di sumbu Y
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
}

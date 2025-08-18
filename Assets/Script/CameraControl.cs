using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;      // titik pusat kamera
    public float radius = 10f;    // jarak kamera dari target
    public float height = 8f;     // tinggi kamera
    public float duration = 2f;   // waktu transisi

    [Header("Angles Y")]
    public float angleA = 225f;
    public float angleB = 45f;

    private float currentAngle;
    private float startAngle;
    private float targetAngle;
    private float t;
    private bool isMoving = false;

    private bool atA = true;  // kamera sedang di posisi A?

    void Start()
    {
        // Mulai di posisi A
        currentAngle = angleA;
        targetAngle = angleA;
        UpdateCameraPosition();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startAngle = currentAngle;

            // tentukan target angle, tapi pastikan searah jarum jam
            if (atA)
            {
                targetAngle = angleB;
                if (targetAngle <= startAngle) targetAngle += 360f;
            }
            else
            {
                targetAngle = angleA;
                if (targetAngle <= startAngle) targetAngle += 360f;
            }

            atA = !atA;
            t = 0f;
            isMoving = true;
        }

        if (isMoving)
        {
            t += Time.deltaTime / duration;
            currentAngle = Mathf.Lerp(startAngle, targetAngle, t);

            UpdateCameraPosition();

            if (t >= 1f)
            {
                // normalisasi biar gak lebih dari 360
                currentAngle %= 360f;
                isMoving = false;
            }
        }
    }

    void UpdateCameraPosition()
    {
        float rad = currentAngle * Mathf.Deg2Rad;
        float x = target.position.x + Mathf.Cos(rad) * radius;
        float z = target.position.z + Mathf.Sin(rad) * radius;
        transform.position = new Vector3(x, height, z);

        // Kamera lihat ke target, tapi simpan rotasi X lama
        Vector3 lookDir = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(lookDir);

        Vector3 euler = lookRot.eulerAngles;
        float savedX = transform.rotation.eulerAngles.x;
        lookRot = Quaternion.Euler(savedX, euler.y, 0);

        transform.rotation = lookRot;
    }


}

using UnityEngine;

public class RotationControl : MonoBehaviour
{
    public float duration = 1.5f; // waktu transisi putar
    private float currentAngle;
    private float startAngle;
    private float targetAngle;
    private float t;
    private bool isRotating = false;
    private bool atFirstAngle = false; // false = mulai di 225°

    private GameObject[] objects2D;

    void Start()
    {
        // cari semua gameobject dengan tag "Object2D"
        objects2D = GameObject.FindGameObjectsWithTag("Object2D");

        // set semua ke 225° (awal)
        foreach (GameObject obj in objects2D)
        {
            Vector3 euler = obj.transform.rotation.eulerAngles;
            obj.transform.rotation = Quaternion.Euler(euler.x, 225f, euler.z);
        }
        currentAngle = 225f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // toggle
        {
            startAngle = currentAngle;

            if (atFirstAngle) // sedang di 45° → balik ke 225°
            {
                targetAngle = 225f;
                if (targetAngle >= startAngle) targetAngle -= 360f; // paksa counter-clockwise
            }
            else // sedang di 225° → pindah ke 45°
            {
                targetAngle = 45f;
                if (targetAngle >= startAngle) targetAngle -= 360f; // paksa counter-clockwise
            }

            atFirstAngle = !atFirstAngle;
            t = 0f;
            isRotating = true;
        }

        if (isRotating)
        {
            t += Time.deltaTime / duration;
            currentAngle = Mathf.Lerp(startAngle, targetAngle, t);

            // apply rotasi ke semua Object2D
            foreach (GameObject obj in objects2D)
            {
                Vector3 euler = obj.transform.rotation.eulerAngles;
                obj.transform.rotation = Quaternion.Euler(euler.x, currentAngle, euler.z);
            }

            if (t >= 1f)
            {
                currentAngle = (currentAngle % 360f + 360f) % 360f; // normalize 0–360
                isRotating = false;
            }
        }
    }
}

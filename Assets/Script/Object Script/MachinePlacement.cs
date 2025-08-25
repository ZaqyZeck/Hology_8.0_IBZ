using UnityEngine;

public class MachinePlacement : MonoBehaviour
{
    public GameObject machineSign;
    private RotationControl rotationControl;

    private void Awake()
    {
        rotationControl = FindAnyObjectByType<RotationControl>();
    }

    void OnMouseOver()
    {
        // Check if the right mouse button is clicked while the cursor is over this object
        if (Input.GetMouseButtonDown(0) && !rotationControl._isRotating) // 1 = Right Mouse Button
        {
            machineSign.SetActive(!machineSign.activeSelf);
            machineSign.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, rotationControl._currentAngle, gameObject.transform.rotation.z);
        }
    }
}

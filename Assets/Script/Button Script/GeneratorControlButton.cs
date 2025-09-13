using UnityEngine;

public class GeneratorControlButton : MonoBehaviour
{
    RotationControl rotationControl;

    private void OnEnable()
    {
        if (rotationControl == null)
            rotationControl = FindAnyObjectByType<RotationControl>();

        transform.rotation = Quaternion.Euler(
             transform.rotation.eulerAngles.x,
             rotationControl._currentAngle,
             transform.rotation.eulerAngles.z
        );

    }
}

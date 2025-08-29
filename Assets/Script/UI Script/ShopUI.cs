using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject shopObject;
    [SerializeField] private Vector3 originalPosition = new Vector3(-447, 79, 0);
    [SerializeField] private Vector3 jarakTarget = new Vector3(-1032, 182, 0);
    [SerializeField] private float slideSpeed = 5f;

    private Vector3 targetPosition;

    private void Start()
    {
        // posisi awal
        targetPosition = originalPosition;
        shopObject.transform.localPosition = originalPosition;
    }

    private void Update()
    {
        // lerp menuju target
        shopObject.transform.localPosition = Vector3.Lerp(
            shopObject.transform.localPosition,
            targetPosition,
            Time.deltaTime * slideSpeed
        );
    }

    public void goToCategory(int index)
    {
        // hitung target posisi sesuai index
        targetPosition = originalPosition + jarakTarget * index;
    }
}

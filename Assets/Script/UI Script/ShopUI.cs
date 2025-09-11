using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject shopObject;
    [SerializeField] private Vector3 originalPosition = new Vector3(-447, 79, 0);
    [SerializeField] private Vector3 jarakTarget = new Vector3(-1032, 182, 0);
    [SerializeField] private float slideSpeed = 5f;

    private Vector3 targetPosition;

    public int currentCategory;

    [SerializeField] private GameObject[] arrowDirection;

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

        if (alurTutorial.alur[1] && !alurTutorial.alur[2])
        {
            if(currentCategory == 2)
            {
                arrowDirection[0].SetActive(false);

                for(int i = 1; i < arrowDirection.Length; i++)
                {
                    arrowDirection[i].SetActive(true);
                }
            }
            else
            {
                arrowDirection[0].SetActive(true);
            }
        }
        else if (arrowDirection[0].activeSelf || arrowDirection[1].activeSelf)
        {
            for(int i = 0;i < 4; i++)
            {
                arrowDirection[i].SetActive(false);
            }
        }

        if (alurTutorial.alur[6] && !alurTutorial.alur[7])
        {
            if(currentCategory == 1)
            {
                arrowDirection[4].SetActive(false);
                arrowDirection[5].SetActive(true);
            }
            else
            {
                arrowDirection[4].SetActive(true);
                arrowDirection[5].SetActive(false);
            }
        }
        else if (arrowDirection[4].activeSelf || arrowDirection[5].activeSelf)
        {
            arrowDirection[4].SetActive(false);
            arrowDirection[5].SetActive(false);
        }

        if (alurTutorial.alur[6] && alurTutorial.alur[7] && !alurTutorial.alur[8])
        {
            if (currentCategory == 0)
            {
                arrowDirection[6].SetActive(false);
                arrowDirection[7].SetActive(true);
            }
            else
            {
                arrowDirection[6].SetActive(true);
                arrowDirection[7].SetActive(false);
            }
        }
        else if (arrowDirection[6].activeSelf || arrowDirection[7].activeSelf)
        {
            arrowDirection[6].SetActive(false);
            arrowDirection[7].SetActive(false);
        }
    }

    public void goToCategory(int index)
    {
        // hitung target posisi sesuai index
        targetPosition = originalPosition + jarakTarget * index;
        currentCategory = index;
    }

    private void OnEnable()
    {
        currentCategory = -1;
        targetPosition = new Vector3(1244, -284, 0);
        shopObject.transform.localPosition = targetPosition;
    }
}

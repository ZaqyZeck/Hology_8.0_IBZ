using UnityEngine;
using UnityEngine.UI;

public class challengerArrivedSprite : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField]private Image image;
    [SerializeField] private Sprite[] sprites;

    private void OnEnable()
    {
        image.sprite = sprites[gameManager.day / 90];

    }
}
